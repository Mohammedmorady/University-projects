using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phon
{
    public partial class Signin : Form
    {
        private MySql sql;
        public Signin()
        {
            InitializeComponent();
            sql = new MySql();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            sql.SigninCustomer(username, password);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup s = new Signup();
            s.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            s.ShowDialog();
            this.Close();
        }
    }
}
