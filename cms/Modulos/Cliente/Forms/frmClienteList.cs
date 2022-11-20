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
using cms.Modulos.Cliente.Cn;
using cms.Modulos.Util;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace cms.Modulos.Cliente.Forms
{

    public partial class frmClienteList : cms.Modulos.Util.WindowBase
    {

        cnCliente cCliente = new cnCliente();
        private IQueryable<cliente> clientes;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmClienteList()
        {
            InitializeComponent();
            cbTipoCliente.DataSource = Util.Combos.TipoCliente();
            cbTipoCliente.Refresh();
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

            threadPreencherGrid = new Thread(AtualizarGvCliente);
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

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Cliente.Forms.frmCliente fCliente = new cms.Modulos.Cliente.Forms.frmCliente();

            fCliente.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fCliente.MdiParent = this;
                fCliente.Show();
            }
            else
                fCliente.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gvCliente.CurrentRow == null)
                return;

            cliente cliente = (cliente)gvCliente.CurrentRow.DataBoundItem;

            cms.Modulos.Cliente.Forms.frmCliente fCliente = new cms.Modulos.Cliente.Forms.frmCliente();

            fCliente.id_cliente = cliente.id_cliente;

            fCliente.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fCliente.MdiParent = this;
                fCliente.Show();
            }
            else
                fCliente.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvCliente()
        {
            string razao_social = string.Empty;
            string cpf = string.Empty;
            string rg = string.Empty;
            string cnpj = string.Empty;
            string ie = string.Empty;
            string tipo_cliente = string.Empty;

            long? id_cliente = null;
            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_cliente = long.Parse(txtCodigo.Text);

            string tipo_pessoa = string.Empty;
            if (rbFisica.InvokeRequired)
                if (rbFisica.Checked)
                    tipo_pessoa = "Fisica";
                else if (rbJuridica.Checked)            
                    tipo_pessoa = "Juridica";

            if(txtRazaoSocial.InvokeRequired)
                razao_social = txtRazaoSocial.Text;

            if(txtCPF.InvokeRequired)
                cpf = txtCPF.Text;

            if(txtRG.InvokeRequired)
                rg = txtRG.Text;

            if(txtCNPJ.InvokeRequired)
                cnpj = txtCNPJ.Text;

            if(txtIE.InvokeRequired)
                ie = txtIE.Text;

            if(cbTipoCliente.InvokeRequired)
                cbTipoCliente.Invoke(new MethodInvoker(delegate { tipo_cliente = cbTipoCliente.SelectedValue.ToString(); }));

            try
            {
                clientes = cCliente.ClienteProcurar(id_cliente, razao_social, cpf, rg, cnpj, ie, tipo_pessoa, tipo_cliente);
            }
            catch 
            {
                Thread.Sleep(200);             
            }

            if (gvCliente.InvokeRequired)
                gvCliente.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvCliente.AutoGenerateColumns = false;
            gvCliente.DataSource = clientes;

            gvCliente.Refresh();
            
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        //private void lockup1_OnLockup(object sender, LockupEventArgs e)
        //{
        //    cms.Modulos.Cliente.Forms.frmClienteLockup fClienteLockup = new cms.Modulos.Cliente.Forms.frmClienteLockup();
        //    Data.cliente cliente = new Data.cliente();

        //    if (e.LockupEx == LockupEx.KeysF1 || e.LockupEx == LockupEx.KeysEnter)
        //    {
        //        int id = 0;

        //        if (int.TryParse(lockup1.Id, out id))
        //        {
        //            cliente = fClienteLockup.GetClienteByID(Convert.ToInt64(id));
        //        }

        //        if(cliente == null)
        //        {
        //            if (fClienteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //            {
        //                cliente = fClienteLockup.GetClienteSelecionado();
        //            }
        //            else
        //            {
        //                lockup1.Clear();
        //            }
        //        }
        //    }

        //    if (e.LockupEx == LockupEx.MouseClick)
        //    {
        //        if (fClienteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            cliente = fClienteLockup.GetClienteSelecionado();
        //        }
        //    }

        //    if (cliente != null)
        //    {                
        //        lockup1.Value = cliente;
        //        lockup1.Id = Convert.ToString(cliente.id_cliente);
        //        lockup1.Text = cliente.razao_social;
        //    }
        //}

    }
}
