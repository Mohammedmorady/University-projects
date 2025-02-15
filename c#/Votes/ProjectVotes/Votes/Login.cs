using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Votes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VotingSystem.accdb";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT [UserID] FROM [Users] WHERE [Username] = @Username AND [Password] = @Password";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@Password",txtPassword.Text);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int loggedInUserID = Convert.ToInt32(result);
                        MessageBox.Show("به صفحه رای خوش آمدید");

                        // باز کردن فرم رأی‌گیری
                        VotingForm votingForm = new VotingForm(loggedInUserID);
                        votingForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("رمز یا نام کاربری اشتباه است");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp s = new SignUp();
            this.Hide();
            s.ShowDialog();
            this.Close();
        }
    }
}
