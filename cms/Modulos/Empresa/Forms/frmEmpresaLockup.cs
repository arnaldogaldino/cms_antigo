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
using cms.Modulos.Empresa.Cn;

namespace cms.Modulos.Empresa.Forms
{
    public partial class frmEmpresaLockup : cms.Modulos.Util.WindowBase
    {
        private empresa empresa = new empresa();

        cnEmpresa cEmpresa = new cnEmpresa();
        IQueryable<empresa> empresas;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmEmpresaLockup()
        {
            InitializeComponent();

            cbTipoEmpresa.DataSource = Util.Combos.TipoCliente();
            cbTipoEmpresa.Refresh();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarEmpresa();            
        }

        public empresa GetEmpresaSelecionado()
        {
            return empresa;
        }

        private void SelecionarEmpresa()
        {
            if (gvEmpresa.CurrentRow == null)
                return;

            empresa = (empresa)gvEmpresa.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvEmpresa_DoubleClick(object sender, EventArgs e)
        {
            SelecionarEmpresa();
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

            threadPreencherGrid = new Thread(AtualizarGvEmpresa);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }
        
        private void AtualizarGvEmpresa()
        {
            string razao_social = string.Empty;
            string cpf = string.Empty;
            string rg = string.Empty;
            string cnpj = string.Empty;
            string ie = string.Empty;
            string tipo_empresa = string.Empty;

            long? id_empresa = null;
            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_empresa = long.Parse(txtCodigo.Text);

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

            if (cbTipoEmpresa.InvokeRequired)
                cbTipoEmpresa.Invoke(new MethodInvoker(delegate { tipo_empresa = cbTipoEmpresa.SelectedValue.ToString(); }));

            try
            {
                empresas = cEmpresa.EmpresaProcurar(id_empresa, razao_social, cpf, rg, cnpj, ie, tipo_pessoa, tipo_empresa);
            }
            catch { }
            
            if (gvEmpresa.InvokeRequired)
                gvEmpresa.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvEmpresa.AutoGenerateColumns = false;
            gvEmpresa.DataSource = empresas;
            gvEmpresa.Refresh();

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
