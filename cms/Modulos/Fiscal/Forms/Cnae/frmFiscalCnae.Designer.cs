namespace cms.Modulos.Fiscal.Forms.Cnae
{
    partial class frmFiscalCnae
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
            this.components = new System.ComponentModel.Container();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbCnae = new System.Windows.Forms.GroupBox();
            this.lblDenominacao = new System.Windows.Forms.Label();
            this.txtDenominacao = new System.Windows.Forms.TextBox();
            this.txtSubClasse = new System.Windows.Forms.TextBox();
            this.txtClasse = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.txtDivisao = new System.Windows.Forms.TextBox();
            this.txtSecao = new System.Windows.Forms.TextBox();
            this.lblSubClasse = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblDivisao = new System.Windows.Forms.Label();
            this.lblSecao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.tsMenu.SuspendLayout();
            this.gbCnae.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btEditar,
            this.btExcluir,
            this.btGravar,
            this.btCancelar,
            this.toolStripSeparator1,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(860, 39);
            this.tsMenu.TabIndex = 33;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btNovo
            // 
            this.btNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btNovo.Image = global::cms.Properties.Resources.novo;
            this.btNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(36, 36);
            this.btNovo.Text = "Novo CNAE";
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btEditar
            // 
            this.btEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEditar.Image = global::cms.Properties.Resources.editar;
            this.btEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(36, 36);
            this.btEditar.Text = "Editar CNAE";
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btExcluir.Image = global::cms.Properties.Resources.excluir;
            this.btExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(36, 36);
            this.btExcluir.Text = "Excluir CNAE";
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btGravar
            // 
            this.btGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGravar.Image = global::cms.Properties.Resources.gravar;
            this.btGravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(36, 36);
            this.btGravar.Text = "Gravar CNAE";
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelar.Image = global::cms.Properties.Resources.cancelar;
            this.btCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(36, 36);
            this.btCancelar.Text = "Cancelar Ação";
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btFechar
            // 
            this.btFechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btFechar.Image = global::cms.Properties.Resources.fechar;
            this.btFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(36, 36);
            this.btFechar.Text = "Fechar";
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // gbCnae
            // 
            this.gbCnae.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCnae.Controls.Add(this.lblDenominacao);
            this.gbCnae.Controls.Add(this.txtDenominacao);
            this.gbCnae.Controls.Add(this.txtSubClasse);
            this.gbCnae.Controls.Add(this.txtClasse);
            this.gbCnae.Controls.Add(this.txtGrupo);
            this.gbCnae.Controls.Add(this.txtDivisao);
            this.gbCnae.Controls.Add(this.txtSecao);
            this.gbCnae.Controls.Add(this.lblSubClasse);
            this.gbCnae.Controls.Add(this.lblClasse);
            this.gbCnae.Controls.Add(this.lblGrupo);
            this.gbCnae.Controls.Add(this.lblDivisao);
            this.gbCnae.Controls.Add(this.lblSecao);
            this.gbCnae.Controls.Add(this.txtCodigo);
            this.gbCnae.Controls.Add(this.lblCodigo);
            this.gbCnae.Location = new System.Drawing.Point(12, 42);
            this.gbCnae.Name = "gbCnae";
            this.gbCnae.Size = new System.Drawing.Size(836, 169);
            this.gbCnae.TabIndex = 34;
            this.gbCnae.TabStop = false;
            this.gbCnae.Text = "CFOP";
            // 
            // lblDenominacao
            // 
            this.lblDenominacao.AutoSize = true;
            this.lblDenominacao.Location = new System.Drawing.Point(7, 74);
            this.lblDenominacao.Name = "lblDenominacao";
            this.lblDenominacao.Size = new System.Drawing.Size(76, 13);
            this.lblDenominacao.TabIndex = 16;
            this.lblDenominacao.Text = "Denominação:";
            // 
            // txtDenominacao
            // 
            this.txtDenominacao.Location = new System.Drawing.Point(89, 71);
            this.txtDenominacao.MaxLength = 705;
            this.txtDenominacao.Multiline = true;
            this.txtDenominacao.Name = "txtDenominacao";
            this.txtDenominacao.Size = new System.Drawing.Size(671, 88);
            this.txtDenominacao.TabIndex = 15;
            this.TextMaskedit.SetTextMasked(this.txtDenominacao, ToolMasked.TextMask.Formats.None);
            // 
            // txtSubClasse
            // 
            this.txtSubClasse.Location = new System.Drawing.Point(508, 45);
            this.txtSubClasse.MaxLength = 8;
            this.txtSubClasse.Name = "txtSubClasse";
            this.txtSubClasse.Size = new System.Drawing.Size(66, 20);
            this.txtSubClasse.TabIndex = 14;
            this.TextMaskedit.SetTextMasked(this.txtSubClasse, ToolMasked.TextMask.Formats.None);
            // 
            // txtClasse
            // 
            this.txtClasse.Location = new System.Drawing.Point(367, 45);
            this.txtClasse.MaxLength = 6;
            this.txtClasse.Name = "txtClasse";
            this.txtClasse.Size = new System.Drawing.Size(66, 20);
            this.txtClasse.TabIndex = 14;
            this.TextMaskedit.SetTextMasked(this.txtClasse, ToolMasked.TextMask.Formats.None);
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(263, 45);
            this.txtGrupo.MaxLength = 3;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(51, 20);
            this.txtGrupo.TabIndex = 14;
            this.TextMaskedit.SetTextMasked(this.txtGrupo, ToolMasked.TextMask.Formats.None);
            // 
            // txtDivisao
            // 
            this.txtDivisao.Location = new System.Drawing.Point(161, 45);
            this.txtDivisao.MaxLength = 2;
            this.txtDivisao.Name = "txtDivisao";
            this.txtDivisao.Size = new System.Drawing.Size(51, 20);
            this.txtDivisao.TabIndex = 14;
            this.TextMaskedit.SetTextMasked(this.txtDivisao, ToolMasked.TextMask.Formats.None);
            // 
            // txtSecao
            // 
            this.txtSecao.Location = new System.Drawing.Point(53, 45);
            this.txtSecao.MaxLength = 1;
            this.txtSecao.Name = "txtSecao";
            this.txtSecao.Size = new System.Drawing.Size(51, 20);
            this.txtSecao.TabIndex = 14;
            this.TextMaskedit.SetTextMasked(this.txtSecao, ToolMasked.TextMask.Formats.None);
            // 
            // lblSubClasse
            // 
            this.lblSubClasse.AutoSize = true;
            this.lblSubClasse.Location = new System.Drawing.Point(439, 48);
            this.lblSubClasse.Name = "lblSubClasse";
            this.lblSubClasse.Size = new System.Drawing.Size(63, 13);
            this.lblSubClasse.TabIndex = 13;
            this.lblSubClasse.Text = "Sub-Classe:";
            // 
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Location = new System.Drawing.Point(320, 48);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(41, 13);
            this.lblClasse.TabIndex = 13;
            this.lblClasse.Text = "Classe:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(218, 48);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 13;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblDivisao
            // 
            this.lblDivisao.AutoSize = true;
            this.lblDivisao.Location = new System.Drawing.Point(110, 48);
            this.lblDivisao.Name = "lblDivisao";
            this.lblDivisao.Size = new System.Drawing.Size(45, 13);
            this.lblDivisao.TabIndex = 13;
            this.lblDivisao.Text = "Divisão:";
            // 
            // lblSecao
            // 
            this.lblSecao.AutoSize = true;
            this.lblSecao.Location = new System.Drawing.Point(6, 48);
            this.lblSecao.Name = "lblSecao";
            this.lblSecao.Size = new System.Drawing.Size(41, 13);
            this.lblSecao.TabIndex = 13;
            this.lblSecao.Text = "Seção:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(66, 20);
            this.txtCodigo.TabIndex = 9;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.Numero);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 22);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código:";
            // 
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // ValidarForm
            // 
            this.ValidarForm.AutomaticDelay = 50;
            this.ValidarForm.AutoPopDelay = 500;
            this.ValidarForm.InitialDelay = 50;
            this.ValidarForm.IsBalloon = true;
            this.ValidarForm.OwnerDraw = true;
            this.ValidarForm.ReshowDelay = 5;
            this.ValidarForm.ShowAlways = true;
            this.ValidarForm.StripAmpersands = true;
            this.ValidarForm.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.ValidarForm.ToolTipTitle = "Campo Inválido.";
            // 
            // frmFiscalCnae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 262);
            this.Controls.Add(this.gbCnae);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFiscalCnae";
            this.Text = "CNAE";
            this.Load += new System.EventHandler(this.frmFiscalCfop_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCnae.ResumeLayout(false);
            this.gbCnae.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btEditar;
        private System.Windows.Forms.ToolStripButton btExcluir;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbCnae;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.Label lblSecao;
        private System.Windows.Forms.Label lblDenominacao;
        private System.Windows.Forms.TextBox txtDenominacao;
        private System.Windows.Forms.TextBox txtSecao;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.Label lblDivisao;
        private System.Windows.Forms.TextBox txtDivisao;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.TextBox txtClasse;
        private System.Windows.Forms.TextBox txtSubClasse;
        private System.Windows.Forms.Label lblSubClasse;
    }
}