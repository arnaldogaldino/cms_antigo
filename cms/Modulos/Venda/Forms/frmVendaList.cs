using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Modulos.Venda.Cn;
using cms.Modulos.Util;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Venda.Forms
{

    public partial class frmVendaList : cms.Modulos.Util.WindowBase
    {
        cnVenda cVenda = new cnVenda();

        IQueryable vendas;
        Thread threadPreencherGrid;
        Carregando load = new Carregando();

        public frmVendaList()
        {
            InitializeComponent();
        }

        private void frmVendaList_Load(object sender, EventArgs e)
        {
            cbStatusVenda.DataSource = Util.Combos.StatusVenda();
            cbStatusVenda.Refresh();
        }
        
        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Venda.Forms.frmVenda fVenda = new cms.Modulos.Venda.Forms.frmVenda();

            fVenda.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fVenda.MdiParent = this;
                fVenda.Show();
            }
            else
                fVenda.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

            threadPreencherGrid = new Thread(AtualizarGvVenda);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }
        
        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCliente_Click(sender, e);
            }
        }
        
        private void btCliente_Click(object sender, EventArgs e)
        {
            cms.Modulos.Cliente.Forms.frmClienteLockup fClienteLockup = new cms.Modulos.Cliente.Forms.frmClienteLockup();

            if (fClienteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cliente = fClienteLockup.GetClienteSelecionado();

                txtCliente.Tag = cliente;
                txtCliente.Text = cliente.id_cliente + " - " + cliente.nome_fantasia;

                fClienteLockup.Close();
                fClienteLockup.Dispose();
            }
            else
            {
                txtCliente.Tag = null;
                txtCliente.Text = string.Empty;
            }
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
        
        private void gvPedidos_DoubleClick(object sender, EventArgs e)
        {
            if (gvPedidos.CurrentRow == null)
                return;

            cms.Modulos.Venda.Forms.frmVenda fVenda = new cms.Modulos.Venda.Forms.frmVenda();
            if (gvPedidos.CurrentRow.Cells[0].Value != null)
                fVenda.id_venda = long.Parse(gvPedidos.CurrentRow.Cells[0].Value.ToString());
            else
                return;

            fVenda.Acao = Util.Acao.Visualizar;
            fVenda.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fVenda.MdiParent = this;
                fVenda.Show();
            }
            else
                fVenda.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvVenda()
        {
            long? id_venda = null;
            long? id_cliente = null;
            string status = string.Empty;
            DateTime? data_cadastro_de = null;
            DateTime? data_cadastro_ate = null;

            bool chk_data_cadastro_de = false;
            bool chk_data_cadastro_ate = false;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_venda = long.Parse(txtCodigo.Text);

            if (txtCliente.InvokeRequired)
                if (txtCliente.Tag != null)
                    id_cliente = ((cliente)txtCliente.Tag).id_cliente;

            if (cbStatusVenda.InvokeRequired)
                cbStatusVenda.Invoke(new MethodInvoker(delegate { status = cbStatusVenda.SelectedText; }));

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

            try
            {
                vendas = cVenda.VendaProcurar(id_venda, id_cliente, status, data_cadastro_de, data_cadastro_ate);
            }
            catch { }

            if (gvPedidos.InvokeRequired)
                gvPedidos.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvPedidos.AutoGenerateColumns = false;
            gvPedidos.DataSource = vendas;

            gvPedidos.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

    }

}
