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
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }

        private void btnsabt_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "provider=Microsoft.ace.oledb.12.0;Data Source=Database1.accdb";
                con.Open();

                // بررسی وجود شماره تلفن
                string checkQuery = "SELECT COUNT(*) FROM person WHERE phonnumber = @Phon";
                OleDbCommand comcheck = new OleDbCommand();   //OleDbCommand comcheck = new OleDbCommand(checkQuery, con);
                comcheck.CommandText = checkQuery;
                comcheck.Connection = con;
                comcheck.Parameters.AddWithValue("@Phon", txtphonnumber.Text);

              
                int count = (int)comcheck.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("شماره تلفن وارد شده در پایگاه داده وجود ندارد.");
                    con.Close();
                    return;
                }


                OleDbCommand com = new OleDbCommand();
                // com.CommandText = "delete from person where phonnumber='"+txtphonnumber.Text+"'";
                com.CommandText = "delete from person where phonnumber=@Phon";
                com.Connection = con;

                //پارامتر
                com.Parameters.AddWithValue("@Phon", txtphonnumber.Text);

                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات داده حذف شد");
            }
            catch (Exception exception)
            {
                Console.WriteLine(":خطا حذف اطلاعات" + exception);
                throw;
            }
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }
    }
}
