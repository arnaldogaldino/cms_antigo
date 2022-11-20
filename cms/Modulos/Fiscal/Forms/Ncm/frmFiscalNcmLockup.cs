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
    public partial class frmFiscalNcmLockup : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Fiscal.Cn.cnFiscalNcm cFiscalNcm = new cms.Modulos.Fiscal.Cn.cnFiscalNcm();
        fiscal_ncm adoNcm = new fiscal_ncm();

        IQueryable<fiscal_ncm> fiscal_ncm;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalNcmLockup()
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

            threadPreencherGrid = new Thread(AtualizarGvNcm);
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

        public void Preencher()
        {
            gvFinanceiroNcm.AutoGenerateColumns = false;
            gvFinanceiroNcm.DataSource = fiscal_ncm;
            gvFinanceiroNcm.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void AtualizarGvNcm()
        {
            string descricao = string.Empty;
            string ncm = string.Empty;

            if (txtNcm.InvokeRequired)
                if (!string.IsNullOrEmpty(txtNcm.Text))
                    ncm = txtNcm.Text;

            if (txtDescricao.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    descricao = txtDescricao.Text;

            try
            {
                fiscal_ncm = cFiscalNcm.FiscalNcmProcurar(ncm, descricao);
            }
            catch { }

            if (gvFinanceiroNcm.InvokeRequired)
                gvFinanceiroNcm.Invoke(new MethodInvoker(Preencher));
        }

        private void SelecionarNcm()
        {
            if (gvFinanceiroNcm.CurrentRow == null)
                return;
            
            adoNcm = (fiscal_ncm)gvFinanceiroNcm.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvFinanceiroNcm_DoubleClick(object sender, EventArgs e)
        {
            SelecionarNcm();
        }

        public fiscal_ncm GetNcmSelecionado()
        {
            return adoNcm;
        }
        
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarNcm();
        }

    }
}
