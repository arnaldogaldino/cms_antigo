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

namespace cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas
{
    public partial class frmFinanceiroPlanoContasLockup : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta cFinanceiroPlanoContas = new cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta();
        vw_financeiro_plano_conta adoPlanoConta = new vw_financeiro_plano_conta();

        IQueryable<vw_financeiro_plano_conta> financeiro_plano_conta;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        cms.Modulos.Util.TipoPlanoConta tipoPlanoConta;

        public frmFinanceiroPlanoContasLockup(cms.Modulos.Util.TipoPlanoConta tipo)
        {
            InitializeComponent();
            tipoPlanoConta = tipo;
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

            threadPreencherGrid = new Thread(AtualizarGvPlanoContas);
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
            gvFinanceiroPlanoContas.AutoGenerateColumns = false;
            gvFinanceiroPlanoContas.DataSource = financeiro_plano_conta;
            gvFinanceiroPlanoContas.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void AtualizarGvPlanoContas()
        {
            string descricao = string.Empty;

            if (txtDescricao.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    descricao = txtDescricao.Text;

            try
            {
                financeiro_plano_conta = cFinanceiroPlanoContas.FinanceiroPlanoContasProcurar(descricao, tipoPlanoConta);
            }
            catch { }

            if (gvFinanceiroPlanoContas.InvokeRequired)
                gvFinanceiroPlanoContas.Invoke(new MethodInvoker(Preencher));
        }

        private void SelecionarPlanoContas()
        {
            if (gvFinanceiroPlanoContas.CurrentRow == null)
                return;

            adoPlanoConta = (vw_financeiro_plano_conta)gvFinanceiroPlanoContas.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvFinanceiroPlanoContas_DoubleClick(object sender, EventArgs e)
        {
            SelecionarPlanoContas();
        }

        public vw_financeiro_plano_conta GetPlanoContasSelecionado()
        {
            return adoPlanoConta;
        }
        
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarPlanoContas();
        }

    }
}
