using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace library
{
    static class Msg
    {
        public static DialogResult confirmDelete()
        {
            DialogResult result = MessageBox.Show("آیا از حذف این مورد اطمینان دارید", "مقدار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }
        public static DialogResult confirm(string text)
        {
            DialogResult result = MessageBox.Show(text, " هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }
        public static void inAnotherTableUsed()
        {
            MessageBox.Show("امکان حذف این مورد وجود ندارد.زیرا در جدول دیگری از این فیلد استفاده شده است");
        }

        public static void error(string txt)
        {
            MessageBox.Show(txt, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void info(string txt)
        {
            MessageBox.Show(txt, "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
