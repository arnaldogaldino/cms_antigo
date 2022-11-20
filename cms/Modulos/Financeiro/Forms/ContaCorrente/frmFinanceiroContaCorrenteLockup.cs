using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.ContaCorrente
{
    public partial class frmFinanceiroContaCorrenteLockup : cms.Modulos.Util.WindowBase
    {
        private financeiro_conta_corrente adoContaCorrente = new financeiro_conta_corrente();
        private cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente cFinanceiroContaCorrente = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaCorrente();

        public frmFinanceiroContaCorrenteLockup()
        {
            InitializeComponent();
            long id_empresa = 0;

            id_empresa = Util.AuthEntity.EmpresaPadrao.id_empresa;

            gvFinanceiroContaCorrente.AutoGenerateColumns = false;
            gvFinanceiroContaCorrente.DataSource = cFinanceiroContaCorrente.FinanceiroContaCorrenteProcurar(id_empresa);
            gvFinanceiroContaCorrente.Refresh();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SelecionarFormaPagamento();            
        }

        public financeiro_conta_corrente GetFormaPagamentoSelecionado()
        {
            return adoContaCorrente;
        }

        private void SelecionarFormaPagamento()
        {
            if (gvFinanceiroContaCorrente.CurrentRow == null)
                return;

            adoContaCorrente = cFinanceiroContaCorrente.GetFinanceiroContaCorrenteByID(long.Parse(gvFinanceiroContaCorrente.CurrentRow.Cells[0].Value.ToString()));
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void gvFinanceiroContaCorrente_DoubleClick(object sender, EventArgs e)
        {
            SelecionarFormaPagamento();
        }

    }
}
