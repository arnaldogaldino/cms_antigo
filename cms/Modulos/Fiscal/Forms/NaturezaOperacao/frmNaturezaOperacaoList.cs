using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cms.Modulos.Fiscal.Cn;
using cms.Data;

namespace cms.Modulos.Fiscal.Forms.NaturezaOperacao
{
    public partial class frmNaturezaOperacaoList : cms.Modulos.Util.WindowBase
    {
        cnFiscalNaturezaOperacao cFiscalNaturezaOperacao = new cnFiscalNaturezaOperacao();

        IQueryable<fiscal_natureza_operacao> fiscal_natureza_operacaos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
                
        public frmNaturezaOperacaoList()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmNaturezaOperacao fNaturezaOperacao = new cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmNaturezaOperacao();

            fNaturezaOperacao.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fNaturezaOperacao.MdiParent = this;
                fNaturezaOperacao.Show();
            }
            else
                fNaturezaOperacao.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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

        private void AtualizarGvNaturezaOperacao()
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
                fiscal_natureza_operacaos = cFiscalNaturezaOperacao.FiscalNaturezaOperacaoProcurar(tipo, natop, descricao);
            }
            catch
            {
                Thread.Sleep(200);
            }

            if (gvNaturezaOperacao.InvokeRequired)
                gvNaturezaOperacao.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvNaturezaOperacao.AutoGenerateColumns = false;
            gvNaturezaOperacao.DataSource = fiscal_natureza_operacaos;
            gvNaturezaOperacao.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void gvNaturezaOperacao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gvNaturezaOperacao.CurrentRow == null)
                return;

            fiscal_natureza_operacao natureza_operacao = (fiscal_natureza_operacao)gvNaturezaOperacao.CurrentRow.DataBoundItem;

            cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmNaturezaOperacao fNaturezaOperacao = new cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmNaturezaOperacao();

            fNaturezaOperacao.id_fiscal_natureza_operacao = natureza_operacao.id_fiscal_natureza_operacao;

            fNaturezaOperacao.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fNaturezaOperacao.MdiParent = this;
                fNaturezaOperacao.Show();
            }
            else
                fNaturezaOperacao.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }
        
    }
}
