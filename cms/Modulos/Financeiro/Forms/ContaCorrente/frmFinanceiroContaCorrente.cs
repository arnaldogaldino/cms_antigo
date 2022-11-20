using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using BoletoNet;

namespace cms.Modulos.Financeiro.Forms.ContaCorrente
{
    public partial class frmFinanceiroContaCorrente : cms.Modulos.Util.WindowBase
    {        
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cFinanceiroContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();
        
        private financeiro_conta_corrente financeiro_conta_corrente = new financeiro_conta_corrente();

        public Util.Acao Acao { get; set; }
        public long id_conta_corrente { get; set; }
        
        public frmFinanceiroContaCorrente()
        {
            InitializeComponent();
            cbBanco.DataSource = cFinanceiroContaCorrente.GetBanco();
            cbBanco.Refresh();
        }

        private void frmFinanceiroContaCorrente_Load(object sender, EventArgs e)
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
            this.financeiro_conta_corrente = new financeiro_conta_corrente();
            this.Text = "Conta Corrente - Cadastrar nova conta corrente";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtDataCadastro.ReadOnly = true;
            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            
            cbBanco.ResetText();

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Conta Corrente - Editar cadastro da conta corrente";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            
            rbCnab240.Enabled = true;
            rbCnab400.Enabled = true;
            rbCnabNenhum.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.financeiro_conta_corrente = cFinanceiroContaCorrente.GetFinanceiroContaCorrenteByID(id_conta_corrente);

            if (this.financeiro_conta_corrente == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de conta corrente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Conta Corrente - Visualizar cadastro de conta corrente";
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
                PreencherContaCorrente();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    financeiro_conta_corrente.data_cadastro = Util.Util.GetDataServidor();
                    if (cFinanceiroContaCorrente.FinanceiroContaCorrenteCadastrar(ref financeiro_conta_corrente))
                    {
                        this.id_conta_corrente = financeiro_conta_corrente.id_financeiro_conta_corrente;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar a conta corrente!", "Erro ao cadastrar conta corrente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroContaCorrente.FinanceiroContaCorrenteEditar(ref financeiro_conta_corrente))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o conta corrente!", "Erro ao cadastrar conta corrente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o conta corrente: " + financeiro_conta_corrente.financeiro_banco.nome + "!", "Cadastro de conta corrente.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                financeiro_conta_corrente.excluido = true;
                if (cFinanceiroContaCorrente.FinanceiroContaCorrenteEditar(ref financeiro_conta_corrente))
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

        private void PreencherContaCorrente()
        {
            this.financeiro_conta_corrente.id_empresa = ctrlFilial.GetEmpresa().id_empresa;

            this.financeiro_conta_corrente.id_financeiro_banco = long.Parse(cbBanco.SelectedValue.ToString());
            this.financeiro_conta_corrente.agencia = txtAgencia.Text;
            this.financeiro_conta_corrente.agencia_digito = txtAgenciaDigito.Text;
            this.financeiro_conta_corrente.conta = txtConta.Text;
            this.financeiro_conta_corrente.conta_digito = txtContaDigito.Text;
            this.financeiro_conta_corrente.gerente = txtGerente.Text;
            this.financeiro_conta_corrente.telefone1 = txtTelefone1.Text;
            this.financeiro_conta_corrente.telefone2 = txtTelefone2.Text;
            this.financeiro_conta_corrente.telefone3 = txtTelefone3.Text;
            this.financeiro_conta_corrente.telefone4 = txtTelefone4.Text;
            this.financeiro_conta_corrente.data_cadastro = DateTime.Parse(txtDataCadastro.Text);
            this.financeiro_conta_corrente.boleto = chkBoleto.Checked;
            this.financeiro_conta_corrente.boleto_razao_social = txtNomeRazaoSocial.Text;
            this.financeiro_conta_corrente.boleto_cnpj = txtCpfCnpj.Text;

            if (!string.IsNullOrEmpty(txtCodigoCedente.Text))
                this.financeiro_conta_corrente.boleto_codigo_cedente = int.Parse(txtCodigoCedente.Text);
            else
                this.financeiro_conta_corrente.boleto_codigo_cedente = null;

            this.financeiro_conta_corrente.boleto_carteira = txtCarteira.Text;
            this.financeiro_conta_corrente.boleto_instrucao1 = txtInstrucaoLinha1.Text;
            this.financeiro_conta_corrente.boleto_instrucao2 = txtInstrucaoLinha2.Text;
            this.financeiro_conta_corrente.boleto_instrucao3 = txtInstrucaoLinha3.Text;

            if (rbCnab400.Checked)
                this.financeiro_conta_corrente.boleto_cnab = 400;

            if (rbCnab240.Checked)
                this.financeiro_conta_corrente.boleto_cnab = 240;

            if (rbCnabNenhum.Checked)
                this.financeiro_conta_corrente.boleto_cnab = null;
            
        }

        private void PreencherCampos()
        {
            ctrlFilial.SetSelectedValue(this.financeiro_conta_corrente.id_empresa.ToString());

            cbBanco.SelectedValue = this.financeiro_conta_corrente.id_financeiro_banco;
            txtAgencia.Text = this.financeiro_conta_corrente.agencia;
            txtAgenciaDigito.Text = this.financeiro_conta_corrente.agencia_digito;
            txtConta.Text = this.financeiro_conta_corrente.conta;
            txtContaDigito.Text = this.financeiro_conta_corrente.conta_digito;
            txtGerente.Text = this.financeiro_conta_corrente.gerente;

            txtTelefone1.Text = this.financeiro_conta_corrente.telefone1;
            txtTelefone2.Text = this.financeiro_conta_corrente.telefone2;
            txtTelefone3.Text = this.financeiro_conta_corrente.telefone3;
            txtTelefone4.Text = this.financeiro_conta_corrente.telefone4;

            txtDataCadastro.Text = this.financeiro_conta_corrente.data_cadastro.ToString("dd/MM/yyyy");

            chkBoleto.Checked = this.financeiro_conta_corrente.boleto;
            txtNomeRazaoSocial.Text = this.financeiro_conta_corrente.boleto_razao_social;
            txtCpfCnpj.Text = this.financeiro_conta_corrente.boleto_cnpj;

            if (this.financeiro_conta_corrente.boleto_codigo_cedente != null)
                txtCodigoCedente.Text = this.financeiro_conta_corrente.boleto_codigo_cedente.Value.ToString();

            txtCarteira.Text = this.financeiro_conta_corrente.boleto_carteira;
            txtInstrucaoLinha1.Text = this.financeiro_conta_corrente.boleto_instrucao1;
            txtInstrucaoLinha2.Text = this.financeiro_conta_corrente.boleto_instrucao2;
            txtInstrucaoLinha3.Text = this.financeiro_conta_corrente.boleto_instrucao3;

            if (this.financeiro_conta_corrente.boleto_cnab == 400)
                rbCnab400.Checked = true;

            if (this.financeiro_conta_corrente.boleto_cnab == 240)
                rbCnab240.Checked = true;

            if (this.financeiro_conta_corrente.boleto_cnab == null)
                rbCnabNenhum.Checked = true;
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (cbBanco.SelectedValue.ToString() == "")
            {
                this.ValidarForm.SetToolTip(this.cbBanco, "Campo banco é obrigatório.");
                cbBanco.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                cbBanco.BackColor = DefaultBackColor;  

            if (string.IsNullOrEmpty(txtAgencia.Text))
            {
                this.ValidarForm.SetToolTip(this.txtAgencia, "Campo nome é obrigatório.");
                erro = true;
            }
            else
                txtAgencia.BackColor = DefaultBackColor;

            #region # Valida carteira #
            //if ((cbBanco.SelectedValue.ToString() != "") && !string.IsNullOrEmpty(txtCarteira.Text))
            //{
            //    string carteiras = string.Empty;
            //    bool exist = false;
            //    financeiro_banco banco = (financeiro_banco)cbBanco.SelectedItem;

            //    // 001 - Banco do Brasil
            //    if (banco.codigo == 1)
            //    {
            //        foreach (BoletoNet.EnumCarteiras_BancoBrasil i in Enum.GetValues(typeof(BoletoNet.EnumCarteiras_BancoBrasil)))
            //        {
            //            carteiras += ((int)i).ToString() + ",";
            //            if ((int)i == int.Parse(txtCarteira.Text))
            //                exist = true;
            //        }
            //    }
            //    // 356 - BankBoston
            //    else if (banco.codigo == 356)
            //    {
            //        foreach (BoletoNet.EnumCarteiras_BankBoston i in Enum.GetValues(typeof(BoletoNet.EnumCarteiras_BankBoston)))
            //        {
            //            if ((int)i == int.Parse(txtCarteira.Text))
            //                exist = true;
            //        }
            //    }
            //    // 104 - Caixa
            //    else if (banco.codigo == 104)
            //    {
            //        foreach (BoletoNet.EnumCarteiras_Caixa i in Enum.GetValues(typeof(BoletoNet.EnumCarteiras_Caixa)))
            //        {
            //            carteiras += ((int)i).ToString() + ",";
            //            if ((int)i == int.Parse(txtCarteira.Text))
            //                exist = true;
            //        }
            //    }
            //    // 341 - Itaú
            //    else if (banco.codigo == 341)
            //    {
            //        foreach (BoletoNet.EnumCarteiras_Itau i in Enum.GetValues(typeof(BoletoNet.EnumCarteiras_Itau)))
            //        {
            //            carteiras += ((int)i).ToString() + ",";
            //            if ((int)i == int.Parse(txtCarteira.Text))
            //                exist = true;
            //        }
            //    }
            //    // 033 - Santander
            //    else if (banco.codigo == 33)
            //    {
            //        foreach (BoletoNet.EnumCarteiras_Santander i in Enum.GetValues(typeof(BoletoNet.EnumCarteiras_Santander)))
            //        {
            //            carteiras += ((int)i).ToString() + ",";
            //            if ((int)i == int.Parse(txtCarteira.Text))
            //                exist = true;
            //        }
            //    }                

            //    if (!exist)
            //    {
            //        this.ValidarForm.SetToolTip(this.txtCarteira, "Campo carteira inválida. \n Carteiras disponíveis: " + carteiras);
            //        txtCarteira.BackColor = CorCampoInvalido;
            //        erro = true;
            //    }
            //    else
            //        txtCarteira.BackColor = DefaultBackColor;
            //}            
            #endregion

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        private void chkBoleto_CheckedChanged(object sender, EventArgs e)
        {
            long id_financeiro_banco = 0;
            if(cbBanco.SelectedValue.ToString() != "")
                id_financeiro_banco = long.Parse(cbBanco.SelectedValue.ToString());

            financeiro_banco banco = cFinanceiroContaCorrente.GetFinanceiroBancoByID(id_financeiro_banco);
            if (banco.boleto == false)
            {
                gbBoleto.Visible = false;
                chkBoleto.Checked = false;
            }
            else
            {
                gbBoleto.Visible = true;                
            }
        }

        private void cbBanco_SelectedValueChanged(object sender, EventArgs e)
        {
            long id_financeiro_banco = 0;
            if (cbBanco.SelectedValue.ToString() != "")
                id_financeiro_banco = long.Parse(cbBanco.SelectedValue.ToString());

            financeiro_banco banco = cFinanceiroContaCorrente.GetFinanceiroBancoByID(id_financeiro_banco);
            chkBoleto.Checked = false;
            if (banco.boleto == false)
            {
                gbBoleto.Visible = false;                
            }
            else
            {
                gbBoleto.Visible = true;
            }
        }

    }
}
