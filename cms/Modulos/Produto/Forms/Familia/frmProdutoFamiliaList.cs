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

namespace cms.Modulos.Produto.Forms.Familia
{
    public partial class frmProdutoFamiliaList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Produto.Cn.cnFamilia cFamilia = new cms.Modulos.Produto.Cn.cnFamilia();

        IQueryable<vw_produto_familia> familias;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoFamiliaList()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Familia.frmProdutoFamilia fProdutoFamilia = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamilia();

            fProdutoFamilia.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoFamilia.MdiParent = this;
                fProdutoFamilia.Show();
            }
            else
                fProdutoFamilia.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvFamilia);
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
        
        private void gvProdutoFamilia_DoubleClick(object sender, EventArgs e)
        {
            if (gvProdutoFamilia.CurrentRow == null)
                return;

            vw_produto_familia produto_familia = (vw_produto_familia)gvProdutoFamilia.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.Familia.frmProdutoFamilia fProdutoFamilia = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamilia();

            fProdutoFamilia.id_familia = produto_familia.id_produto_familia;
            fProdutoFamilia.Acao = Util.Acao.Visualizar;
            fProdutoFamilia.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoFamilia.MdiParent = this;
                fProdutoFamilia.Show();
            }
            else
                fProdutoFamilia.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvFamilia()
        {
            long? id_familia = null;
            long? id_grupo = null;
            long? id_subgrupo = null;
            string familia = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_familia = long.Parse(txtCodigo.Text);

            if (txtFamilia.InvokeRequired)
                if (!string.IsNullOrEmpty(txtFamilia.Text))
                    familia = txtFamilia.Text;

            if (txtGrupo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtGrupo.Text))
                    id_grupo = ((produto_grupo)txtGrupo.Tag).id_produto_grupo;
            
            if (txtSubGrupo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtSubGrupo.Text))
                    id_subgrupo = ((produto_subgrupo)txtSubGrupo.Tag).id_produto_subgrupo;

            try
            {
                familias = cFamilia.FamiliaProcurar(id_familia, id_grupo, id_subgrupo, familia);
            }
            catch { }

            if (gvProdutoFamilia.InvokeRequired)
                gvProdutoFamilia.Invoke(new MethodInvoker(Preencher));

        }
        
        public void Preencher()
        {
            gvProdutoFamilia.AutoGenerateColumns = false;
            gvProdutoFamilia.DataSource = familias;
            gvProdutoFamilia.Refresh();

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
