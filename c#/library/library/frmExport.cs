using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace library
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private string reportName = "";
        private string id = "";
        private string[] csv;
        private void frmExport_Load(object sender, EventArgs e)
        {
            cmbReport.DataSource = db.select("reports");
            cmbReport.DisplayMember = "name";
            cmbReport.ValueMember = "id";
            cmbReport.SelectedIndex = -1;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cmbReport.SelectedIndex == -1)
            {
                Msg.error("لطفا گزارش رو انتخاب کنید");
                return;
            }

            string id = cmbReport.SelectedValue.ToString();
            var report = db.find("reports", "id", id);
            db.com.CommandText = report["sql"].ToString() + " LIMIT 1000";
            db.ad.SelectCommand = db.com;
            DataTable dt = new DataTable();
            db.ad.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbReport.SelectedIndex == -1)
            {
                Msg.error("لطفا گزارش رو انتخاب کنید");
                return;
            }
            id = cmbReport.SelectedValue.ToString();
            backgroundWorker1.RunWorkerAsync();
            btnExport.Enabled= false;
        }

        private string exportformat(string value, string column)
        {
            if (column == "taken" && value != null)
            {
                if (value == "0")
                {
                    value = "خیر";
                }
                else if (value == "1")
                {
                    value = "بله";
                }
            }

            if (column == "borrow_date" && value != null)
            {
                value = pdate(DateTime.Parse(value));
            }
            if (column == "back_date" && value != null)
            {
                value = pdate(DateTime.Parse(value));
            }

            return value;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Database db = new Database(); 
            var report = db.find("reports", "id", id);
            reportName = report["name"].ToString();
            db.com.CommandText = "SELECT count(*) from(" + report["sql"].ToString() + ")";
            int countRow = Convert.ToInt32(db.com.ExecuteScalar());
            csv = new string[countRow];
            db.com.CommandText = report["sql"].ToString() + " LIMIT 1000";
            var row1 = db.com.ExecuteReader();
            // db.ad.SelectCommand = db.com;
            // DataTable dt = new DataTable();
            // db.ad.Fill(dt);

            //
            // string csv = "";
            for (int i = 0; i < row1.FieldCount; i++)
            {
                csv[0] += row1.GetName(i) + ",";
            }
            csv[0] += "\r\n";
            int divide = countRow / 100;
            divide++;
            int rowNumber = 0;
            while (row1.Read())
            {
                for (int i = 0; i < row1.FieldCount; i++)
                {
                    csv[rowNumber] += exportformat(row1[i].ToString(), row1.GetName(i) + ",".Replace(",", ";")) + ",";
                }
                csv[rowNumber] += "\r\n";
                if (rowNumber%divide==0)
                {
                    backgroundWorker1.ReportProgress(rowNumber/divide);
                }
                rowNumber++;
            }
            row1.Close();
            // foreach (DataColumn column in dt.Columns)
            // {
            //     csv += column.ColumnName + ",";
            // }
            // csv += "\r\n";
            //
            // foreach (DataRow row in dt.Rows)
            // {
            //     foreach (DataColumn column in dt.Columns)
            //     {
            //         csv += exportformat(row[column.ColumnName].ToString(),column.ColumnName.Replace(",", ";")) + ",";
            //     }
            //     csv += "\r\n";
            // }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            lblPerson.Text = "100%";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".csv";
            saveFile.Filter = "CSV Files |*.csv";
            saveFile.Title = "ذخیره گزارش";
            saveFile.FileName = reportName + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName != "")
            {
                File.WriteAllText(saveFile.FileName, string.Join("", csv), Encoding.UTF8);
            }

            btnExport.Enabled = true;
            id = "";
            reportName = "";
            for (int i = 0; i < csv.Length; i++)
            {
                csv[i] = "";
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPerson.Text = e.ProgressPercentage.ToString()+"%";

        }
    }
}
