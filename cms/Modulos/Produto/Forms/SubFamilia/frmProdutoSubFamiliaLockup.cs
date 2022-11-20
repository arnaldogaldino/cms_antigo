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

namespace cms.Modulos.Produto.Forms.SubFamilia
{
    public partial class frmProdutoSubFamiliaLockup : cms.Modulos.Util.WindowBase
    {
        produto_subfamilia produto_subfamilia = new produto_subfamilia();
        cms.Modulos.Produto.Cn.cnSubFamilia cSubFamilia = new cms.Modulos.Produto.Cn.cnSubFamilia();
        IQueryable<vw_produto_subfamilia> subfamilias;
        Thread threadPreencherGrid;

        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoSubFamiliaLockup(produto_familia familia)
        {
            InitializeComponent();

            if (familia == null)
            {
                MessageBox.Show(null, "Familia não foi selecionado!", "Cadastro de familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                this.Dispose();
            }
            else
            {
                txtFamilia.Tag = familia;
                txtFamilia.Text = familia.id_produto_familia + " - " + familia.familia;
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
            SelecionarSubFamilia();
        }

        private void AtualizarGvProdutoSubFamilia()
        {
            long? id_familia = null;
            long? id_subfamilia = null;
            string subfamilia = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_subfamilia = long.Parse(txtCodigo.Text);

            if (txtFamilia.InvokeRequired)
                if (txtFamilia.Tag != null)
                    id_familia = ((produto_familia)txtFamilia.Tag).id_produto_familia;
                    
            if (txtSubFamilia.InvokeRequired)
                if (!string.IsNullOrEmpty(txtSubFamilia.Text))
                    subfamilia = txtSubFamilia.Text;
                    
            try
            {
                subfamilias = cSubFamilia.SubFamiliaProcurar(id_subfamilia, id_familia, null, null, subfamilia);
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

        private void btFamilia_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup fProdutoFamiliaLockup = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup(((produto_familia)txtFamilia.Tag).produto_subgrupo);

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

        private void SelecionarSubFamilia()
        {
            if (gvProdutoSubFamilia.CurrentRow == null)
                return;

            produto_subfamilia = cSubFamilia.GetSubFamiliaByID(((vw_produto_subfamilia)gvProdutoSubFamilia.CurrentRow.DataBoundItem).id_produto_subfamilia);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public produto_subfamilia GetSubFamiliaSelecionado()
        {
            return produto_subfamilia;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarSubFamilia();
        }

    }
}
