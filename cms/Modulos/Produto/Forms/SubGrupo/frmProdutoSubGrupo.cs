using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Produto.Forms.SubGrupo
{
    public partial class frmProdutoSubGrupo : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Produto.Cn.cnSubGrupo cProdutoSubGrupo = new cms.Modulos.Produto.Cn.cnSubGrupo();
        cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupo _fProdutoGrupo;

        private produto_subgrupo produto_subgrupo = new produto_subgrupo();

        public Util.Acao Acao { get; set; }
        public long id_subgrupo { get; set; }

        public cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupo fProdutoGrupo
        {
            set { _fProdutoGrupo = value; }
        }

        public frmProdutoSubGrupo()
        {
            InitializeComponent();
        }

        private void frmProdutoGrupo_Load(object sender, EventArgs e)
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
            this.produto_subgrupo = new produto_subgrupo();
            this.Text = "Sub-Grupo de Produto - Cadastrar novo sub-grupo de produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;
            txtGrupo.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            btGrupo.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Sub-Grupo de Produto - Editar cadastro de sub-grupo de produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;
            txtGrupo.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            btGrupo.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.produto_subgrupo = cProdutoSubGrupo.GetSubGrupoByID(id_subgrupo);

            if (this.produto_subgrupo == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Sub-Grupo de Produto - Visualizar cadastro de sub-grupo de produto";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            btGrupo.Enabled = false;

            TravaFormControles(this.Controls);
        }
        #endregion

        #region Menu Ação
        private void btFechar_Click(object sender, EventArgs e)
        {
            if (_fProdutoGrupo != null)
                _fProdutoGrupo.PreencherGridSubGrupo();

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
                PreencherGrupo();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cProdutoSubGrupo.SubGrupoCadastrar(ref produto_subgrupo))
                    {
                        this.id_subgrupo = produto_subgrupo.id_produto_subgrupo;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o sub-grupo de produto!", "Erro ao cadastrar sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cProdutoSubGrupo.SubGrupoEditar(ref produto_subgrupo))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o sub-grupo de produto!", "Erro ao cadastrar sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Sub-Grupo de Produto: " + produto_subgrupo.subgrupo + "!", "Cadastro de Sub-Grupo de Produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                produto_subgrupo.excluido = true;
                if (cProdutoSubGrupo.SubGrupoEditar(ref produto_subgrupo))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            txtGrupo.ReadOnly = true;
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            txtGrupo.ReadOnly = true;
            TelaModoCadastrarNovo();
        }

        private void PreencherGrupo()
        {
            produto_subgrupo.subgrupo = txtSubGrupo.Text;
            produto_subgrupo.id_produto_grupo = ((produto_grupo)txtGrupo.Tag).id_produto_grupo;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.produto_subgrupo.id_produto_subgrupo.ToString();
            txtSubGrupo.Text = this.produto_subgrupo.subgrupo;
            txtGrupo.Tag = this.produto_subgrupo.produto_grupo;
            txtGrupo.Text = this.produto_subgrupo.produto_grupo.id_produto_grupo + " - " + this.produto_subgrupo.produto_grupo.grupo;

        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (txtGrupo.Tag == null)
            {
                erro = true;
                txtGrupo.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtGrupo, "Campo grupo de produto é obrigatório.");
            }
            else
                txtGrupo.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtSubGrupo.Text))
            {
                erro = true;
                txtSubGrupo.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtGrupo, "Campo sub-grupo de produto é obrigatório.");
            }
            else
                txtSubGrupo.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion
        
        private void btGrupo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupoLockup fProdutoGrupoLockup = new cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupoLockup();

            if (fProdutoGrupoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var grupo = fProdutoGrupoLockup.GetGrupoSelecionado();

                txtGrupo.Tag = grupo;
                txtGrupo.Text = grupo.id_produto_grupo + " - " + grupo.grupo;

                fProdutoGrupoLockup.Close();
                fProdutoGrupoLockup.Dispose();
            }
            else
            {
                txtGrupo.Tag = null;
                txtGrupo.Text = string.Empty;
            }
        }
        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btGrupo_Click(sender, e);
            }
        }

    }
}
