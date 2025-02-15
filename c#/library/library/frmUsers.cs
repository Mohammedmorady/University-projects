using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace library
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private int edite = 0;
        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Myfont.vazir(), 11, FontStyle.Regular);
            loadUsers();
        }

        void loadUsers()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = db.select("users");
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["username"].DisplayIndex = 2;
            dataGridView1.Columns["password"].DisplayIndex = 3;
            dataGridView1.Columns["access"].DisplayIndex = 4;
            dataGridView1.Columns["phone"].DisplayIndex = 5;
            dataGridView1.Columns["address"].DisplayIndex = 6;
            dataGridView1.Columns["btnEditeRow"].DisplayIndex = 7;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 8;

        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // if (dataGridView1.Columns[e.ColumnIndex].Name == "access" && e.Value != null)
            // {
            //     string access = e.Value.ToString();
            //     if (access == "0" || access == "")
            //     {
            //         e.Value = "معمولی";
            //     }
            //     else
            //     {
            //         e.Value = "مدیر"; 
            //     }
            // }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                Msg.error("فیلد نام خالی است");
                return;
            }
            if (txtUser.Text == "")
            {
                Msg.error("فیلد نام کاربری خالی است");
                return;
            }
            if (txtPass.Text == "")
            {
                Msg.error("فیلد رمزعبور خالی است");
                return;
            }
            if (comboBox1.SelectedIndex < 0)
            {
                Msg.error("سطح دسترسی انتخاب نشده");
                return;
            }

            if (edite == 0)
            {//Insert
                if (db.countRow("users", "username",txtUser.Text) > 0)
                {
                    Msg.error(" از قبل ثبت شده است" + txtUser.Text + " نام کاربری");
                    return;
                }
                db.com.CommandText = "INSERT INTO users (name,username,password,access,phone,address) VALUES(@name,@username,@pass,@access,@phone,@address)";
                db.com.Parameters.AddWithValue("@name", txtName.Text);
                db.com.Parameters.AddWithValue("@username", txtUser.Text);
                db.com.Parameters.AddWithValue("@pass", txtPass.Text);
                db.com.Parameters.AddWithValue("@access", comboBox1.SelectedIndex);
                db.com.Parameters.AddWithValue("@phone", txtPhon.Text);
                db.com.Parameters.AddWithValue("@address", txtAddress.Text);
            }
            else //edite
            {
                if (comboBox1.SelectedIndex!=1)
                {
                    if (db.countRow("users","access","1")<=1)
                    {
                        Msg.error("نرم افزار باید یک مدیر داشته باشد");
                    }
                }
                db.com.CommandText = "SELECT COUNT(*) FROM users WHERE username=@user AND id != @id";
                db.com.Parameters.AddWithValue("@user", txtUser.Text);
                db.com.Parameters.AddWithValue("@id", edite);
                int count=Convert.ToInt32(db.com.ExecuteScalar());
                if (count > 0)
                {
                    Msg.error(" از قبل ثبت شده است" + txtUser.Text + " نام کاربری");
                    return;
                }
                db.com.CommandText = "UPDATE users SET name=@name,username=@user,password=@pass,access=@access,phone=@phone,address=@address WHERE id=@id";
                db.com.Parameters.AddWithValue("@id", edite);
                db.com.Parameters.AddWithValue("@name", txtName.Text);
                db.com.Parameters.AddWithValue("@user", txtUser.Text);
                db.com.Parameters.AddWithValue("@pass", txtPass.Text);
                db.com.Parameters.AddWithValue("@access", comboBox1.SelectedIndex);
                db.com.Parameters.AddWithValue("@phone", txtPhon.Text);
                db.com.Parameters.AddWithValue("@address", txtAddress.Text);
            }

            db.com.ExecuteNonQuery();
            loadUsers();
            txtName.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            comboBox1.SelectedIndex = 0;
            txtPhon.Text = "";
            txtAddress.Text = "";
            edite = 0;
            button1.Text = "ثبت";

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit click
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEditeRow")
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                var user = db.find("users", "id", id);
                txtName.Text = user["name"].ToString();
                txtUser.Text = user["username"].ToString();
                txtPass.Text = user["password"].ToString();

                if (user["access"] != "")
                {
                    comboBox1.SelectedIndex = Convert.ToInt32(user["access"]);
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
                txtPhon.Text = user["phone"].ToString();
                txtAddress.Text = user["address"].ToString();
                edite = Convert.ToInt32(user["id"]);
                button1.Text = "ویرایش";
            }

            //delete click
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDeleteRow" && e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                if (PublicVar.user_id.ToString()==id)
                {
                    Msg.error("شما نمی توانید خودتان را حدف کنید");
                    return;
                }
                if (Msg.confirmDelete() == DialogResult.Yes)
                {
                    if (db.countRow("borrow_book", "user_id", id) == 0)
                    {
                        db.delete("users", "id", id);
                        loadUsers();
                    }
                    else
                    {
                        Msg.inAnotherTableUsed();
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Msg.error("فیلد سرچ خالی است");
            }
            db.com.CommandText = "SELECT *FROM users WHERE name LIKE @search OR username LIKE @search OR password LIKE @search OR phone LIKE @search LIMIT 1000";
            db.com.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
            db.ad.SelectCommand = db.com;
            DataTable dt = new DataTable();
            db.ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["username"].DisplayIndex = 2;
            dataGridView1.Columns["password"].DisplayIndex = 3;
            dataGridView1.Columns["access"].DisplayIndex = 4;
            dataGridView1.Columns["phone"].DisplayIndex = 5;
            dataGridView1.Columns["address"].DisplayIndex = 6;
            dataGridView1.Columns["btnEditeRow"].DisplayIndex = 7;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 8;


        }

        private void txtPhon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                Msg.error("فقط عدد وارد کنید");
                e.Handled=true;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            loadUsers();
        }
    }
}
