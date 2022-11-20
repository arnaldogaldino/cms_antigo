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

namespace cms.Modulos.Produto.Forms.Grupo
{
    public partial class frmProdutoGrupoList : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnGrupo cGrupo = new cms.Modulos.Produto.Cn.cnGrupo();

        IQueryable<produto_grupo> grupos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoGrupoList()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupo fProdutoGrupo = new cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupo();

            fProdutoGrupo.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoGrupo.MdiParent = this;
                fProdutoGrupo.Show();
            }
            else
                fProdutoGrupo.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvProdutoGrupo);
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
        
        private void gvProdutoGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (gvProdutoGrupo.CurrentRow == null)
                return;

            produto_grupo produto_grupo = (produto_grupo)gvProdutoGrupo.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupo fProdutoGrupo = new cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupo();

            fProdutoGrupo.id_grupo = produto_grupo.id_produto_grupo;
            fProdutoGrupo.Acao = Util.Acao.Visualizar;
            fProdutoGrupo.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoGrupo.MdiParent = this;
                fProdutoGrupo.Show();
            }
            else
                fProdutoGrupo.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvProdutoGrupo()
        {
            long? id_grupo = null;
            string grupo = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_grupo = long.Parse(txtCodigo.Text);

            if (txtGrupo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtGrupo.Text))
                    grupo = txtGrupo.Text;

            try
            {
                grupos = cGrupo.GrupoProcurar(id_grupo, grupo);
            }
            catch { }

            if (gvProdutoGrupo.InvokeRequired)
                gvProdutoGrupo.Invoke(new MethodInvoker(Preencher));

        }
        
        public void Preencher()
        {
            gvProdutoGrupo.AutoGenerateColumns = false;
            gvProdutoGrupo.DataSource = grupos;
            gvProdutoGrupo.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

    }
}
