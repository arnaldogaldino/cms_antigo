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

namespace cms.Modulos.Financeiro.Forms.ContaCorrente
{
    
    public partial class frmFinanceiroContaCorrenteList : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cFinanceiroContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();

        IQueryable<vw_financeiro_conta_corrente> conta_correntes;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFinanceiroContaCorrenteList()
        {
            InitializeComponent();
            long id_empresa = Util.AuthEntity.EmpresaPadrao.id_empresa;

            gvFinanceiroContaCorrente.AutoGenerateColumns = false;
            gvFinanceiroContaCorrente.DataSource = cFinanceiroContaCorrente.FinanceiroContaCorrenteProcurar(id_empresa);
            gvFinanceiroContaCorrente.Refresh();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvContaCorrente);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        private void AtualizarGvContaCorrente()
        {
            try
            {
                long id_empresa = Util.AuthEntity.EmpresaPadrao.id_empresa;
                conta_correntes = cFinanceiroContaCorrente.FinanceiroContaCorrenteProcurar(id_empresa);
            }
            catch { }

            if (gvFinanceiroContaCorrente.InvokeRequired)
                gvFinanceiroContaCorrente.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvFinanceiroContaCorrente.AutoGenerateColumns = false;
            gvFinanceiroContaCorrente.DataSource = conta_correntes;
            gvFinanceiroContaCorrente.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrente fContaCorrente = new cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrente();

            fContaCorrente.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContaCorrente.MdiParent = this;
                fContaCorrente.Show();
            }
            else
                fContaCorrente.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvFinanceiroContaCorrente_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroContaCorrente.CurrentRow == null)
                return;

            financeiro_conta_corrente ContaCorrente = new financeiro_conta_corrente();

            try
            {
                ContaCorrente = cFinanceiroContaCorrente.GetFinanceiroContaCorrenteByID(long.Parse(gvFinanceiroContaCorrente.CurrentRow.Cells[0].Value.ToString()));
            }
            catch { }

            cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrente fContaCorrente = new cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrente();

            fContaCorrente.id_conta_corrente = ContaCorrente.id_financeiro_conta_corrente;
            fContaCorrente.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContaCorrente.MdiParent = this;
                fContaCorrente.Show();
            }
            else
                fContaCorrente.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
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
