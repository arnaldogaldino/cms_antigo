using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.LancamentoBancario
{
    public partial class frmFinanceiroLancamento : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento cFinanceiroLancamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento();

        private financeiro_lancamento financeiro_lancamento = new financeiro_lancamento();

        public Util.Acao Acao { get; set; }
        public long id_lancamento { get; set; }

        private void frmFinanceiroLancamento_Load(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Cadastrar)
                this.TelaModoCadastrarNovo();
            else if (this.Acao == Util.Acao.Editar)
                this.TelaModoEditar();
            else if (this.Acao == Util.Acao.Visualizar)
                this.TelaModoVisualizar();
        }

        public frmFinanceiroLancamento()
        {
            InitializeComponent();
        }
        
        #region Modo de Tela
        private void TelaModoCadastrarNovo()
        {
            this.financeiro_lancamento = new financeiro_lancamento();
            this.Text = "Lançamento - Cadastrar novo lançamento bancario";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtDataLancamento.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            dtaDataConciliado.Enabled = true;
            txtContaCorrente.ReadOnly = true;

            txtContaCorrente.ReadOnly = true;
            txtDataLancamento.ReadOnly = true;
            txtCodigo.ReadOnly = true;

            txtValorCredito.Text = "0,00";
            txtValorDebito.Text = "0,00";

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;

            btContaPagar.Enabled = false;
            btContaReceber.Enabled = false;

            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Lançamento - Editar cadastro de lançamento bancario";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            
            dtaDataConciliado.Enabled = true;
            txtContaCorrente.ReadOnly = true;
            txtDataLancamento.ReadOnly = true;
            txtCodigo.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;

            btContaPagar.Enabled = false;
            btContaReceber.Enabled = false;

            btFechar.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.financeiro_lancamento = cFinanceiroLancamento.GetFinanceiroLancamentoByID(id_lancamento);

            if (this.financeiro_lancamento == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de lançamento bancario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Lançamento - Visualizar cadastro de lançamento bancario";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;

            btContaPagar.Enabled = false;
            btContaReceber.Enabled = false;

            btFechar.Enabled = true;

            if (financeiro_lancamento.id_financeiro_conta_pagar != null)
            {
                btContaPagar.Enabled = true;
                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                ctrlFilial.Enabled = false;
            }
            if (financeiro_lancamento.id_financeiro_conta_receber != null)
            {
                btContaReceber.Enabled = true;
                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                ctrlFilial.Enabled = false;
            }

            TravaFormControles(this.Controls);
            dtaDataConciliado.Enabled = false;
            txtContaCorrente.ReadOnly = true;
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
                PreencherLancamento();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    financeiro_lancamento.data_lancamento = Util.Util.GetDataServidor();
                    if (cFinanceiroLancamento.FinanceiroLancamentoCadastrar(ref financeiro_lancamento))
                    {
                        this.id_lancamento = financeiro_lancamento.id_financeiro_lancamento;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o lançamento bancario!", "Erro ao cadastrar lançamento bancario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroLancamento.FinanceiroLancamentoEditar(ref financeiro_lancamento))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o lançamento!", "Erro ao cadastrar lançamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Lancamento Bancario: " + financeiro_lancamento.id_financeiro_lancamento + "!", "Cadastro de Lançamento Bancario.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cFinanceiroLancamento.FinanceiroLancamentoExcluir(financeiro_lancamento))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            TelaModoCadastrarNovo();
        }
        
        private void btContaPagar_Click(object sender, EventArgs e)
        {
            financeiro_conta_pagar ContasPagar = new financeiro_conta_pagar();
            cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar cFinanceiroContaPagar = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar();
     
            try
            {
                ContasPagar = cFinanceiroContaPagar.GetFinanceiroContaPagarByID((long)financeiro_lancamento.id_financeiro_conta_pagar);
            }
            catch { }

            cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagar fContaPagar = new cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagar();

            fContaPagar.id_contas_pagar = ContasPagar.id_financeiro_conta_pagar;
            fContaPagar.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContaPagar.MdiParent = this;
                fContaPagar.Show();
            }
            else
                fContaPagar.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btContaReceber_Click(object sender, EventArgs e)
        {
            financeiro_conta_receber ContasReceber = new financeiro_conta_receber();
            cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber cFinanceiroContaReceber = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber();

            try
            {
                ContasReceber = cFinanceiroContaReceber.GetFinanceiroContaReceberByID((long)financeiro_lancamento.id_financeiro_conta_receber);
            }
            catch { }

            cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceber fContaReceber = new cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceber();

            fContaReceber.id_contas_receber = ContasReceber.id_financeiro_conta_receber;
            fContaReceber.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContaReceber.MdiParent = this;
                fContaReceber.Show();
            }
            else
                fContaReceber.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }
        
        private void PreencherLancamento()
        {
            financeiro_lancamento.id_financeiro_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;
            financeiro_lancamento.id_empresa = ctrlFilial.GetEmpresa().id_empresa;

            if (dtaDataConciliado.Checked)
                financeiro_lancamento.data_conciliado = dtaDataConciliado.Value;

            financeiro_lancamento.descricao = txtDescricao.Text;
            financeiro_lancamento.valor_debito = decimal.Parse(txtValorDebito.Text);
            financeiro_lancamento.valor_credito = decimal.Parse(txtValorCredito.Text);
        }

        private void PreencherCampos()
        {
            cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();
            var conta_corrente = cContaCorrente.GetFinanceiroContaCorrenteByID(this.financeiro_lancamento.id_financeiro_conta_corrente);

            ctrlFilial.SetSelectedValue(financeiro_lancamento.id_empresa.ToString());

            txtCodigo.Text = financeiro_lancamento.id_financeiro_lancamento.ToString();
            txtDataLancamento.Text = financeiro_lancamento.data_lancamento.ToString("dd/MM/yyyy");

            txtContaCorrente.Tag = conta_corrente;
            txtContaCorrente.Text = conta_corrente.financeiro_banco.nome;

            dtaDataConciliado.Value = financeiro_lancamento.data_conciliado;

            txtDescricao.Text = financeiro_lancamento.descricao;
            txtValorDebito.Text = financeiro_lancamento.valor_debito.ToString("n2");
            txtValorCredito.Text = financeiro_lancamento.valor_credito.ToString("n2");
        }
        #endregion

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

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;
            
            if (txtContaCorrente.Tag == null)
            {
                txtDescricao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtContaCorrente, "Campo conta corrente é obrigatório.");
                erro = true;
            }

            if(!dtaDataConciliado.Checked)
            {
                dtaDataConciliado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.dtaDataConciliado, "Campo data de conciliado é obrigatório.");
                erro = true;
            }

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                erro = true;
                txtDescricao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição é obrigatório.");
            }
            else
                txtDescricao.BackColor = DefaultBackColor;

            if (txtValorCredito.Text == "0,00" && txtValorDebito.Text == "0,00")
            {
                erro = true;
                txtValorCredito.BackColor = CorCampoInvalido;
                txtValorDebito.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtValorCredito, "Campo crédito ou débito é obrigatório.");
                this.ValidarForm.SetToolTip(this.txtValorDebito, "Campo crédito ou débito é obrigatório.");
            }
            else
            {
                txtValorCredito.BackColor = DefaultBackColor;
                txtValorDebito.BackColor = DefaultBackColor;
            }

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

    }
}
