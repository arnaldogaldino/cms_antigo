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

namespace cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento
{
    public partial class frmFinanceiroFormaPagamentoLockup : cms.Modulos.Util.WindowBase
    {
        private financeiro_forma_pagamento forma_pagamento = new financeiro_forma_pagamento();
        cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento cFinanceiroFormaPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento();
        
        IQueryable<financeiro_forma_pagamento> forma_pagamentos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmFinanceiroFormaPagamentoLockup()
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

            threadPreencherGrid = new Thread(AtualizarGvFormaPagamento);
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
            SelecionarFormaPagamento();            
        }

        public financeiro_forma_pagamento GetFormaPagamentoSelecionado()
        {
            return forma_pagamento;
        }

        private void SelecionarFormaPagamento()
        {
            if (gvFinanceiroFormaPagamento.CurrentRow == null)
                return;

            forma_pagamento = (financeiro_forma_pagamento)gvFinanceiroFormaPagamento.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvFinanceiroFormaPagamento_DoubleClick(object sender, EventArgs e)
        {
            SelecionarFormaPagamento();
        }
        
        private void AtualizarGvFormaPagamento()
        {
            try
            {
                forma_pagamentos = cFinanceiroFormaPagamento.FinanceiroFormaPagamentoProcurar();
            }
            catch { }

            if (gvFinanceiroFormaPagamento.InvokeRequired)
                gvFinanceiroFormaPagamento.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
        {
            gvFinanceiroFormaPagamento.AutoGenerateColumns = false;
            gvFinanceiroFormaPagamento.DataSource = forma_pagamentos;
            gvFinanceiroFormaPagamento.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }


    }
}
