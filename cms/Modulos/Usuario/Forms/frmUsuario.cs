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
using cms.Modulos.Usuario.Cn;

namespace cms.Modulos.Usuario.Forms
{
    public partial class frmUsuario : cms.Modulos.Util.WindowBase
    {
        private cnUsuario cUsuario = new cnUsuario();

        private usuario oUsuario = new usuario();

        public Util.Acao Acao { get; set; }
        public long id_usuario { get; set; }
        
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
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
            this.oUsuario = new usuario();
            this.Text = "Usuário - Cadastrar novo usuário";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataCadastro.ReadOnly = true;

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
            this.Text = "Usuário - Editar cadastro do usuário";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

        }
        private void TelaModoVisualizar()
        {
            this.oUsuario = cUsuario.GetUsuarioByID(id_usuario);
            if (this.oUsuario == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de usuário.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Usuário - Visualizar cadastro do usuário";
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n a Usuário: " + oUsuario.nome + "!", "Cadastro de usuário.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                oUsuario.excluido = true;
                if (cUsuario.UsuarioEditar(ref oUsuario))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            ValidForm();
            if (FormIsValid)
                PreencherUsuario();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    oUsuario.data_cadastro = Util.Util.sp_getdatetime();
                    if (cUsuario.UsuarioCadastrar(ref oUsuario))
                    {
                        this.id_usuario = oUsuario.id_usuario;
                        txtCodigo.Text = oUsuario.id_usuario.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o usuário!", "Erro ao cadastrar usuário.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cUsuario.UsuarioEditar(ref oUsuario))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o usuário!", "Erro ao cadastrar usuário.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PreencherUsuario()
        {
            oUsuario.data_cadastro = DateTime.Parse(txtDataCadastro.Text);

            oUsuario.nome = txtNome.Text;
            oUsuario.usuario1 = txtUsuario.Text;
            oUsuario.senha = txtSenha.Text;
            oUsuario.email = txtEmail.Text;
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = this.oUsuario.id_usuario.ToString();
            txtDataCadastro.Text = this.oUsuario.data_cadastro.ToString("dd/MM/yyyy");

            txtNome.Text = this.oUsuario.nome;
            txtUsuario.Text = this.oUsuario.usuario1;
            txtSenha.Text = this.oUsuario.senha;
            txtEmail.Text = this.oUsuario.email;

            tvPermissao.Nodes.Clear();
            PreencherPermissao();
        }
        #endregion
        
        #region Validação de Formulario
        private void ValidForm()
        {
            bool erro = false;
            if (Acao == Util.Acao.Cadastrar)
            {
                if (cUsuario.UsuarioIsExist(txtUsuario.Text))
                {
                    erro = true;
                    txtUsuario.BackColor = CorCampoInvalido;
                    this.ValidarForm.SetToolTip(this.txtUsuario, "Campo usuário já cadastrado.");
                }
                else
                    txtUsuario.BackColor = DefaultBackColor;
            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erro = true;
                txtUsuario.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtUsuario, "Campo usuário e obrigatório.");
            }
            else
                txtUsuario.BackColor = DefaultBackColor;
            
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                erro = true;
                txtNome.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtUsuario, "Campo nome e obrigatório.");
            }
            else
                txtUsuario.BackColor = DefaultBackColor;
            
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                erro = true;
                txtEmail.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtEmail, "Campo e-mail e obrigatório.");
            }
            else
                txtEmail.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                erro = true;
                txtSenha.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtSenha, "Campo senha e obrigatório.");
            }
            else
                txtSenha.BackColor = DefaultBackColor;

            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;
        }
        #endregion

        #region Validação de Formulario
        private void PreencherPermissao()
        {
            var menus = cUsuario.GetMenus();
            
            AddNote(menus.Where(o => o.id_menu_pai == null));
        }

        private void AddNote(IQueryable<menu> mnu)
        {
            foreach (var m in mnu)
            {
                TreeNode t = tvPermissao.Nodes.Add(m.id_menu.ToString(), m.texto);
                t.Tag = m.id_menu;

                if (cUsuario.UsuarioPermissaoMenu(oUsuario.id_usuario, m.id_menu))
                    t.Checked = true;

                AddNote(m.menu1.AsQueryable(), t);
                AddNoteDetalhe(m.menu_detalhe.AsQueryable(), t);
            }
        }

        private void AddNote(IQueryable<menu> mnu, TreeNode tn)
        {
            foreach (var m in mnu)
            {
                TreeNode t = tn.Nodes.Add(m.id_menu.ToString(), m.texto);
                t.Tag = m.id_menu;

                if (cUsuario.UsuarioPermissaoMenu(oUsuario.id_usuario, m.id_menu))
                    t.Checked = true;

                AddNote(m.menu1.AsQueryable(), t);
                AddNoteDetalhe(m.menu_detalhe.AsQueryable(), t);
            }
        }

        private void AddNoteDetalhe(IQueryable<menu_detalhe> mnu, TreeNode tn)
        {
            foreach (var m in mnu)
            {
                TreeNode t = tn.Nodes.Add(m.id_menu_detalhe.ToString(), m.descricao);
                t.Tag = m.id_menu_detalhe;
                t.ToolTipText = "Detalhe";

                if (cUsuario.UsuarioPermissaoMenuDetalhe(oUsuario.id_usuario, m.id_menu_detalhe))
                    t.Checked = true;                
            }
        }

        private void tvPermissao_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    if (e.Node.Checked)
                        if(e.Node.ToolTipText != "Detalhe")
                            cUsuario.AddPermissaoMenu(oUsuario, cUsuario.GetMenuByID(long.Parse(e.Node.Nodes[i].Tag.ToString())));
                        else
                            cUsuario.AddPermissaoMenuDetalhe(oUsuario, cUsuario.GetMenuDetalheByID(long.Parse(e.Node.Nodes[i].Tag.ToString())));
                    else
                        if (e.Node.ToolTipText != "Detalhe")
                            cUsuario.RemPermissaoMenu(oUsuario, cUsuario.GetMenuByID(long.Parse(e.Node.Nodes[i].Tag.ToString())));
                        else
                            cUsuario.RemPermissaoMenuDetalhe(oUsuario, cUsuario.GetMenuDetalheByID(long.Parse(e.Node.Nodes[i].Tag.ToString())));

                    e.Node.Nodes[i].Checked = e.Node.Checked;
                }

                if (e.Node.Checked)
                {
                    if (e.Node.Parent != null && e.Node.Parent.ToolTipText != "Detalhe")
                    {
                        e.Node.Parent.Checked = true;
                        cUsuario.AddPermissaoMenu(oUsuario, cUsuario.GetMenuByID(long.Parse(e.Node.Parent.Tag.ToString())));
                    }
                    else if (e.Node.Parent != null && e.Node.Parent.ToolTipText == "Detalhe")
                    {
                        e.Node.Parent.Checked = true;
                        cUsuario.AddPermissaoMenuDetalhe(oUsuario, cUsuario.GetMenuDetalheByID(long.Parse(e.Node.Parent.Tag.ToString())));
                    }

                    if (e.Node.ToolTipText != "Detalhe")
                    {
                        cUsuario.AddPermissaoMenu(oUsuario, cUsuario.GetMenuByID(long.Parse(e.Node.Tag.ToString())));
                    }
                    else
                    {
                        cUsuario.AddPermissaoMenuDetalhe(oUsuario, cUsuario.GetMenuDetalheByID(long.Parse(e.Node.Tag.ToString())));
                    }
                }
                else
                {
                    if (e.Node.Parent != null && e.Node.Parent.ToolTipText != "Detalhe")
                    {
                        e.Node.Parent.Checked = false;
                        cUsuario.RemPermissaoMenu(oUsuario, cUsuario.GetMenuByID(long.Parse(e.Node.Parent.Tag.ToString())));
                    }
                    else if (e.Node.Parent != null && e.Node.Parent.ToolTipText == "Detalhe")
                    {
                        e.Node.Parent.Checked = false;
                        cUsuario.RemPermissaoMenuDetalhe(oUsuario, cUsuario.GetMenuDetalheByID(long.Parse(e.Node.Parent.Tag.ToString())));
                    }

                    if (e.Node.ToolTipText != "Detalhe")
                    {
                        cUsuario.RemPermissaoMenu(oUsuario, cUsuario.GetMenuByID(long.Parse(e.Node.Tag.ToString())));
                    }
                    else
                    {
                        cUsuario.RemPermissaoMenuDetalhe(oUsuario, cUsuario.GetMenuDetalheByID(long.Parse(e.Node.Tag.ToString())));
                    }
                }
            }
        }

        #endregion

    }
}

