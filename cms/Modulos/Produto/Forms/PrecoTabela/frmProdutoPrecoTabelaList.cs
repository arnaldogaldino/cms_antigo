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

namespace cms.Modulos.Produto.Forms.PrecoTabela
{
    public partial class frmProdutoPrecoTabelaList : cms.Modulos.Util.WindowBase
    {

        cms.Modulos.Produto.Cn.cnPrecoTabela cPrecoTabela = new cms.Modulos.Produto.Cn.cnPrecoTabela();

        IQueryable<produto_preco_tabela> preco_tabelas;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmProdutoPrecoTabelaList()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabela fProdutoPrecoTabela = new cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabela();

            fProdutoPrecoTabela.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoPrecoTabela.MdiParent = this;
                fProdutoPrecoTabela.Show();
            }
            else
                fProdutoPrecoTabela.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvFinanceiroNcm);
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
            if (gvProdutoPrecoTabela.CurrentRow == null)
                return;

            produto_preco_tabela produto_preco_tabela = (produto_preco_tabela)gvProdutoPrecoTabela.CurrentRow.DataBoundItem;

            cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabela fProdutoPrecoTabela = new cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabela();

            fProdutoPrecoTabela.id_preco_tabela = produto_preco_tabela.id_produto_preco_tabela;
            fProdutoPrecoTabela.Acao = Util.Acao.Visualizar;
            fProdutoPrecoTabela.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoPrecoTabela.MdiParent = this;
                fProdutoPrecoTabela.Show();
            }
            else
                fProdutoPrecoTabela.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvFinanceiroNcm()
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

    }
}
