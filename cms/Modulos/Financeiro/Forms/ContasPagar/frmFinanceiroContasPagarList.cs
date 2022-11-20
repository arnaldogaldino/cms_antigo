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

namespace cms.Modulos.Financeiro.Forms.ContasPagar
{
    public partial class frmFinanceiroContasPagarList : cms.Modulos.Util.WindowBase
    {
        private DateTime data_atual = new DateTime();
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar cFinanceiroContaPagar = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar();

        IQueryable<vw_financeiro_conta_pagar> conta_pagars;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFinanceiroContasPagarList()
        {
            InitializeComponent();
        }

        private void btFormaPagamento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamentoLockup fFormaPagamentoLockup = new cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamentoLockup();

            if (fFormaPagamentoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var forma_pagamento = fFormaPagamentoLockup.GetFormaPagamentoSelecionado();

                txtFormaPagamento.Tag = forma_pagamento;
                txtFormaPagamento.Text = forma_pagamento.nome;

                fFormaPagamentoLockup.Close();
                fFormaPagamentoLockup.Dispose();
            }
            else
            {
                txtFormaPagamento.Tag = null;
                txtFormaPagamento.Text = string.Empty;
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagar fContasPagar = new cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagar();

            fContasPagar.Acao = Util.Acao.Cadastrar;
            fContasPagar.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContasPagar.MdiParent = this;
                fContasPagar.Show();
            }
            else
                fContasPagar.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvFinanceiroContasPagar_DoubleClick(object sender, EventArgs e)
        {

            if (gvFinanceiroContasPagar.CurrentRow == null)
                return;

            financeiro_conta_pagar ContasPagar = new financeiro_conta_pagar();

            try
            {
                ContasPagar = cFinanceiroContaPagar.GetFinanceiroContaPagarByID(long.Parse(gvFinanceiroContasPagar.CurrentRow.Cells[0].Value.ToString()));
            }
            catch { }

            cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagar fContasPagar = new cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagar();

            fContasPagar.id_contas_pagar = ContasPagar.id_financeiro_conta_pagar;
            fContasPagar.Acao = Util.Acao.Visualizar;
            fContasPagar.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContasPagar.MdiParent = this;
                fContasPagar.Show();
            }
            else
                fContasPagar.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            data_atual = Util.Util.GetDataServidor();
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvContaPagar);
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

        private void AtualizarGvContaPagar()
        {
            gvFinanceiroContasPagar.AutoGenerateColumns = false;

            long? id_conta_pagar = null;
            long? id_conta_corrente = null;
            long? id_forma_pagamento = null;
            long? id_fornecedor = null;
            long? id_empresa = null;
           
            DateTime? data_vencimento_de = null;
            DateTime? data_vencimento_ate = null;
            DateTime? data_pagamento_de = null;
            DateTime? data_pagamento_ate = null;

            bool chk_data_vencimento_de = false;
            bool chk_data_vencimento_ate = false;
            bool chk_data_pagamento_de = false;
            bool chk_data_pagamento_ate = false;

            string documento = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_conta_pagar = long.Parse(txtCodigo.Text);

            if (txtDocumento.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDocumento.Text))
                    documento = txtDocumento.Text;

            if (txtContaCorrente.InvokeRequired)
                if (txtContaCorrente.Tag != null)
                    id_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;

            if (txtFormaPagamento.InvokeRequired)
                if (txtFormaPagamento.Tag != null)
                    id_forma_pagamento = ((financeiro_forma_pagamento)txtFormaPagamento.Tag).id_financeiro_forma_pagamento;

            if (txtFornecedor.InvokeRequired)
                if (txtFornecedor.Tag != null)
                    id_fornecedor = ((fornecedor)txtFornecedor.Tag).id_fornecedor;

            if (ctrlFilial.InvokeRequired)
                if (!string.IsNullOrEmpty(ctrlFilial.GetSelectedValue()))
                    id_empresa = long.Parse(ctrlFilial.GetSelectedValue());

            if (dtaVencimentoDataDe.InvokeRequired)
            {
                dtaVencimentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_vencimento_de = dtaVencimentoDataDe.Checked; }));
                if (chk_data_vencimento_de)
                    dtaVencimentoDataDe.Invoke(new MethodInvoker(delegate { data_vencimento_de = dtaVencimentoDataDe.Value; }));
            }

            if (dtaVencimentoDataAte.InvokeRequired)
            {
                dtaVencimentoDataAte.Invoke(new MethodInvoker(delegate { chk_data_vencimento_ate = dtaVencimentoDataAte.Checked; }));
                if (chk_data_vencimento_ate)
                    dtaVencimentoDataAte.Invoke(new MethodInvoker(delegate { data_vencimento_ate = dtaVencimentoDataAte.Value; }));
            }

            if (dtaPagamentoDataDe.InvokeRequired)
            {
                dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_pagamento_de = dtaPagamentoDataDe.Checked; }));
                if (chk_data_pagamento_de)
                    dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { data_pagamento_de = dtaPagamentoDataDe.Value; }));
            }

            if (dtaPagamentoDataAte.InvokeRequired)
            {
                dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_pagamento_ate = dtaPagamentoDataAte.Checked; }));
                if (chk_data_pagamento_ate)
                    dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { data_pagamento_ate = dtaPagamentoDataAte.Value; }));
            }

            try
            {
                conta_pagars = cFinanceiroContaPagar.FinanceiroContaPagarProcurar(id_conta_pagar, id_empresa, id_fornecedor, id_forma_pagamento, id_conta_corrente, documento, data_vencimento_de, data_vencimento_ate, data_pagamento_de, data_pagamento_ate);
            }
            catch { }
            
            if (gvFinanceiroContasPagar.InvokeRequired)
                gvFinanceiroContasPagar.Invoke(new MethodInvoker(Preencher));
            
        }
        
        public void Preencher()
        {
            gvFinanceiroContasPagar.AutoGenerateColumns = false;
            gvFinanceiroContasPagar.DataSource = conta_pagars;
            gvFinanceiroContasPagar.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void btContaCorrente_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrenteLockup fContaCorrenteLockup = new cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrenteLockup();

            if (fContaCorrenteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var conta_corrente = fContaCorrenteLockup.GetFormaPagamentoSelecionado();

                txtContaCorrente.Tag = conta_corrente;
                txtContaCorrente.Text = conta_corrente.financeiro_banco.nome;

                fContaCorrenteLockup.Close();
                fContaCorrenteLockup.Dispose();
            }
            else
            {
                txtContaCorrente.Tag = null;
                txtContaCorrente.Text = string.Empty;
            }
        }

        private void txtContaCorrente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btContaCorrente_Click(sender, e);
            }
        }

        private void txtFormaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFormaPagamento_Click(sender, e);
            }
        }
        
        private void btFornecedor_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fornecedor.Forms.frmFornecedorLockup fFornecedorLockup = new cms.Modulos.Fornecedor.Forms.frmFornecedorLockup();

            if (fFornecedorLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fornecedor = fFornecedorLockup.GetFornecedorSelecionado();

                txtFornecedor.Tag = fornecedor;
                txtFornecedor.Text = fornecedor.id_fornecedor + " - " + fornecedor.nome_fantasia;

                fFornecedorLockup.Close();
                fFornecedorLockup.Dispose();
            }
            else
            {
                txtFornecedor.Tag = null;
                txtFornecedor.Text = string.Empty;
            }
        }
        
        private void txtFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFornecedor_Click(sender, e);
            }
        }

        private void gvFinanceiroContasPagar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gvFinanceiroContasPagar.Rows[e.RowIndex];

            // Traja linha de contas em atrazo que ainda não quitadas.
            if (e.ColumnIndex == 5 && (DateTime)e.Value < data_atual && row.Cells[7].Value == null && row.Cells[9].Value == null)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.Crimson;
            }

            // Traja linha de contas quitadas.
            if (row.Cells[7].Value != null && row.Cells[9].Value == null)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.SteelBlue;
            }

            // Traja linha de contas não quitadas com vencimento hoje.
            if (e.ColumnIndex == 5 && ((DateTime)e.Value).ToString("dd/MM/yyyy") == data_atual.ToString("dd/MM/yyyy") && row.Cells[7].Value == null && row.Cells[9].Value == null)
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.BackColor = Color.Gold;
            }

            // Traja linha de contas lançadas.
            if (row.Cells[9].Value != null)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.Navy;
            }

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (e.ColumnIndex == 5 && (DateTime)e.Value < data_atual && row.Cells[7].Value == null && row.Cells[9].Value == null)
                    cell.ToolTipText = "Conta com vencimento em atrazo há " + ((((DateTime)e.Value).Day - data_atual.Day) * -1) + " dias.";
                if (row.Cells[7].Value != null && row.Cells[9].Value == null)
                    cell.ToolTipText = "Conta quitada.";
                if (row.Cells[9].Value != null)
                    cell.ToolTipText = "Conta lançada em " + ((DateTime)row.Cells[9].Value).ToString("dd/MM/yyyy") + ".";
            }
        }
    
    }
}
