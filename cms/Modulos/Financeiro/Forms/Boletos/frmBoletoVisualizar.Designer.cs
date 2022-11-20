namespace cms.Modulos.Financeiro.Forms.Boletos
{
    partial class frmBoletoVisualizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpvBoletos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBoletos
            // 
            this.rpvBoletos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsBoleto";
            reportDataSource1.Value = null;
            this.rpvBoletos.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBoletos.LocalReport.ReportEmbeddedResource = "cms.Modulos.Financeiro.Reports.boleto_comprovante.rdlc";
            this.rpvBoletos.Location = new System.Drawing.Point(0, 0);
            this.rpvBoletos.Name = "rpvBoletos";
            this.rpvBoletos.Size = new System.Drawing.Size(555, 438);
            this.rpvBoletos.TabIndex = 0;
            // 
            // frmBoletoVisualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 438);
            this.Controls.Add(this.rpvBoletos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBoletoVisualizar";
            this.Text = "Visualizar Boletos";
            this.Load += new System.EventHandler(this.frmBoletoVisualizar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBoletos;



    }
}