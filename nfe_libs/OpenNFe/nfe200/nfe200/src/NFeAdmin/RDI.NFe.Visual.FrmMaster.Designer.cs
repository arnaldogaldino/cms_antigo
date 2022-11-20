namespace RDI.NFe.Visual
{
    partial class FrmMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaster));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbHabilitar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCertificado = new System.Windows.Forms.ToolStripButton();
            this.tsbFolders = new System.Windows.Forms.ToolStripButton();
            this.tsbProxy = new System.Windows.Forms.ToolStripButton();
            this.tsbWebsrv = new System.Windows.Forms.ToolStripButton();
            this.tsbLotes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbStatusWebsrv = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbsobre = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certificadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastasDeArquivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosPendenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasFiscaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasInutilizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.janelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrincipal.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHabilitar,
            this.toolStripSeparator1,
            this.tsbCertificado,
            this.tsbFolders,
            this.tsbProxy,
            this.tsbWebsrv,
            this.tsbLotes,
            this.toolStripSeparator3,
            this.tsbLog,
            this.toolStripSeparator4,
            this.tsbStatusWebsrv,
            this.toolStripSeparator5,
            this.tsbsobre});
            this.tsPrincipal.Location = new System.Drawing.Point(0, 24);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(925, 25);
            this.tsPrincipal.TabIndex = 0;
            this.tsPrincipal.Text = "tsPrincipal";
            this.tsPrincipal.Visible = false;
            // 
            // tsbHabilitar
            // 
            this.tsbHabilitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHabilitar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHabilitar.Name = "tsbHabilitar";
            this.tsbHabilitar.Size = new System.Drawing.Size(23, 22);
            this.tsbHabilitar.Text = "Habilita Automação";
            this.tsbHabilitar.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCertificado
            // 
            this.tsbCertificado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCertificado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCertificado.Name = "tsbCertificado";
            this.tsbCertificado.Size = new System.Drawing.Size(23, 22);
            this.tsbCertificado.Text = "Selecione o certificado";
            this.tsbCertificado.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbFolders
            // 
            this.tsbFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFolders.Name = "tsbFolders";
            this.tsbFolders.Size = new System.Drawing.Size(23, 22);
            this.tsbFolders.Text = "Configuração Diretórios";
            this.tsbFolders.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tsbProxy
            // 
            this.tsbProxy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProxy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProxy.Name = "tsbProxy";
            this.tsbProxy.Size = new System.Drawing.Size(23, 22);
            this.tsbProxy.Text = "Configuração Proxy";
            this.tsbProxy.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tsbWebsrv
            // 
            this.tsbWebsrv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWebsrv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWebsrv.Name = "tsbWebsrv";
            this.tsbWebsrv.Size = new System.Drawing.Size(23, 22);
            this.tsbWebsrv.Text = "Configuração WebService";
            this.tsbWebsrv.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // tsbLotes
            // 
            this.tsbLotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLotes.Name = "tsbLotes";
            this.tsbLotes.Size = new System.Drawing.Size(23, 22);
            this.tsbLotes.Text = "Configuração Lotes de Notas";
            this.tsbLotes.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLog
            // 
            this.tsbLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLog.Name = "tsbLog";
            this.tsbLog.Size = new System.Drawing.Size(23, 22);
            this.tsbLog.Text = "Log do Sistema";
            this.tsbLog.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbStatusWebsrv
            // 
            this.tsbStatusWebsrv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStatusWebsrv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStatusWebsrv.Name = "tsbStatusWebsrv";
            this.tsbStatusWebsrv.Size = new System.Drawing.Size(23, 22);
            this.tsbStatusWebsrv.Text = "Status do Webservice";
            this.tsbStatusWebsrv.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbsobre
            // 
            this.tsbsobre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbsobre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbsobre.Name = "tsbsobre";
            this.tsbsobre.Size = new System.Drawing.Size(23, 22);
            this.tsbsobre.Text = "Sobre";
            this.tsbsobre.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(925, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.manutençãoToolStripMenuItem,
            this.logToolStripMenuItem1,
            this.janelasToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(925, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeEmpresaToolStripMenuItem,
            this.automaçãoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // cadastroDeEmpresaToolStripMenuItem
            // 
            this.cadastroDeEmpresaToolStripMenuItem.Name = "cadastroDeEmpresaToolStripMenuItem";
            this.cadastroDeEmpresaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cadastroDeEmpresaToolStripMenuItem.Text = "Cadastro de Empresa";
            this.cadastroDeEmpresaToolStripMenuItem.Visible = false;
            // 
            // automaçãoToolStripMenuItem
            // 
            this.automaçãoToolStripMenuItem.Name = "automaçãoToolStripMenuItem";
            this.automaçãoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.automaçãoToolStripMenuItem.Text = "Automação";
            this.automaçãoToolStripMenuItem.Click += new System.EventHandler(this.automaçãoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.certificadosToolStripMenuItem,
            this.pastasDeArquivosToolStripMenuItem,
            this.proxyToolStripMenuItem,
            this.webServicesToolStripMenuItem,
            this.lotesToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // certificadosToolStripMenuItem
            // 
            this.certificadosToolStripMenuItem.Name = "certificadosToolStripMenuItem";
            this.certificadosToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.certificadosToolStripMenuItem.Text = "Certificados";
            this.certificadosToolStripMenuItem.Click += new System.EventHandler(this.certificadosToolStripMenuItem_Click);
            // 
            // pastasDeArquivosToolStripMenuItem
            // 
            this.pastasDeArquivosToolStripMenuItem.Name = "pastasDeArquivosToolStripMenuItem";
            this.pastasDeArquivosToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.pastasDeArquivosToolStripMenuItem.Text = "Diretórios";
            this.pastasDeArquivosToolStripMenuItem.Click += new System.EventHandler(this.pastasDeArquivosToolStripMenuItem_Click);
            // 
            // proxyToolStripMenuItem
            // 
            this.proxyToolStripMenuItem.Name = "proxyToolStripMenuItem";
            this.proxyToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.proxyToolStripMenuItem.Text = "Proxy";
            this.proxyToolStripMenuItem.Click += new System.EventHandler(this.proxyToolStripMenuItem_Click);
            // 
            // webServicesToolStripMenuItem
            // 
            this.webServicesToolStripMenuItem.Name = "webServicesToolStripMenuItem";
            this.webServicesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.webServicesToolStripMenuItem.Text = "WebServices";
            this.webServicesToolStripMenuItem.Click += new System.EventHandler(this.webServicesToolStripMenuItem_Click);
            // 
            // lotesToolStripMenuItem
            // 
            this.lotesToolStripMenuItem.Name = "lotesToolStripMenuItem";
            this.lotesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.lotesToolStripMenuItem.Text = "Lotes";
            this.lotesToolStripMenuItem.Click += new System.EventHandler(this.lotesToolStripMenuItem_Click);
            // 
            // manutençãoToolStripMenuItem
            // 
            this.manutençãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviçosPendenteToolStripMenuItem,
            this.notasFiscaisToolStripMenuItem,
            this.notasInutilizadasToolStripMenuItem});
            this.manutençãoToolStripMenuItem.Name = "manutençãoToolStripMenuItem";
            this.manutençãoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.manutençãoToolStripMenuItem.Text = "Listas";
            // 
            // serviçosPendenteToolStripMenuItem
            // 
            this.serviçosPendenteToolStripMenuItem.Name = "serviçosPendenteToolStripMenuItem";
            this.serviçosPendenteToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.serviçosPendenteToolStripMenuItem.Text = "Serviços Pendentes";
            this.serviçosPendenteToolStripMenuItem.Click += new System.EventHandler(this.serviçosPendenteToolStripMenuItem_Click);
            // 
            // notasFiscaisToolStripMenuItem
            // 
            this.notasFiscaisToolStripMenuItem.Name = "notasFiscaisToolStripMenuItem";
            this.notasFiscaisToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.notasFiscaisToolStripMenuItem.Text = "Notas Fiscais";
            this.notasFiscaisToolStripMenuItem.Click += new System.EventHandler(this.notasFiscaisToolStripMenuItem_Click);
            // 
            // notasInutilizadasToolStripMenuItem
            // 
            this.notasInutilizadasToolStripMenuItem.Name = "notasInutilizadasToolStripMenuItem";
            this.notasInutilizadasToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.notasInutilizadasToolStripMenuItem.Text = "Notas Inutilizadas";
            this.notasInutilizadasToolStripMenuItem.Click += new System.EventHandler(this.notasInutilizadasToolStripMenuItem_Click);
            // 
            // logToolStripMenuItem1
            // 
            this.logToolStripMenuItem1.Name = "logToolStripMenuItem1";
            this.logToolStripMenuItem1.Size = new System.Drawing.Size(36, 20);
            this.logToolStripMenuItem1.Text = "Log";
            this.logToolStripMenuItem1.Click += new System.EventHandler(this.logToolStripMenuItem1_Click);
            // 
            // janelasToolStripMenuItem
            // 
            this.janelasToolStripMenuItem.Name = "janelasToolStripMenuItem";
            this.janelasToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.janelasToolStripMenuItem.Text = "Janelas";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // FrmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 564);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDI - Open NFe 2.00";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMaster_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaster_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem certificadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastasDeArquivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosPendenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasFiscaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbHabilitar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCertificado;
        private System.Windows.Forms.ToolStripButton tsbFolders;
        private System.Windows.Forms.ToolStripButton tsbProxy;
        private System.Windows.Forms.ToolStripButton tsbWebsrv;
        private System.Windows.Forms.ToolStripButton tsbLotes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbStatusWebsrv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbsobre;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbLog;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasInutilizadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem janelasToolStripMenuItem;
    }
}