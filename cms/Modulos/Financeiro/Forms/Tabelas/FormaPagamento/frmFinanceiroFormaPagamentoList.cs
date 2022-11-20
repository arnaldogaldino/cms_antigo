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
    public partial class frmFinanceiroFormaPagamentoList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento cFinanceiroFormaPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento();

        IQueryable<financeiro_forma_pagamento> forma_pagamentos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFinanceiroFormaPagamentoList()
        {
            InitializeComponent();
        }

        private void frmFinanceiroFormaPagamentoList_Load(object sender, EventArgs e)
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

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamento fFormaPagamento = new cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamento();

            fFormaPagamento.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFormaPagamento.MdiParent = this;
                fFormaPagamento.Show();
            }
            else
                fFormaPagamento.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvFinanceiroFormaPagamento_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroFormaPagamento.CurrentRow == null)
                return;

            financeiro_forma_pagamento FormaPagamento = (financeiro_forma_pagamento)gvFinanceiroFormaPagamento.CurrentRow.DataBoundItem;

            cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamento fFormaPagamento = new cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamento();

            fFormaPagamento.id_forma_pagamento = FormaPagamento.id_financeiro_forma_pagamento;
            fFormaPagamento.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFormaPagamento.MdiParent = this;
                fFormaPagamento.Show();
            }
            else
                fFormaPagamento.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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
