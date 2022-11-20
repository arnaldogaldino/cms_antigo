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
using cms.Modulos.Cliente.Cn;

namespace cms.Modulos.Cliente.Forms
{
    public partial class frmCliente : cms.Modulos.Util.WindowBase
    {
        cnCliente cCliente = new cnCliente();

        private cliente cliente = new cliente();
        private cliente_contato cliente_contato = new cliente_contato();
        private cliente_comentario cliente_comentario = new cliente_comentario();

        public Util.Acao Acao { get; set; }
        public long id_cliente { get; set; }

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
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
            this.cliente = new cliente();
            this.Text = "Cliente - Cadastrar novo cliente";
            
            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            tsMenuContato.Enabled = false;
            tsMenuComentario.Enabled = false;

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
            this.Text = "Cliente - Editar cadastro do cliente";
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
            this.cliente = cCliente.GetClienteByID(id_cliente);
            if (this.cliente == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Cliente - Visualizar cadastro do cliente";
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a cliente: " + cliente.nome_fantasia + "!", "Cadastro de cliente.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                cliente.excluido = true;
                if (cCliente.ClienteEditar(ref cliente))
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
                    cliente.data_cadastro = Util.Util.GetDataServidor();
                    if (cCliente.ClienteCadastrar(ref cliente))
                    {
                        this.id_cliente = cliente.id_cliente;
                        txtCodigo.Text = cliente.id_cliente.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o cliente!", "Erro ao cadastrar cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cCliente.ClienteEditar(ref cliente))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o cliente!", "Erro ao cadastrar cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PreencherCliente()
        {
            cliente.data_cadastro = DateTime.Parse(txtDataCadastro.Text);

            if (rbFisica.Checked)
                cliente.tipo_pessoa = "Fisica";
            else if (rbJuridica.Checked)
                cliente.tipo_pessoa = "Juridica";

            cliente.razao_social = txtRazaoSocial.Text;
            cliente.nome_fantasia = txtNomeFantasia.Text;
            cliente.cnpj = txtCNPJ.Text;

            if (rbJuridica.Checked)
            {
                if (chkInscrEstIsento.Checked)
                    cliente.i_estadual = "Isento";
                else
                    cliente.i_estadual = txtInscrEst.Text;
            }
            else
            {
                cliente.nome_fantasia = txtRazaoSocial.Text;
            }

            if (rbFisica.Checked)
            {
                cliente.i_estadual = txtInscrEst.Text;
            }

            cliente.i_municipal = txtInscrMun.Text;
            cliente.telefone = txtTelefone.Text;
            cliente.fax = txtFax.Text;
            cliente.email = txtEmail.Text;

            cliente.end_cep = txtEndCep.Text;
            cliente.end_endereco = txtEndEndereco.Text;
            cliente.end_numero = txtEndNumero.Text;
            cliente.end_complemento = txtEndComplemento.Text;
            cliente.end_bairro = txtEndBairro.Text;
            cliente.end_cidade = txtEndCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                cliente.end_estado = cbEndEstado.SelectedValue.ToString();
            else
                cliente.end_estado = string.Empty;

            if (cbEndMunicipio.SelectedValue != null)
                cliente.end_municipio = cbEndMunicipio.SelectedValue.ToString();
            else
                cliente.end_municipio = string.Empty;

            cliente.ent_cep = txtEntCep.Text;
            cliente.ent_endereco = txtEntEndereco.Text;
            cliente.ent_numero = txtEntNumero.Text;
            cliente.ent_complemento = txtEntComplemento.Text;
            cliente.ent_bairro = txtEntBairro.Text;
            cliente.ent_cidade = txtEntCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                cliente.ent_estado = cbEntEstado.SelectedValue.ToString();
            else
                cliente.ent_estado = string.Empty;

            cliente.cob_cep = txtCobCep.Text;
            cliente.cob_endereco = txtCobEndereco.Text;
            cliente.cob_numero = txtCobNumero.Text;
            cliente.cob_complemento = txtCobComplemento.Text;
            cliente.cob_bairro = txtCobBairro.Text;
            cliente.cob_cidade = txtCobCidade.Text;

            if (cbCobEstado.SelectedValue != null)
                cliente.cob_estado = cbCobEstado.SelectedValue.ToString();
            else
                cliente.cob_estado = string.Empty;

        }

        private void PreencherCampos()
        {
            txtCodigo.Text = this.cliente.id_cliente.ToString();
            txtDataCadastro.Text = this.cliente.data_cadastro.ToString("dd/MM/yyyy");

            if (this.cliente.tipo_pessoa == "Fisica")
                rbFisica.Checked = true;
            else if (this.cliente.tipo_pessoa == "Juridica")
                rbJuridica.Checked = true;

            txtRazaoSocial.Text = this.cliente.razao_social;
            txtNomeFantasia.Text = this.cliente.nome_fantasia;
            txtCNPJ.Text = this.cliente.cnpj;

            if (rbJuridica.Checked)
            {
                if (this.cliente.i_estadual == "Isento")
                    chkInscrEstIsento.Checked = true;
                else
                    txtInscrEst.Text = this.cliente.i_estadual;
            }
            else
            {
                txtNomeFantasia.Text = txtRazaoSocial.Text;
            }
            
            txtInscrEst.Text = this.cliente.i_estadual;

            txtInscrMun.Text = this.cliente.i_municipal;
            txtTelefone.Text = this.cliente.telefone;
            txtFax.Text = this.cliente.fax;
            txtEmail.Text = this.cliente.email;

            txtEndCep.Text = this.cliente.end_cep;
            txtEndEndereco.Text = this.cliente.end_endereco;
            txtEndNumero.Text = this.cliente.end_numero;
            txtEndComplemento.Text = this.cliente.end_complemento;
            txtEndBairro.Text = this.cliente.end_bairro;
            txtEndCidade.Text = this.cliente.end_cidade;

            if (!string.IsNullOrEmpty(this.cliente.end_estado))
                cbEndEstado.SelectedValue = this.cliente.end_estado;

            PreencherMunicipios();

            if (!string.IsNullOrEmpty(this.cliente.end_municipio))
                cbEndMunicipio.SelectedValue = this.cliente.end_municipio;

            txtEntCep.Text = this.cliente.ent_cep;
            txtEntEndereco.Text = this.cliente.ent_endereco;
            txtEntNumero.Text = this.cliente.ent_numero;
            txtEntComplemento.Text = this.cliente.ent_complemento;
            txtEntBairro.Text = this.cliente.ent_bairro;
            txtEntCidade.Text = this.cliente.ent_cidade;

            if (!string.IsNullOrEmpty(this.cliente.ent_estado))
                cbEntEstado.SelectedValue = this.cliente.ent_estado;

            txtCobCep.Text = this.cliente.cob_cep;
            txtCobEndereco.Text = this.cliente.cob_endereco;
            txtCobNumero.Text = this.cliente.cob_numero;
            txtCobComplemento.Text = this.cliente.cob_complemento;
            txtCobBairro.Text = this.cliente.cob_bairro;
            txtCobCidade.Text = this.cliente.cob_cidade;

            if (!string.IsNullOrEmpty(this.cliente.cob_estado))
                cbCobEstado.SelectedValue = this.cliente.cob_estado;

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

        void btCancelarPreencherEndCep_Click(object sender, EventArgs e)
        {
            if (ThreadPreencherEndCep != null)
            {
                ThreadPreencherEndCep.Abort();
                ThreadPreencherEndCep = null;
                //LoadPreencherEndCep.LoadHide(this);

                txtEndCep.Text = string.Empty;
                txtEndEndereco.Text = string.Empty;
                txtEndNumero.Text = string.Empty;
                txtEndComplemento.Text = string.Empty;
                txtEndBairro.Text = string.Empty;
                txtEndCidade.Text = string.Empty;
                cbEndEstado.SelectedValue = string.Empty;

                txtEndCep.Focus();
            }
        }

        Thread ThreadPreencherCobCep;
        private void txtCobCep_Validating(object sender, CancelEventArgs e)
        {
            if (ThreadPreencherCobCep != null)
            {
                ThreadPreencherCobCep.Abort();
                ThreadPreencherCobCep = null;
            }

            ThreadPreencherCobCep = new Thread(PreencherCobCep);
            ThreadPreencherCobCep.IsBackground = true;
            ThreadPreencherCobCep.Start();
           
            txtCobNumero.Focus();
        }

        private void PreencherCobCep()
        {
            if (txtCobCep.InvokeRequired && txtCobEndereco.InvokeRequired && txtCobNumero.InvokeRequired && txtCobComplemento.InvokeRequired && txtCobBairro.InvokeRequired && txtCobCidade.InvokeRequired && cbCobEstado.InvokeRequired && txtEntNumero.InvokeRequired)
            {
                cms.Modulos.Util.Cep.BuscaCep(txtCobCep, txtCobEndereco, txtCobNumero, txtCobComplemento, txtCobBairro, txtCobCidade, cbCobEstado);
                if (ThreadPreencherCobCep != null)
                {
                    ThreadPreencherCobCep.Abort();
                    ThreadPreencherCobCep = null;
                }
            }
        }

        Thread ThreadPreencherEntCep;
        private void txtEntCep_Validating(object sender, CancelEventArgs e)
        {
            if (ThreadPreencherEntCep != null)
            {
                ThreadPreencherEntCep.Abort();
                ThreadPreencherEntCep = null;
            }

            ThreadPreencherEntCep = new Thread(PreencherEntCep);
            ThreadPreencherEntCep.IsBackground = true;
            ThreadPreencherEntCep.Start();

            txtEntNumero.Focus();
        }

        private void PreencherEntCep()
        {
            if (txtEntCep.InvokeRequired && txtEntEndereco.InvokeRequired && txtEntNumero.InvokeRequired && txtEntComplemento.InvokeRequired && txtEntBairro.InvokeRequired && txtEntCidade.InvokeRequired && cbEntEstado.InvokeRequired && txtEntNumero.InvokeRequired)
            {
                cms.Modulos.Util.Cep.BuscaCep(txtEntCep, txtEntEndereco, txtEntNumero, txtEntComplemento, txtEntBairro, txtEntCidade, cbEntEstado);
                if (ThreadPreencherEntCep != null)
                {
                    ThreadPreencherEntCep.Abort();
                    ThreadPreencherEntCep = null;
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
                if (cCliente.ClienteCnpjIsExist(txtCNPJ.Text))
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

        #region Cliente Contato

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
            cliente_contato = new cliente_contato();
        }
        private void ContatoAdd()
        {
            cliente_contato.nome = txtContatoNome.Text;
            cliente_contato.cargo = txtContatoCargo.Text;
            cliente_contato.descricao = txtContatoDescricao.Text;
            cliente_contato.email = txtContatoEmail.Text;
            cliente_contato.telefone = txtContatoTelefone.Text;
            cliente_contato.celular = txtContatoCelular.Text;
            cliente_contato.nextel = txtContatoNextel.Text;
            cliente_contato.nextel_id = txtContatoNextelID.Text;
            cliente_contato.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                cliente_contato.id_cliente = id_cliente;
                cCliente.ClienteContatoCadastrar(cliente_contato);
            }
        }

        private void ContatoAtualizaGrid()
        {            
            gvContato.DataSource = cCliente.ClienteContatoProcurar(id_cliente);
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o contato: " + cliente_contato.nome + "!", "Cadastro de cliente.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.cliente_contato.excluido = true;

                cCliente.ClienteContatoEditar(this.cliente_contato);
                ContatoAtualizaGrid();
                ContatoNovo();
            }
        }
        
        private void gvContato_DoubleClick(object sender, EventArgs e)
        {
            if (gvContato.CurrentRow == null)
                return;

            this.cliente_contato = (cliente_contato)gvContato.CurrentRow.DataBoundItem;
            txtContatoNome.Text = cliente_contato.nome;
            txtContatoCargo.Text = cliente_contato.cargo;
            txtContatoDescricao.Text = cliente_contato.descricao;
            txtContatoEmail.Text = cliente_contato.email;
            txtContatoTelefone.Text = cliente_contato.telefone;
            txtContatoCelular.Text = cliente_contato.celular;
            txtContatoNextel.Text = cliente_contato.nextel;
            txtContatoNextelID.Text = cliente_contato.nextel_id;
        }

        #endregion

        #region Cliente Comentário
        private void ComentarioNovo()
        {
            txtComentarioComentario.Text = "";

            txtComentarioComentario.Focus();
            cliente_comentario = new cliente_comentario();
        }
        private void ComentarioAdd()
        {
            cliente_comentario.comentario = txtComentarioComentario.Text;
            cliente_comentario.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                cliente_comentario.id_cliente = id_cliente;
                cCliente.ClienteComentarioCadastrar(cliente_comentario);
            }
        }

        private void ComentarioAtualizaGrid()
        {
            gvComentario.DataSource = cCliente.ClienteComentarioProcurar(id_cliente);
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

        private void gbEmpresa_Enter(object sender, EventArgs e)
        {

        }

        private void gbContato_Enter(object sender, EventArgs e)
        {

        }

        private void gbEndereco_Enter(object sender, EventArgs e)
        {

        }

        private void gbEntrega_Enter(object sender, EventArgs e)
        {

        }

        private void gbCobranca_Enter(object sender, EventArgs e)
        {

        }
              
    }
}
