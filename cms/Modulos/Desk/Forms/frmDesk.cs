using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms.Modulos.Desk.Forms
{
    public partial class frmDesk : Form
    {
        public frmDesk()
        {
            InitializeComponent();
        }

        private void adsfsdfasfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tabPage1 = new TabPage("ChildForm1");

            //you can use or pre-defined class for this, or just 
            //call upon Form class
            cms.Modulos.Cliente.Forms.frmClienteList childForm1 = new cms.Modulos.Cliente.Forms.frmClienteList();
            childForm1.TopLevel = false;
            childForm1.Visible = true;
            childForm1.Parent = this;

            //Also Anchor and Dock properties are the playground for
            //you to find the best arrangement       
            childForm1.Anchor = AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top;
            childForm1.Dock = DockStyle.Fill;
            childForm1.FormBorderStyle = FormBorderStyle.None;
            
            tabPage1.Controls.Add(childForm1);
            childForm1.Tag = tabPage1;

            //tabForm.TabPages.Add(tabPage1);
        }
    }
}
