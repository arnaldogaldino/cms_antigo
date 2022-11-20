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

namespace cms.Modulos.Transportadora.Forms
{
    public partial class frmTransportadora : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Transportadora.Cn.cnTransportadora cTransportadora = new cms.Modulos.Transportadora.Cn.cnTransportadora();

        private transportadora transportadora = new transportadora();
        private transportadora_contato transportadora_contato = new transportadora_contato();
        private transportadora_comentario transportadora_comentario = new transportadora_comentario();

        public Util.Acao Acao { get; set; }
        public long id_transportadora { get; set; }

        public frmTransportadora()
        {
            InitializeComponent();
        }

        private void frmTransportadora_Load(object sender, EventArgs e)
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
            this.transportadora = new transportadora();
            this.Text = "Transportadora - Cadastrar nova transportadora";

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
            this.Text = "Transportadora - Editar cadastro da transportadora";
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
            this.transportadora = cTransportadora.GetTransportadoraByID(id_transportadora);
            if (this.transportadora == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de transportadora.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Transportadora - Visualizar cadastro da transportadora";
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a transportadora: " + transportadora.nome_fantasia + "!", "Cadastro de transportadora.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                transportadora.excluido = true;
                if (cTransportadora.TransportadoraEditar(ref transportadora))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherTransportadora();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    transportadora.data_cadastro = Util.Util.GetDataServidor();
                    if (cTransportadora.TransportadoraCadastrar(ref transportadora))
                    {
                        this.id_transportadora = transportadora.id_transportadora;
                        txtCodigo.Text = transportadora.id_transportadora.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar a transportadora!", "Erro ao cadastrar transportadora.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cTransportadora.TransportadoraEditar(ref transportadora))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar a transportadora!", "Erro ao cadastrar transportadora.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PreencherTransportadora()
        {
            transportadora.data_cadastro = DateTime.Parse(txtDataCadastro.Text);

            if (rbFisica.Checked)
                transportadora.tipo_pessoa = "Fisica";
            else if (rbJuridica.Checked)
                transportadora.tipo_pessoa = "Juridica";

            transportadora.razao_social = txtRazaoSocial.Text;
            transportadora.nome_fantasia = txtNomeFantasia.Text;
            transportadora.cnpj = txtCNPJ.Text;

            if (rbJuridica.Checked)
            {
                if (chkInscrEstIsento.Checked)
                    transportadora.i_estadual = "Isento";
                else
                    transportadora.i_estadual = txtInscrEst.Text;
            }

            if (rbFisica.Checked)
            {
                transportadora.i_estadual = txtInscrEst.Text;
            }

            transportadora.i_municipal = txtInscrMun.Text;
            transportadora.telefone = txtTelefone.Text;
            transportadora.fax = txtFax.Text;
            transportadora.email = txtEmail.Text;

            transportadora.end_cep = txtEndCep.Text;
            transportadora.end_endereco = txtEndEndereco.Text;
            transportadora.end_numero = txtEndNumero.Text;
            transportadora.end_complemento = txtEndComplemento.Text;
            transportadora.end_bairro = txtEndBairro.Text;
            transportadora.end_cidade = txtEndCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                transportadora.end_estado = cbEndEstado.SelectedValue.ToString();

            if (cbEndMunicipio.SelectedValue != null)
                transportadora.end_municipio = cbEndMunicipio.SelectedValue.ToString();
            else
                transportadora.end_municipio = string.Empty;

            transportadora.ent_cep = txtEntCep.Text;
            transportadora.ent_endereco = txtEntEndereco.Text;
            transportadora.ent_numero = txtEntNumero.Text;
            transportadora.ent_complemento = txtEntComplemento.Text;
            transportadora.ent_bairro = txtEntBairro.Text;
            transportadora.ent_cidade = txtEntCidade.Text;

            if (cbEntEstado.SelectedValue != null)
                transportadora.ent_estado = cbEntEstado.SelectedValue.ToString();

            transportadora.cob_cep = txtCobCep.Text;
            transportadora.cob_endereco = txtCobEndereco.Text;
            transportadora.cob_numero = txtCobNumero.Text;
            transportadora.cob_complemento = txtCobComplemento.Text;
            transportadora.cob_bairro = txtCobBairro.Text;
            transportadora.cob_cidade = txtCobCidade.Text;

            if (cbCobEstado.SelectedValue != null)
                transportadora.cob_estado = cbCobEstado.SelectedValue.ToString();
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.transportadora.id_transportadora.ToString();
            txtDataCadastro.Text = this.transportadora.data_cadastro.ToString("dd/MM/yyyy");

            if (this.transportadora.tipo_pessoa == "Fisica")
                rbFisica.Checked = true;
            else if (this.transportadora.tipo_pessoa == "Juridica")
                rbJuridica.Checked = true;

            txtRazaoSocial.Text = this.transportadora.razao_social;
            txtNomeFantasia.Text = this.transportadora.nome_fantasia;
            txtCNPJ.Text = this.transportadora.cnpj;

            if (rbJuridica.Checked)
            {
                if (this.transportadora.i_estadual == "Isento")
                    chkInscrEstIsento.Checked = true;
                else
                    txtInscrEst.Text = this.transportadora.i_estadual;
            }

            txtInscrMun.Text = this.transportadora.i_municipal;
            txtTelefone.Text = this.transportadora.telefone;
            txtFax.Text = this.transportadora.fax;
            txtEmail.Text = this.transportadora.email;

            txtEndCep.Text = this.transportadora.end_cep;
            txtEndEndereco.Text = this.transportadora.end_endereco;
            txtEndNumero.Text = this.transportadora.end_numero;
            txtEndComplemento.Text = this.transportadora.end_complemento;
            txtEndBairro.Text = this.transportadora.end_bairro;
            txtEndCidade.Text = this.transportadora.end_cidade;

            if (!string.IsNullOrEmpty(this.transportadora.end_estado))
                cbEndEstado.SelectedValue = this.transportadora.end_estado;

            PreencherMunicipios();

            if (!string.IsNullOrEmpty(this.transportadora.end_municipio))
                cbEndMunicipio.SelectedValue = this.transportadora.end_municipio;
            
            txtEntCep.Text = this.transportadora.ent_cep;
            txtEntEndereco.Text = this.transportadora.ent_endereco;
            txtEntNumero.Text = this.transportadora.ent_numero;
            txtEntComplemento.Text = this.transportadora.ent_complemento;
            txtEntBairro.Text = this.transportadora.ent_bairro;
            txtEntCidade.Text = this.transportadora.ent_cidade;

            if (!string.IsNullOrEmpty(this.transportadora.ent_estado))
                cbEntEstado.SelectedValue = this.transportadora.ent_estado;

            txtCobCep.Text = this.transportadora.cob_cep;
            txtCobEndereco.Text = this.transportadora.cob_endereco;
            txtCobNumero.Text = this.transportadora.cob_numero;
            txtCobComplemento.Text = this.transportadora.cob_complemento;
            txtCobBairro.Text = this.transportadora.cob_bairro;
            txtCobCidade.Text = this.transportadora.cob_cidade;

            if (!string.IsNullOrEmpty(this.transportadora.cob_estado))
                cbCobEstado.SelectedValue = this.transportadora.cob_estado;

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
                if (cTransportadora.TransportadoraCnpjIsExist(txtCNPJ.Text))
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

        #region Transportadora Contato

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
            transportadora_contato = new transportadora_contato();
        }
        private void ContatoAdd()
        {
            transportadora_contato.nome = txtContatoNome.Text;
            transportadora_contato.cargo = txtContatoCargo.Text;
            transportadora_contato.descricao = txtContatoDescricao.Text;
            transportadora_contato.email = txtContatoEmail.Text;
            transportadora_contato.telefone = txtContatoTelefone.Text;
            transportadora_contato.celular = txtContatoCelular.Text;
            transportadora_contato.nextel = txtContatoNextel.Text;
            transportadora_contato.nextel_id = txtContatoNextelID.Text;
            transportadora_contato.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                transportadora_contato.id_transportadora = id_transportadora;
                cTransportadora.TransportadoraContatoCadastrar(transportadora_contato);
            }
        }

        private void ContatoAtualizaGrid()
        {
            gvContato.DataSource = cTransportadora.TransportadoraContatoProcurar(id_transportadora);
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o contato: " + transportadora_contato.nome + "!", "Cadastro de transportadora.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.transportadora_contato.excluido = true;

                cTransportadora.TransportadoraContatoEditar(this.transportadora_contato);
                ContatoAtualizaGrid();
                ContatoNovo();
            }
        }

        private void gvContato_DoubleClick(object sender, EventArgs e)
        {
            if (gvContato.CurrentRow == null)
                return;

            this.transportadora_contato = (transportadora_contato)gvContato.CurrentRow.DataBoundItem;
            txtContatoNome.Text = transportadora_contato.nome;
            txtContatoCargo.Text = transportadora_contato.cargo;
            txtContatoDescricao.Text = transportadora_contato.descricao;
            txtContatoEmail.Text = transportadora_contato.email;
            txtContatoTelefone.Text = transportadora_contato.telefone;
            txtContatoCelular.Text = transportadora_contato.celular;
            txtContatoNextel.Text = transportadora_contato.nextel;
            txtContatoNextelID.Text = transportadora_contato.nextel_id;
        }

        #endregion

        #region Transportadora Comentário
        private void ComentarioNovo()
        {
            txtComentarioComentario.Text = "";

            txtComentarioComentario.Focus();
            transportadora_comentario = new transportadora_comentario();
        }
        private void ComentarioAdd()
        {
            transportadora_comentario.comentario = txtComentarioComentario.Text;
            transportadora_comentario.data_cadastro = Util.Util.GetDataServidor();

            if (Acao == Util.Acao.Editar)
            {
                transportadora_comentario.id_transportadora = id_transportadora;
                cTransportadora.TransportadoraComentarioCadastrar(transportadora_comentario);
            }
        }

        private void ComentarioAtualizaGrid()
        {
            gvComentario.DataSource = cTransportadora.TransportadoraComentarioProcurar(id_transportadora);
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
