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
    public partial class frmFornecedorList : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Fornecedor.Cn.cnFornecedor cFornecedor = new cms.Modulos.Fornecedor.Cn.cnFornecedor();
        IQueryable<fornecedor> fornecedores;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFornecedorList()
        {
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                //load.LoadHide(this);
            }

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

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fornecedor.Forms.frmFornecedor fFornecedor = new cms.Modulos.Fornecedor.Forms.frmFornecedor();

            fFornecedor.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFornecedor.MdiParent = this;
                fFornecedor.Show();
            }
            else
                fFornecedor.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvFornecedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gvFornecedor.CurrentRow == null)
                return;

            fornecedor fornecedor = (fornecedor)gvFornecedor.CurrentRow.DataBoundItem;

            cms.Modulos.Fornecedor.Forms.frmFornecedor fFornecedor = new cms.Modulos.Fornecedor.Forms.frmFornecedor();

            fFornecedor.id_fornecedor = fornecedor.id_fornecedor;

            fFornecedor.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFornecedor.MdiParent = this;
                fFornecedor.Show();
            }
            else
                fFornecedor.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarGvFornecedor();
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
