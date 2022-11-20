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

namespace cms.Modulos.Cliente.Forms
{
    public partial class frmClienteLockup : cms.Modulos.Util.WindowBase
    {
        private cliente cliente = new cliente();

        cnCliente cCliente = new cnCliente();
        IQueryable<cliente> clientes;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmClienteLockup()
        {
            InitializeComponent();

            cbTipoCliente.DataSource = Util.Combos.TipoCliente();
            cbTipoCliente.Refresh();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarCliente();            
        }

        public cliente GetClienteSelecionado()
        {
            return cliente;
        }

        public cliente GetClienteByID(long id)
        {
            return cCliente.GetClienteByID(id);
        }

        private void SelecionarCliente()
        {
            if (gvCliente.CurrentRow == null)
                return;

            cliente = (cliente)gvCliente.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            SelecionarCliente();
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

            if (txtRazaoSocial.InvokeRequired)
                razao_social = txtRazaoSocial.Text;

            if (txtCPF.InvokeRequired)
                cpf = txtCPF.Text;

            if (txtRG.InvokeRequired)
                rg = txtRG.Text;

            if (txtCNPJ.InvokeRequired)
                cnpj = txtCNPJ.Text;

            if (txtIE.InvokeRequired)
                ie = txtIE.Text;

            if (cbTipoCliente.InvokeRequired)
                cbTipoCliente.Invoke(new MethodInvoker(delegate { tipo_cliente = cbTipoCliente.SelectedValue.ToString(); }));

            try
            {
                clientes = cCliente.ClienteProcurar(id_cliente, razao_social, cpf, rg, cnpj, ie, tipo_pessoa, tipo_cliente);
            }
            catch { }
            
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

        void btCancelar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }
    }
}
