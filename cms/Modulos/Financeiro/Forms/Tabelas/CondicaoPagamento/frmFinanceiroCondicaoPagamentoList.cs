using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using System.Threading;

namespace cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento
{
    public partial class frmFinanceiroCondicaoPagamentoList : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroCondicaoPagamento cFinanceiroCondicaoPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroCondicaoPagamento();

        IQueryable<financeiro_condicao_pagamento> condicoes_pagamentos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        private void frmFinanceiroCondicaoPagamentoList_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        public frmFinanceiroCondicaoPagamentoList()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamento fFinanceiroCondicaoPagamento = new cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamento();

            fFinanceiroCondicaoPagamento.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroCondicaoPagamento.MdiParent = this;
                fFinanceiroCondicaoPagamento.Show();
            }
            else
                fFinanceiroCondicaoPagamento.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvFormaPagamento);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        private void gvFinanceiroCondicaoPagamento_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroCondicaoPagamento.CurrentRow == null)
                return;

            financeiro_condicao_pagamento condicao_pagamento = (financeiro_condicao_pagamento)gvFinanceiroCondicaoPagamento.CurrentRow.DataBoundItem;

            cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamento fCondicaoPagamento = new cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamento();

            fCondicaoPagamento.id_financeiro_condicao_pagamento = condicao_pagamento.id_financeiro_condicao_pagamento;
            fCondicaoPagamento.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fCondicaoPagamento.MdiParent = this;
                fCondicaoPagamento.Show();
            }
            else
                fCondicaoPagamento.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvFormaPagamento()
        {
            try
            {
                condicoes_pagamentos = cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoProcurar();
            }
            catch { }

            if (gvFinanceiroCondicaoPagamento.InvokeRequired)
                gvFinanceiroCondicaoPagamento.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvFinanceiroCondicaoPagamento.AutoGenerateColumns = false;
            gvFinanceiroCondicaoPagamento.DataSource = condicoes_pagamentos;
            gvFinanceiroCondicaoPagamento.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        
    }
}
