using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Cliente.Forms
{
    public partial class frmClienteTelefoneView : Util.WindowBase
    {

        private cliente oCliente = new cliente();

        public frmClienteTelefoneView(cliente Cliente)
        {
            InitializeComponent();
            oCliente = Cliente;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmClienteTelefoneView_Load(object sender, EventArgs e)
        {
            txtCliente.Text = oCliente.id_cliente + " - " + oCliente.nome_fantasia;

            if(!string.IsNullOrEmpty(oCliente.telefone))
                gvTelefones.Rows.Add(oCliente.nome_fantasia, oCliente.telefone);

            if(!string.IsNullOrEmpty(oCliente.fax))
                gvTelefones.Rows.Add(oCliente.nome_fantasia, oCliente.fax);

            foreach (var c in oCliente.cliente_contato)
            {
                gvTelefones.Rows.Add(c.nome + " - Telefone", c.telefone);
                gvTelefones.Rows.Add(c.nome + " - Celular", c.celular);
                gvTelefones.Rows.Add(c.nome + " - Nextel", c.nextel + " - ID: " + c.nextel_id);
            }
        }
    }
}
