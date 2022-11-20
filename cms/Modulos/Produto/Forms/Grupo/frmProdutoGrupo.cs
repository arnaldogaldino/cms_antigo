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

namespace cms.Modulos.Produto.Forms.Grupo
{

    public partial class frmProdutoGrupo : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnGrupo cProdutoGrupo = new cms.Modulos.Produto.Cn.cnGrupo();

        private produto_grupo produto_grupo = new produto_grupo();

        cms.Modulos.Produto.Cn.cnSubGrupo cSubGrupo = new cms.Modulos.Produto.Cn.cnSubGrupo();

        IQueryable<vw_produto_subgrupo> subgrupos;
        Thread threadPreencherGrid;

        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public Util.Acao Acao { get; set; }
        public long id_grupo { get; set; }

        public frmProdutoGrupo()
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
            this.produto_grupo = new produto_grupo();
            this.Text = "Grupo de Produto - Cadastrar novo grupo de produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelarAcao.Enabled = false;
            btFechar.Enabled = true;

            PreencherGridSubGrupo();
        }
        private void TelaModoEditar()
        {
            this.Text = "Grupo de Produto - Editar cadastro de grupo de produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelarAcao.Enabled = true;
            btFechar.Enabled = true;

            if(this.FormIsValid)
                PreencherGridSubGrupo();
        }
        private void TelaModoVisualizar()
        {
            this.produto_grupo = cProdutoGrupo.GetGrupoByID(id_grupo);

            if (this.produto_grupo == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Grupo de Produto - Visualizar cadastro de grupo de produto";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelarAcao.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);

            PreencherGridSubGrupo();
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
                PreencherGrupo();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cProdutoGrupo.GrupoCadastrar(ref produto_grupo))
                    {
                        this.id_grupo = produto_grupo.id_produto_grupo;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o grupo de produto!", "Erro ao cadastrar grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cProdutoGrupo.GrupoEditar(ref produto_grupo))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o grupo de produto!", "Erro ao cadastrar grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Grupo de Produto: " + produto_grupo.grupo + "!", "Cadastro de Grupo de Produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                produto_grupo.excluido = true;
                if (cProdutoGrupo.GrupoEditar(ref produto_grupo))
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

        private void PreencherGrupo()
        {
            produto_grupo.grupo = txtGrupo.Text;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.produto_grupo.id_produto_grupo.ToString();
            txtGrupo.Text = this.produto_grupo.grupo;
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (string.IsNullOrEmpty(txtGrupo.Text))
            {
                erro = true;
                txtGrupo.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtGrupo, "Campo grupo de produto é obrigatório.");
            }
            else
                txtGrupo.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        #region SugGrupo

        public void PreencherGridSubGrupo()
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                //load.LoadHide(this);
            }

            //load.btCancelar.Click += new EventHandler(btCancelarThread_Click);
            //load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvProdutoSubGrupo);
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

        private void gvProdutoSubGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (gvProdutoSubGrupo.CurrentRow == null)
                return;

            vw_produto_subgrupo produto_subgrupo = (vw_produto_subgrupo)gvProdutoSubGrupo.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupo fProdutoSubGrupo = new cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupo();

            fProdutoSubGrupo.id_subgrupo = produto_subgrupo.id_produto_subgrupo;
            fProdutoSubGrupo.Acao = Util.Acao.Visualizar;
            fProdutoSubGrupo.fProdutoGrupo = this;
            fProdutoSubGrupo.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoSubGrupo.MdiParent = this;
                fProdutoSubGrupo.Show();
            }
            else
                fProdutoSubGrupo.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvProdutoSubGrupo()
        {
            //if (gvProdutoSubGrupo.InvokeRequired)
            //    this.gvProdutoSubGrupo.

            //if (gbGrupo.InvokeRequired)
            //    this.gbGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //                | System.Windows.Forms.AnchorStyles.Left)
            //                | System.Windows.Forms.AnchorStyles.Right)));

            try
            {
                subgrupos = cSubGrupo.SubGrupoProcurar(null, produto_grupo.id_produto_grupo, null);
            }
            catch { }

            if (gvProdutoSubGrupo.InvokeRequired)
                gvProdutoSubGrupo.Invoke(new MethodInvoker(PreencherSubGrupo));

        }

        public void PreencherSubGrupo()
        {
            gvProdutoSubGrupo.AutoGenerateColumns = false;
            gvProdutoSubGrupo.DataSource = subgrupos;
            gvProdutoSubGrupo.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        #endregion

    }

}
