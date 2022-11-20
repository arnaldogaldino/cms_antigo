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

namespace cms.Modulos.Fornecedor.Forms
{

    public partial class frmFornecedorLockup : cms.Modulos.Util.WindowBase
    {
        private fornecedor fornecedor = new fornecedor();
        private cms.Modulos.Fornecedor.Cn.cnFornecedor cFornecedor = new cms.Modulos.Fornecedor.Cn.cnFornecedor();

        IQueryable<fornecedor> fornecedores;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFornecedorLockup()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarFornecedor();            
        }

        public fornecedor GetFornecedorSelecionado()
        {
            return fornecedor;
        }

        private void SelecionarFornecedor()
        {
            if (gvFornecedor.CurrentRow == null)
                return;
            
            fornecedor = (fornecedor)gvFornecedor.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvFornecedor_DoubleClick(object sender, EventArgs e)
        {
            SelecionarFornecedor();
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

            threadPreencherGrid = new Thread(AtualizarGvFornecedor);
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

        private void AtualizarGvFornecedor()
        {
            string razao_social = string.Empty;
            string cpf = string.Empty;
            string rg = string.Empty;
            string cnpj = string.Empty;
            string ie = string.Empty;
            string tipo_cliente = string.Empty;

            long? id_fornecedor = null;
            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_fornecedor = long.Parse(txtCodigo.Text);

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

            try
            {
                fornecedores = cFornecedor.FornecedorProcurar(id_fornecedor, txtRazaoSocial.Text, txtCPF.Text, txtRG.Text, txtCNPJ.Text, txtIE.Text, tipo_pessoa);
            }
            catch { }

            if (gvFornecedor.InvokeRequired)
                gvFornecedor.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvFornecedor.AutoGenerateColumns = false;
            gvFornecedor.DataSource = fornecedores;
            gvFornecedor.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

    }

}
