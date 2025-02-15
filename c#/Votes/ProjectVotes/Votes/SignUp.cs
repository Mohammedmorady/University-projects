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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VotingSystem.accdb";
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("فیلد نام کاربری خالی هست");
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("فیلد رمز عبور خالی هست");
            }
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users ([Username], [Password]) VALUES (@Username, @Password)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("ثبتنام با موفقیت انجام شد");
                    Form1 login = new Form1();
                    this.Hide();
                    login.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
