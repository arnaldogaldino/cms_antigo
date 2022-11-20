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
using cms.Modulos.Transportadora.Cn;

namespace cms.Modulos.Transportadora.Forms
{
    public partial class frmTransportadoraLockup : cms.Modulos.Util.WindowBase
    {
        private transportadora transportadora = new transportadora();

        cnTransportadora cTransportadora = new cnTransportadora();
        IQueryable<transportadora> transportadoras;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmTransportadoraLockup()
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
            SelecionarTransportadora();            
        }

        public transportadora GetTransportadoraSelecionado()
        {
            return transportadora;
        }

        private void SelecionarTransportadora()
        {
            if (gvTransportadora.CurrentRow == null)
                return;

            transportadora = (transportadora)gvTransportadora.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvTransportadora_DoubleClick(object sender, EventArgs e)
        {
            SelecionarTransportadora();
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

            long? id_transportadora = null;
            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_transportadora = long.Parse(txtCodigo.Text);
            
            if (txtRazaoSocial.InvokeRequired)
                razao_social = txtRazaoSocial.Text;

            if (txtRG.InvokeRequired)
                rg = txtRG.Text;

            if (txtCnpj.InvokeRequired)
                cnpj = txtCnpj.Text;

            try
            {
                transportadoras = cTransportadora.TransportadoraProcurar(id_transportadora, razao_social, cnpj, rg);
            }
            catch { }
            
            if (gvTransportadora.InvokeRequired)
                gvTransportadora.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvTransportadora.AutoGenerateColumns = false;
            gvTransportadora.DataSource = transportadoras;
            gvTransportadora.Refresh();

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
