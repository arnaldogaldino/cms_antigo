using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Modulos.Produto.Cn;
using cms.Data;
using System.Threading;

namespace cms.Modulos.Produto.Forms.Produto
{
    public partial class frmProdutoList : cms.Modulos.Util.WindowBase
    {
        cnProduto cProduto = new cnProduto();

        IQueryable<vw_produto> produtos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmProdutoList()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Produto.frmProduto fProduto = new cms.Modulos.Produto.Forms.Produto.frmProduto();

            fProduto.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProduto.MdiParent = this;
                fProduto.Show();
            }
            else
                fProduto.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        public void btPesquisar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvProduto);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        void btCancelar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void gvProduto_DoubleClick(object sender, EventArgs e)
        {
            if (gvProduto.CurrentRow == null)
                return;

            vw_produto oProduto = (vw_produto)gvProduto.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.Produto.frmProduto fProduto = new cms.Modulos.Produto.Forms.Produto.frmProduto();

            fProduto.id_produto = oProduto.id_produto;
            fProduto.Acao = Util.Acao.Visualizar;
            fProduto.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProduto.MdiParent = this;
                fProduto.Show();
            }
            else
                fProduto.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvProduto()
        {
            long? id_produto = null;
            long? id_produto_grupo = null;
            long? id_produto_subgrupo = null;
            long? id_produto_familia = null;
            long? id_produto_subfamilia = null;
            long? id_empresa = null;
            long? id_produto_preco_tabela = null;
            string descricao = string.Empty;
            string referencia = string.Empty;
            string codigo_barra = string.Empty;
            string codigo_barra_fornecedor = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_produto = long.Parse(txtCodigo.Text);

            if (cbFilial.InvokeRequired)
                if (!string.IsNullOrEmpty(cbFilial.GetSelectedValue()))
                    id_empresa = long.Parse(cbFilial.GetSelectedValue());

            if (txtGrupo.InvokeRequired)
                if (txtGrupo.Tag != null)
                    id_produto_grupo = ((produto_grupo)txtGrupo.Tag).id_produto_grupo;

            if (txtSubGrupo.InvokeRequired)
                if (txtSubGrupo.Tag != null)
                    id_produto_subgrupo = ((produto_subgrupo)txtSubGrupo.Tag).id_produto_subgrupo;

            if (txtFamilia.InvokeRequired)
                if (txtFamilia.Tag != null)
                    id_produto_familia = ((produto_familia)txtFamilia.Tag).id_produto_familia;

            if (txtSubFamilia.InvokeRequired)
                if (txtSubFamilia.Tag != null)
                    id_produto_subfamilia = ((produto_subfamilia)txtSubFamilia.Tag).id_produto_subfamilia;
            
            if (txtProdutoPrecoTabela.InvokeRequired)
                if (txtProdutoPrecoTabela.Tag != null)
                    id_produto_preco_tabela = ((produto_preco_tabela)txtProdutoPrecoTabela.Tag).id_produto_preco_tabela;
            
            try
            {
                 produtos = cProduto.ProdutoProcurar(id_produto, id_produto_grupo, id_produto_subgrupo, id_produto_familia, id_produto_subfamilia, id_empresa, id_produto_preco_tabela, descricao, referencia, codigo_barra, codigo_barra_fornecedor);
            }
            catch { }

            if (gvProduto.InvokeRequired)
                gvProduto.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
        {
            gvProduto.AutoGenerateColumns = false;
            gvProduto.DataSource = produtos;
            gvProduto.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }
               
        #region Lookups

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

        private void btSubFamilia_Click(object sender, EventArgs e)
        {
            if (txtFamilia.Tag == null)
            {
                MessageBox.Show(null, "Familia não foi selecionada!", "Cadastro de sub-familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamiliaLockup fProdutoSubFamiliaLockup = new cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamiliaLockup((produto_familia)txtFamilia.Tag);

            if (fProdutoSubFamiliaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var subfamilia = fProdutoSubFamiliaLockup.GetSubFamiliaSelecionado();

                txtSubFamilia.Tag = subfamilia;
                txtSubFamilia.Text = subfamilia.id_produto_subfamilia + " - " + subfamilia.subfamilia;

                fProdutoSubFamiliaLockup.Close();
                fProdutoSubFamiliaLockup.Dispose();
            }
            else
            {
                txtSubFamilia.Tag = null;
                txtSubFamilia.Text = string.Empty;
            }
        }
        private void txtSubFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btSubFamilia_Click(sender, e);
            }
        }
        
        private void btProdutoPrecoTabela_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaLockup fProdutoPrecoTabelaLockup = new cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaLockup();

            if (fProdutoPrecoTabelaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var tabela = fProdutoPrecoTabelaLockup.GetPrecoTabelaSelecionado();

                txtProdutoPrecoTabela.Tag = tabela;
                txtProdutoPrecoTabela.Text = tabela.id_produto_preco_tabela + " - " + tabela.preco_tabela;

                fProdutoPrecoTabelaLockup.Close();
                fProdutoPrecoTabelaLockup.Dispose();
            }
            else
            {
                txtProdutoPrecoTabela.Tag = null;
                txtProdutoPrecoTabela.Text = string.Empty;
            }
        }
        private void txtProdutoPrecoTabela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btProdutoPrecoTabela_Click(sender, e);
            }
        }
        
        #endregion

        private void frmProdutoList_Load(object sender, EventArgs e)
        {
            colFoto.DefaultCellStyle.NullValue = global::cms.Properties.Resources.preview;
        }
        
    }
}
