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

namespace cms.Modulos.Fornecedor.Forms
{
    public partial class frmFornecedor : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Fornecedor.Cn.cnFornecedor cFornecedor = new cms.Modulos.Fornecedor.Cn.cnFornecedor();

        private fornecedor fornecedor = new fornecedor();
        private fornecedor_contato fornecedor_contato = new fornecedor_contato();
        private fornecedor_comentario fornecedor_comentario = new fornecedor_comentario();

        public Util.Acao Acao { get; set; }
        public long id_fornecedor { get; set; }

        public frmFornecedor()
        {
            InitializeComponent();
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
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
            this.fornecedor = new fornecedor();
            this.Text = "Fornecedor - Cadastrar nova fornecedor";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            tsMenuContato.Enabled = true;
            tsMenuComentario.Enabled = true;

            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataCadastro.ReadOnly = true;

            txtCodigo.ReadOnly = true;

            rbFisica.Checked = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            tbAderecos.Visible = false;

            rbFisica.Enabled = true;
            rbJuridica.Enabled = true;
            TrocarTipoPessoa();
        }
        private void TelaModoEditar()
        {
            this.Text = "Fornecedor - Editar cadastro da fornecedor";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            tsMenuContato.Enabled = true;
            tsMenuComentario.Enabled = true;
            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            tbAderecos.Visible = true;
        }
        private void TelaModoVisualizar()
        {
            this.fornecedor = cFornecedor.GetFornecedorByID(id_fornecedor);
            if (this.fornecedor == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de fornecedor.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Fornecedor - Visualizar cadastro da fornecedor";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();
            TrocarTipoPessoa();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a fornecedor: " + fornecedor.nome_fantasia + "!", "Cadastro de fornecedor.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                fornecedor.excluido = true;
                if (cFornecedor.FornecedorEditar(ref fornecedor))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {

            ValidForm();
            if (FormIsValid)
                PreencherFornecedor();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    fornecedor.data_cadastro = Util.Util.GetDataServidor();
                    if (cFornecedor.FornecedorCadastrar(ref fornecedor))
                    {
                        this.id_fornecedor = fornecedor.id_fornecedor;
                        txtCodigo.Text = fornecedor.id_fornecedor.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar a fornecedor!", "Erro ao cadastrar fornecedor.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFornecedor.FornecedorEditar(ref fornecedor))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar a fornecedor!", "Erro ao cadastrar fornecedor.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            //if (this.Acao == Util.Acao.Cadastrar)
            //    this.TelaModoCadastrarNovo();
            // else 
            if (this.Acao == Util.Acao.Editar)
                this.TelaModoVisualizar();

            //    this.TelaModoEditar();
            //else if (this.Acao == Util.Acao.Visualizar)
            //    this.TelaModoVisualizar();
        }
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreencherFornecedor()
        {
            fornecedor.data_cadastro = DateTime.Parse(txtDataCadastro.Text);

            if (rbFisica.Checked)
                fornecedor.tipo_pessoa = "Fisica";
            else if (rbJuridica.Checked)
                fornecedor.tipo_pessoa = "Juridica";

            fornecedor.razao_social = txtRazaoSocial.Text;
            fornecedor.nome_fantasia = txtNomeFantasia.Text;
            fornecedor.cnpj = txtCNPJ.Text;

            if (rbJuridica.Checked)
            {
                if (chkInscrEstIsento.Checked)
                    fornecedor.i_estadual = "Isento";
                else
                    fornecedor.i_estadual = txtInscrEst.Text;
            }
            else
            {
                fornecedor.nome_fantasia = txtRazaoSocial.Text;
            }

            if (rbFisica.Checked)
            {
                fornecedor.i_estadual = txtInscrEst.Text;
            }

            fornecedor.i_municipal = txtInscrMun.Text;
            fornecedor.telefone = txtTelefone.Text;
            fornecedor.fax = txtFax.Text;
            fornecedor.email = txtEmail.Text;

            fornecedor.end_cep = txtEndCep.Text;
            fornecedor.end_endereco = txtEndEndereco.Text;
            fornecedor.end_numero = txtEndNumero.Text;
            fornecedor.end_complemento = txtEndComplemento.Text;
            fornecedor.end_bairro = txtEndBairro.Text;
            fornecedor.end_cidade = txtEndCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                fornecedor.end_estado = cbEndEstado.SelectedValue.ToString();

            if (cbEndMunicipio.SelectedValue != null)
                fornecedor.end_municipio = cbEndMunicipio.SelectedValue.ToString();
            else
                fornecedor.end_municipio = string.Empty;

            fornecedor.ent_cep = txtEntCep.Text;
            fornecedor.ent_endereco = txtEntEndereco.Text;
            fornecedor.ent_numero = txtEntNumero.Text;
            fornecedor.ent_complemento = txtEntComplemento.Text;
            fornecedor.ent_bairro = txtEntBairro.Text;
            fornecedor.ent_cidade = txtEntCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                fornecedor.ent_estado = cbEntEstado.SelectedValue.ToString();

            fornecedor.cob_cep = txtCobCep.Text;
            fornecedor.cob_endereco = txtCobEndereco.Text;
            fornecedor.cob_numero = txtCobNumero.Text;
            fornecedor.cob_complemento = txtCobComplemento.Text;
            fornecedor.cob_bairro = txtCobBairro.Text;
            fornecedor.cob_cidade = txtCobCidade.Text;

            if (cbCobEstado.SelectedValue != null)
                fornecedor.cob_estado = cbCobEstado.SelectedValue.ToString();
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.fornecedor.id_fornecedor.ToString();
            txtDataCadastro.Text = this.fornecedor.data_cadastro.ToString("dd/MM/yyyy");

            if (this.fornecedor.tipo_pessoa == "Fisica")
                rbFisica.Checked = true;
            else if (this.fornecedor.tipo_pessoa == "Juridica")
                rbJuridica.Checked = true;

            txtRazaoSocial.Text = this.fornecedor.razao_social;
            txtNomeFantasia.Text = this.fornecedor.nome_fantasia;
            txtCNPJ.Text = this.fornecedor.cnpj;

            if (rbJuridica.Checked)
            {
                if (this.fornecedor.i_estadual == "Isento")
                    chkInscrEstIsento.Checked = true;
                else
                    txtInscrEst.Text = this.fornecedor.i_estadual;
            }
            else
            {
                txtNomeFantasia.Text = txtRazaoSocial.Text;
            }

            txtInscrMun.Text = this.fornecedor.i_municipal;
            txtTelefone.Text = this.fornecedor.telefone;
            txtFax.Text = this.fornecedor.fax;
            txtEmail.Text = this.fornecedor.email;

            txtEndCep.Text = this.fornecedor.end_cep;
            txtEndEndereco.Text = this.fornecedor.end_endereco;
            txtEndNumero.Text = this.fornecedor.end_numero;
            txtEndComplemento.Text = this.fornecedor.end_complemento;
            txtEndBairro.Text = this.fornecedor.end_bairro;
            txtEndCidade.Text = this.fornecedor.end_cidade;

            if (!string.IsNullOrEmpty(this.fornecedor.end_estado))
                cbEndEstado.SelectedValue = this.fornecedor.end_estado;

            PreencherMunicipios();

            if (!string.IsNullOrEmpty(this.fornecedor.end_municipio))
                cbEndMunicipio.SelectedValue = this.fornecedor.end_municipio;

            txtEntCep.Text = this.fornecedor.ent_cep;
            txtEntEndereco.Text = this.fornecedor.ent_endereco;
            txtEntNumero.Text = this.fornecedor.ent_numero;
            txtEntComplemento.Text = this.fornecedor.ent_complemento;
            txtEntBairro.Text = this.fornecedor.ent_bairro;
            txtEntCidade.Text = this.fornecedor.ent_cidade;

            if (!string.IsNullOrEmpty(this.fornecedor.ent_estado))
                cbEntEstado.SelectedValue = this.fornecedor.ent_estado;

            txtCobCep.Text = this.fornecedor.cob_cep;
            txtCobEndereco.Text = this.fornecedor.cob_endereco;
            txtCobNumero.Text = this.fornecedor.cob_numero;
            txtCobComplemento.Text = this.fornecedor.cob_complemento;
            txtCobBairro.Text = this.fornecedor.cob_bairro;
            txtCobCidade.Text = this.fornecedor.cob_cidade;

            if (!string.IsNullOrEmpty(this.fornecedor.cob_estado))
                cbCobEstado.SelectedValue = this.fornecedor.cob_estado;

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
        Thread ThreadPreencherEndCep;

        private void txtEndCep_Validating(object sender, CancelEventArgs e)
        {
            if (ThreadPreencherEndCep != null)
            {
                ThreadPreencherEndCep.Abort();
                ThreadPreencherEndCep = null;
            }

            ThreadPreencherEndCep = new Thread(PreencherEndCep);
            ThreadPreencherEndCep.IsBackground = true;
            ThreadPreencherEndCep.Start();

            txtEndNumero.Focus();
        }

        private void PreencherEndCep()
        {
            if (txtEndCep.InvokeRequired && txtEndEndereco.InvokeRequired && txtEndNumero.InvokeRequired && txtEndComplemento.InvokeRequired && txtEndBairro.InvokeRequired && txtEndCidade.InvokeRequired && cbEndEstado.InvokeRequired && txtEntNumero.InvokeRequired)
            {
                cms.Modulos.Util.Cep.BuscaCep(txtEndCep, txtEndEndereco, txtEndNumero, txtEndComplemento, txtEndBairro, txtEndCidade, cbEndEstado);
                if (ThreadPreencherEndCep != null)
                {
                    ThreadPreencherEndCep.Abort();
                    ThreadPreencherEndCep = null;
                }
            }
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

            //if (string.IsNullOrEmpty(txtCodigo.Text))
            //{
            //    erro = true;
            //    txtCodigo.BackColor = CorCampoInvalido;
            //    this.ValidarForm.SetToolTip(this.txtCodigo, "Campo código e obrigatório.");
            //}
            //else
            //    txtCodigo.BackColor = DefaultBackColor;

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
                if (cFornecedor.FornecedorCnpjIsExist(txtCNPJ.Text))
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

        #region Fornecedor Contato

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
            fornecedor_contato = new fornecedor_contato();
        }
        private void ContatoAdd()
        {
            fornecedor_contato.nome = txtContatoNome.Text;
            fornecedor_contato.cargo = txtContatoCargo.Text;
            fornecedor_contato.descricao = txtContatoDescricao.Text;
            fornecedor_contato.email = txtContatoEmail.Text;
            fornecedor_contato.telefone = txtContatoTelefone.Text;
            fornecedor_contato.celular = txtContatoCelular.Text;
            fornecedor_contato.nextel = txtContatoNextel.Text;
            fornecedor_contato.nextel_id = txtContatoNextelID.Text;
            fornecedor_contato.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {

                fornecedor_contato.id_fornecedor = id_fornecedor;
                cFornecedor.FornecedorContatoCadastrar(fornecedor_contato);
            }
        }

        private void ContatoAtualizaGrid()
        {
            gvContato.DataSource = cFornecedor.FornecedorContatoProcurar(id_fornecedor);
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o contato: " + fornecedor_contato.nome + "!", "Cadastro de fornecedor.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.fornecedor_contato.excluido = true;

                cFornecedor.FornecedorContatoEditar(this.fornecedor_contato);
                ContatoAtualizaGrid();
                ContatoNovo();
            }
        }

        private void gvContato_DoubleClick(object sender, EventArgs e)
        {
            if (gvContato.CurrentRow == null)
                return;

            this.fornecedor_contato = (fornecedor_contato)gvContato.CurrentRow.DataBoundItem;
            txtContatoNome.Text = fornecedor_contato.nome;
            txtContatoCargo.Text = fornecedor_contato.cargo;
            txtContatoDescricao.Text = fornecedor_contato.descricao;
            txtContatoEmail.Text = fornecedor_contato.email;
            txtContatoTelefone.Text = fornecedor_contato.telefone;
            txtContatoCelular.Text = fornecedor_contato.celular;
            txtContatoNextel.Text = fornecedor_contato.nextel;
            txtContatoNextelID.Text = fornecedor_contato.nextel_id;
        }

        #endregion

        #region Fornecedor Comentário
        private void ComentarioNovo()
        {
            txtComentarioComentario.Text = "";

            txtComentarioComentario.Focus();
            fornecedor_comentario = new fornecedor_comentario();
        }
        private void ComentarioAdd()
        {
            fornecedor_comentario.comentario = txtComentarioComentario.Text;
            fornecedor_comentario.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                fornecedor_comentario.id_fornecedor = id_fornecedor;
                cFornecedor.FornecedorComentarioCadastrar(fornecedor_comentario);
            }
        }

        private void ComentarioAtualizaGrid()
        {
            gvComentario.DataSource = cFornecedor.FornecedorComentarioProcurar(id_fornecedor);
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

    }
}
