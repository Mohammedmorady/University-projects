using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace library
{
    public partial class frmBorrowBook : Form
    {
        public frmBorrowBook()
        {
            InitializeComponent();
        }

        private Database db = new Database();
        private int editId = 0;

        private void frmBorrowBook_Load(object sender, EventArgs e)
        {
            loadBorrowBook();
            cmbTaken.SelectedIndex = 0;
        }

        private void loadBorrowBook()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = db.select("view_borrow_book");
            dataGridView1.Columns["member_name"].DisplayIndex = 0;
            dataGridView1.Columns["book_name"].DisplayIndex = 1;
            dataGridView1.Columns["user_name"].DisplayIndex = 2;
            dataGridView1.Columns["borrow_date"].DisplayIndex = 3;
            dataGridView1.Columns["back_date"].DisplayIndex = 4;
            dataGridView1.Columns["taken"].DisplayIndex = 5;
            dataGridView1.Columns["btnEditRow"].DisplayIndex = 6;
            dataGridView1.Columns["btnDeleteRow"].DisplayIndex = 7;
        }

        private void txtMemberId_TextChanged(object sender, EventArgs e)
        {
            if (txtMemberId.Text == "")
            {
                lblMember.Text = "";
                return;
            }
            var member = db.find("members", "id", txtMemberId.Text);
            if (member != null)
            {
                lblMember.Text = member["name"].ToString() + "\n" + member["phone"].ToString();
                lblMember.ForeColor = Color.Green;
            }
            else
            {
                lblMember.Text = "عضو یافت نشد";
                lblMember.ForeColor = Color.Red;
            }
        }

        private void txtBookId_TextChanged(object sender, EventArgs e)
        {
            if (txtBookId.Text == "")
            {
                lblBook.Text = "";
                return;
            }
            var books = db.find("books", "id", txtBookId.Text);
            if (books != null)
            {
                lblBook.Text = books["name"].ToString();
                lblBook.ForeColor = Color.Green;
            }
            else
            {
                lblBook.Text = "کتاب یافت نشد";
                lblBook.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (txtMemberId.Text == "")
            {
                Msg.error("فیلد کد عضو خالی هست");
                return;
            }
            if (txtBookId.Text == "")
            {
                Msg.error("فیلد کد کتاب خالی هست");
                return;
            }
            if (dtsBorrowDate.Value == null)
            {
                Msg.error("فیلد تارخ امانت خالی هست");
                return;
            }
            if (dtsBackDate.Value == null)
            {
                Msg.error("فیلد تارخ بازگشت خالی هست");
                return;
            }

            if (cmbTaken.SelectedIndex == -1)
            {
                Msg.error("فیلد وضعیت تحویل خالی هست خالی هست");
                return;
            }

            if (dtsBorrowDate.Value > dtsBackDate.Value)
            {
                Msg.error("تارخ امانت نباید بعداز تاریخ بازگشت باشد");
                return;
            }

            if (db.countRow("members", "id", txtMemberId.Text) == 0)
            {
                Msg.error("کد عضویت واردشده موجود نیست");
                return;
            }
            if (db.countRow("books", "id", txtBookId.Text) == 0)
            {
                Msg.error("کد کتاب واردشده موجود نیست");
                return;
            }

            if (editId == 0) //insert
            {
                db.com.CommandText = "SELECT *FROM view_borrow_book WHERE book_id=@book_id AND taken=0";
                db.com.Parameters.AddWithValue("@book_id", txtBookId.Text);
                db.ad.SelectCommand = db.com;
                DataTable dt = new DataTable();
                db.ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Msg.error("کتاب " + row["book_name"].ToString() + " توسط " + row["member_name"].ToString() + " امانت گرفته شده و تحویل داده نشده ");
                    return;
                }

                db.com.CommandText = "SELECT *FROM view_borrow_book WHERE member_id=@member_id AND taken=0";
                db.com.Parameters.AddWithValue("@member_id", txtMemberId.Text);
                db.ad.SelectCommand = db.com;
                db.ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Msg.error("کاربر " + row["member_name"].ToString() + " کتاب " + row["book_name"].ToString() + " گرفته و هنوز تحویل نداده ");
                    return;
                }

                db.com.CommandText = @"INSERT INTO borrow_book
            (member_id,book_id,borrow_date,back_date,taken,user_id) 
             VALUES
            (@member_id,@book_id,@borrow_date,@back_date,@taken,@user_id) ";

                db.com.Parameters.AddWithValue("@member_id", txtMemberId.Text);
                db.com.Parameters.AddWithValue("@book_id", txtBookId.Text);
                db.com.Parameters.AddWithValue("@borrow_date", dtsBorrowDate.Value.Value.ToString("yyyy-MM-dd"));
                db.com.Parameters.AddWithValue("@back_date", dtsBackDate.Value.Value.ToString("yyyy-MM-dd"));
                db.com.Parameters.AddWithValue("@taken", cmbTaken.SelectedIndex);
                db.com.Parameters.AddWithValue("@user_id",PublicVar.user_id);

                db.com.ExecuteNonQuery();
                loadBorrowBook();
                txtMemberId.Text = "";
                txtBookId.Text = "";
                dtsBorrowDate.Value = null;
                dtsBackDate.Value = null;
                cmbTaken.SelectedIndex = 0;

            }
            else //update
            {
                db.com.CommandText = "SELECT *FROM view_borrow_book WHERE book_id=@book_id AND taken=0 AND id!=@id";
                db.com.Parameters.AddWithValue("@book_id", txtBookId.Text);
                db.com.Parameters.AddWithValue("@id", editId);
                db.ad.SelectCommand = db.com;
                DataTable dt = new DataTable();
                db.ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Msg.error("کتاب " + row["book_name"].ToString() + " توسط " + row["member_name"].ToString() + " امانت گرفته شده و تحویل داده نشده ");
                    return;
                }

                db.com.CommandText = "SELECT *FROM view_borrow_book WHERE member_id=@member_id AND taken=0 AND id!=@id";
                db.com.Parameters.AddWithValue("@member_id", txtMemberId.Text);
                db.com.Parameters.AddWithValue("@id", editId);
                db.ad.SelectCommand = db.com;
                db.ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Msg.error("کاربر " + row["member_name"].ToString() + " کتاب " + row["book_name"].ToString() + " گرفته و هنوز تحویل نداده ");
                    return;
                }

                db.com.CommandText = "UPDATE borrow_book SET member_id=@member_id , book_id=@book_id,borrow_date=@borrow_date,back_date=@back_date,taken=@taken,user_id=@user_id WHERE id=@id";

                db.com.Parameters.AddWithValue("@member_id", txtMemberId.Text);
                db.com.Parameters.AddWithValue("@book_id", txtBookId.Text);
                db.com.Parameters.AddWithValue("@borrow_date", dtsBorrowDate.Value.Value.ToString("yyyy-MM-dd"));
                db.com.Parameters.AddWithValue("@back_date", dtsBackDate.Value.Value.ToString("yyyy-MM-dd"));
                db.com.Parameters.AddWithValue("@taken", cmbTaken.SelectedIndex);
                db.com.Parameters.AddWithValue("@user_id", PublicVar.user_id);
                db.com.Parameters.AddWithValue("@id", editId);

                db.com.ExecuteNonQuery();
                loadBorrowBook();
                txtMemberId.Text = "";
                txtBookId.Text = "";
                dtsBorrowDate.Value = null;
                dtsBackDate.Value = null;
                cmbTaken.SelectedIndex = 0;
                editId = 0;
                button1.Text = "ثبت";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEditRow" && e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                var borrow_book = db.find("borrow_book", "id", id);

                txtMemberId.Text = borrow_book["member_id"].ToString();
                txtBookId.Text = borrow_book["book_id"].ToString();
                dtsBorrowDate.Value = (DateTime)borrow_book["borrow_date"];
                dtsBackDate.Value = (DateTime)borrow_book["back_date"];
                cmbTaken.SelectedIndex = Convert.ToInt32(borrow_book["taken"]);
                editId = Convert.ToInt32(borrow_book["id"]);
                button1.Text = "ویرایش";
            }
            //delete
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDeleteRow" && e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (Msg.confirmDelete() == DialogResult.Yes)
                {
                    db.delete("borrow_book", "id", id);
                    loadBorrowBook();
                }
            }
        }

        private string pdate(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "taken" && e.Value != null)
            {
                if (e.Value.ToString() == "0")
                {
                    e.Value = "خیر";
                    dataGridView1.Rows[e.RowIndex].Cells["taken"].Style.ForeColor = Color.Red;
                }
                else if (e.Value.ToString() == "1")
                {
                    e.Value = "بله";
                    dataGridView1.Rows[e.RowIndex].Cells["taken"].Style.ForeColor = Color.Green;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "borrow_date" && e.Value != null)
            {
                e.Value = pdate((DateTime)e.Value);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "back_date" && e.Value != null)
            {
                e.Value = pdate((DateTime)e.Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text=="")
            {
                return;
            }

            db.com.CommandText = "SELECT *FROM view_borrow_book WHERE book_id LIKE @search OR member_id LIKE @search OR book_name LIKE @search OR member_name LIKE @search";
            db.com.Parameters.AddWithValue("@search","%"+txtSearch.Text+"%");
            db.ad.SelectCommand = db.com;
            DataTable dt = new DataTable();
            db.ad.Fill(dt);

            dataGridView1.DataSource=dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            loadBorrowBook();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd");

            db.com.CommandText = "SELECT *FROM view_borrow_book WHERE @now>=back_date AND taken=0";
            db.com.Parameters.AddWithValue("@now", now);
            db.ad.SelectCommand = db.com;
            DataTable dt = new DataTable();
            db.ad.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string csv = "";
            csv = "نام عضو" + ",";
            csv += "نام کتاب" + ",";
            csv += "نام کاربر" + ",";
            csv += "تاریخ امانت" + ",";
            csv += "تاریخ بازگشت" + ",";
            csv += "وضعیت تحویل" + ",";
            csv += "\r\n";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                csv += row.Cells["member_name"].FormattedValue.ToString().Replace(",", ";") + ",";
                csv += row.Cells["book_name"].FormattedValue.ToString().Replace(",", ";") + ",";
                csv += row.Cells["user_name"].FormattedValue.ToString().Replace(",", ";") + ",";
                csv += row.Cells["borrow_date"].FormattedValue.ToString().Replace(",", ";") + ",";
                csv += row.Cells["back_date"].FormattedValue.ToString().Replace(",", ";") + ",";
                csv += row.Cells["taken"].FormattedValue.ToString().Replace(",", ";") + ",";
                csv += "\r\n";
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".csv";
            saveFile.Filter = "CSV Files |*.csv";
            saveFile.Title = "ذخیره گزارش";
            saveFile.FileName = "borrow_book"+DateTime.Now.ToString("yyyyMMdd-HHmmss");
            if (saveFile.ShowDialog()==DialogResult.OK && saveFile.FileName!="")
            {
                File.WriteAllText(saveFile.FileName, csv, Encoding.UTF8);
            }
        }
    }
}
