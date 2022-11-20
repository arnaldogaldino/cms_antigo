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

namespace cms.Modulos.Produto.Forms.SubGrupo
{
    public partial class frmProdutoSubGrupoLockup : cms.Modulos.Util.WindowBase
    {
        produto_subgrupo produto_subgrupo = new produto_subgrupo();
        cms.Modulos.Produto.Cn.cnSubGrupo cSubGrupo = new cms.Modulos.Produto.Cn.cnSubGrupo();
        IQueryable<vw_produto_subgrupo> subgrupos;
        Thread threadPreencherGrid;

        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoSubGrupoLockup(produto_grupo grupo)
        {
            InitializeComponent();

            if (grupo == null)
            {
                MessageBox.Show(null, "Grupo não foi selecionado!", "Cadastro de sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                this.Dispose();
            }
            else
            {
                txtGrupo.Tag = grupo;
                txtGrupo.Text = grupo.id_produto_grupo + " - " + grupo.grupo;
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvProdutoSubGrupo);
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

        private void gvProdutoSubGrupo_DoubleClick(object sender, EventArgs e)
        {
            SelecionarSubGrupo();
        }

        private void AtualizarGvProdutoSubGrupo()
        {
            long? id_grupo = null;
            long? id_subgrupo = null;
            string subgrupo = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_subgrupo = long.Parse(txtCodigo.Text);

            if (txtGrupo.InvokeRequired)
                if (txtGrupo.Tag != null)
                    id_grupo = ((produto_grupo)txtGrupo.Tag).id_produto_grupo;
                    
            if (txtSubGrupo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtSubGrupo.Text))
                    subgrupo = txtSubGrupo.Text;
                    
            try
            {
                subgrupos = cSubGrupo.SubGrupoProcurar(id_subgrupo, id_grupo, subgrupo);
            }
            catch { }

            if (gvProdutoSubGrupo.InvokeRequired)
                gvProdutoSubGrupo.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
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

        private void SelecionarSubGrupo()
        {
            if (gvProdutoSubGrupo.CurrentRow == null)
                return;

            produto_subgrupo = cSubGrupo.GetSubGrupoByID(((vw_produto_subgrupo)gvProdutoSubGrupo.CurrentRow.DataBoundItem).id_produto_subgrupo);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public produto_subgrupo GetSubGrupoSelecionado()
        {
            return produto_subgrupo;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarSubGrupo();
        }
    }
}
