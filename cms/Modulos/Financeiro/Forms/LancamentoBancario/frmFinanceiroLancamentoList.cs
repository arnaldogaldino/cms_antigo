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

namespace cms.Modulos.Financeiro.Forms.LancamentoBancario
{
    public partial class frmFinanceiroLancamentoList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento cFinanceiroLancamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento();

        IQueryable<vw_financeiro_lancamento> lancamentos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public long? id_contas_pagar { get; set; }
        public long? id_contas_receber { get; set; }

        public frmFinanceiroLancamentoList()
        {
            InitializeComponent();
        }

        private void frmFinanceiroLancamentoList_Load(object sender, EventArgs e)
        {
            if (id_contas_pagar != null)
            {
                txtContaPagar.Text = id_contas_pagar.ToString();
                btPesquisar_Click(sender, e);
            }

            if (id_contas_receber != null)
            {
                txtContaReceber.Text = id_contas_receber.ToString();
                btPesquisar_Click(sender, e);
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamento fLancamento = new cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamento();

            fLancamento.Acao = Util.Acao.Cadastrar;
            fLancamento.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fLancamento.MdiParent = this;
                fLancamento.Show();
            }
            else
                fLancamento.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            threadPreencherGrid = new Thread(AtualizarGvLancamento);
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

        public void AtualizarGvLancamento()
        {
            long? id_lancamento = null;
            long? id_conta_corrente = null;
            long? id_cliente = null;
            long? id_fornecedor = null;

            long? id_contas_pagar = null;
            long? id_contas_receber = null;
            long? id_empresa = null;

            DateTime? data_lancamento_de = null;
            DateTime? data_lancamento_ate = null;
            DateTime? data_conciliacao_de = null;
            DateTime? data_conciliacao_ate = null;

            bool chk_data_lancamento_de = false;
            bool chk_data_lancamento_ate = false;
            bool chk_data_conciliacao_de = false;
            bool chk_data_conciliacao_ate = false;
            
            string documento = string.Empty;
            string descricao = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_lancamento = long.Parse(txtCodigo.Text);
            
            if (ctrlFilial.InvokeRequired)
                if (!string.IsNullOrEmpty(ctrlFilial.GetSelectedValue()))
                    id_empresa = long.Parse(ctrlFilial.GetSelectedValue());

            if (txtDocumento.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDocumento.Text))
                    documento = txtDocumento.Text;

            if (txtDescricao.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    descricao = txtDescricao.Text;

            if (txtContaPagar.InvokeRequired)
                if (!string.IsNullOrEmpty(txtContaPagar.Text))
                    id_contas_pagar = long.Parse(txtContaPagar.Text);

            if (txtContaReceber.InvokeRequired)
                if (!string.IsNullOrEmpty(txtContaReceber.Text))
                    id_contas_receber = long.Parse(txtContaReceber.Text);

            if (txtContaCorrente.InvokeRequired)
                if (txtContaCorrente.Tag != null)
                    id_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;

            if (txtCliente.InvokeRequired)
                if (txtCliente.Tag != null)
                    id_cliente = ((cliente)txtCliente.Tag).id_cliente;

            if (txtFornecedor.InvokeRequired)
                if (txtFornecedor.Tag != null)
                    id_fornecedor = ((fornecedor)txtFornecedor.Tag).id_fornecedor;
            
            if (dtaLancamentoDataDe.InvokeRequired)
            {
                dtaLancamentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_lancamento_de = dtaLancamentoDataDe.Checked; }));
                if (chk_data_lancamento_de)
                    dtaLancamentoDataDe.Invoke(new MethodInvoker(delegate { data_lancamento_de = dtaLancamentoDataDe.Value; }));
            }

            if (dtaLancamentoDataAte.InvokeRequired)
            {
                dtaLancamentoDataAte.Invoke(new MethodInvoker(delegate { chk_data_lancamento_ate = dtaLancamentoDataAte.Checked; }));
                if (chk_data_lancamento_ate)
                    dtaLancamentoDataAte.Invoke(new MethodInvoker(delegate { data_lancamento_ate = dtaLancamentoDataAte.Value; }));
            }

            if (dtaConciliacaoDataDe.InvokeRequired)
            {
                dtaConciliacaoDataDe.Invoke(new MethodInvoker(delegate { chk_data_conciliacao_de = dtaConciliacaoDataDe.Checked; }));
                if (chk_data_conciliacao_de)
                    dtaConciliacaoDataDe.Invoke(new MethodInvoker(delegate { data_conciliacao_de = dtaConciliacaoDataDe.Value; }));
            }

            if (dtaConciliacaoDataAte.InvokeRequired)
            {
                dtaConciliacaoDataAte.Invoke(new MethodInvoker(delegate { chk_data_conciliacao_ate = dtaConciliacaoDataAte.Checked; }));
                if (chk_data_conciliacao_ate)
                    dtaConciliacaoDataAte.Invoke(new MethodInvoker(delegate { data_conciliacao_ate = dtaConciliacaoDataAte.Value; }));
            }
            
            try
            {
                lancamentos = cFinanceiroLancamento.FinanceiroLancamentoProcurar(id_lancamento, id_empresa, id_cliente, id_fornecedor, id_conta_corrente, id_contas_pagar, id_contas_receber, documento, descricao, data_lancamento_de, data_lancamento_ate, data_conciliacao_de, data_conciliacao_ate);
            }
            catch { }

            if (gvFinanceiroLancamento.InvokeRequired)
                gvFinanceiroLancamento.Invoke(new MethodInvoker(Preencher));
        }
        
        public void Preencher()
        {
            gvFinanceiroLancamento.AutoGenerateColumns = false;
            gvFinanceiroLancamento.DataSource = lancamentos;
            gvFinanceiroLancamento.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void gvFinanceiroLancamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gvFinanceiroLancamento.Rows[e.RowIndex];
            
            if (((decimal)row.Cells[6].Value) < 0)
            {
                row.Cells[6].Style.ForeColor = Color.DarkRed;
            } 
            else if (((decimal)row.Cells[6].Value) > 0)
            {
                row.Cells[6].Style.ForeColor = Color.DarkBlue;
            }

            if (((decimal)row.Cells[7].Value) < 0)
            {
                row.Cells[7].Style.ForeColor = Color.DarkRed;
            } 
            else if (((decimal)row.Cells[7].Value) > 0)
            {
                row.Cells[7].Style.ForeColor = Color.DarkBlue;
            }
            
            if (((decimal)row.Cells[8].Value) < 0)
            {
                row.Cells[8].Style.ForeColor = Color.DarkRed;
            } 
            else if (((decimal)row.Cells[8].Value) > 0)
            {
                row.Cells[8].Style.ForeColor = Color.DarkBlue;
            }
        }

        private void gvFinanceiroLancamento_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroLancamento.CurrentRow == null)
                return;

            financeiro_lancamento lancamento = new financeiro_lancamento();

            try
            {
                lancamento = cFinanceiroLancamento.GetFinanceiroLancamentoByID(long.Parse(gvFinanceiroLancamento.CurrentRow.Cells[0].Value.ToString()));
            }
            catch { }

            cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamento fLancamento = new cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamento();

            fLancamento.id_lancamento = lancamento.id_financeiro_lancamento;
            fLancamento.Acao = Util.Acao.Visualizar;
            fLancamento.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fLancamento.MdiParent = this;
                fLancamento.Show();
            }
            else
                fLancamento.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

        private void btCliente_Click(object sender, EventArgs e)
        {
            cms.Modulos.Cliente.Forms.frmClienteLockup fClienteLockup = new cms.Modulos.Cliente.Forms.frmClienteLockup();

            if (fClienteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cliente = fClienteLockup.GetClienteSelecionado();

                txtCliente.Tag = cliente;
                txtCliente.Text = cliente.id_cliente + " - " + cliente.nome_fantasia;

                fClienteLockup.Close();
                fClienteLockup.Dispose();
            }
            else
            {
                txtCliente.Tag = null;
                txtCliente.Text = string.Empty;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCliente_Click(sender, e);
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
        
    }
}
