using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phon
{
    public partial class sabt : Form
    {
        public sabt()
        {
            InitializeComponent();
        }

        private void btnsabt_Click(object sender, EventArgs e)
        {
            try
            {
            // اعبارسنجی فیلد نام
            if (String.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("فیلد نام خالی هست");
                 return;
            }
            else if (txtname.Text.Length < 3)
            {
                MessageBox.Show("فیلد نام باید حداقل سه کاراکتر باشد");
                return;
            }
            //اعتبارسنجی فیلد نام خانوادگی
             if(string.IsNullOrWhiteSpace(txtfamily.Text))
            {
                MessageBox.Show("فیلد نام خانوادگی خالی هست");
                return;
            }
            if (txtfamily.Text.Length < 3)
            {
                MessageBox.Show("فیلد نام خانوادگی باید حداقل سه کاراکتر باشد");
                return;
            }
            //اعتبارسنجی فیلد تلفن
            if (string.IsNullOrWhiteSpace(txtphon.Text))
            {
                MessageBox.Show("فیلد تلفن خالی هست");
                return;
            }
            if (!long.TryParse(txtphon.Text, out long phon))
            {
                MessageBox.Show("شماره تلفن باید فقط شامل اعداد باشد");
                return;
            }
            if (txtphon.Text.Length != 11)
            {
                MessageBox.Show("شماره تلفن باید دقیقاً 11 رقم باشد");
                return;
            }
            //اعتبارسنجی فیلد آدرس
            if (string.IsNullOrWhiteSpace(txtaddress.Text))
            {
                MessageBox.Show("فیلد آدرس خالی هست");
                return;
            }

         

       


            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "provider=Microsoft.ace.oledb.12.0;Data Source=Database1.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            // com.CommandText = "insert into person (fname,lname,phonnumber,address) values('"+txtname.Text+"','"+txtfamily.Text+"','"+txtphon.Text+"','"+txtaddress.Text +"')";
            com.CommandText = "insert into person (fname,lname,phonnumber,address) values(@Name,@Family,@Phon,@Address)";
            com.Connection = con;

            //پارامترها
            com.Parameters.AddWithValue("@Name", txtname.Text);
            com.Parameters.AddWithValue("@Family", txtfamily.Text);
            com.Parameters.AddWithValue("@Phon", txtphon.Text);
            com.Parameters.AddWithValue("@Address", txtaddress.Text);


            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اطلاعات درج شد");

            // خالی کردن فیلدها
            txtname.Text = "";
            txtfamily.Text = "";
            txtphon.Text = "";
            txtaddress.Text = "";


            // تمرکز (Focus) روی اولین فیلد
            txtname.Focus();

            }
            catch (Exception exception)
            {
                Console.WriteLine(":خطا درج اطلاعات"+exception);
                throw;
            }

        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            Form1 f =new Form1();
            this.Hide();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            this.Close();

        }


        private void txtphon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
