using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace library
{
    public partial class frmMembers : Form
    {
        public frmMembers()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private int edite = 0;

        private void frmMembers_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Myfont.vazir(), 11, FontStyle.Regular);
            loadMembers();
        }

        private void loadMembers()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = db.select("members");
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["codemeli"].DisplayIndex = 2;
            dataGridView1.Columns["phone"].DisplayIndex = 3;
            dataGridView1.Columns["address"].DisplayIndex = 4;
            dataGridView1.Columns["btnEditRow"].DisplayIndex = 5;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                Msg.error("فیلد نام خالی است");
                return;
            }
            if (txtNational.Text == "")
            {
                Msg.error("فیلد کدملی خالی است");
                return;
            }

            if (edite == 0)//Insert
            {
                if (db.countRow("members", "codemeli", txtNational.Text) > 0)
                {
                    Msg.error(" از قبل ثبت شده است" + txtNational.Text + " نام کاربری");
                    return;
                }
                db.com.CommandText = "INSERT INTO members(name,codemeli,phone,address) VALUES(@name,@codemeli,@phone,@address)";
                db.com.Parameters.AddWithValue("@name", txtName.Text);
                db.com.Parameters.AddWithValue("@codemeli", txtNational.Text);
                db.com.Parameters.AddWithValue("@phone", txtPhone.Text);
                db.com.Parameters.AddWithValue("@address", txtAddreess.Text);
            }
            else//edite
            {
                db.com.CommandText = "SELECT COUNT(*) FROM members WHERE codemeli=@codemeli AND id != @id";
                db.com.Parameters.AddWithValue("@codemeli", txtNational.Text);
                db.com.Parameters.AddWithValue("@id", edite);
                int count = Convert.ToInt32(db.com.ExecuteScalar());
                if (count > 0)
                {
                    Msg.error(" از قبل ثبت شده است" + txtNational.Text + " نام کاربری");
                    return;
                }
                db.com.CommandText = "UPDATE members SET name=@name ,codemeli=@codemeli,phone=@phone,address=@address WHERE id=@id";
                db.com.Parameters.AddWithValue("@name", txtName.Text);
                db.com.Parameters.AddWithValue("@codemeli", txtNational.Text);
                db.com.Parameters.AddWithValue("@phone", txtPhone.Text);
                db.com.Parameters.AddWithValue("@address", txtAddreess.Text);
                db.com.Parameters.AddWithValue("@id", edite);
            }

            db.com.ExecuteNonQuery();
            txtName.Text = "";
            txtNational.Text = "";
            txtPhone.Text = "";
            txtAddreess.Text = "";
            loadMembers();
            edite = 0;
            button1.Text = "ثبت";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //click edite
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEditRow" && e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                var count = db.find("members", "id", id);
                txtName.Text = count["name"].ToString();
                txtNational.Text = count["codemeli"].ToString();
                txtPhone.Text = count["phone"].ToString();
                txtAddreess.Text = count["address"].ToString();
                edite = Convert.ToInt32(count["id"]);
                button1.Text = "ویرایش";

            }
            //click delete
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDeleteRow" && e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                if (Msg.confirmDelete()==DialogResult.Yes)
                {
                    if (db.countRow("borrow_book", "id", id) == 0)
                    {
                        db.delete("members", "id", id);
                        loadMembers();
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
            db.com.CommandText = "SELECT *FROM members WHERE id LIKE @search OR name LIKE @search OR codemeli LIKE @search OR phone LIKE @search OR address LIKE @search LIMIT 1000";
            db.com.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
            DataTable dt = new DataTable();
            db.ad.SelectCommand = db.com;
            db.ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["codemeli"].DisplayIndex = 2;
            dataGridView1.Columns["phone"].DisplayIndex = 3;
            dataGridView1.Columns["address"].DisplayIndex = 4;
            dataGridView1.Columns["btnEditRow"].DisplayIndex = 5;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            loadMembers();
        }

        private void txtNational_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                Msg.error("فقط عدد وارد کنید");
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                Msg.error("فقط عدد وارد کنید");
                e.Handled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
