using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace library
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.DefaultExt = "*.lbk";
                saveFile.Filter = "library backup|*.lbk";
                saveFile.Title = "تهیه نسخه پشتیبان";
                saveFile.FileName = "library_backup_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName != "")
                {
                    File.Copy("library.db", saveFile.FileName);
                    Msg.info("فایل پشتیبان با موفقیت ذخیره شد");
                }
            }
            catch (Exception ex)
            {
                Msg.error(ex.ToString());
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.DefaultExt = "*.lbk";
                openFile.Filter = "library backup|*.lbk";
                openFile.Title = "بازیابی پشتیبان";
                if (Msg.confirm("تمام اطلاعات قبلی از بین خواهد رفت و اطلاعات جدید جایگزین می شوند آیا از این عمل اطمینان دارید؟ \n") == DialogResult.Yes)
                {
                    if (openFile.ShowDialog()==DialogResult.OK && openFile.FileName!="")
                    {
                        File.Delete("library.db");
                        File.Copy(openFile.FileName,"library.db");
                        Msg.info("فایل پشتیبان با موفقیت بازیابی شد");
                        Application.Restart();
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.error(ex.ToString());
                throw;
            }
        }
    }
}
