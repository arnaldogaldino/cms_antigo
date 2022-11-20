using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms.Modulos.Venda.Forms
{
    public partial class frmVendaCopiarItens : cms.Modulos.Util.WindowBase
    {
        public long id_venda = 0;

        public frmVendaCopiarItens()
        {
            InitializeComponent();
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            id_venda = long.Parse(txtCodigo.Text);
            this.Hide();
        }
    }
}
