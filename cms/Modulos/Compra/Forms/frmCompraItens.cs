using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using System.Threading;
using cms.Modulos.Produto.Cn;
using cms.Modulos.Compra.Cn;

namespace cms.Modulos.Compra.Forms
{
    public partial class frmCompraItens : cms.Modulos.Util.WindowBase
    {
        public long id_compra = 0;

        cnProduto cProduto = new cnProduto();
        cnCompra cCompra = new cnCompra();
        compra oCompra = new compra();

        IQueryable<vw_produto> produtos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmCompraItens()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
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


            for (int i = 0; i < gvProduto.Rows.Count; i++)
            {
                vw_produto p = (vw_produto)gvProduto.Rows[i].DataBoundItem;

                if (cCompra.ProdutoExistItem(id_compra, p.id_produto))
                {
                    gvProduto.Rows[i].Cells[0].Value = true;
                    gvProduto.Rows[i].Cells[0].ReadOnly = true;
                }
                else
                {
                    gvProduto.Rows[i].Cells[0].Value = false;
                    gvProduto.Rows[i].Cells[0].ReadOnly = false;
                }
            }

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

            txtSubGrupo.Tag = null;
            txtSubGrupo.Text = string.Empty;

            txtFamilia.Tag = null;
            txtFamilia.Text = string.Empty;

            txtSubFamilia.Tag = null;
            txtSubFamilia.Text = string.Empty;
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

            txtFamilia.Tag = null;
            txtFamilia.Text = string.Empty;

            txtSubFamilia.Tag = null;
            txtSubFamilia.Text = string.Empty;

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
            if (txtSubGrupo.Tag == null)
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

            txtSubFamilia.Tag = null;
            txtSubFamilia.Text = string.Empty;

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

        private void frmCompraItens_Load(object sender, EventArgs e)
        {
            chkTodos = new CheckBox();
            //Get the column header cell bounds
            Rectangle rect =
                this.gvProduto.GetCellDisplayRectangle(-1, -1, true);

            chkTodos.Size = new Size(14, 14);
            //Change the location of the CheckBox to make it stay on the header
            chkTodos.Location = new Point(rect.Location.X + 3, rect.Location.Y + 10);

            chkTodos.CheckedChanged += new EventHandler(chkTodos_CheckedChanged);
            //Add the CheckBox into the DataGridView
            this.gvProduto.Controls.Add(chkTodos);
            
            oCompra = cCompra.GetCompraByID(id_compra);

            cbFilial.Enabled = false;
            cbFilial.SetSelectedValue(oCompra.id_empresa.ToString());
        }
        CheckBox chkTodos;
        void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.gvProduto.RowCount; j++)
            {
                if(this.gvProduto[0, j].ReadOnly == false)
                    this.gvProduto[0, j].Value = this.chkTodos.Checked;
            }
            this.gvProduto.EndEdit();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            List<long> lId_produto = new List<long>();
            
            gvProduto.CommitEdit(DataGridViewDataErrorContexts.Commit);
            gvProduto.EndEdit();

            for (int i = 0; i < gvProduto.RowCount; i++)
            {
                if (bool.Parse(gvProduto.Rows[i].Cells[0].EditedFormattedValue.ToString()) == true)
                    lId_produto.Add(((vw_produto)gvProduto.Rows[i].DataBoundItem).id_produto);
            }

            cCompra.CompraItensCadastrar(id_compra, lId_produto);

            MessageBox.Show(null, "Itens incluidos com sucesso!", "Itens da compra.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
    }
}
