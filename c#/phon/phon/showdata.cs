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

namespace phon
{
    public partial class showdata : Form
    {
        public showdata()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "provider=Microsoft.ace.oledb.12.0;data source=Database1.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "select *from person";
            com.Connection = con;
            // com.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = com;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void showdata_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

        }

        private void btnmain_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
