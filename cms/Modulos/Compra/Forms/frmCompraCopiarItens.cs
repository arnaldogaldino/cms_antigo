using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms.Modulos.Compra.Forms
{
    public partial class frmCompraCopiarItens : cms.Modulos.Util.WindowBase
    {
        public long id_compra = 0;

        public frmCompraCopiarItens()
        {
            InitializeComponent();
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            id_compra = long.Parse(txtCodigo.Text);
            this.Hide();
        }
    }
}
