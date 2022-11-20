using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BoletoNet;
using Microsoft.Reporting.WinForms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.Boletos
{
    public partial class frmBoletoVisualizar : cms.Modulos.Util.WindowBase
    {
        private cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber cFinanceiroContaReceber = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber();
        private cms.Modulos.Financeiro.Cn.cnFinanceiroBoleto cFinanceiroBoleto = new cms.Modulos.Financeiro.Cn.cnFinanceiroBoleto();
        private BoletoBancario boletoBancario = new BoletoBancario();

        public frmBoletoVisualizar(long id_conta_receber)
        {
            InitializeComponent();

            List<Boleto> boletos = new List<Boleto>();

            var conta = cFinanceiroContaReceber.GetFinanceiroContaReceberByID(id_conta_receber);
            var boleto = cFinanceiroBoleto.ToBoleto(conta);

            boletos.Add(boleto);
            
            cFinanceiroBoleto.GravarBoleto(boleto, conta);

            PreencherReport(boletos);
        }

        public frmBoletoVisualizar(long[] ids_conta_receber)
        {
            InitializeComponent();

            List<Boleto> boletos = new List<Boleto>();
            var list = cFinanceiroContaReceber.GetFinanceiroContaReceberByIDs(ids_conta_receber);

            foreach (var conta in list)
            {
                var boleto = cFinanceiroBoleto.ToBoleto(conta);
                boletos.Add(boleto);

                cFinanceiroBoleto.GravarBoleto(boleto, conta);
            }

            PreencherReport(boletos);
        }

        private void frmBoletoVisualizar_Load(object sender, EventArgs e)
        {
       
        }

        private void PreencherReport(List<Boleto> boletos)
        {
            this.rpvBoletos.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            rpvBoletos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            ReportDataSource rds = new ReportDataSource();
            BoletoRepot br = new BoletoRepot();

            rds.Name = "Boleto";
            rds.Value = br.ToList(boletos);

            rpvBoletos.LocalReport.DataSources.Add(rds);
            rpvBoletos.LocalReport.ReportPath = boletoBancario.GetReportPath();

            this.rpvBoletos.RefreshReport();

        }
        
    }
}
 