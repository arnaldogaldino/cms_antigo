using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using cms.Data;

namespace cms.Modulos.Produto.Forms.SubGrupo
{
    public partial class frmProdutoSubGrupoList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Produto.Cn.cnSubGrupo cSubGrupo = new cms.Modulos.Produto.Cn.cnSubGrupo();

        IQueryable<vw_produto_subgrupo> subgrupos;
        Thread threadPreencherGrid;

        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoSubGrupoList()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupo fProdutoSubGrupo = new cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupo();

            fProdutoSubGrupo.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoSubGrupo.MdiParent = this;
                fProdutoSubGrupo.Show();
            }
            else
                fProdutoSubGrupo.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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
            if (gvProdutoSubGrupo.CurrentRow == null)
                return;

            vw_produto_subgrupo produto_subgrupo = (vw_produto_subgrupo)gvProdutoSubGrupo.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupo fProdutoSubGrupo = new cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupo();

            fProdutoSubGrupo.id_subgrupo = produto_subgrupo.id_produto_subgrupo;
            fProdutoSubGrupo.Acao = Util.Acao.Visualizar;

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

    }
}
