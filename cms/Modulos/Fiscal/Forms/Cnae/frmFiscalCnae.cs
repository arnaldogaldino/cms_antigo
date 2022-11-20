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

namespace cms.Modulos.Fiscal.Forms.Cnae
{
    public partial class frmFiscalCnae : cms.Modulos.Util.WindowBase
    {
        cnFiscalCnae cFiscalCnae = new cnFiscalCnae();
        fiscal_cnae oCnae = new fiscal_cnae();

        public Util.Acao Acao { get; set; }
        public long id_fiscal_cnae { get; set; }
        
        public frmFiscalCnae()
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
            this.oCnae = new fiscal_cnae();
            this.Text = "CNAE - Cadastrar novo cnae";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            
            txtCodigo.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "CNAE - Editar cadastro do cnae";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            
            txtCodigo.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;        
        }
        private void TelaModoVisualizar()
        {
            this.oCnae = cFiscalCnae.GetFiscalCnaeById(id_fiscal_cnae);
            if (this.oCnae == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de cnae.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "CNAE - Visualizar cadastro do cnae";
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a CNAE: " + oCnae.denominacao + "!", "Cadastro de cnae.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                oCnae.excluido = true;
                if (cFiscalCnae.FiscalCnaeEditar(ref oCnae))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherCnae();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cFiscalCnae.FiscalCnaeCadastrar(ref oCnae))
                    {
                        this.id_fiscal_cnae = oCnae.id_fiscal_cnae;
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o cnae!", "Erro ao cadastrar cnae.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFiscalCnae.FiscalCnaeEditar(ref oCnae))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o cnae!", "Erro ao cadastrar cnae.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidForm()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtSecao.Text))
            {
                erro = true;
                txtSecao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtSecao, "Campo seção e obrigatório.");
            }
            else
                txtSecao.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtDenominacao.Text))
            {
                erro = true;
                txtDenominacao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDenominacao, "Campo denominação e obrigatório.");
            }
            else
                txtDenominacao.BackColor = DefaultBackColor;

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

        private void PreencherCnae()
        {        
            int codigo = 0;

            if(int.TryParse(txtCodigo.Text, out codigo))
                oCnae.id_fiscal_cnae = codigo;

            oCnae.secao = txtSecao.Text;
            oCnae.divisao = txtDivisao.Text;
            oCnae.grupo = txtGrupo.Text;
            oCnae.classe = txtClasse.Text;
            oCnae.subclasse = txtSubClasse.Text;
            oCnae.denominacao = txtDenominacao.Text;
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = oCnae.id_fiscal_cnae.ToString();
            txtSecao.Text = oCnae.secao;
            txtDivisao.Text = oCnae.divisao;
            txtGrupo.Text = oCnae.grupo;
            txtClasse.Text = oCnae.classe;
            txtSubClasse.Text = oCnae.subclasse;
            txtDenominacao.Text = oCnae.denominacao;
        }
        #endregion

    }
}
