namespace cms.Modulos.Fiscal.Forms.Ncm
{
    partial class frmFiscalNcmLockup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiscalNcmLockup));
            this.gvFinanceiroNcm = new System.Windows.Forms.DataGridView();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.txtNcm = new System.Windows.Forms.TextBox();
            this.lbNcm = new System.Windows.Forms.Label();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.ncm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroNcm)).BeginInit();
            this.gbPesquisa.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvFinanceiroNcm
            // 
            this.gvFinanceiroNcm.AllowUserToAddRows = false;
            this.gvFinanceiroNcm.AllowUserToDeleteRows = false;
            this.gvFinanceiroNcm.AllowUserToResizeColumns = false;
            this.gvFinanceiroNcm.AllowUserToResizeRows = false;
            this.gvFinanceiroNcm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroNcm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroNcm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ncm,
            this.descricao});
            this.gvFinanceiroNcm.Location = new System.Drawing.Point(12, 95);
            this.gvFinanceiroNcm.MultiSelect = false;
            this.gvFinanceiroNcm.Name = "gvFinanceiroNcm";
            this.gvFinanceiroNcm.ReadOnly = true;
            this.gvFinanceiroNcm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroNcm.ShowEditingIcon = false;
            this.gvFinanceiroNcm.ShowRowErrors = false;
            this.gvFinanceiroNcm.Size = new System.Drawing.Size(531, 278);
            this.gvFinanceiroNcm.TabIndex = 14;
            this.gvFinanceiroNcm.DoubleClick += new System.EventHandler(this.gvFinanceiroNcm_DoubleClick);
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.txtNcm);
            this.gbPesquisa.Controls.Add(this.lbNcm);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtDescricao);
            this.gbPesquisa.Controls.Add(this.lblDescricao);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(531, 47);
            this.gbPesquisa.TabIndex = 15;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Plano de Contas";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(428, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(222, 17);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(177, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(158, 20);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição:";
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOk,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(555, 39);
            this.tsMenu.TabIndex = 16;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btOk
            // 
            this.btOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOk.Image = global::cms.Properties.Resources.ok;
            this.btOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(36, 36);
            this.btOk.Text = "Selecionar Cliente";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
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
            // txtNcm
            // 
            this.txtNcm.Location = new System.Drawing.Point(44, 17);
            this.txtNcm.Name = "txtNcm";
            this.txtNcm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNcm.Size = new System.Drawing.Size(108, 20);
            this.txtNcm.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtNcm, ToolMasked.TextMask.Formats.Ncm);
            // 
            // lbNcm
            // 
            this.lbNcm.AutoSize = true;
            this.lbNcm.Location = new System.Drawing.Point(6, 20);
            this.lbNcm.Name = "lbNcm";
            this.lbNcm.Size = new System.Drawing.Size(32, 13);
            this.lbNcm.TabIndex = 7;
            this.lbNcm.Text = "Ncm:";
            // 
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // ncm
            // 
            this.ncm.DataPropertyName = "ncm";
            this.ncm.HeaderText = "NCM";
            this.ncm.Name = "ncm";
            this.ncm.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // frmFiscalNcmLockup
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 385);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.gvFinanceiroNcm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFiscalNcmLockup";
            this.Text = "Pesquisar Plano de Contas";
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroNcm)).EndInit();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFinanceiroNcm;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.TextBox txtNcm;
        private System.Windows.Forms.Label lbNcm;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncm;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}