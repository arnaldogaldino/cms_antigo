using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento
{
    public partial class frmFinanceiroFormaPagamento : cms.Modulos.Util.WindowBase
    {        
        cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento cFinanceiroFormaPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento();
        cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta cFinanceiroPlanoContas = new cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta();

        private financeiro_forma_pagamento financeiro_forma_pagamento = new financeiro_forma_pagamento();

        public Util.Acao Acao { get; set; }
        public long id_forma_pagamento { get; set; }
        
        public frmFinanceiroFormaPagamento()
        {
            InitializeComponent();
        }

        private void frmFinanceiroFormaPagamento_Load(object sender, EventArgs e)
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
            this.financeiro_forma_pagamento = new financeiro_forma_pagamento();
            this.Text = "Forma de Pagamento - Cadastrar nova forma de pagamento";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtDataCadastro.ReadOnly = true;
            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            
            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Forma de Pagamento - Editar cadastro da forma de pagamento";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.financeiro_forma_pagamento = cFinanceiroFormaPagamento.GetFinanceiroFormaPagamentoByID(id_forma_pagamento);

            if (this.financeiro_forma_pagamento == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de forma de pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Forma de Pagamento - Visualizar cadastro de forma de pagamento";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);
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
                PreencherNCM();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    financeiro_forma_pagamento.data_cadastro = Util.Util.GetDataServidor();
                    if (cFinanceiroFormaPagamento.FinanceiroFormaPagamentoCadastrar(ref financeiro_forma_pagamento))
                    {
                        this.id_forma_pagamento = financeiro_forma_pagamento.id_financeiro_forma_pagamento;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar a forma de pagamento!", "Erro ao cadastrar forma de pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroFormaPagamento.FinanceiroFormaPagamentoEditar(ref financeiro_forma_pagamento))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o forma de pagamento!", "Erro ao cadastrar forma de pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o forma de pagamento: " + financeiro_forma_pagamento.nome + "!", "Cadastro de forma de pagamento.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                financeiro_forma_pagamento.excluido = true;
                if (cFinanceiroFormaPagamento.FinanceiroFormaPagamentoEditar(ref financeiro_forma_pagamento))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            TelaModoCadastrarNovo();
        }

        private void PreencherNCM()
        {
            this.financeiro_forma_pagamento.data_cadastro = DateTime.Parse(txtDataCadastro.Text);
            this.financeiro_forma_pagamento.id_financeiro_plano_conta = ((vw_financeiro_plano_conta)txtPlanoContas.Tag).id_financeiro_plano_conta;
            this.financeiro_forma_pagamento.nome = txtNome.Text;
            this.financeiro_forma_pagamento.descricao = txtDescricao.Text;
            this.financeiro_forma_pagamento.taxa_admin = decimal.Parse(txtTaxaAdmin.Text);
        }
        private void PreencherCampos()
        {
            txtDataCadastro.Text = this.financeiro_forma_pagamento.data_cadastro.ToString("dd/MM/yyyy");
            txtPlanoContas.Tag = cFinanceiroPlanoContas.GetVWFinanceiroPlanoContasByID(this.financeiro_forma_pagamento.id_financeiro_plano_conta);
            
            if(txtPlanoContas.Tag != null)
                txtPlanoContas.Text = ((vw_financeiro_plano_conta)txtPlanoContas.Tag).plano_conta + " - " + ((vw_financeiro_plano_conta)txtPlanoContas.Tag).descricao;
            
            txtNome.Text = this.financeiro_forma_pagamento.nome;
            txtDescricao.Text = this.financeiro_forma_pagamento.descricao;
            txtTaxaAdmin.Text = this.financeiro_forma_pagamento.taxa_admin.ToString("N2");
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;
            
            if (txtPlanoContas.Text == "")
            {
                this.ValidarForm.SetToolTip(this.txtPlanoContas, "Campo plano de contas é obrigatório.");
                txtPlanoContas.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtPlanoContas.BackColor = DefaultBackColor;
            
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                this.ValidarForm.SetToolTip(this.txtNome, "Campo nome é obrigatório.");
                erro = true;
            }
            else
                txtNome.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição é obrigatório.");
                erro = true;
            }
            else
                txtDescricao.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        private void btPlanoContas_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasLockup fPlanoContasLockup = new cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasLockup(Util.TipoPlanoConta.Entrada);

            if (fPlanoContasLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var plano_conta = fPlanoContasLockup.GetPlanoContasSelecionado();

                txtPlanoContas.Tag = plano_conta;
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
        private void txtPlanoContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btPlanoContas_Click(sender, e);
            }
        }
    }
}
