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
using cms.Modulos.Cliente.Cn;
using cms.Modulos.Fiscal.Cn;

namespace cms.Modulos.Fiscal.Forms.Cnae
{
    public partial class frmFiscalCnaeLockup : cms.Modulos.Util.WindowBase
    {

        private fiscal_cnae cnae = new fiscal_cnae();

        cnFiscalCnae cFiscalCnae = new cnFiscalCnae();

        IQueryable<fiscal_cnae> cnaes;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalCnaeLockup()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarCNAE();
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

        void btCancelar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
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

        private void gvCNAE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelecionarCNAE();
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

        private void SelecionarCNAE()
        {
            if (gvCNAE.CurrentRow == null)
                return;

            cnae = (fiscal_cnae)gvCNAE.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public fiscal_cnae GetCNAESelecionado()
        {
            return cnae;
        }

    }
}
