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
    public partial class frmBooks : Form
    {
        public frmBooks()
        {
            InitializeComponent();
        }

        private Database db = new Database();
        private int editId;
        private void frmBooks_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Myfont.vazir(), 11, FontStyle.Regular);

            // cmbSubjectid.DataSource = db.select("subjects");
            DataTable dt = new DataTable();
            db.com.CommandText = "SELECT * FROM subjects LIMIT 1000";
            db.ad.SelectCommand = db.com;
            db.ad.Fill(dt);
            cmbSubjectid.DataSource= dt;
            cmbSubjectid.DisplayMember = "name";
            cmbSubjectid.ValueMember = "id";
            cmbSubjectid.SelectedIndex = -1;
            loadBooks();
        }

        private void loadBooks()
        {
            dataGridView1.DataSource = db.select("view_books");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["writer"].DisplayIndex = 2;
            dataGridView1.Columns["subject_name"].DisplayIndex = 3;
            dataGridView1.Columns["publish_year"].DisplayIndex = 4;
            dataGridView1.Columns["price"].DisplayIndex = 5;
            dataGridView1.Columns["btnEditRow"].DisplayIndex = 6;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 7;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "price" && e.Value != null)
            {
                e.Value = string.Format("{0:n0}", e.Value) + "تومان";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                Msg.error("فیلد نام کتاب خالی است");
                return;
            }
            if (txtWriter.Text == "")
            {
                Msg.error("فیلد نویسنده خالی است");
                return;
            }

            if (editId == 0) //insert
            {
                db.com.CommandText = "INSERT INTO books (name,writer,subject_id,publish_year,price) VALUES(@name,@writer,@subject_id,@publish_year,@price)";
                db.com.Parameters.AddWithValue("@name", txtName.Text);
                db.com.Parameters.AddWithValue("@writer", txtWriter.Text);
                db.com.Parameters.AddWithValue("@subject_id", cmbSubjectid.SelectedIndex);
                db.com.Parameters.AddWithValue("@publish_year", txtPulish_year.Text);
                db.com.Parameters.AddWithValue("@price", txtPrice.Text);
                db.com.ExecuteNonQuery();
                loadBooks();
                txtPulish_year.Text = "";
                txtName.Text = "";
                txtPrice.Text = "";
                txtWriter.Text = "";
                cmbSubjectid.Text = "";
                cmbSubjectid.SelectedIndex = -1;
            }
            else //update
            {
                db.com.CommandText = "UPDATE books SET name=@name,writer=@writer,subject_id=@subject_id,publish_year=@publish_year,price=@price WHERE id=@id";
                db.com.Parameters.AddWithValue("@name", txtName.Text);
                db.com.Parameters.AddWithValue("@writer", txtWriter.Text);
                db.com.Parameters.AddWithValue("@subject_id", cmbSubjectid.SelectedIndex);
                db.com.Parameters.AddWithValue("@publish_year", txtPulish_year.Text);
                db.com.Parameters.AddWithValue("@price", txtPrice.Text);
                db.com.Parameters.AddWithValue("@id", editId);
                db.com.ExecuteNonQuery();
                loadBooks();
                txtPulish_year.Text = "";
                txtName.Text = "";
                txtPrice.Text = "";
                txtWriter.Text = "";
                cmbSubjectid.Text = "";
                cmbSubjectid.SelectedIndex = -1;
                button1.Text = "ثبت";
            }

        }

        private void txtPulish_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEditRow" && e.RowIndex>=0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                var book = db.find("books", "id", id);

                txtName.Text = book["name"].ToString();
                txtWriter.Text = book["writer"].ToString();
                cmbSubjectid.SelectedValue = book["subject_id"].ToString();
                txtPulish_year.Text = book["publish_year"].ToString();
                txtPrice.Text = book["price"].ToString();

                editId = Convert.ToInt32(book["id"]);
                button1.Text = "ویرایش";
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDeleteRow"&& e.RowIndex>=0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (Msg.confirmDelete() == DialogResult.Yes)
                {
                    if (db.countRow("borrow_book", "book_id", id) == 0)
                    {
                        db.delete("books", "id", id);
                        loadBooks();
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
            db.com.CommandText = "SELECT *FROM view_books WHERE id LIKE @search OR name LIKE @search OR writer LIKE @search OR [name:1] LIKE @search OR publish_year LIKE @search OR price LIKE @search LIMIT 1000";
            db.com.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
            db.ad.SelectCommand = db.com;

            DataTable dt = new DataTable();
            db.ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["writer"].DisplayIndex = 2;
            dataGridView1.Columns["subject_name"].DisplayIndex = 3;
            dataGridView1.Columns["publish_year"].DisplayIndex = 4;
            dataGridView1.Columns["price"].DisplayIndex = 5;
            dataGridView1.Columns["btnEditRow"].DisplayIndex = 6;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 7;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            loadBooks();
        }
    }
}
