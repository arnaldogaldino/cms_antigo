using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BoletoNet.Arquivo
{
    public partial class Report : Form
    {

        private List<Boleto> boletos = new List<Boleto>();

        public Report(List<BoletoBancario> pBoletos)
        {
            InitializeComponent();

            foreach (var b in pBoletos)
                boletos.Add(b.Boleto);
        }

        private void Report_Load(object sender, EventArgs e)
        {
            BoletoBancario bb = new BoletoBancario();

            ReportDataSource rds = new ReportDataSource();
            BoletoRepot br = new BoletoRepot();

            rds.Name = "Boleto";
            rds.Value = br.ToList(boletos);


            rv2.LocalReport.DataSources.Add(rds);
            rv2.LocalReport.ReportPath = bb.GetReportPath();

            this.rv2.RefreshReport();
        }    
    }
}
