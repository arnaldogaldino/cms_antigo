using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDI.NFe.Visual
{
    public class ItemWithObject
    {
        private System.Windows.Forms.Form _Frm;

        public System.Windows.Forms.Form Frm
        {
            get { return _Frm; }
            set { _Frm = value; }
        }
        private System.Windows.Forms.ToolStripItem _Item;

        public System.Windows.Forms.ToolStripItem Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
    }
}
