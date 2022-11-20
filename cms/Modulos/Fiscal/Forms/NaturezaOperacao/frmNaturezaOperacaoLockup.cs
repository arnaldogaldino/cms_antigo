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

namespace cms.Modulos.Fiscal.Forms.NaturezaOperacao
{
    public partial class frmFiscalNaturesaOperacaoLockup : cms.Modulos.Util.WindowBase
    {
        private fiscal_natureza_operacao natureza_operacao = new fiscal_natureza_operacao();
        cms.Modulos.Fiscal.Cn.cnFiscalNaturezaOperacao cFiscalNaturezaOperacao = new cms.Modulos.Fiscal.Cn.cnFiscalNaturezaOperacao();

        IQueryable<fiscal_natureza_operacao> natureza_operacoes;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFiscalNaturesaOperacaoLockup()
        {
            InitializeComponent();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvNaturezaOperacao);
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarNaturezaOperacao();            
        }

        public fiscal_natureza_operacao GetNaturezaOperacaoSelecionado()
        {
            return natureza_operacao;
        }

        private void SelecionarNaturezaOperacao()
        {
            if (gvNaturezaOperacao.CurrentRow == null)
                return;

            natureza_operacao = (fiscal_natureza_operacao)gvNaturezaOperacao.CurrentRow.DataBoundItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvNaturezaOperacao_DoubleClick(object sender, EventArgs e)
        {
            SelecionarNaturezaOperacao();
        }
        
        private void AtualizarGvNaturezaOperacao()
        {
            try
            {
                long? natop = null;
                string descricao = string.Empty;
                string tipo = string.Empty;

                if (txtNatOp.InvokeRequired)
                    if (!string.IsNullOrEmpty(txtNatOp.Text))
                        natop = int.Parse(txtNatOp.Text);

                if (rbTipoEntrada.InvokeRequired)
                    if (rbTipoEntrada.Checked)
                        tipo = "Entrada";
                    else if (rbTipoSaida.Checked)
                        tipo = "Saída";

                if (txtDescricao.InvokeRequired)
                    descricao = txtDescricao.Text;

                try
                {
                    natureza_operacoes = cFiscalNaturezaOperacao.FiscalNaturezaOperacaoProcurar(tipo, natop, descricao);
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }
            catch { }

            if (gvNaturezaOperacao.InvokeRequired)
                gvNaturezaOperacao.Invoke(new MethodInvoker(Preencher));

        }

        public void Preencher()
        {
            gvNaturezaOperacao.AutoGenerateColumns = false;
            gvNaturezaOperacao.DataSource = natureza_operacoes;
            gvNaturezaOperacao.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }


    }
}
