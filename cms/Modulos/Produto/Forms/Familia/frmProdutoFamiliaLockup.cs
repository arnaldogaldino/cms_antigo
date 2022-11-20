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

namespace cms.Modulos.Produto.Forms.Familia
{
    public partial class frmProdutoFamiliaLockup : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnFamilia cFamilia = new cms.Modulos.Produto.Cn.cnFamilia();

        produto_familia produto_familia = new produto_familia();

        IQueryable<vw_produto_familia> familias;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmProdutoFamiliaLockup(produto_subgrupo subgrupo)
        {
            InitializeComponent();

            if (subgrupo == null)
            {
                MessageBox.Show(null, "Sub-Grupo não foi selecionado!", "Cadastro de familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                this.Dispose();
            }
            else
            {
                txtSubGrupo.ReadOnly = true;
                txtSubGrupo.Tag = subgrupo;
                txtSubGrupo.Text = subgrupo.id_produto_subgrupo + " - " + subgrupo.subgrupo;
            }
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

            threadPreencherGrid = new Thread(AtualizarGvProdutoFamilia);
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
            SelecionarFamilia();
        }
        
        private void AtualizarGvProdutoFamilia()
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

            if (txtSubGrupo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtSubGrupo.Text))
                {
                    id_grupo = ((produto_subgrupo)txtSubGrupo.Tag).id_produto_grupo;
                    id_subgrupo = ((produto_subgrupo)txtSubGrupo.Tag).id_produto_subgrupo;
                }

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

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarFamilia();
        }
        
        private void SelecionarFamilia()
        {
            if (gvProdutoFamilia.CurrentRow == null)
                return;
            
            produto_familia = cFamilia.GetFamiliaByID(((vw_produto_familia)gvProdutoFamilia.CurrentRow.DataBoundItem).id_produto_familia);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public produto_familia GetFamiliaSelecionado()
        {
            return produto_familia;
        }
    }
}

