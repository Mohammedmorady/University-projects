using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace library
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Myfont.vazir(),11,FontStyle.Regular);

            lblUser.Text = "کاربر: "+PublicVar.name_user;
            if (PublicVar.access==0)
            {
                button4.Enabled= false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSubjects subjects =new frmSubjects();
            subjects.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmBooks().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmUsers().ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmMembers().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmBorrowBook().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new frmExport().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new frmBackup().ShowDialog();
        }
    }
}
