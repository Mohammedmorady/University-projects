using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Drawing;

namespace library
{
    static class Myfont
    {
        public static FontFamily vazir()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("VazirFD.ttf");
            return pfc.Families[0];
        }
    }
}
