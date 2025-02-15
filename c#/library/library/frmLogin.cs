using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace library
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Myfont.vazir(), 11, FontStyle.Regular);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text=="")
            {
                Msg.error("فیلد نام کاربری اشتباه است");
                return;
            }
            if (txtPassword.Text == "")
            {
                Msg.error("فیلد رمزعبور اشتباه است");
                return;
            }
            Database db = new Database();

            if (db.countRow("users","username",txtUsername.Text)>0)
            {
                var user = db.find("users", "username", txtUsername.Text);
                string verify = user["password"].ToString();
                if (verify==txtPassword.Text)
                {
                    PublicVar.access = Convert.ToInt32(user["access"]);
                    PublicVar.user_id = Convert.ToInt32(user["id"]);
                    PublicVar.name_user = user["name"].ToString();
                    frmMain f = new frmMain();
                    this.Hide();
                    f.ShowDialog();
                }
                else
                {
                    Msg.error("رمز عبور اشتباه است");
                }
            }
            else
            {
                Msg.error("نام کاربری اشتباه است");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
