using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Cliente.Cn;

namespace cms.Modulos.Cliente.Forms
{
    public partial class frmClienteContatoLockup : Util.WindowBase
    {
        private cliente oCliente = new cliente();
        private cliente_contato adoContato = new cliente_contato();
        private cnCliente cCliente = new cnCliente();

        public frmClienteContatoLockup(cliente Cliente)
        {
            InitializeComponent();
            this.oCliente = Cliente;
        }

        private void frmClienteContatoLockup_Load(object sender, EventArgs e)
        {
            txtCliente.Text = oCliente.id_cliente + " - " + oCliente.nome_fantasia;

            gvContato.AutoGenerateColumns = false;
            gvContato.DataSource = oCliente.cliente_contato;
            gvContato.Refresh();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarClienteContato();
        }

        public cliente_contato GetClienteContatoSelecionado()
        {
            return adoContato;
        }

        private void SelecionarClienteContato()
        {
            if (gvContato.CurrentRow == null)
                return;

            adoContato = cCliente.GetClienteContatoByIDClienteContato(long.Parse(gvContato.CurrentRow.Cells[0].Value.ToString()));

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvContato_DoubleClick(object sender, EventArgs e)
        {
            SelecionarClienteContato();
        }


    }
}
