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

namespace cms.Modulos.Fiscal.Forms.Cnae
{
    public partial class frmFiscalCnaeList : cms.Modulos.Util.WindowBase
    {
        cnFiscalCnae cFiscalCnae = new cnFiscalCnae();
        private IQueryable<fiscal_cnae> cnaes;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalCnaeList()
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

            threadPreencherGrid = new Thread(AtualizarGvCnae);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnae fFiscalCnae = new cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnae();

            fFiscalCnae.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalCnae.MdiParent = this;
                fFiscalCnae.Show();
            }
            else
                fFiscalCnae.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

        private void gvCnae_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gvCNAE.CurrentRow == null)
                return;

            fiscal_cnae cnae = (fiscal_cnae)gvCNAE.CurrentRow.DataBoundItem;

            cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnae fFiscalCnae = new cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnae();

            fFiscalCnae.id_fiscal_cnae = cnae.id_fiscal_cnae;

            fFiscalCnae.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalCnae.MdiParent = this;
                fFiscalCnae.Show();
            }
            else
                fFiscalCnae.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvCnae()
        {
            long? id_fiscal_cnae = null;
            string secao = string.Empty;
            string divisao = string.Empty;
            string grupo = string.Empty;
            string classe = string.Empty;
            string subclasse = string.Empty;
            string denominacao = string.Empty;

            if (txtSubClasse.InvokeRequired)
                if (!string.IsNullOrEmpty(txtSubClasse.Text))
                    subclasse = txtSubClasse.Text;

            if (txtDenominacao.InvokeRequired)
                denominacao = txtDenominacao.Text;

            try
            {
                cnaes = cFiscalCnae.FiscalCnaeProcurar(id_fiscal_cnae, secao, divisao, grupo, classe, subclasse, denominacao);
            }
            catch
            {
                Thread.Sleep(200);
            }

            if (gvCNAE.InvokeRequired)
                gvCNAE.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvCNAE.AutoGenerateColumns = false;
            gvCNAE.DataSource = cnaes;
            gvCNAE.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

    }

}
