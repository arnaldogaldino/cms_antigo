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

namespace cms.Modulos.Produto.Forms.PrecoTabela
{
    public partial class frmProdutoPrecoTabelaLockup : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnPrecoTabela cPrecoTabela = new cms.Modulos.Produto.Cn.cnPrecoTabela();

        produto_preco_tabela produto_preco_tabela = new produto_preco_tabela();

        IQueryable<produto_preco_tabela> preco_tabelas;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmProdutoPrecoTabelaLockup()
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

            threadPreencherGrid = new Thread(AtualizarGvProdutoPrecoTabela);
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

        private void gvProdutoPrecoTabela_DoubleClick(object sender, EventArgs e)
        {
            SelecionarPrecoTabela();
        }

        private void AtualizarGvProdutoPrecoTabela()
        {
            long? id_preco_tabela = null;
            string preco_tabela = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_preco_tabela = long.Parse(txtCodigo.Text);

            if (txtPrecoTabela.InvokeRequired)
                if (!string.IsNullOrEmpty(txtPrecoTabela.Text))
                    preco_tabela = txtPrecoTabela.Text;

            try
            {
                preco_tabelas = cPrecoTabela.PrecoTabelaProcurar(id_preco_tabela, preco_tabela);
            }
            catch { }

            if (gvProdutoPrecoTabela.InvokeRequired)
                gvProdutoPrecoTabela.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
        {
            gvProdutoPrecoTabela.AutoGenerateColumns = false;
            gvProdutoPrecoTabela.DataSource = preco_tabelas;
            gvProdutoPrecoTabela.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarPrecoTabela();
        }

        private void SelecionarPrecoTabela()
        {
            if (gvProdutoPrecoTabela.CurrentRow == null)
                return;

            produto_preco_tabela = (produto_preco_tabela)gvProdutoPrecoTabela.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public produto_preco_tabela GetPrecoTabelaSelecionado()
        {
            return produto_preco_tabela;
        }

    }
}
