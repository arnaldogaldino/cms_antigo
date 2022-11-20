using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Modulos.Fiscal.Cn;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Fiscal.Forms.Cfop
{
    public partial class frmFiscalCfop : cms.Modulos.Util.WindowBase
    {
        cnFiscalCfop cFiscalCfop = new cnFiscalCfop();
        fiscal_cfop oCfop = new fiscal_cfop();

        public Util.Acao Acao { get; set; }
        public long id_fiscal_cfop { get; set; }
        
        public frmFiscalCfop()
        {
            InitializeComponent();
        }

        private void frmFiscalCfop_Load(object sender, EventArgs e)
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
            this.oCfop = new fiscal_cfop();
            this.Text = "CFOP - Cadastrar novo cfop";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
  
            rbEntrada.Checked = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "CFOP - Editar cadastro do cfop";
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
            this.oCfop = cFiscalCfop.GetFiscalCfopById(id_fiscal_cfop);
            if (this.oCfop == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de cfop.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "CFOP - Visualizar cadastro do cfop";
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
        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            TelaModoCadastrarNovo();
        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            TelaModoEditar();
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a CFOP: " + oCfop.cfop + "!", "Cadastro de cfop.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                oCfop.excluido = true;
                if (cFiscalCfop.FiscalCfopEditar(ref oCfop))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            ValidForm();
            if (FormIsValid)
                PreencherCliente();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    //cliente.data_cadastro = Util.Util.GetDataServidor();
                    if (cFiscalCfop.FiscalCfopCadastrar(ref oCfop))
                    {
                        this.id_fiscal_cfop = oCfop.id_fiscal_cfop;
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o cfop!", "Erro ao cadastrar cfop.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFiscalCfop.FiscalCfopEditar(ref oCfop))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o cfop!", "Erro ao cadastrar cfop.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidForm()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                erro = true;
                txtDescricao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição e obrigatório.");
            }
            else
                txtDescricao.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtAplicacao.Text))
            {
                erro = true;
                txtAplicacao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtAplicacao, "Campo aplicação e obrigatório.");
            }
            else
                txtAplicacao.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtCfop.Text))
            {
                erro = true;
                txtCfop.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCfop, "Campo cfop e obrigatório.");
            }
            else
                txtCfop.BackColor = DefaultBackColor;

            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;
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

        private void PreencherCliente()
        {        
            if (rbEntrada.Checked)
                oCfop.tipo = "Entrada";
            else if (rbSaida.Checked)
                oCfop.tipo = "Saída";

            int cfop_cod = 0;

            if(int.TryParse(txtCfop.Text, out cfop_cod))
                oCfop.cfop = cfop_cod;

            oCfop.descricao = txtDescricao.Text;
            oCfop.aplicacao = txtAplicacao.Text;
        }

        private void PreencherCampos()
        {
            txtCfop.Text = this.oCfop.cfop.ToString();
            txtDescricao.Text = this.oCfop.descricao;
            txtAplicacao.Text = this.oCfop.aplicacao;

            if (this.oCfop.tipo == "Entrada")
                rbEntrada.Checked = true;
            else if (this.oCfop.tipo == "Saída")
                rbSaida.Checked = true;

        }
        #endregion

    }
}
