using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phon
{
    internal class Validation
    {
        public bool match(string password, string confirm)
        {
         
            if (password != confirm)
            {
                return false;
            }
            return true;
        }

        public bool nullable(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }

        public bool phoneval(string p)
        {
            if (!p.StartsWith("09"))
            {
                return false;
            }else if (p.Length != 11)
            {
                return false;
            }

            return true;
        }

        public bool length(string l)
        {
            if (l.Length < 3)
            {
                return false;
            }
            return true;
        }

        public bool pass(string password)
        {
            var hasUpper = false;
            var hasLower = false;
            var hasadd = false;
            var haschar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpper=true;
                }

                if (char.IsLower(c))
                {
                    hasLower=true;
                }

                if (char.IsDigit(c))
                {
                    hasadd=true;
                }
                
                if ("!@#%^&*()".Contains(c))
                {
                    haschar = true;
                }
            }


            if (!(hasUpper && hasLower && hasadd &&haschar))
            {
                return false;
            }


            return true;
        }

    }
}
