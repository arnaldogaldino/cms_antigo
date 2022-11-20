using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas
{
    public partial class frmFinanceiroPlanoContas : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta cFinanceiroPlanoContas = new cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta();

        private financeiro_plano_conta financeiro_plano_conta = new financeiro_plano_conta();
        
        public Util.Acao Acao { get; set; }
        public long id_financeiro_plano_conta { get; set; }

        public frmFinanceiroPlanoContas()
        {
            InitializeComponent();
        }
        
        private void frmFinanceiroPlanoContas_Load(object sender, EventArgs e)
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
            this.financeiro_plano_conta = new financeiro_plano_conta();
            this.Text = "Plano de Contas - Cadastrar novo plano de contas";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Plano de Contas - Editar cadastro de plano de contas";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.financeiro_plano_conta = cFinanceiroPlanoContas.GetFinanceiroPlanoContasByID(id_financeiro_plano_conta);

            if (this.financeiro_plano_conta == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de plano de contas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Plano de Contas - Visualizar cadastro de plano de contas";
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
                PreencherPlanoContas();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cFinanceiroPlanoContas.FinanceiroPlanoContasCadastrar(ref financeiro_plano_conta))
                    {
                        this.id_financeiro_plano_conta = financeiro_plano_conta.id_financeiro_plano_conta;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o plano de contas!", "Erro ao cadastrar plano de contas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroPlanoContas.FinanceiroPlanoContasEditar(ref financeiro_plano_conta))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o plano de contas!", "Erro ao cadastrar plano de contas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o plano de contas: " + financeiro_plano_conta.plano_conta + "!", "Cadastro de plano de contas.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                financeiro_plano_conta.excluido = true;
                if (cFinanceiroPlanoContas.FinanceiroPlanoContasEditar(ref financeiro_plano_conta))
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

        private void PreencherPlanoContas()
        {
            financeiro_plano_conta.plano_conta = txtPlanoContas.Text;
            financeiro_plano_conta.descricao = txtDescricao.Text;
        }
        private void PreencherCampos()
        {
            txtPlanoContas.Text = this.financeiro_plano_conta.plano_conta;
            txtDescricao.Text = this.financeiro_plano_conta.descricao;
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (string.IsNullOrEmpty(txtPlanoContas.Text))
            {
                this.ValidarForm.SetToolTip(this.txtPlanoContas, "Campo plano de contas é obrigatório.");
                txtPlanoContas.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtPlanoContas.BackColor = DefaultBackColor;

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


    }

}


