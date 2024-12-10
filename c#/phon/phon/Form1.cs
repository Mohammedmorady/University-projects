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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnconect_Click(object sender, EventArgs e)
        {
            // OleDbConnection conn = new OleDbConnection();
            // conn.ConnectionString = "provider=Microsoft.ace.oledb.16.0;Data Source=Database1.accdb";
            // conn.Open();
            // MessageBox.Show("ok");

            sabt sabt = new sabt();
            this.Hide();
            sabt.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete d = new delete();
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showdata s = new showdata();
            this.Hide();
            s.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
