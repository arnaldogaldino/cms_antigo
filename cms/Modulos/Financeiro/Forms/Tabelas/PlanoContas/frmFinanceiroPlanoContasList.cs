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
    public partial class frmFinanceiroPlanoContasList : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta cFinanceiroPlanoContas = new cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta();

        IQueryable<financeiro_plano_conta> financeiro_plano_conta;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmFinanceiroPlanoContasList()
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
        
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContas fPlanoContas = new cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContas();

            fPlanoContas.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fPlanoContas.MdiParent = this;
                fPlanoContas.Show();
            }
            else
                fPlanoContas.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvPlanoContas()
        {
            string descricao = string.Empty;

            if (txtDescricao.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    descricao = txtDescricao.Text;
            
            try
            {
                financeiro_plano_conta = cFinanceiroPlanoContas.FinanceiroPlanoContasProcurar(descricao);
            }
            catch { }

            if (gvFinanceiroPlanoContas.InvokeRequired)
                gvFinanceiroPlanoContas.Invoke(new MethodInvoker(Preencher));
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

        private void gvFinanceiroPlanoContas_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroPlanoContas.CurrentRow == null)
                return;

            financeiro_plano_conta plano_conta = (financeiro_plano_conta)gvFinanceiroPlanoContas.CurrentRow.DataBoundItem;

            cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContas fPlanoContas = new cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContas();

            fPlanoContas.id_financeiro_plano_conta = plano_conta.id_financeiro_plano_conta;

            fPlanoContas.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fPlanoContas.MdiParent = this;
                fPlanoContas.Show();
            }
            else
                fPlanoContas.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }
        
    }
}
