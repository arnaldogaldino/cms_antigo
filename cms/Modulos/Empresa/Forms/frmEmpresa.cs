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
using cms.Modulos.Empresa.Cn;
using System.IO;

namespace cms.Modulos.Empresa.Forms
{
    public partial class frmEmpresa : cms.Modulos.Util.WindowBase
    {
        cnEmpresa cEmpresa = new cnEmpresa();

        private empresa empresa = new empresa();
        private empresa_contato empresa_contato = new empresa_contato();
        private empresa_comentario empresa_comentario = new empresa_comentario();

        public Util.Acao Acao { get; set; }
        public long id_empresa { get; set; }

        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            cbEndEstado.DataSource = Util.Combos.Estado();
            cbEntEstado.DataSource = Util.Combos.Estado();
            cbCobEstado.DataSource = Util.Combos.Estado();
            cbEndEstado.Refresh();
            cbEntEstado.Refresh();
            cbCobEstado.Refresh();

            gvContato.AutoGenerateColumns = false;
            gvComentario.AutoGenerateColumns = false;

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
            this.empresa = new empresa();
            this.Text = "Empresa - Cadastrar novo empresa";
            
            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            tsMenuContato.Enabled = false;
            tsMenuComentario.Enabled = false;

            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataCadastro.ReadOnly = true;

            txtCodigo.ReadOnly = true;
            txtCNAE.ReadOnly = true;
            btCNAE.Enabled = true;

            rbFisica.Checked = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            tbAderecos.Visible = false;

            btLogotipo.Enabled = false;

            rbFisica.Enabled = true;
            rbJuridica.Enabled = true;

            rbCRT1.Enabled = true;
            rbCRT2.Enabled = true;
            rbCRT3.Enabled = true;
            TrocarTipoPessoa();
        }
        private void TelaModoEditar()
        {
            this.Text = "Empresa - Editar cadastro do empresa";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            tsMenuContato.Enabled = true;
            tsMenuComentario.Enabled = true;
            
            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            txtCNAE.ReadOnly = true;
            btCNAE.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            btLogotipo.Enabled = false;

            rbCRT1.Enabled = true;
            rbCRT2.Enabled = true;
            rbCRT3.Enabled = true;

            tbAderecos.Visible = true;
        }
        private void TelaModoVisualizar()
        {
            this.empresa = cEmpresa.GetEmpresaByID(id_empresa);
            if (this.empresa == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de empresa.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Empresa - Visualizar cadastro do empresa";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();
            TrocarTipoPessoa();

            txtCNAE.ReadOnly = true;
            btCNAE.Enabled = false;

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
            
            btLogotipo.Enabled = true;

            rbCRT1.Enabled = false;
            rbCRT2.Enabled = false;
            rbCRT3.Enabled = false;

            TravaFormControles(this.Controls);
            tbAderecos.Visible = true;
            tsMenuContato.Enabled = false;
            tsMenuComentario.Enabled = false;
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a empresa: " + empresa.nome_fantasia + "!", "Cadastro de empresa.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                empresa.excluido = true;
                if (cEmpresa.EmpresaEditar(ref empresa))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            ValidForm();
            if (FormIsValid)
                PreencherEmpresa();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    empresa.data_cadastro = Util.Util.GetDataServidor();
                    if (cEmpresa.EmpresaCadastrar(ref empresa))
                    {
                        this.id_empresa = empresa.id_empresa;
                        txtCodigo.Text = empresa.id_empresa.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o empresa!", "Erro ao cadastrar empresa.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cEmpresa.EmpresaEditar(ref empresa))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o empresa!", "Erro ao cadastrar empresa.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PreencherEmpresa()
        {
            empresa.data_cadastro = DateTime.Parse(txtDataCadastro.Text);
            empresa.apelido = txtApelido.Text;

            if (rbFisica.Checked)
                empresa.tipo_pessoa = "Fisica";
            else if (rbJuridica.Checked)
                empresa.tipo_pessoa = "Juridica";

            if (rbCRT1.Checked == true)
                this.empresa.crt = 1;
            else if (rbCRT2.Checked == true)
                this.empresa.crt = 2;
            else if (rbCRT3.Checked == true)
                this.empresa.crt = 3;

            empresa.razao_social = txtRazaoSocial.Text;
            empresa.nome_fantasia = txtNomeFantasia.Text;
            empresa.cnpj = txtCNPJ.Text;

            if (rbJuridica.Checked)
            {
                if (chkInscrEstIsento.Checked)
                    empresa.i_estadual = "Isento";
                else
                    empresa.i_estadual = txtInscrEst.Text;
            }

            if (rbFisica.Checked)
            {
                empresa.i_estadual = txtInscrEst.Text;
            }

            empresa.i_municipal = txtInscrMun.Text;
            empresa.telefone = txtTelefone.Text;
            empresa.fax = txtFax.Text;
            empresa.email = txtEmail.Text;

            empresa.end_cep = txtEndCep.Text;
            empresa.end_endereco = txtEndEndereco.Text;
            empresa.end_numero = txtEndNumero.Text;
            empresa.end_complemento = txtEndComplemento.Text;
            empresa.end_bairro = txtEndBairro.Text;
            empresa.end_cidade = txtEndCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                empresa.end_estado = cbEndEstado.SelectedValue.ToString();
            else
                empresa.end_estado = string.Empty;

            if (cbEndMunicipio.SelectedValue != null)
                empresa.end_municipio = cbEndMunicipio.SelectedValue.ToString();
            else
                empresa.end_municipio = string.Empty;
            
            empresa.ent_cep = txtEntCep.Text;
            empresa.ent_endereco = txtEntEndereco.Text;
            empresa.ent_numero = txtEntNumero.Text;
            empresa.ent_complemento = txtEntComplemento.Text;
            empresa.ent_bairro = txtEntBairro.Text;
            empresa.ent_cidade = txtEntCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                empresa.ent_estado = cbEntEstado.SelectedValue.ToString();
            else
                empresa.ent_estado = string.Empty;

            empresa.cob_cep = txtCobCep.Text;
            empresa.cob_endereco = txtCobEndereco.Text;
            empresa.cob_numero = txtCobNumero.Text;
            empresa.cob_complemento = txtCobComplemento.Text;
            empresa.cob_bairro = txtCobBairro.Text;
            empresa.cob_cidade = txtCobCidade.Text;

            if (cbCobEstado.SelectedValue != null)
                empresa.cob_estado = cbCobEstado.SelectedValue.ToString();
            else
                empresa.cob_estado = string.Empty;

            if (txtCNAE.Tag != null)
                empresa.id_fiscal_cnae = ((fiscal_cnae)txtCNAE.Tag).id_fiscal_cnae;
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = this.empresa.id_empresa.ToString();
            txtDataCadastro.Text = this.empresa.data_cadastro.ToString("dd/MM/yyyy");

            txtApelido.Text = this.empresa.apelido;

            if (this.empresa.tipo_pessoa == "Fisica")
                rbFisica.Checked = true;
            else if (this.empresa.tipo_pessoa == "Juridica")
                rbJuridica.Checked = true;

            if (this.empresa.crt == 1)
                rbCRT1.Checked = true;
            else if (this.empresa.crt == 2)
                rbCRT2.Checked = true;
            else if (this.empresa.crt == 3)
                rbCRT3.Checked = true;

            txtRazaoSocial.Text = this.empresa.razao_social;
            txtNomeFantasia.Text = this.empresa.nome_fantasia;
            txtCNPJ.Text = this.empresa.cnpj;

            if (rbJuridica.Checked)
            {
                if (this.empresa.i_estadual == "Isento")
                    chkInscrEstIsento.Checked = true;
                else
                    txtInscrEst.Text = this.empresa.i_estadual;
            }
            
            txtInscrEst.Text = this.empresa.i_estadual;

            txtInscrMun.Text = this.empresa.i_municipal;
            txtTelefone.Text = this.empresa.telefone;
            txtFax.Text = this.empresa.fax;
            txtEmail.Text = this.empresa.email;

            txtEndCep.Text = this.empresa.end_cep;
            txtEndEndereco.Text = this.empresa.end_endereco;
            txtEndNumero.Text = this.empresa.end_numero;
            txtEndComplemento.Text = this.empresa.end_complemento;
            txtEndBairro.Text = this.empresa.end_bairro;
            txtEndCidade.Text = this.empresa.end_cidade;

            if (!string.IsNullOrEmpty(this.empresa.end_estado))
                cbEndEstado.SelectedValue = this.empresa.end_estado;

            PreencherMunicipios();

            if (!string.IsNullOrEmpty(this.empresa.end_municipio)) 
                cbEndMunicipio.SelectedValue = this.empresa.end_municipio;

            txtEntCep.Text = this.empresa.ent_cep;
            txtEntEndereco.Text = this.empresa.ent_endereco;
            txtEntNumero.Text = this.empresa.ent_numero;
            txtEntComplemento.Text = this.empresa.ent_complemento;
            txtEntBairro.Text = this.empresa.ent_bairro;
            txtEntCidade.Text = this.empresa.ent_cidade;

            if (!string.IsNullOrEmpty(this.empresa.ent_estado))
                cbEntEstado.SelectedValue = this.empresa.ent_estado;

            txtCobCep.Text = this.empresa.cob_cep;
            txtCobEndereco.Text = this.empresa.cob_endereco;
            txtCobNumero.Text = this.empresa.cob_numero;
            txtCobComplemento.Text = this.empresa.cob_complemento;
            txtCobBairro.Text = this.empresa.cob_bairro;
            txtCobCidade.Text = this.empresa.cob_cidade;

            if (!string.IsNullOrEmpty(this.empresa.cob_estado))
                cbCobEstado.SelectedValue = this.empresa.cob_estado;

            if(this.empresa.logotipo != null)
                imgLogomarca.Image = Image.FromStream(new MemoryStream(this.empresa.logotipo));

            if (empresa.id_fiscal_cnae != null)
            {
                txtCNAE.Tag = empresa.fiscal_cnae;
                txtCNAE.Text = empresa.fiscal_cnae.subclasse + " - " + empresa.fiscal_cnae.denominacao;
            }

            ComentarioAtualizaGrid();
            ContatoAtualizaGrid();            
        }
        #endregion

        #region Tipo Pessoa
        private void SelectTipoPessoa(object sender, EventArgs e)
        {
            TrocarTipoPessoa();
        }
        private void TrocarTipoPessoa()
        {
            if (rbFisica.Checked == true)
            {
                lblRazaoSocial.Text = "Nome:";
                lblNomeFantasia.Visible = false;
                txtNomeFantasia.Visible = false;
                lblCNPJ.Text = "CPF:";
                this.TextMaskedit.SetTextMasked(this.txtCNPJ, ToolMasked.TextMask.Formats.Cpf);
                lblInscrEst.Text = "RG:";
                this.TextMaskedit.SetTextMasked(this.txtInscrEst, ToolMasked.TextMask.Formats.Rg);
                chkInscrEstIsento.Visible = false;
                lblInscrMun.Visible = false;
                txtInscrMun.Visible = false;
            }

            if (rbJuridica.Checked == true)
            {
                lblRazaoSocial.Text = "Razão Social:";
                lblNomeFantasia.Visible = true;
                txtNomeFantasia.Visible = true;
                lblCNPJ.Text = "CNPJ:";
                this.TextMaskedit.SetTextMasked(this.txtCNPJ, ToolMasked.TextMask.Formats.Cnpj);
                lblInscrEst.Text = "Inscr. Est.:";
                this.TextMaskedit.SetTextMasked(this.txtInscrEst, ToolMasked.TextMask.Formats.Ie);
                chkInscrEstIsento.Visible = true;
                lblInscrMun.Visible = true;
                txtInscrMun.Visible = true;
            }

        }
        #endregion

        #region Busca de Ceps
        private void txtEndCep_Validating(object sender, CancelEventArgs e)
        {
            cms.Modulos.Util.Cep.BuscaCep(txtEndCep, txtEndEndereco, txtEndNumero, txtEndComplemento, txtEndBairro, txtEndCidade, cbEndEstado);
            PreencherMunicipios();
            txtEndNumero.Focus();
        }
        private void txtEntCep_Validating(object sender, CancelEventArgs e)
        {
            cms.Modulos.Util.Cep.BuscaCep(txtEntCep, txtEntEndereco, txtEntNumero, txtEntComplemento, txtEntBairro, txtEntCidade, cbEntEstado);
            txtEntNumero.Focus();
        }
        private void txtCobCep_Validating(object sender, CancelEventArgs e)
        {
            cms.Modulos.Util.Cep.BuscaCep(txtCobCep, txtCobEndereco, txtCobNumero, txtCobComplemento, txtCobBairro, txtCobCidade, cbCobEstado);
            txtCobNumero.Focus();
        }
        private void cbEndEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PreencherMunicipios();
        }
        private void PreencherMunicipios()
        {
            cbEndMunicipio.DataSource = Util.Combos.Municipios(cbEndEstado.SelectedValue.ToString());
            cbEndMunicipio.ValueMember = "Value";
            cbEndMunicipio.DisplayMember = "Display";
            cbEndMunicipio.Refresh();
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtRazaoSocial.Text))
            {
                erro = true;
                txtRazaoSocial.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtRazaoSocial, "Campo razão social e obrigatório.");
            }
            else
                txtRazaoSocial.BackColor = DefaultBackColor;

            if (rbJuridica.Checked)
            {
                if (string.IsNullOrEmpty(txtNomeFantasia.Text))
                {
                    erro = true;
                    txtNomeFantasia.BackColor = CorCampoInvalido;
                    this.ValidarForm.SetToolTip(this.txtNomeFantasia, "Campo nome fantasia e obrigatório.");
                }
                else
                    txtNomeFantasia.BackColor = DefaultBackColor;
            }


            if (rbCRT1.Checked == false && rbCRT2.Checked == false && rbCRT3.Checked == false)
            {
                erro = true;
                rbCRT1.BackColor = CorCampoInvalido;
                rbCRT2.BackColor = CorCampoInvalido;
                rbCRT3.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.rbCRT1, "Campo CRT e obrigatório.");
                this.ValidarForm.SetToolTip(this.rbCRT2, "Campo CRT e obrigatório.");
                this.ValidarForm.SetToolTip(this.rbCRT3, "Campo CRT e obrigatório.");
            }
            else
            {
                rbCRT1.BackColor = DefaultBackColor;
                rbCRT2.BackColor = DefaultBackColor;
                rbCRT3.BackColor = DefaultBackColor;
            }

            if (string.IsNullOrEmpty(txtCNPJ.Text))
            {
                erro = true;
                txtCNPJ.BackColor = CorCampoInvalido;
                if (rbJuridica.Checked)
                    this.ValidarForm.SetToolTip(this.txtCNPJ, "Campo CNPJ e obrigatório.");
                else
                    this.ValidarForm.SetToolTip(this.txtCNPJ, "Campo CPF e obrigatório.");
            }
            else
                txtCNPJ.BackColor = DefaultBackColor;

            if (rbJuridica.Checked)
            {
                if (!cms.Modulos.Util.Validacoes.ValidaCNPJ(txtCNPJ.Text))
                {
                    erro = true;
                    txtCNPJ.BackColor = CorCampoInvalido;
                    this.ValidarForm.SetToolTip(this.txtCNPJ, "CNPJ inválido!");
                }
                else
                    txtCNPJ.BackColor = DefaultBackColor;
            }
            else
            {
                if (!cms.Modulos.Util.Validacoes.ValidaCPF(txtCNPJ.Text))
                {
                    erro = true;
                    txtCNPJ.BackColor = CorCampoInvalido;
                    this.ValidarForm.SetToolTip(this.txtCNPJ, "CPF inválido!");
                }
                else
                    txtCNPJ.BackColor = DefaultBackColor;
            }

            if (Acao == Util.Acao.Cadastrar)
            {
                if (cEmpresa.EmpresaCnpjIsExist(txtCNPJ.Text))
                {
                    erro = true;
                    txtCNPJ.BackColor = CorCampoInvalido;
                    if (rbJuridica.Checked)
                        this.ValidarForm.SetToolTip(this.txtCNPJ, "Campo CNPJ já cadastrado.");
                    else
                        this.ValidarForm.SetToolTip(this.txtCNPJ, "Campo CPF já cadastrado.");
                }
                else
                    txtCNPJ.BackColor = DefaultBackColor;
            }

            if (string.IsNullOrEmpty(txtInscrEst.Text))
            {
                erro = true;
                txtInscrEst.BackColor = CorCampoInvalido;
                if (rbJuridica.Checked)
                    this.ValidarForm.SetToolTip(this.txtInscrEst, "Campo inscrição estadual e obrigatório.");
                else
                    this.ValidarForm.SetToolTip(this.txtInscrEst, "Campo RG e obrigatório.");
            }
            else
                txtInscrEst.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtTelefone.Text))
            {
                erro = true;
                txtTelefone.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtTelefone, "Campo telefone e obrigatório.");
            }
            else
                txtTelefone.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                erro = true;
                txtEmail.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEmail, "Campo e-mail e obrigatório.");
            }
            else
                txtEmail.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtEndCep.Text))
            {
                erro = true;
                txtEndCep.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEndCep, "Campo cep e obrigatório.");
            }
            else
                txtEndCep.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtEndEndereco.Text))
            {
                erro = true;
                txtEndEndereco.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEndEndereco, "Campo endereço e obrigatório.");
            }
            else
                txtEndEndereco.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtEndNumero.Text))
            {
                erro = true;
                txtEndNumero.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEndNumero, "Campo numero e obrigatório.");
            }
            else
                txtEndNumero.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtEndBairro.Text))
            {
                erro = true;
                txtEndBairro.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEndBairro, "Campo bairro e obrigatório.");
            }
            else
                txtEndBairro.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtEndCidade.Text))
            {
                erro = true;
                txtEndCidade.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEndCidade, "Campo cidade e obrigatório.");
            }
            else
                txtEndCidade.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(cbEndEstado.SelectedValue.ToString()))
            {
                erro = true;
                cbEndEstado.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.cbEndEstado, "Campo estado e obrigatório.");
            }
            else
                cbEndEstado.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(cbEndMunicipio.SelectedValue.ToString()))
            {
                erro = true;
                cbEndMunicipio.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.cbEndMunicipio, "Campo municipio e obrigatório.");
            }
            else
                cbEndMunicipio.BackColor = DefaultBackColor;


            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;
        }
        #endregion

        private void chkInscrEstIsento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInscrEstIsento.Checked)
            {
                txtInscrEst.Text = "Isento";
                txtInscrEst.ReadOnly = true;
            }
            else
            {
                txtInscrEst.Text = "";
                txtInscrEst.ReadOnly = false;
            }
        }

        #region Empresa Contato

        private void ContatoNovo()
        {
            txtContatoNome.Text = "";
            txtContatoTelefone.Text = "";
            txtContatoNextelID.Text = "";
            txtContatoNextel.Text = "";
            txtContatoEmail.Text = "";
            txtContatoDescricao.Text = "";
            txtContatoCelular.Text = "";
            txtContatoCargo.Text = "";

            txtContatoNome.Focus();
            empresa_contato = new empresa_contato();
        }
        private void ContatoAdd()
        {
            empresa_contato.nome = txtContatoNome.Text;
            empresa_contato.cargo = txtContatoCargo.Text;
            empresa_contato.descricao = txtContatoDescricao.Text;
            empresa_contato.email = txtContatoEmail.Text;
            empresa_contato.telefone = txtContatoTelefone.Text;
            empresa_contato.celular = txtContatoCelular.Text;
            empresa_contato.nextel = txtContatoNextel.Text;
            empresa_contato.nextel_id = txtContatoNextelID.Text;
            empresa_contato.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                empresa_contato.id_empresa = id_empresa;
                cEmpresa.EmpresaContatoCadastrar(empresa_contato);
            }
        }

        private void ContatoAtualizaGrid()
        {            
            gvContato.DataSource = cEmpresa.EmpresaContatoProcurar(id_empresa);
            gvContato.Refresh();
        }

        private void btContatoNovo_Click(object sender, EventArgs e)
        {
            ContatoNovo();                        
        }

        private void btContatoGravar_Click(object sender, EventArgs e)
        {
            ContatoAdd();
            ContatoAtualizaGrid();
            ContatoNovo();
        }

        private void btContatoExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o contato: " + empresa_contato.nome + "!", "Cadastro de empresa.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.empresa_contato.excluido = true;

                cEmpresa.EmpresaContatoEditar(this.empresa_contato);
                ContatoAtualizaGrid();
                ContatoNovo();
            }
        }
        
        private void gvContato_DoubleClick(object sender, EventArgs e)
        {
            if (gvContato.CurrentRow == null)
                return;

            this.empresa_contato = (empresa_contato)gvContato.CurrentRow.DataBoundItem;
            txtContatoNome.Text = empresa_contato.nome;
            txtContatoCargo.Text = empresa_contato.cargo;
            txtContatoDescricao.Text = empresa_contato.descricao;
            txtContatoEmail.Text = empresa_contato.email;
            txtContatoTelefone.Text = empresa_contato.telefone;
            txtContatoCelular.Text = empresa_contato.celular;
            txtContatoNextel.Text = empresa_contato.nextel;
            txtContatoNextelID.Text = empresa_contato.nextel_id;
        }

        #endregion

        #region Empresa Comentário
        private void ComentarioNovo()
        {
            txtComentarioComentario.Text = "";

            txtComentarioComentario.Focus();
            empresa_comentario = new empresa_comentario();
        }
        private void ComentarioAdd()
        {
            empresa_comentario.comentario = txtComentarioComentario.Text;
            empresa_comentario.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                empresa_comentario.id_empresa = id_empresa;
                cEmpresa.EmpresaComentarioCadastrar(empresa_comentario);
            }
        }

        private void ComentarioAtualizaGrid()
        {
            gvComentario.DataSource = cEmpresa.EmpresaComentarioProcurar(id_empresa);
            gvComentario.Refresh();
        }

        private void btComentarioGravar_Click(object sender, EventArgs e)
        {
            ComentarioAdd();
            ComentarioAtualizaGrid();
            ComentarioNovo();
        }

        private void btComentarioNovo_Click(object sender, EventArgs e)
        {
            ComentarioNovo();
        }
        #endregion

        #region Logotipo
        private void btLogotipo_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream st = OpenFile.OpenFile();
                empresa.logotipo = Util.Util.ReadFile(st);

                cEmpresa.EmpresaEditar(ref empresa);
                TelaModoVisualizar();
            }
        }
        #endregion

        #region # Lockups #
        private void btCNAE_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnaeLockup fCnaeLockup = new cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnaeLockup();

            if (fCnaeLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cnae = fCnaeLockup.GetCNAESelecionado();

                txtCNAE.Tag = cnae;
                txtCNAE.Text = cnae.subclasse + " - " + cnae.denominacao;

                fCnaeLockup.Close();
                fCnaeLockup.Dispose();
            }
            else
            {
                txtCNAE.Tag = null;
                txtCNAE.Text = string.Empty;
            }
        }
        private void txtCNAE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCNAE_Click(sender, e);
            }
        }
        #endregion
   
    }
}
