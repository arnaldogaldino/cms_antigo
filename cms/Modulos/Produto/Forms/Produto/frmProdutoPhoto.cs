using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms.Modulos.Produto.Forms.Produto
{
    public partial class frmProdutoPhoto : Form
    {
        public frmProdutoPhoto()
        {
            InitializeComponent();
        }

        public void Show(MouseEventArgs me)
        {
            this.Top = me.Location.Y + (this.Width-90);
            this.Left = me.Location.X + (this.Height-90);
            this.Show();
        }
    }
}
