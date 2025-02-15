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
    public partial class frmSubjects : Form
    {
        public frmSubjects()
        {
            InitializeComponent();
        }
        Database db = new Database();
        int editid = 0;
        private void frmSubjects_Load(object sender, EventArgs e)
        {
            loadSubjects();
        }

        private void loadSubjects()
        {
            this.Font = new Font(Myfont.vazir(), 11, FontStyle.Regular);
            dataGridView1.DataSource = db.select("subjects");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtsubject.Text == "")
            {
                Msg.error("فیلد نام موضوع خالی هست");
                return;
            }

            if (editid == 0)
            {
               db.com.CommandText = "INSERT INTO subjects (name) VALUES (@name)";
               db.com.Parameters.AddWithValue("@name", txtsubject.Text);
               db.com.ExecuteNonQuery();
                loadSubjects();
                txtsubject.Text = "";
            }
            else
            {
                db.com.CommandText = "UPDATE subjects SET name=@name WHERE id=@id";
                db.com.Parameters.AddWithValue("@name", txtsubject.Text);
                db.com.Parameters.AddWithValue("@id", editid);
                db.com.ExecuteNonQuery();
                loadSubjects();
                txtsubject.Text = "";
                editid = 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit Click
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEditRow")
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                var subject = db.find("subjects","id",id);
                txtsubject.Text = subject["name"].ToString();
                editid = Convert.ToInt32(subject["id"]);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDeleteRow")
            {
                if (Msg.confirmDelete() == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();


                    if (db.countRow("books", "id", id) == 0)
                    {
                        db.delete("subjects","id",id);
                        loadSubjects();
                    }
                    else
                    {
                        Msg.inAnotherTableUsed();
                    }
                }
            }
        }
    }
}
