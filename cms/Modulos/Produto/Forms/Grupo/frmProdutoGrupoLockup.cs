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

namespace cms.Modulos.Produto.Forms.Grupo
{
    public partial class frmProdutoGrupoLockup : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnGrupo cGrupo = new cms.Modulos.Produto.Cn.cnGrupo();

        produto_grupo produto_grupo = new produto_grupo();

        IQueryable<produto_grupo> grupos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmProdutoGrupoLockup()
        {
            InitializeComponent();
        }
        
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            SelecionarGrupo();
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

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarGrupo();
        }
        
        private void SelecionarGrupo()
        {
            if (gvProdutoGrupo.CurrentRow == null)
                return;
            
            produto_grupo = (produto_grupo)gvProdutoGrupo.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public produto_grupo GetGrupoSelecionado()
        {
            return produto_grupo;
        }

    }
}
