using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cms.Modulos.Produto.Cn;
using cms.Data;
using cms.Modulos.Compra.Cn;

namespace cms.Modulos.Compra.Forms
{
    public partial class frmCompraList : cms.Modulos.Util.WindowBase
    {
        cnCompra cCompra = new cnCompra();

        IQueryable compras;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmCompraList()
        {
            InitializeComponent();

            cbStatusCompra.DataSource = Util.Combos.StatusCompra();
            cbStatusCompra.Refresh();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Compra.Forms.frmCompra fCompra = new cms.Modulos.Compra.Forms.frmCompra();

            fCompra.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fCompra.MdiParent = this;
                fCompra.Show();
            }
            else
                fCompra.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvCompra);
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

        private void gvCompras_DoubleClick(object sender, EventArgs e)
        {
            if (gvCompras.CurrentRow == null)
                return;

            cms.Modulos.Compra.Forms.frmCompra fCompra = new cms.Modulos.Compra.Forms.frmCompra();
            if (gvCompras.CurrentRow.Cells[0].Value != null)
                fCompra.id_compra = long.Parse(gvCompras.CurrentRow.Cells[0].Value.ToString());
            else
                return;
            
            fCompra.Acao = Util.Acao.Visualizar;
            fCompra.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fCompra.MdiParent = this;
                fCompra.Show();
            }
            else
                fCompra.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvCompra()
        {
            long? id_compra = null;
            long? id_fornecedor = null;
            string status = string.Empty;
            DateTime? data_cadastro_de = null;
            DateTime? data_cadastro_ate = null;
            DateTime? data_previsao_de = null;
            DateTime? data_previsao_ate = null;
            DateTime? data_recebimento_de = null;
            DateTime? data_recebimento_ate = null;

            bool chk_data_cadastro_de = false;
            bool chk_data_cadastro_ate = false;
            bool chk_data_previsao_de = false;
            bool chk_data_previsao_ate = false;
            bool chk_data_entrega_de = false;
            bool chk_data_entrega_ate = false;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_compra = long.Parse(txtCodigo.Text);

            if (txtFornecedor.InvokeRequired)
                if (txtFornecedor.Tag != null)
                    id_fornecedor = ((fornecedor)txtFornecedor.Tag).id_fornecedor;

            if (cbStatusCompra.InvokeRequired)
                cbStatusCompra.Invoke(new MethodInvoker(delegate { status = cbStatusCompra.SelectedText; }));

            if (dtaDataCadastroDe.InvokeRequired)
            {
                dtaDataCadastroDe.Invoke(new MethodInvoker(delegate { chk_data_cadastro_de = dtaDataCadastroDe.Checked; }));
                if (chk_data_cadastro_de)
                    dtaDataCadastroDe.Invoke(new MethodInvoker(delegate { data_cadastro_de = dtaDataCadastroDe.Value; }));
            }

            if (dtaDataCadastroAte.InvokeRequired)
            {
                dtaDataCadastroAte.Invoke(new MethodInvoker(delegate { chk_data_cadastro_ate = dtaDataCadastroAte.Checked; }));
                if (chk_data_cadastro_ate)
                    dtaDataCadastroAte.Invoke(new MethodInvoker(delegate { data_cadastro_ate = dtaDataCadastroAte.Value; }));
            }

            if (dtaPrevisaoEntregaDe.InvokeRequired)
            {
                dtaPrevisaoEntregaDe.Invoke(new MethodInvoker(delegate { chk_data_previsao_de = dtaPrevisaoEntregaDe.Checked; }));
                if (chk_data_previsao_de)
                    dtaPrevisaoEntregaDe.Invoke(new MethodInvoker(delegate { data_previsao_de = dtaPrevisaoEntregaDe.Value; }));
            }

            if (dtaPrevisaoEntregaAte.InvokeRequired)
            {
                dtaPrevisaoEntregaAte.Invoke(new MethodInvoker(delegate { chk_data_previsao_ate = dtaPrevisaoEntregaAte.Checked; }));
                if (chk_data_previsao_ate)
                    dtaPrevisaoEntregaAte.Invoke(new MethodInvoker(delegate { data_previsao_ate = dtaPrevisaoEntregaAte.Value; }));
            }


            if (dtaRecebimentoDe.InvokeRequired)
            {
                dtaRecebimentoDe.Invoke(new MethodInvoker(delegate { chk_data_entrega_de = dtaRecebimentoDe.Checked; }));
                if (chk_data_entrega_de)
                    dtaRecebimentoDe.Invoke(new MethodInvoker(delegate { data_recebimento_de = dtaRecebimentoDe.Value; }));
            }

            if (dtaRecebimentoAte.InvokeRequired)
            {
                dtaRecebimentoAte.Invoke(new MethodInvoker(delegate { chk_data_entrega_ate = dtaRecebimentoAte.Checked; }));
                if (chk_data_entrega_ate)
                    dtaPrevisaoEntregaAte.Invoke(new MethodInvoker(delegate { data_recebimento_ate = dtaRecebimentoAte.Value; }));
            }
            
            try
            {
                compras = cCompra.CompraProcurar(id_compra, id_fornecedor, status, data_cadastro_de, data_cadastro_ate, data_previsao_de, data_previsao_ate, data_recebimento_de, data_recebimento_ate);
            }
            catch { }

            if (gvCompras.InvokeRequired)
                gvCompras.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
        {
            gvCompras.AutoGenerateColumns = false;
            gvCompras.DataSource = compras;

            gvCompras.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }               

        #region Lockups
        private void btFornecedor_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fornecedor.Forms.frmFornecedorLockup fFornecedorLockup = new cms.Modulos.Fornecedor.Forms.frmFornecedorLockup();

            if (fFornecedorLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fornecedor = fFornecedorLockup.GetFornecedorSelecionado();

                txtFornecedor.Tag = fornecedor;
                txtFornecedor.Text = fornecedor.id_fornecedor + " - " + fornecedor.nome_fantasia;

                fFornecedorLockup.Close();
                fFornecedorLockup.Dispose();
            }
            else
            {
                txtFornecedor.Tag = null;
                txtFornecedor.Text = string.Empty;
            }
        }
        private void txtFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFornecedor_Click(sender, e);
            }
        }
        #endregion
          
    }
}
