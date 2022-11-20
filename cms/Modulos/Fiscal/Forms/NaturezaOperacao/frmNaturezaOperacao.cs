using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Fiscal.Cn;

namespace cms.Modulos.Fiscal.Forms.NaturezaOperacao
{
    public partial class frmNaturezaOperacao : cms.Modulos.Util.WindowBase
    {
        private cnFiscalNaturezaOperacao cFiscalNaturezaOperacao = new cnFiscalNaturezaOperacao();

        private fiscal_natureza_operacao natureza_operacao = new fiscal_natureza_operacao();

        public Util.Acao Acao { get; set; }
        public long id_fiscal_natureza_operacao { get; set; }
        
        public frmNaturezaOperacao()
        {
            InitializeComponent();
        }
        
        private void frmNaturezaOperacao_Load(object sender, EventArgs e)
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
            this.natureza_operacao = new fiscal_natureza_operacao();
            this.Text = "Natureza da Operação - Cadastrar nova natureza da operação";
            this.natureza_operacao.data_cadastro = Util.Util.GetDataServidor();

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");

            rbEntrada.Enabled = true;
            rbSaida.Enabled = true;

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            txtCFOPforaEstado.ReadOnly = true;
            txtCFOPnoEstado.ReadOnly = true;
            txtCFOPcomCSTforaEstado.ReadOnly = true;
            txtCFOPcomCST.ReadOnly = true;
            txtCFOPAux2.ReadOnly = true;
            txtCFOPAux1.ReadOnly = true;

            txtCFOPcomIEIsento.ReadOnly = true;
            txtCFOPcomIEISENTOforaEstado.ReadOnly = true;

            btCFOPAux1.Enabled = true;
            btCFOPAux2.Enabled = true;
            btCFOPcomCST.Enabled = true;
            btCFOPcomCSTforaEstado.Enabled = true;
            btCFOPforaEstado.Enabled = true;
            btCFOPnoEstado.Enabled = true;
            
            btCFOPcomIEIsento.Enabled = true;
            btCFOPcomIEISENTOforaEstado.Enabled = true;

            btCodigoNaturezaOperacao.Enabled = true;
            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Natureza da Operação - Editar natureza da operação";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);

            rbEntrada.Enabled = true;
            rbSaida.Enabled = true;

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            txtCFOPforaEstado.ReadOnly = true;
            txtCFOPnoEstado.ReadOnly = true;
            txtCFOPcomCSTforaEstado.ReadOnly = true;
            txtCFOPcomCST.ReadOnly = true;
            txtCFOPAux2.ReadOnly = true;
            txtCFOPAux1.ReadOnly = true;
            
            txtCFOPcomIEIsento.ReadOnly = true;
            txtCFOPcomIEISENTOforaEstado.ReadOnly = true;

            btCFOPcomIEIsento.Enabled = true;
            btCFOPcomIEISENTOforaEstado.Enabled = true;

            btCFOPAux1.Enabled = true;
            btCFOPAux2.Enabled = true;
            btCFOPcomCST.Enabled = true;
            btCFOPcomCSTforaEstado.Enabled = true;
            btCFOPforaEstado.Enabled = true;
            btCFOPnoEstado.Enabled = true;
            btCodigoNaturezaOperacao.Enabled = true;



            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

        }
        private void TelaModoVisualizar()
        {
            this.natureza_operacao = cFiscalNaturezaOperacao.GetFiscalNaturezaOperacaoById(id_fiscal_natureza_operacao);
            if (this.natureza_operacao == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de Natureza da Operação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Natureza da Operação - Visualizar cadastro da Natureza da Operação";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            rbEntrada.Enabled = false;
            rbSaida.Enabled = false;

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);

            btCFOPcomIEIsento.Enabled = false;
            btCFOPcomIEISENTOforaEstado.Enabled = false;

            btCFOPAux1.Enabled = false;
            btCFOPAux2.Enabled = false;
            btCFOPcomCST.Enabled = false;
            btCFOPcomCSTforaEstado.Enabled = false;
            btCFOPforaEstado.Enabled = false;
            btCFOPnoEstado.Enabled = false;
            btCodigoNaturezaOperacao.Enabled = false;

        }
        #endregion

        #region Menu Ação
        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoCadastrarNovo();
        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoEditar();
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a natureza da operação: " + natureza_operacao.id_fiscal_natureza_operacao.ToString() + "!", "Cadastro de natureza da operação.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                natureza_operacao.excluido = true;
                if (cFiscalNaturezaOperacao.FiscalNaturezaOperacaoEditar(ref natureza_operacao))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {

            ValidForm();
            if (FormIsValid)
                PreencherNaturezaOperacao();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    natureza_operacao.data_cadastro = Util.Util.GetDataServidor();
                    if (cFiscalNaturezaOperacao.FiscalNaturezaOperacaoCadastrar(ref natureza_operacao))
                    {
                        this.id_fiscal_natureza_operacao = natureza_operacao.id_fiscal_natureza_operacao;
                        txtCodigo.Text = natureza_operacao.id_fiscal_natureza_operacao.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar a natureza da operação!", "Erro ao cadastrar natureza da operação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFiscalNaturezaOperacao.FiscalNaturezaOperacaoEditar(ref natureza_operacao))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar a natureza da operação!", "Erro ao cadastrar natureza da operação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Editar)
                this.TelaModoVisualizar();
        }
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreencherNaturezaOperacao()
        {
            if (rbEntrada.Checked)
                natureza_operacao.tipo = "Entrada";
            else if (rbSaida.Checked)
                natureza_operacao.tipo = "Saida";

            if (!string.IsNullOrEmpty(txtCodigo.Text))
                natureza_operacao.id_fiscal_natureza_operacao = long.Parse(txtCodigo.Text);

            natureza_operacao.descricao = txtDescricao.Text;
                        
            this.natureza_operacao.atualiza_valores_compra = chkAtualizaValoresCompra.Checked;
            this.natureza_operacao.calcular_custo_medio = chkCalculaCusto.Checked;
            this.natureza_operacao.devolucao = chkDevolucao.Checked;
            this.natureza_operacao.gera_titulo_financeiro = chkGeraTitulo.Checked;
            this.natureza_operacao.gerenciar_comissao = chkGerenciaComissao.Checked;
            this.natureza_operacao.movimenta_estoque = chkMovimentaEstoque.Checked;
            this.natureza_operacao.verificar_tab_compra = chkTabelaCompra.Checked;
            this.natureza_operacao.venda = chkVenda.Checked;
            
            if (txtCFOPAux1.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_aux1 = ((fiscal_cfop)txtCFOPAux1.Tag).id_fiscal_cfop;

            if (txtCFOPAux2.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_aux2 = ((fiscal_cfop)txtCFOPAux2.Tag).id_fiscal_cfop;

            if (txtCFOPcomCST.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_comcst = ((fiscal_cfop)txtCFOPcomCST.Tag).id_fiscal_cfop;

            if (txtCFOPcomCSTforaEstado.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_comcst_forauf = ((fiscal_cfop)txtCFOPcomCSTforaEstado.Tag).id_fiscal_cfop;

            if (txtCFOPforaEstado.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_forauf = ((fiscal_cfop)txtCFOPforaEstado.Tag).id_fiscal_cfop;

            if (txtCFOPnoEstado.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_nouf = ((fiscal_cfop)txtCFOPnoEstado.Tag).id_fiscal_cfop;

            if (txtCFOPcomIEIsento.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_ie_isento_nouf = ((fiscal_cfop)txtCFOPcomIEIsento.Tag).id_fiscal_cfop;

            if (txtCFOPcomIEIsento.Tag != null)
                this.natureza_operacao.id_fiscal_cfop_ie_isento_nofora = ((fiscal_cfop)txtCFOPcomIEISENTOforaEstado.Tag).id_fiscal_cfop;

        }

        private void PreencherCampos()
        {
            txtCodigo.Text = this.natureza_operacao.id_fiscal_natureza_operacao.ToString();
            txtDataCadastro.Text = this.natureza_operacao.data_cadastro.ToString("dd/MM/yyyy");

            if (this.natureza_operacao.tipo == "Entrada")
                rbEntrada.Checked = true;
            else if (this.natureza_operacao.tipo == "Saida")
                rbSaida.Checked = true;

            txtDescricao.Text = this.natureza_operacao.descricao;
            
            if (this.natureza_operacao.fiscal_cfop_aux1 != null)
            {
                txtCFOPAux1.Text = this.natureza_operacao.fiscal_cfop_aux1.cfop + " - " + this.natureza_operacao.fiscal_cfop_aux1.descricao;
                txtCFOPAux1.Tag = this.natureza_operacao.fiscal_cfop_aux1;
            }

            if (this.natureza_operacao.fiscal_cfop_aux2 != null)
            {
                txtCFOPAux2.Text = this.natureza_operacao.fiscal_cfop_aux2.cfop + " - " + this.natureza_operacao.fiscal_cfop_aux2.descricao;
                txtCFOPAux2.Tag = this.natureza_operacao.fiscal_cfop_aux2;
            }

            if (this.natureza_operacao.fiscal_cfop_com_cst != null)
            {
                txtCFOPcomCST.Text = this.natureza_operacao.fiscal_cfop_com_cst.cfop + " - " + this.natureza_operacao.fiscal_cfop_com_cst.descricao;
                txtCFOPcomCST.Tag = this.natureza_operacao.fiscal_cfop_com_cst;
            }

            if (this.natureza_operacao.fiscal_cfop_com_cst_fora_estado != null)
            {
                txtCFOPcomCSTforaEstado.Text = this.natureza_operacao.fiscal_cfop_com_cst_fora_estado.cfop + " - " + this.natureza_operacao.fiscal_cfop_com_cst_fora_estado.descricao;
                txtCFOPcomCSTforaEstado.Tag = this.natureza_operacao.fiscal_cfop_com_cst_fora_estado;
            }

            if (this.natureza_operacao.fiscal_cfop_fora_estado != null)
            {
                txtCFOPforaEstado.Text = this.natureza_operacao.fiscal_cfop_fora_estado.cfop + " - " + this.natureza_operacao.fiscal_cfop_fora_estado.descricao;
                txtCFOPforaEstado.Tag = this.natureza_operacao.fiscal_cfop_fora_estado;
            }

            if (this.natureza_operacao.fiscal_cfop_no_estado != null)
            {
                txtCFOPnoEstado.Text = this.natureza_operacao.fiscal_cfop_no_estado.cfop + " - " + this.natureza_operacao.fiscal_cfop_no_estado.descricao;
                txtCFOPnoEstado.Tag = this.natureza_operacao.fiscal_cfop_no_estado;
            }

            if (this.natureza_operacao.fiscal_cfop_com_ie_isento != null)
            {
                txtCFOPcomIEIsento.Text = this.natureza_operacao.fiscal_cfop_com_ie_isento.cfop + " - " + this.natureza_operacao.fiscal_cfop_com_ie_isento.descricao;
                txtCFOPcomIEIsento.Tag = this.natureza_operacao.fiscal_cfop_com_ie_isento;
            }

            if (this.natureza_operacao.fiscal_cfop_com_ie_isento_fora_estado != null)
            {
                txtCFOPcomIEISENTOforaEstado.Text = this.natureza_operacao.fiscal_cfop_com_ie_isento_fora_estado.cfop + " - " + this.natureza_operacao.fiscal_cfop_com_ie_isento_fora_estado.descricao;
                txtCFOPcomIEISENTOforaEstado.Tag = this.natureza_operacao.fiscal_cfop_com_ie_isento_fora_estado;
            }

            chkAtualizaValoresCompra.Checked = this.natureza_operacao.atualiza_valores_compra;
            chkCalculaCusto.Checked = this.natureza_operacao.calcular_custo_medio;
            chkDevolucao.Checked = this.natureza_operacao.devolucao;
            chkGeraTitulo.Checked = this.natureza_operacao.gera_titulo_financeiro;
            chkGerenciaComissao.Checked = this.natureza_operacao.gerenciar_comissao;
            chkMovimentaEstoque.Checked = this.natureza_operacao.movimenta_estoque;
            chkTabelaCompra.Checked = this.natureza_operacao.verificar_tab_compra;
            chkVenda.Checked = this.natureza_operacao.venda;
        

        }
        #endregion
        
        #region Validação de Formulario
        private void ValidForm()
        {
            bool erro = false;

            if (!rbEntrada.Checked && !rbSaida.Checked)
            {
                erro = true;
                rbEntrada.BackColor = CorCampoInvalido;
                rbSaida.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.rbEntrada, "Campo tipo e obrigatório.");
            }
            else
            {
                rbEntrada.BackColor = DefaultBackColor;
                rbSaida.BackColor = DefaultBackColor;
            }

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                erro = true;
                txtDescricao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição e obrigatório.");
            }
            else
                txtDescricao.BackColor = DefaultBackColor;
            
            if (string.IsNullOrEmpty(txtCFOPAux1.Text))
            {
                erro = true;
                txtCFOPAux1.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPAux1, "Campo cfop aux 1 e obrigatório.");
            }
            else
                txtCFOPAux1.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPAux2.Text))
            {
                erro = true;
                txtCFOPAux2.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPAux2, "Campo cfop aux 2 e obrigatório.");
            }
            else
                txtCFOPAux2.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPcomCST.Text))
            {
                erro = true;
                txtCFOPcomCST.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPcomCST, "Campo cfop com cst e obrigatório.");
            }
            else
                txtCFOPcomCST.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPcomCSTforaEstado.Text))
            {
                erro = true;
                txtCFOPcomCSTforaEstado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPcomCSTforaEstado, "Campo cfop com cst fora do estado e obrigatório.");
            }
            else
                txtCFOPcomCSTforaEstado.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPforaEstado.Text))
            {
                erro = true;
                txtCFOPforaEstado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPforaEstado, "Campo cfop fora do estado e obrigatório.");
            }
            else
                txtCFOPforaEstado.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPnoEstado.Text))
            {
                erro = true;
                txtCFOPnoEstado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPnoEstado, "Campo cfop no estado e obrigatório.");
            }
            else
                txtCFOPnoEstado.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPnoEstado.Text))
            {
                erro = true;
                txtCFOPnoEstado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPnoEstado, "Campo cfop no estado e obrigatório.");
            }
            else
                txtCFOPnoEstado.BackColor = DefaultBackColor;


            if (string.IsNullOrEmpty(txtCFOPcomIEIsento.Text))
            {
                erro = true;
                txtCFOPcomIEIsento.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPcomIEIsento, "Campo cfop com IE Isento no estado e obrigatório.");
            }
            else
                txtCFOPcomIEIsento.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCFOPcomIEISENTOforaEstado.Text))
            {
                erro = true;
                txtCFOPcomIEISENTOforaEstado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCFOPcomIEISENTOforaEstado, "Campo cfop com IE Isento fora do estado e obrigatório.");
            }
            else
                txtCFOPcomIEISENTOforaEstado.BackColor = DefaultBackColor;

            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;
        }
        #endregion

        #region Loockups
        private void btCFOPnoEstado_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPnoEstado.Tag = cfop;
                txtCFOPnoEstado.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPnoEstado.Tag = null;
                txtCFOPnoEstado.Text = string.Empty;
            }
        }
        private void txtCFOPnoEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPnoEstado_Click(sender, e);
            }
        }

        private void btCFOPcomCST_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPcomCST.Tag = cfop;
                txtCFOPcomCST.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPcomCST.Tag = null;
                txtCFOPcomCST.Text = string.Empty;
            }
        }
        private void txtCFOPcomCST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPcomCST_Click(sender, e);
            }
        }

        private void btCFOPAux1_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPAux1.Tag = cfop;
                txtCFOPAux1.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPAux1.Tag = null;
                txtCFOPAux1.Text = string.Empty;
            }
        }
        private void txtCFOPAux1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPAux1_Click(sender, e);
            }
        }

        private void btCFOPAux2_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPAux2.Tag = cfop;
                txtCFOPAux2.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPAux2.Tag = null;
                txtCFOPAux2.Text = string.Empty;
            }
        }
        private void txtCFOPAux2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPAux2_Click(sender, e);
            }
        }

        private void btCFOPforaEstado_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPforaEstado.Tag = cfop;
                txtCFOPforaEstado.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPforaEstado.Tag = null;
                txtCFOPforaEstado.Text = string.Empty;
            }
        }
        private void txtCFOPforaEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPforaEstado_Click(sender, e);
            }
        }

        private void btCFOPcomCSTforaEstado_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPcomCSTforaEstado.Tag = cfop;
                txtCFOPcomCSTforaEstado.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPcomCSTforaEstado.Tag = null;
                txtCFOPcomCSTforaEstado.Text = string.Empty;
            }
        }
        private void txtCFOPcomCSTforaEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPcomCSTforaEstado_Click(sender, e);
            }
        }

        private void btCFOPcomIEIsento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPcomIEIsento.Tag = cfop;
                txtCFOPcomIEIsento.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPcomIEIsento.Tag = null;
                txtCFOPcomIEIsento.Text = string.Empty;
            }
        }
        private void txtCFOPcomIEIsento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPcomIEIsento_Click(sender, e);
            }
        }

        private void btCFOPcomIEISENTOforaEstado_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup fFiscalCfopLockup = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopLockup();

            if (fFiscalCfopLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cfop = fFiscalCfopLockup.GetCFOPSelecionado();

                txtCFOPcomIEISENTOforaEstado.Tag = cfop;
                txtCFOPcomIEISENTOforaEstado.Text = cfop.id_fiscal_cfop + " - " + cfop.descricao;

                fFiscalCfopLockup.Close();
                fFiscalCfopLockup.Dispose();
            }
            else
            {
                txtCFOPcomIEISENTOforaEstado.Tag = null;
                txtCFOPcomIEISENTOforaEstado.Text = string.Empty;
            }
        }
        private void txtCFOPcomIEISENTOforaEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCFOPcomIEISENTOforaEstado_Click(sender, e);
            }
        }
        #endregion


    }
}
