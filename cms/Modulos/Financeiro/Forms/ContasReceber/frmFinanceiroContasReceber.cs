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

namespace cms.Modulos.Financeiro.Forms.ContasReceber
{
    public partial class frmFinanceiroContasReceber : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber cFinanceiroContaReceber = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber();
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cFinanceiroContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();
        cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento cFinanceiroLancamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroLancamento();

        private financeiro_conta_receber financeiro_conta_receber = new financeiro_conta_receber();

        public Util.Acao Acao { get; set; }
        public long id_contas_receber { get; set; }
        
        public frmFinanceiroContasReceber()
        {
            InitializeComponent();
        }

        private void frmFinanceiroContaReceber_Load(object sender, EventArgs e)
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
            this.financeiro_conta_receber = new financeiro_conta_receber();
            this.Text = "Contas a Receber - Cadastrar nova conta a receber";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtDataCadastro.ReadOnly = true;
            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataLancamento.ReadOnly = true;

            txtCodigo.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtPlanoContas.ReadOnly = true;
            txtContaCorrente.ReadOnly = true;
            txtFormaPagamento.ReadOnly = true;

            btCliente.Enabled = true;
            btPlanoContas.Enabled = true;
            btContaCorrente.Enabled = true;
            btFormaPagamento.Enabled = true;
            btGerarBoleto.Enabled = false;

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
            this.Text = "Contas a Receber - Editar cadastro da conta a receber";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            txtDataLancamento.ReadOnly = true;

            txtCodigo.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtPlanoContas.ReadOnly = true;
            txtContaCorrente.ReadOnly = true;
            txtFormaPagamento.ReadOnly = true;

            btCliente.Enabled = true;
            btPlanoContas.Enabled = true;
            btContaCorrente.Enabled = true;
            btFormaPagamento.Enabled = true;
            btGerarBoleto.Enabled = false;

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
            this.financeiro_conta_receber = cFinanceiroContaReceber.GetFinanceiroContaReceberByID(id_contas_receber);

            if (this.financeiro_conta_receber == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de conta a receber.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Contas a Receber - Visualizar cadastro de conta a receber";
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
            btGerarBoleto.Enabled = false;

            if (financeiro_conta_receber.id_financeiro_conta_corrente != null)
                if(financeiro_conta_receber.financeiro_conta_corrente.boleto)
                    if(txtFormaPagamento.Text == "Boleto")
                        btGerarBoleto.Enabled = true;

            if (financeiro_conta_receber.data_pagamento != null && financeiro_conta_receber.valor_pagamento != null && financeiro_conta_receber.id_financeiro_conta_corrente != null && financeiro_conta_receber.data_lancamento == null)
            {
                btLancarConta.Enabled = true;
                btEstornarLancamento.Enabled = false;
                btGerarBoleto.Enabled = false;
            }

            if (financeiro_conta_receber.data_pagamento != null && financeiro_conta_receber.valor_pagamento != null && financeiro_conta_receber.id_financeiro_conta_corrente != null && financeiro_conta_receber.data_lancamento != null)
            {
                btLancarConta.Enabled = false;
                btEstornarLancamento.Enabled = true;
                btLancamento.Enabled = true;

                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                btGerarBoleto.Enabled = false;
            }

            btFechar.Enabled = true;

            dtaDataPagamento.Enabled = false;
            dtaVencimentoData.Enabled = false;

            TravaFormControles(this.Controls);

            btCliente.Enabled = false;
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
                PreencherContaReceber();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    financeiro_conta_receber.data_cadastro = Util.Util.GetDataServidor();
                    if (cFinanceiroContaReceber.FinanceiroContaReceberCadastrar(ref financeiro_conta_receber))
                    {
                        this.id_contas_receber = financeiro_conta_receber.id_financeiro_conta_receber;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar a conta a receber!", "Erro ao cadastrar conta a receber.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroContaReceber.FinanceiroContaReceberEditar(ref financeiro_conta_receber))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o conta a receber!", "Erro ao cadastrar conta a receber.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o conta a receber: " + financeiro_conta_receber.id_financeiro_conta_receber + "!", "Cadastro de conta a receber.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                financeiro_conta_receber.excluido = true;
                if (cFinanceiroContaReceber.FinanceiroContaReceberEditar(ref financeiro_conta_receber))
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

        private void PreencherContaReceber()
        {            
            this.financeiro_conta_receber.data_cadastro = DateTime.Parse(txtDataCadastro.Text);

            this.financeiro_conta_receber.id_empresa = ctrlFilial.GetEmpresa().id_empresa;

            if (!string.IsNullOrEmpty(txtDataLancamento.Text))
                this.financeiro_conta_receber.data_lancamento = DateTime.Parse(txtDataLancamento.Text);

            if (txtCliente.Tag != null)
                this.financeiro_conta_receber.id_cliente = ((cliente)txtCliente.Tag).id_cliente;

            if (txtPlanoContas.Tag != null)
                this.financeiro_conta_receber.id_financeiro_plano_conta = ((financeiro_plano_conta)txtPlanoContas.Tag).id_financeiro_plano_conta;

            if (txtContaCorrente.Tag != null)
                this.financeiro_conta_receber.id_financeiro_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;

            if (txtFormaPagamento.Tag != null)
                this.financeiro_conta_receber.id_financeiro_forma_pagamento = ((financeiro_forma_pagamento)txtFormaPagamento.Tag).id_financeiro_forma_pagamento;

            this.financeiro_conta_receber.descricao = txtDescricao.Text;
            this.financeiro_conta_receber.observacao = txtObservacao.Text;
            this.financeiro_conta_receber.documento = txtDocumento.Text;

            if (!string.IsNullOrEmpty(txtValorVencimento.Text))
                this.financeiro_conta_receber.valor_vencimento = decimal.Parse(txtValorVencimento.Text);
            else
                this.financeiro_conta_receber.valor_vencimento = null;

            if (dtaVencimentoData.Checked)
                this.financeiro_conta_receber.data_vencimento = dtaVencimentoData.Value;

            if (!string.IsNullOrEmpty(txtValorPagamento.Text))
                this.financeiro_conta_receber.valor_pagamento = decimal.Parse(txtValorPagamento.Text);
            else
                this.financeiro_conta_receber.valor_pagamento = null;

            if (dtaDataPagamento.Checked)
                this.financeiro_conta_receber.data_pagamento = dtaDataPagamento.Value;
            else
                this.financeiro_conta_receber.data_pagamento = null;
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = this.financeiro_conta_receber.id_financeiro_conta_receber.ToString();

            txtDataCadastro.Text = this.financeiro_conta_receber.data_cadastro.ToString("dd/MM/yyyy");

            ctrlFilial.SetSelectedValue(this.financeiro_conta_receber.id_empresa.ToString());

            if (this.financeiro_conta_receber.data_lancamento != null)
                txtDataLancamento.Text = this.financeiro_conta_receber.data_lancamento.Value.ToString("dd/MM/yyyy");
            else
                txtDataLancamento.Text = string.Empty;

            //if (this.financeiro_conta_receber.id_cliente != null)
            //{
                cms.Modulos.Cliente.Cn.cnCliente cCliente = new cms.Modulos.Cliente.Cn.cnCliente();
                var cliente = cCliente.GetClienteByID(this.financeiro_conta_receber.id_cliente);
                
                txtCliente.Tag = cliente;
                txtCliente.Text = cliente.id_cliente + " - " + cliente.nome_fantasia;
            //}

            //if (this.financeiro_conta_receber.id_plano_conta != null)
            //{
                financeiro_plano_conta plano_conta = new financeiro_plano_conta();
                cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta cPlanoContas = new cms.Modulos.Financeiro.Cn.cnFinanceiroPlanoConta();
                if (this.financeiro_conta_receber.id_financeiro_plano_conta != null)
                {
                    plano_conta = cPlanoContas.GetFinanceiroPlanoContasByID(this.financeiro_conta_receber.id_financeiro_plano_conta.Value);
                    var vw_plano_conta = cPlanoContas.GetVWFinanceiroPlanoContasByID(this.financeiro_conta_receber.id_financeiro_plano_conta.Value);

                    txtPlanoContas.Tag = plano_conta;
                    txtPlanoContas.Text = vw_plano_conta.plano_conta + " - " + vw_plano_conta.descricao;
                }
            //}

            if (this.financeiro_conta_receber.id_financeiro_conta_corrente != null)
            {
                cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();
                var conta_corrente = cContaCorrente.GetFinanceiroContaCorrenteByID(this.financeiro_conta_receber.id_financeiro_conta_corrente.Value);

                txtContaCorrente.Tag = conta_corrente;
                txtContaCorrente.Text = conta_corrente.financeiro_banco.nome;
            }

            //if (this.financeiro_conta_receber.id_forma_pagamento != null)
            //{
                cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento cFormaPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroFormaPagamento();
                var forma_pagamento = cFormaPagamento.GetFinanceiroFormaPagamentoByID(this.financeiro_conta_receber.id_financeiro_forma_pagamento);
                
                txtFormaPagamento.Tag = forma_pagamento;
                txtFormaPagamento.Text = forma_pagamento.nome;
            //}

            txtDescricao.Text = this.financeiro_conta_receber.descricao;
            txtObservacao.Text = this.financeiro_conta_receber.observacao;
            txtDocumento.Text = this.financeiro_conta_receber.documento;

            if (this.financeiro_conta_receber.valor_vencimento != null)
                txtValorVencimento.Text = string.Format("{0:n}", this.financeiro_conta_receber.valor_vencimento.Value);
            else
                txtValorVencimento.Text = string.Empty;

            if (this.financeiro_conta_receber.data_vencimento != null)
            {
                dtaVencimentoData.Value = this.financeiro_conta_receber.data_vencimento;
                dtaVencimentoData.Checked = true;
            }

            if (this.financeiro_conta_receber.valor_pagamento != null)
                txtValorPagamento.Text = string.Format("{0:n}", this.financeiro_conta_receber.valor_pagamento.Value);
            else
                txtValorPagamento.Text = string.Empty;

            if (this.financeiro_conta_receber.data_pagamento != null)
            {
                dtaDataPagamento.Value = this.financeiro_conta_receber.data_pagamento.Value;
                dtaDataPagamento.Checked = true;
            }
        }
        
        private void btDuplicarConta_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceberDuplicar fContasReceberDuplicar = new cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceberDuplicar();
            fContasReceberDuplicar.SetContaReceber(financeiro_conta_receber);

            if (fContasReceberDuplicar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }

        }

        private void btLancarConta_Click(object sender, EventArgs e)
        {
            if (financeiro_conta_receber.data_pagamento != null && financeiro_conta_receber.valor_pagamento != null && financeiro_conta_receber.id_financeiro_conta_corrente != null && financeiro_conta_receber.data_lancamento == null)
                if (!cFinanceiroLancamento.LancarContasReceber(ref this.financeiro_conta_receber))
                    MessageBox.Show(null, "Não foi possivel lançar a conta a receber!", "Erro ao lançar conta a receber.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.financeiro_conta_receber.data_lancamento = Util.Util.GetDataServidor();
                    cFinanceiroContaReceber.FinanceiroContaReceberEditar(ref this.financeiro_conta_receber);
                    TelaModoVisualizar();
                }
        }

        private void btEstornarLancamento_Click(object sender, EventArgs e)
        {
            if (financeiro_conta_receber.data_pagamento != null && financeiro_conta_receber.valor_pagamento != null && financeiro_conta_receber.id_financeiro_conta_corrente != null && financeiro_conta_receber.data_lancamento != null)
                if (MessageBox.Show(null, "Deseja estornar esta conta do lançamento bancario!", "Estornar conta a receber.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    if (!cFinanceiroLancamento.EstornarContasReceber(ref this.financeiro_conta_receber))
                        MessageBox.Show(null, "Não foi possivel estornar a conta a receber!", "Erro ao estornar conta a receber.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.financeiro_conta_receber.data_lancamento = null;
                        cFinanceiroContaReceber.FinanceiroContaReceberEditar(ref this.financeiro_conta_receber);
                        TelaModoVisualizar();
                    }
        }
        
        private void btLancamento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamentoList fFinanceiroLancamentoList = new Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamentoList();

            fFinanceiroLancamentoList.Tag = this.Tag;
            fFinanceiroLancamentoList.id_contas_receber = financeiro_conta_receber.id_financeiro_conta_receber;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroLancamentoList.MdiParent = this;
                fFinanceiroLancamentoList.Show();
            }
            else
                fFinanceiroLancamentoList.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btGerarBoleto_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Boletos.frmBoletoVisualizar fBoletoVisualizar = new Boletos.frmBoletoVisualizar(financeiro_conta_receber.id_financeiro_conta_receber);

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fBoletoVisualizar.MdiParent = this;
                fBoletoVisualizar.Show();
            }
            else
                fBoletoVisualizar.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));


            //BoletoBancario boleto_bancario = new BoletoBancario();

            //Boleto boleto = cFinanceiroContaReceber.GetBoleto(financeiro_conta_receber);

            //boleto_bancario.Boleto = cFinanceiroContaReceber.GetBoleto(financeiro_conta_receber); 

            //boleto_bancario.Boleto.Banco = cFinanceiroContaCorrente.GetBanco(financeiro_conta_receber.financeiro_conta_corrente.id_conta_corrente);
            //boleto_bancario.Boleto.Carteira = financeiro_conta_receber.financeiro_conta_corrente.boleto_carteira;
            ////boleto_bancario.Cedente = cFinanceiroContaCorrente.GetCedente(financeiro_conta_receber.financeiro_conta_corrente.id_conta_corrente);

            //string html = boleto_bancario.MontaHtml();

            //return;
            //BoletoBancario boleto_bancario;

            //boleto_bancario = new BoletoBancario();

            //boleto_bancario.CodigoBanco = (short)financeiro_conta_receber.financeiro_conta_corrente.financeiro_banco.codigo;

            //Instrucao_Itau item1 = new Instrucao_Itau(9, 5);

            //Instrucao_Itau item2 = new Instrucao_Itau(81, 10);


            //Cedente cedente = new Cedente(financeiro_conta_receber.financeiro_conta_corrente.boleto_cnpj,
            //    financeiro_conta_receber.financeiro_conta_corrente.boleto_razao_social,
            //    financeiro_conta_receber.financeiro_conta_corrente.agencia,
            //    financeiro_conta_receber.financeiro_conta_corrente.agencia_digito,
            //    financeiro_conta_receber.financeiro_conta_corrente.conta,
            //    financeiro_conta_receber.financeiro_conta_corrente.conta_digito);

            ////Na carteira 198 o código do Cedente é a conta bancária
            //cedente.Codigo = (int)financeiro_conta_receber.financeiro_conta_corrente.boleto_codigo_cedente;

            //Boleto boleto = new Boleto(financeiro_conta_receber.data_vencimento,
            //    (double)financeiro_conta_receber.valor_vencimento, 
            //    financeiro_conta_receber.financeiro_conta_corrente.boleto_carteira,
            //    financeiro_conta_receber.id_contas_receber.ToString(), cedente,
            //    new EspecieDocumento(financeiro_conta_receber.financeiro_conta_corrente.financeiro_banco.codigo, 1));
            //boleto.NumeroDocumento = financeiro_conta_receber.id_contas_receber.ToString();
            
            //boleto.Sacado = new Sacado("000.000.000-00", "Fulano de Silva");
            //boleto.Sacado.Endereco.End = "SSS 154 Bloco J Casa 23";
            //boleto.Sacado.Endereco.Bairro = "Testando";
            //boleto.Sacado.Endereco.Cidade = "Testelândia";
            //boleto.Sacado.Endereco.CEP = "70000000";
            //boleto.Sacado.Endereco.UF = "DF";

            //item2.Descricao += " " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            //boleto.Instrucoes.Add(item1);
            //boleto.Instrucoes.Add(item2);

            //if (boleto.ValorDesconto == 0)
            //{
            //    Instrucao_Itau item3 = new Instrucao_Itau(999, 1);
            //    item3.Descricao += ("1,00 por dia de antecipação.");
            //    boleto.Instrucoes.Add(item3);
            //}

            //boleto_bancario.Boleto = boleto;
            //boleto_bancario.Boleto.Valida();


         
        }        

        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (txtCliente.Tag == null)
            {
                this.ValidarForm.SetToolTip(this.txtCliente, "Campo cliente é obrigatório.");
                txtCliente.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtCliente.BackColor = DefaultBackColor;

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
            cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasLockup fPlanoContasLockup = new cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasLockup(Util.TipoPlanoConta.Entrada);

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

        #endregion

    }
}
