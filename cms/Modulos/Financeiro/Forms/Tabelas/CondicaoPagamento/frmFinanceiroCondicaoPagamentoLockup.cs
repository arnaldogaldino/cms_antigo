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
    public partial class frmFinanceiroCondicaoPagamentoLockup : cms.Modulos.Util.WindowBase
    {
        private financeiro_condicao_pagamento condicao_pagamento = new financeiro_condicao_pagamento();
        cms.Modulos.Financeiro.Cn.cnFinanceiroCondicaoPagamento cFinanceiroCondicaoPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroCondicaoPagamento();

        IQueryable<financeiro_condicao_pagamento> condicao_pagamentos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFinanceiroCondicaoPagamentoLockup()
        {
            InitializeComponent();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvCondicaoPagamento);
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarCondicaoPagamento();            
        }

        public financeiro_condicao_pagamento GetCondicaoPagamentoSelecionado()
        {
            return condicao_pagamento;
        }

        private void SelecionarCondicaoPagamento()
        {
            if (gvFinanceiroCondicaoPagamento.CurrentRow == null)
                return;

            condicao_pagamento = (financeiro_condicao_pagamento)gvFinanceiroCondicaoPagamento.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvFinanceiroCondicaoPagamento_DoubleClick(object sender, EventArgs e)
        {
            SelecionarCondicaoPagamento();
        }
        
        private void AtualizarGvCondicaoPagamento()
        {
            try
            {
                condicao_pagamentos = cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoProcurar();
            }
            catch { }

            if (gvFinanceiroCondicaoPagamento.InvokeRequired)
                gvFinanceiroCondicaoPagamento.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
        {
            gvFinanceiroCondicaoPagamento.AutoGenerateColumns = false;
            gvFinanceiroCondicaoPagamento.DataSource = condicao_pagamentos;
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
