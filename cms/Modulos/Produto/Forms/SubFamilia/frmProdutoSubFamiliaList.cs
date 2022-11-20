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

namespace cms.Modulos.Produto.Forms.SubFamilia
{
    public partial class frmProdutoSubFamiliaList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Produto.Cn.cnSubFamilia cSubFamilia = new cms.Modulos.Produto.Cn.cnSubFamilia();

        IQueryable<vw_produto_subfamilia> subfamilias;
        Thread threadPreencherGrid;

        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoSubFamiliaList()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamilia fProdutoSubFamilia = new cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamilia();

            fProdutoSubFamilia.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoSubFamilia.MdiParent = this;
                fProdutoSubFamilia.Show();
            }
            else
                fProdutoSubFamilia.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvProdutoSubFamilia);
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

        private void gvProdutoSubFamilia_DoubleClick(object sender, EventArgs e)
        {
            if (gvProdutoSubFamilia.CurrentRow == null)
                return;

            vw_produto_subfamilia produto_subfamilia = (vw_produto_subfamilia)gvProdutoSubFamilia.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamilia fProdutoSubFamilia = new cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamilia();

            fProdutoSubFamilia.id_subfamilia = produto_subfamilia.id_produto_subfamilia;
            fProdutoSubFamilia.Acao = Util.Acao.Visualizar;

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
            long? id_familia = null;
            long? id_subfamilia = null;
            long? id_grupo = null;
            long? id_subgrupo = null;
            string subfamilia = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_subfamilia = long.Parse(txtCodigo.Text);

            if (txtFamilia.InvokeRequired)
                if (txtFamilia.Tag != null)
                    id_familia = ((vw_produto_familia)txtFamilia.Tag).id_produto_familia;
                    
            if (txtSubFamilia.InvokeRequired)
                if (!string.IsNullOrEmpty(txtSubFamilia.Text))
                    subfamilia = txtSubFamilia.Text;

            if (txtGrupo.InvokeRequired)
                if (txtGrupo.Tag != null)
                    id_grupo = ((produto_grupo)txtGrupo.Tag).id_produto_grupo;

            if (txtSubGrupo.InvokeRequired)
                if (txtSubGrupo.Tag != null)
                    id_subgrupo = ((vw_produto_subgrupo)txtSubGrupo.Tag).id_produto_subgrupo;
        
            try
            {
                subfamilias = cSubFamilia.SubFamiliaProcurar(id_subfamilia, id_familia,null,null, subfamilia);
            }
            catch { }

            if (gvProdutoSubFamilia.InvokeRequired)
                gvProdutoSubFamilia.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
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
            txtSubFamilia.Text = string.Empty;
            
            txtSubGrupo.Tag = null;
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
            
            txtSubFamilia.Text = string.Empty;

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
