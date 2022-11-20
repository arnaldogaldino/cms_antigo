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
using cms.Modulos.Fiscal.Cn;

namespace cms.Modulos.Fiscal.Forms.Cfop
{
    public partial class frmFiscalCfopLockup : cms.Modulos.Util.WindowBase
    {

        private fiscal_cfop cfop = new fiscal_cfop();

        cnFiscalCfop cFiscalCfop = new cnFiscalCfop();

        IQueryable<fiscal_cfop> cfops;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalCfopLockup()
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
            SelecionarCFOP();
        }

        public void Preencher()
        {
            gvCFOP.AutoGenerateColumns = false;
            gvCFOP.DataSource = cfops;
            gvCFOP.Refresh();

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

            threadPreencherGrid = new Thread(AtualizarGvCfop);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        private void gvCFOP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelecionarCFOP();
        }

        private void AtualizarGvCfop()
        {
            int? cfop = null;
            string descricao = string.Empty;
            string tipo = string.Empty;

            if (txtCFOP.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCFOP.Text))
                    cfop = int.Parse(txtCFOP.Text);

            if (rbTipoEntrada.InvokeRequired)
                if (rbTipoEntrada.Checked)
                    tipo = "Entrada";
                else if (rbTipoSaida.Checked)
                    tipo = "Saída";

            if (txtDescricao.InvokeRequired)
                descricao = txtDescricao.Text;

            try
            {
                cfops = cFiscalCfop.FiscalCfopProcurar(cfop, tipo, descricao);
            }
            catch
            {
                Thread.Sleep(200);
            }

            if (gvCFOP.InvokeRequired)
                gvCFOP.Invoke(new MethodInvoker(Preencher));
        }

        private void SelecionarCFOP()
        {
            if (gvCFOP.CurrentRow == null)
                return;

            cfop = (fiscal_cfop)gvCFOP.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        public fiscal_cfop GetCFOPSelecionado()
        {
            return cfop;
        }

    }
}
