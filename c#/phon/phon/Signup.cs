using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace phon
{
    public partial class Signup : Form
    {
        private MySql dbHelper;
        private Validation val;
        public Signup()
        {
            InitializeComponent();
            dbHelper = new MySql();
            val = new Validation();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            string Fullname = txtfullname.Text;
            string Phone = txtphon.Text;
            string Username = txtusername.Text;
            string Password = txtpassword.Text;
            string ConfirmPassword = txtconfirmpassword.Text;

            {
                if (!val.nullable(Fullname))
                {
                    MessageBox.Show("فیلد نام ونام خانوادگی خالی هست");
                    return;
                }

                if (!val.length(Fullname))
                {
                    MessageBox.Show("نام و نام خانوادگی نباید کمتر از سه کاراکتر باشد");
                    return;
                }
            } //Validation Fullname

            {
                if (!val.nullable(Phone))
                {
                    MessageBox.Show("فیلد شماره تلفن خالی هست");
                    return;
                }

                if (!val.phoneval(Phone))
                {
                    MessageBox.Show("شماره تلفن اشتباهست");
                    return;
                }
            } //Validation Phone
            {
                if (!val.nullable(Username))
                {
                    MessageBox.Show("فیلد نام کاربری خالی هست");
                    return;
                }

                if (!val.length(Username))
                {
                    MessageBox.Show("نامکاربری نباید کمتر از سه کاراکتر باشد");
                    return;
                }
            }//Validation Username

            {
                if (!val.pass(Password))
                {
                    MessageBox.Show("گذر واژه نامعبر است!باید حداقل 8 کاراکتر داشته باشد و باید ترکیبی از حروف بزرگ و کوچک,اعداد,وکاراکترهای خاص شامل شود");
                    return;
                }

                if (!val.match(Password,ConfirmPassword))
                {
                    MessageBox.Show("پسورد و تکرار آن هماهنگ نیست");
                    return;
                }

                if (!val.nullable(Password))
                {
                    MessageBox.Show("فیلد پسورد خالی هست");
                    return;
                }
            }//Validation Password

          






            try
            {
                // فراخوانی متد درج اطلاعات
                dbHelper.SignupCustomer(Fullname, Phone, Username, Password, ConfirmPassword); // ارسال username به متد
                MessageBox.Show("ثبت‌نام با موفقیت انجام شد!", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Signin form = new Signin();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ثبت اطلاعات: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lablelogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signin s = new Signin();
            s.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            s.ShowDialog();
            this.Close();
        }
    }
}
