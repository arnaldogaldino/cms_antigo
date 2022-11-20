using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Produto.Forms.SubFamilia
{
    public partial class frmProdutoSubFamilia : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Produto.Cn.cnSubFamilia cProdutoSubFamilia = new cms.Modulos.Produto.Cn.cnSubFamilia();
        cms.Modulos.Produto.Forms.Familia.frmProdutoFamilia _fProdutoFamilia;

        private produto_subfamilia produto_subfamilia = new produto_subfamilia();

        public Util.Acao Acao { get; set; }
        public long id_subfamilia { get; set; }

        public cms.Modulos.Produto.Forms.Familia.frmProdutoFamilia fProdutoFamilia
        {
            set { _fProdutoFamilia = value; }
        }

        public frmProdutoSubFamilia()
        {
            InitializeComponent();
        }

        private void frmProdutoFamilia_Load(object sender, EventArgs e)
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
            this.produto_subfamilia = new produto_subfamilia();
            this.Text = "Sub-Familia de Produto - Cadastrar novo sub-familia de produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;
            txtFamilia.ReadOnly = true;

            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            txtFamilia.ReadOnly = true;

            btGrupo.Enabled = true;
            btSubGrupo.Enabled = true;
            btFamilia.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            btFamilia.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Sub-Familia de Produto - Editar cadastro de sub-familia de produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;
            txtFamilia.ReadOnly = true;

            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            txtFamilia.ReadOnly = true;

            btGrupo.Enabled = true;
            btSubGrupo.Enabled = true;
            btFamilia.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            btFamilia.Enabled = true;
        }
        private void TelaModoVisualizar()
        {
            this.produto_subfamilia = cProdutoSubFamilia.GetSubFamiliaByID(id_subfamilia);

            if (this.produto_subfamilia == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de sub-familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Sub-Familia de Produto - Visualizar cadastro de sub-familia de produto";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            txtFamilia.ReadOnly = true;

            btGrupo.Enabled = false;
            btSubGrupo.Enabled = false;
            btFamilia.Enabled = false;
            
            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
            
            btFamilia.Enabled = false;

            TravaFormControles(this.Controls);
        }
        #endregion

        #region Menu Ação
        public void btFechar_Click(object sender, EventArgs e)
        {
            if (_fProdutoFamilia != null)
                _fProdutoFamilia.PreencherGridSubFamilia();

            this.Close();
        }

        public void btCancelar_Click(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Editar)
                this.TelaModoVisualizar();
        }

        public void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherFamilia();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cProdutoSubFamilia.SubFamiliaCadastrar(ref produto_subfamilia))
                    {
                        this.id_subfamilia = produto_subfamilia.id_produto_subfamilia;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o sub-familia de produto!", "Erro ao cadastrar sub-familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cProdutoSubFamilia.SubFamiliaEditar(ref produto_subfamilia))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o sub-familia de produto!", "Erro ao cadastrar sub-familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Sub-Familia de Produto: " + produto_subfamilia.subfamilia + "!", "Cadastro de Sub-Familia de Produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                produto_subfamilia.excluido = true;
                if (cProdutoSubFamilia.SubFamiliaEditar(ref produto_subfamilia))
                    TelaModoCadastrarNovo();
            }
        }

        public void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            txtFamilia.ReadOnly = true;
            TelaModoEditar();
        }

        public void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            txtFamilia.ReadOnly = true;
            TelaModoCadastrarNovo();
        }
        
        private void PreencherFamilia()
        {
            produto_subfamilia.subfamilia = txtSubFamilia.Text;
            produto_subfamilia.id_produto_familia = ((produto_familia)txtFamilia.Tag).id_produto_familia;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.produto_subfamilia.id_produto_subfamilia.ToString();
            
            txtSubFamilia.Text = this.produto_subfamilia.subfamilia;

            txtGrupo.Tag = this.produto_subfamilia.produto_familia.produto_subgrupo.produto_grupo;
            txtGrupo.Text = this.produto_subfamilia.produto_familia.produto_subgrupo.id_produto_grupo + " - " + this.produto_subfamilia.produto_familia.produto_subgrupo.produto_grupo.grupo;

            txtSubGrupo.Tag = this.produto_subfamilia.produto_familia.produto_subgrupo;
            txtSubGrupo.Text = this.produto_subfamilia.produto_familia.produto_subgrupo.id_produto_grupo + " - " + this.produto_subfamilia.produto_familia.produto_subgrupo.subgrupo;

            txtFamilia.Tag = this.produto_subfamilia.produto_familia;
            txtFamilia.Text = this.produto_subfamilia.produto_familia.id_produto_familia + " - " + this.produto_subfamilia.produto_familia.familia;
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (txtFamilia.Tag == null)
            {
                erro = true;
                txtFamilia.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtFamilia, "Campo familia de produto é obrigatório.");
            }
            else
                txtFamilia.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtSubFamilia.Text))
            {
                erro = true;
                txtSubFamilia.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtFamilia, "Campo sub-familia de produto é obrigatório.");
            }
            else
                txtSubFamilia.BackColor = DefaultBackColor;

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

            txtSubGrupo.Text = string.Empty;
            txtFamilia.Text = string.Empty;
            txtSubFamilia.Text = string.Empty;

            txtSubGrupo.Tag = null;
            txtFamilia.Tag = null;
            txtSubFamilia.Tag = null;
        }
        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btGrupo_Click(sender, e);
            }
        }

        private void btSubGrupo_Click(object sender, EventArgs e)
        {
            if (txtGrupo.Tag == null)
            {
                MessageBox.Show(null, "Grupo não foi selecionado!", "Cadastro de sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupoLockup fProdutoSubGrupoLockup = new cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupoLockup((produto_grupo)txtGrupo.Tag);

            if (fProdutoSubGrupoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var subgrupo = fProdutoSubGrupoLockup.GetSubGrupoSelecionado();

                txtSubGrupo.Tag = subgrupo;
                txtSubGrupo.Text = subgrupo.id_produto_subgrupo + " - " + subgrupo.subgrupo;

                fProdutoSubGrupoLockup.Close();
                fProdutoSubGrupoLockup.Dispose();
            }
            else
            {
                txtSubGrupo.Tag = null;
                txtSubGrupo.Text = string.Empty;
            }

            txtFamilia.Text = string.Empty;
            txtSubFamilia.Text = string.Empty;

            txtFamilia.Tag = null;
            txtSubFamilia.Tag = null;
        }
        private void txtSubGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btSubGrupo_Click(sender, e);
            }
        }

        private void btFamilia_Click(object sender, EventArgs e)
        {
            if (txtGrupo.Tag == null)
            {
                MessageBox.Show(null, "Sub-Grupo não foi selecionado!", "Cadastro de sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup fProdutoFamiliaLockup = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup((produto_subgrupo)txtSubGrupo.Tag);

            if (fProdutoFamiliaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var familia = fProdutoFamiliaLockup.GetFamiliaSelecionado();

                txtFamilia.Tag = familia;
                txtFamilia.Text = familia.id_produto_familia + " - " + familia.familia;

                fProdutoFamiliaLockup.Close();
                fProdutoFamiliaLockup.Dispose();
            }
            else
            {
                txtFamilia.Tag = null;
                txtFamilia.Text = string.Empty;
            }

            txtSubFamilia.Text = string.Empty;
            txtSubFamilia.Tag = null;
        }
        private void txtFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFamilia_Click(sender, e);
            }
        }

    }
}
