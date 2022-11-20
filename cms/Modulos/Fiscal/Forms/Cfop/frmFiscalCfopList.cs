using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Modulos.Fiscal.Cn;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Fiscal.Forms.Cfop
{
    public partial class frmFiscalCfopList : cms.Modulos.Util.WindowBase
    {
        cnFiscalCfop cFiscalCfop = new cnFiscalCfop();
        private IQueryable<fiscal_cfop> cfops;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalCfopList()
        {
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvCfop);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfop fFiscalCfop = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfop();

            fFiscalCfop.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalCfop.MdiParent = this;
                fFiscalCfop.Show();
            }
            else
                fFiscalCfop.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btCancelar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void gvCFOP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gvCFOP.CurrentRow == null)
                return;

            fiscal_cfop cfop = (fiscal_cfop)gvCFOP.CurrentRow.DataBoundItem;

            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfop fFiscalCfop = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfop();

            fFiscalCfop.id_fiscal_cfop = cfop.id_fiscal_cfop;

            fFiscalCfop.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalCfop.MdiParent = this;
                fFiscalCfop.Show();
            }
            else
                fFiscalCfop.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvCfop()
        {
            int? cfop = null;
            string descricao = string.Empty;
            string tipo = string.Empty;

            if (txtCFOP.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCFOP.Text))
                    cfop = int.Parse(txtCFOP.Text);

            if (rbTipoEntrada.InvokeRequired)
                if (rbTipoEntrada.Checked)
                    tipo = "Entrada";
                else if (rbTipoSaida.Checked)
                    tipo = "Saída";

            if (txtDescricao.InvokeRequired)
                descricao = txtDescricao.Text;

            try
            {
                cfops = cFiscalCfop.FiscalCfopProcurar(cfop, tipo, descricao);
            }
            catch
            {
                Thread.Sleep(200);
            }

            if (gvCFOP.InvokeRequired)
                gvCFOP.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvCFOP.AutoGenerateColumns = false;
            gvCFOP.DataSource = cfops;
            gvCFOP.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

    }

}
