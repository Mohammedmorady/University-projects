using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phon
{
    internal class MySql
    {
        private OleDbConnection con;
        public MySql()
        {
            con = new OleDbConnection();
        }



        public void SignupCustomer(string Fullname, string Phone, string Username, string Password, string ConfirmPassword)
        {
            con.ConnectionString = "provider = Microsoft.ace.oledb.12.0;Data Source=Database1.accdb";
            string query = "INSERT INTO [user] ([Fullname],Phon,[Username], [Password], ConfirmPassword) VALUES (@FullName, @Phone, @Username, @Password, @Confirm)";

            // ایجاد شیء MySqlCommand برای اجرای دستور SQL
            OleDbCommand cmd = new OleDbCommand(query, con);

            // اضافه کردن پارامترها به دستور SQL
            cmd.Parameters.AddWithValue("@FullName", Fullname);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Confirm", ConfirmPassword);

            try
            {
                // باز کردن اتصال به دیتابیس
                con.Open();

                // اجرای دستور SQL
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // در صورت بروز خطا، پیغام خطا نمایش داده می‌شود
                throw new Exception("خطا در ثبت اطلاعات: " + ex.Message);
            }
            finally
            {
                // بستن اتصال به دیتابیس
                con.Close();
            }
        }

        public void SigninCustomer(string username ,string password)
        {
            con.ConnectionString = "provider=Microsoft.ace.oledb.12.0;data source=Database1.accdb";
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.CommandText = "SELECT COUNT(*) FROM [user] WHERE Username=@Username AND Password=@Password";

            com.Parameters.AddWithValue("@Username", username);
            com.Parameters.AddWithValue("@Password",password);
            com.Connection = con;
            var role = (int)com.ExecuteScalar();

            if (role >0)
            {
                MessageBox.Show($"خوش آمدید!");
                Signin s = new Signin();
                s.Hide();
                Form1 mainForm = new Form1(); // فرم اصلی کتابخانه
                mainForm.StartPosition = FormStartPosition.CenterParent;
                mainForm.ShowDialog();
                s.Close();
            }
            else
            {
                MessageBox.Show("یوزرنیم یا پسورد اشتباه است");
            }
        }

    }
}
