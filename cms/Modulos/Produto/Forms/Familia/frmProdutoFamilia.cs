using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Produto.Forms.Familia
{

    public partial class frmProdutoFamilia : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnFamilia cProdutoFamilia = new cms.Modulos.Produto.Cn.cnFamilia();

        private produto_familia produto_familia = new produto_familia();

        cms.Modulos.Produto.Cn.cnSubFamilia cSubFamilia = new cms.Modulos.Produto.Cn.cnSubFamilia();

        IQueryable<vw_produto_subfamilia> subfamilias;
        Thread threadPreencherGrid;

        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public Util.Acao Acao { get; set; }
        public long id_familia { get; set; }

        public frmProdutoFamilia()
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
            this.produto_familia = new produto_familia();
            this.Text = "Familia de Produto - Cadastrar novo familia de produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            
            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            
            btGrupo.Enabled = true;
            btSubGrupo.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelarAcao.Enabled = false;
            btFechar.Enabled = true;

            PreencherGridSubFamilia();
        }
        private void TelaModoEditar()
        {
            this.Text = "Familia de Produto - Editar cadastro de familia de produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;

            btGrupo.Enabled = true;
            btSubGrupo.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelarAcao.Enabled = true;
            btFechar.Enabled = true;

            if(this.FormIsValid)
                PreencherGridSubFamilia();
        }
        private void TelaModoVisualizar()
        {
            this.produto_familia = cProdutoFamilia.GetFamiliaByID(id_familia);

            if (this.produto_familia == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Familia de Produto - Visualizar cadastro de familia de produto";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            txtCodigo.ReadOnly = true;
            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            btGrupo.Enabled = false;
            btSubGrupo.Enabled = false;

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelarAcao.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);

            PreencherGridSubFamilia();
        }
        #endregion

        #region Menu Ação
        private void btFechar_Click(object sender, EventArgs e)
        {
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
                PreencherFamilia();
    
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cProdutoFamilia.FamiliaCadastrar(ref produto_familia))
                    {
                        this.id_familia = produto_familia.id_produto_familia;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o familia de produto!", "Erro ao cadastrar familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cProdutoFamilia.FamiliaEditar(ref produto_familia))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o familia de produto!", "Erro ao cadastrar familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Familia de Produto: " + produto_familia.familia + "!", "Cadastro de Familia de Produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                produto_familia.excluido = true;
                if (cProdutoFamilia.FamiliaEditar(ref produto_familia))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoCadastrarNovo();
        }

        private void PreencherFamilia()
        {

            if(txtSubGrupo.Tag != null)
                produto_familia.id_produto_subgrupo = ((produto_subgrupo)txtSubGrupo.Tag).id_produto_subgrupo;
            
            produto_familia.familia = txtFamilia.Text;

        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.produto_familia.id_produto_familia.ToString();
            
            txtGrupo.Text = this.produto_familia.produto_subgrupo.produto_grupo.id_produto_grupo + " - " + this.produto_familia.produto_subgrupo.produto_grupo.grupo;
            txtGrupo.Tag = this.produto_familia.produto_subgrupo.produto_grupo;

            txtSubGrupo.Text = this.produto_familia.produto_subgrupo.id_produto_subgrupo + " - " + this.produto_familia.produto_subgrupo.subgrupo;
            txtSubGrupo.Tag = this.produto_familia.produto_subgrupo;

            txtFamilia.Text = this.produto_familia.familia;
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (string.IsNullOrEmpty(txtFamilia.Text))
            {
                erro = true;
                txtFamilia.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtFamilia, "Campo familia de produto é obrigatório.");
            }
            else
                txtFamilia.BackColor = DefaultBackColor;

            if (txtSubGrupo.Tag == null)
            {
                erro = true;
                txtFamilia.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtSubGrupo, "Campo subgrupo de produto é obrigatório.");
            }
            else
                txtFamilia.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        #region SugFamilia

        public void PreencherGridSubFamilia()
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
            }

            threadPreencherGrid = new Thread(AtualizarGvProdutoSubFamilia);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        void btCancelarThread_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void gvProdutoSubFamilia_DoubleClick(object sender, EventArgs e)
        {
            if (gvProdutoSubFamilia.CurrentRow == null)
                return;

            vw_produto_subfamilia produto_subfamilia = (vw_produto_subfamilia)gvProdutoSubFamilia.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamilia fProdutoSubFamilia = new cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamilia();

            fProdutoSubFamilia.id_subfamilia = produto_subfamilia.id_produto_subfamilia;
            fProdutoSubFamilia.Acao = Util.Acao.Visualizar;
            fProdutoSubFamilia.fProdutoFamilia = this;
            fProdutoSubFamilia.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoSubFamilia.MdiParent = this;
                fProdutoSubFamilia.Show();
            }
            else
                fProdutoSubFamilia.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvProdutoSubFamilia()
        {
            try
            {
                subfamilias = cSubFamilia.SubFamiliaProcurar(null, produto_familia.id_produto_familia, null,null, null);
            }
            catch { }

            if (gvProdutoSubFamilia.InvokeRequired)
                gvProdutoSubFamilia.Invoke(new MethodInvoker(PreencherSubFamilia));
        }

        public void PreencherSubFamilia()
        {
            gvProdutoSubFamilia.AutoGenerateColumns = false;
            gvProdutoSubFamilia.DataSource = subfamilias;
            gvProdutoSubFamilia.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
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
        }
        private void txtSubGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btSubGrupo_Click(sender, e);
            }
        }
    }

}
