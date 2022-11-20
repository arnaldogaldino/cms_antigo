using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Transportadora.Forms
{
    public partial class frmTransportadoraList : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Transportadora.Cn.cnTransportadora cTransportadora = new cms.Modulos.Transportadora.Cn.cnTransportadora();

        public frmTransportadoraList()
        {
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGvTransportadora();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Transportadora.Forms.frmTransportadora fTransportadora = new cms.Modulos.Transportadora.Forms.frmTransportadora();

            fTransportadora.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fTransportadora.MdiParent = this;
                fTransportadora.Show();
            }
            else
                fTransportadora.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvTransportadora_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gvTransportadora.CurrentRow == null)
                return;

            transportadora transportadora = (transportadora)gvTransportadora.CurrentRow.DataBoundItem;

            cms.Modulos.Transportadora.Forms.frmTransportadora fTransportadora = new cms.Modulos.Transportadora.Forms.frmTransportadora();

            fTransportadora.id_transportadora = transportadora.id_transportadora;

            fTransportadora.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fTransportadora.MdiParent = this;
                fTransportadora.Show();
            }
            else
                fTransportadora.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarGvTransportadora();
        }

        private void AtualizarGvTransportadora()
        {
            gvTransportadora.AutoGenerateColumns = false;

            long? id_transportadora = null;

            if (!string.IsNullOrEmpty(txtCodigo.Text))
                id_transportadora = long.Parse(txtCodigo.Text);

            gvTransportadora.DataSource = cTransportadora.TransportadoraProcurar(id_transportadora, txtRazaoSocial.Text, txtCnpj.Text, txtRG.Text);
            gvTransportadora.Refresh();
        }

    }
}
