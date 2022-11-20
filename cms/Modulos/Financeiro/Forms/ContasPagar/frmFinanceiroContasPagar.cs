using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Financeiro.Cn;

namespace cms.Modulos.Financeiro.Forms.ContasPagar
{
    public partial class frmFinanceiroContasPagar : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar cFinanceiroContaPagar = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar();
        cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento cFinanceiroLancamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento();

        private financeiro_conta_pagar financeiro_conta_pagar = new financeiro_conta_pagar();

        public Util.Acao Acao { get; set; }
        public long id_contas_pagar { get; set; }

        public frmFinanceiroContasPagar()
        {
            InitializeComponent();
        }

        private void frmFinanceiroContaPagar_Load(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Cadastrar)
                this.TelaModoCadastrarNovo();
            else if (this.Acao == Util.Acao.Editar)
                this.TelaModoEditar();
            else if (this.Acao == Util.Acao.Visualizar)
                this.TelaModoVisualizar();
        }

        #region Modo de Tela
        private void TelaModoCadastrarNovo()
        {
            this.financeiro_conta_pagar = new financeiro_conta_pagar();
            this.Text = "Contas a Pagar - Cadastrar nova conta a pagar";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtDataCadastro.ReadOnly = true;
            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataLancamento.ReadOnly = true;

            txtCodigo.ReadOnly = true;
            txtFornecedor.ReadOnly = true;
            txtPlanoContas.ReadOnly = true;
            txtContaCorrente.ReadOnly = true;
            txtFormaPagamento.ReadOnly = true;

            btFornecedor.Enabled = true;
            btPlanoContas.Enabled = true;
            btContaCorrente.Enabled = true;
            btFormaPagamento.Enabled = true;

            dtaVencimentoData.Enabled = true;
            dtaDataPagamento.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btDuplicarConta.Enabled = false;
            btLancarConta.Enabled = false;
            btEstornarLancamento.Enabled = false;
            btLancamento.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Contas a Pagar - Editar cadastro da conta a pagar";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            txtDataLancamento.ReadOnly = true;

            txtCodigo.ReadOnly = true;
            txtFornecedor.ReadOnly = true;
            txtPlanoContas.ReadOnly = true;
            txtContaCorrente.ReadOnly = true;
            txtFormaPagamento.ReadOnly = true;

            btFornecedor.Enabled = true;
            btPlanoContas.Enabled = true;
            btContaCorrente.Enabled = true;
            btFormaPagamento.Enabled = true;

            dtaVencimentoData.Enabled = true;
            dtaDataPagamento.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btDuplicarConta.Enabled = false;
            btLancarConta.Enabled = false;
            btEstornarLancamento.Enabled = false;
            btLancamento.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.financeiro_conta_pagar = cFinanceiroContaPagar.GetFinanceiroContaPagarByID(id_contas_pagar);

            if (this.financeiro_conta_pagar == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de conta a pagar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Contas a Pagar - Visualizar cadastro de conta a pagar";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btDuplicarConta.Enabled = true;

            btLancarConta.Enabled = false;
            btEstornarLancamento.Enabled = false;
            btLancamento.Enabled = false;

            if (financeiro_conta_pagar.data_pagamento != null && financeiro_conta_pagar.valor_pagamento != null && financeiro_conta_pagar.id_financeiro_conta_corrente != null && financeiro_conta_pagar.data_lancamento == null)
            {
                btLancarConta.Enabled = true;
                btEstornarLancamento.Enabled = false;
            }

            if (financeiro_conta_pagar.data_pagamento != null && financeiro_conta_pagar.valor_pagamento != null && financeiro_conta_pagar.id_financeiro_conta_corrente != null && financeiro_conta_pagar.data_lancamento != null)
            {
                btLancarConta.Enabled = false;
                btEstornarLancamento.Enabled = true;
                btLancamento.Enabled = true;

                btEditar.Enabled = false;
                btExcluir.Enabled = false;
            }

            btFechar.Enabled = true;

            dtaDataPagamento.Enabled = false;
            dtaVencimentoData.Enabled = false;

            TravaFormControles(this.Controls);

            btFornecedor.Enabled = false;
            btPlanoContas.Enabled = false;
            btContaCorrente.Enabled = false;
            btFormaPagamento.Enabled = false;
        }
        #endregion

        #region Menu Ação
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Editar)
                this.TelaModoVisualizar();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherContaPagar();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    financeiro_conta_pagar.data_cadastro = Util.Util.GetDataServidor();
                    if (cFinanceiroContaPagar.FinanceiroContaPagarCadastrar(ref financeiro_conta_pagar))
                    {
                        this.id_contas_pagar = financeiro_conta_pagar.id_financeiro_conta_pagar;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar a conta a pagar!", "Erro ao cadastrar conta a pagar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroContaPagar.FinanceiroContaPagarEditar(ref financeiro_conta_pagar))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o conta a pagar!", "Erro ao cadastrar conta a pagar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o conta a pagar: " + financeiro_conta_pagar.id_financeiro_conta_pagar + "!", "Cadastro de conta a pagar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                financeiro_conta_pagar.excluido = true;
                if (cFinanceiroContaPagar.FinanceiroContaPagarEditar(ref financeiro_conta_pagar))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            txtDataLancamento.ReadOnly = true;

            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            txtDataLancamento.ReadOnly = true;

            TelaModoCadastrarNovo();
        }

        private void PreencherContaPagar()
        {
            this.financeiro_conta_pagar.data_cadastro = DateTime.Parse(txtDataCadastro.Text);

            this.financeiro_conta_pagar.id_empresa = ctrlFilial.GetEmpresa().id_empresa;

            if (!string.IsNullOrEmpty(txtDataLancamento.Text))
                this.financeiro_conta_pagar.data_lancamento = DateTime.Parse(txtDataLancamento.Text);

            if (txtFornecedor.Tag != null)
                this.financeiro_conta_pagar.id_fornecedor = ((fornecedor)txtFornecedor.Tag).id_fornecedor;

            if (txtPlanoContas.Tag != null)
                this.financeiro_conta_pagar.id_financeiro_plano_conta = ((financeiro_plano_conta)txtPlanoContas.Tag).id_financeiro_plano_conta;
            else
                this.financeiro_conta_pagar.id_financeiro_plano_conta = null;

            if (txtContaCorrente.Tag != null)
                this.financeiro_conta_pagar.id_financeiro_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;
            else
                this.financeiro_conta_pagar.id_financeiro_conta_corrente = null;

            if (txtFormaPagamento.Tag != null)
                this.financeiro_conta_pagar.id_financeiro_forma_pagamento = ((financeiro_forma_pagamento)txtFormaPagamento.Tag).id_financeiro_forma_pagamento;

            this.financeiro_conta_pagar.descricao = txtDescricao.Text;
            this.financeiro_conta_pagar.observacao = txtObservacao.Text;
            this.financeiro_conta_pagar.documento = txtDocumento.Text;

            if (!string.IsNullOrEmpty(txtValorVencimento.Text))
                this.financeiro_conta_pagar.valor_vencimento = decimal.Parse(txtValorVencimento.Text);
            else
                this.financeiro_conta_pagar.valor_vencimento = null;

            if (dtaVencimentoData.Checked)
                this.financeiro_conta_pagar.data_vencimento = dtaVencimentoData.Value;

            if (!string.IsNullOrEmpty(txtValorPagamento.Text))
                this.financeiro_conta_pagar.valor_pagamento = decimal.Parse(txtValorPagamento.Text);
            else
                this.financeiro_conta_pagar.valor_pagamento = null;

            if (dtaDataPagamento.Checked)
                this.financeiro_conta_pagar.data_pagamento = dtaDataPagamento.Value;
            else
                this.financeiro_conta_pagar.data_pagamento = null;
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = this.financeiro_conta_pagar.id_financeiro_conta_pagar.ToString();

            txtDataCadastro.Text = this.financeiro_conta_pagar.data_cadastro.ToString("dd/MM/yyyy");

            ctrlFilial.SetSelectedValue(this.financeiro_conta_pagar.id_empresa.ToString());

            if (this.financeiro_conta_pagar.data_lancamento != null)
                txtDataLancamento.Text = this.financeiro_conta_pagar.data_lancamento.Value.ToString("dd/MM/yyyy");
            else
                txtDataLancamento.Text = string.Empty;

            cms.Modulos.Fornecedor.Cn.cnFornecedor cFornecedor = new cms.Modulos.Fornecedor.Cn.cnFornecedor();
            var fornecedor = cFornecedor.GetFornecedorByID(this.financeiro_conta_pagar.id_fornecedor);

            txtFornecedor.Tag = fornecedor;
            txtFornecedor.Text = fornecedor.id_fornecedor + " - " + fornecedor.nome_fantasia;
            

            if (this.financeiro_conta_pagar.id_financeiro_plano_conta != null)
            {
                financeiro_plano_conta plano_conta = new financeiro_plano_conta();
                cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta cPlanoContas = new cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta();
                if (this.financeiro_conta_pagar.id_financeiro_plano_conta != null)
                    plano_conta = cPlanoContas.GetFinanceiroPlanoContasByID(this.financeiro_conta_pagar.id_financeiro_plano_conta.Value);

                var vw_plano_conta = cPlanoContas.GetVWFinanceiroPlanoContasByID(this.financeiro_conta_pagar.id_financeiro_plano_conta.Value);

                txtPlanoContas.Tag = plano_conta;
                txtPlanoContas.Text = vw_plano_conta.plano_conta + " - " + vw_plano_conta.descricao;
            }

            if (this.financeiro_conta_pagar.id_financeiro_conta_corrente != null)
            {
                cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();
                var conta_corrente = cContaCorrente.GetFinanceiroContaCorrenteByID(this.financeiro_conta_pagar.id_financeiro_conta_corrente.Value);

                txtContaCorrente.Tag = conta_corrente;
                txtContaCorrente.Text = conta_corrente.financeiro_banco.nome;
            }

            cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento cFormaPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento();
            var forma_pagamento = cFormaPagamento.GetFinanceiroFormaPagamentoByID(this.financeiro_conta_pagar.id_financeiro_forma_pagamento);

            txtFormaPagamento.Tag = forma_pagamento;
            txtFormaPagamento.Text = forma_pagamento.nome;

            txtDescricao.Text = this.financeiro_conta_pagar.descricao;
            txtObservacao.Text = this.financeiro_conta_pagar.observacao;
            txtDocumento.Text = this.financeiro_conta_pagar.documento;

            if (this.financeiro_conta_pagar.valor_vencimento != null)
                txtValorVencimento.Text = string.Format("{0:n}", this.financeiro_conta_pagar.valor_vencimento.Value);
            else
                txtValorVencimento.Text = string.Empty;

            if (this.financeiro_conta_pagar.data_vencimento != null)
            {
                dtaVencimentoData.Value = this.financeiro_conta_pagar.data_vencimento;
                dtaVencimentoData.Checked = true;
            }

            if (this.financeiro_conta_pagar.valor_pagamento != null)
                txtValorPagamento.Text = string.Format("{0:n}", this.financeiro_conta_pagar.valor_pagamento.Value);
            else
                txtValorPagamento.Text = string.Empty;

            if (this.financeiro_conta_pagar.data_pagamento != null)
            {
                dtaDataPagamento.Value = this.financeiro_conta_pagar.data_pagamento.Value;
                dtaDataPagamento.Checked = true;
            }
        }

        private void btDuplicarConta_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagarDuplicar fContasPagarDuplicar = new cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagarDuplicar();
            fContasPagarDuplicar.SetContaPagar(financeiro_conta_pagar);

            if (fContasPagarDuplicar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btLancarConta_Click(object sender, EventArgs e)
        {
            if (financeiro_conta_pagar.data_pagamento != null && financeiro_conta_pagar.valor_pagamento != null && financeiro_conta_pagar.id_financeiro_conta_corrente != null && financeiro_conta_pagar.data_lancamento == null)
                if (!cFinanceiroLancamento.LancarContasPagar(ref this.financeiro_conta_pagar))
                    MessageBox.Show(null, "Não foi possivel lançar a conta a pagar!", "Erro ao lançar conta a pagar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.financeiro_conta_pagar.data_lancamento = Util.Util.GetDataServidor();
                    cFinanceiroContaPagar.FinanceiroContaPagarEditar(ref this.financeiro_conta_pagar);

                    TelaModoVisualizar();
                }

        }

        private void btEstornarLancamento_Click(object sender, EventArgs e)
        {
            if (financeiro_conta_pagar.data_pagamento != null && financeiro_conta_pagar.valor_pagamento != null && financeiro_conta_pagar.id_financeiro_conta_corrente != null && financeiro_conta_pagar.data_lancamento != null)
                if (MessageBox.Show(null, "Deseja estornar esta conta do lançamento bancario!", "Estornar conta a pagar.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    if (!cFinanceiroLancamento.EstornarContasPagar(ref this.financeiro_conta_pagar))
                        MessageBox.Show(null, "Não foi possivel estornar a conta a pagar!", "Erro ao estornar conta a pagar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.financeiro_conta_pagar.data_lancamento = null;
                        cFinanceiroContaPagar.FinanceiroContaPagarEditar(ref this.financeiro_conta_pagar);

                        TelaModoVisualizar();
                    }
        }

        private void btLancamento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamentoList fFinanceiroLancamentoList = new Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamentoList();

            fFinanceiroLancamentoList.Tag = this.Tag;
            fFinanceiroLancamentoList.id_contas_pagar = financeiro_conta_pagar.id_financeiro_conta_pagar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroLancamentoList.MdiParent = this;
                fFinanceiroLancamentoList.Show();
            }
            else
                fFinanceiroLancamentoList.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (txtFornecedor.Tag == null)
            {
                this.ValidarForm.SetToolTip(this.txtFornecedor, "Campo fornecedor é obrigatório.");
                txtFornecedor.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtFornecedor.BackColor = DefaultBackColor;

            if (txtPlanoContas.Tag == null)
            {
                this.ValidarForm.SetToolTip(this.txtPlanoContas, "Campo plano de contas é obrigatório.");
                txtPlanoContas.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtPlanoContas.BackColor = DefaultBackColor;

            if (txtFormaPagamento.Tag == null)
            {
                this.ValidarForm.SetToolTip(this.txtFormaPagamento, "Campo forma de pagamento é obrigatório.");
                txtFormaPagamento.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtFormaPagamento.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtValorVencimento.Text) || txtValorVencimento.Text == "0,00")
            {
                this.ValidarForm.SetToolTip(this.txtValorVencimento, "Campo valor de vencimento é obrigatório.");
                txtValorVencimento.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtValorVencimento.BackColor = DefaultBackColor;

            if (!dtaVencimentoData.Checked)
            {
                this.ValidarForm.SetToolTip(this.dtaVencimentoData, "Campo data de vencimento é obrigatório.");
                dtaVencimentoData.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                dtaVencimentoData.BackColor = DefaultBackColor;


            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        #region Botões de pesquisas
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

        private void btPlanoContas_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasLockup fPlanoContasLockup = new cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasLockup(Util.TipoPlanoConta.Saida);

            if (fPlanoContasLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var plano_conta = fPlanoContasLockup.GetPlanoContasSelecionado();
                
                cnFinanceiroPlanoConta cFinanceiroPlanoConta = new cnFinanceiroPlanoConta();
                
                txtPlanoContas.Tag = cFinanceiroPlanoConta.GetFinanceiroPlanoContasByID(plano_conta.id_financeiro_plano_conta);
                txtPlanoContas.Text = plano_conta.plano_conta + " - " + plano_conta.descricao;

                fPlanoContasLockup.Close();
                fPlanoContasLockup.Dispose();
            }
            else
            {
                txtPlanoContas.Tag = null;
                txtPlanoContas.Text = string.Empty;
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

        private void txtPlanoContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btPlanoContas_Click(sender, e);
            }
        }

        private void txtFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFornecedor_Click(sender, e);
            }
        }
        #endregion


    }
}
