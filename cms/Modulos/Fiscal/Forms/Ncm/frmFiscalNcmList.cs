using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Fiscal.Forms.Ncm
{
    public partial class frmFiscalNcmList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Fiscal.Cn.cnFiscalNcm cFiscalNcm = new cms.Modulos.Fiscal.Cn.cnFiscalNcm();

        IQueryable<fiscal_ncm> fiscal_ncms;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalNcmList()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcm fNcm = new cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcm();

            fNcm.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fNcm.MdiParent = this;
                fNcm.Show();
            }
            else
                fNcm.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvFinanceiroNcm);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
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
        
        private void gvFinanceiroNcm_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroNcm.CurrentRow == null)
                return;

            fiscal_ncm ncm = (fiscal_ncm)gvFinanceiroNcm.CurrentRow.DataBoundItem;

            cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcm fNcm = new cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcm();

            fNcm.id_fiscal_ncm = ncm.id_fiscal_ncm;
            fNcm.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fNcm.MdiParent = this;
                fNcm.Show();
            }
            else
                fNcm.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvFinanceiroNcm()
        {
            string ncm = string.Empty;
            string descricao = string.Empty;

            if (txtNcm.InvokeRequired)
                if (!string.IsNullOrEmpty(txtNcm.Text))
                    ncm = txtNcm.Text;

            if (txtDescricao.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    descricao = txtDescricao.Text;

            try
            {
                fiscal_ncms = cFiscalNcm.FiscalNcmProcurar(ncm, descricao);
            }
            catch
            {
                Thread.Sleep(200);
            }

            if (gvFinanceiroNcm.InvokeRequired)
                gvFinanceiroNcm.Invoke(new MethodInvoker(Preencher));

        }
        
        public void Preencher()
        {
            gvFinanceiroNcm.AutoGenerateColumns = false;
            gvFinanceiroNcm.DataSource = fiscal_ncms;
            gvFinanceiroNcm.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }
        
    }
}
