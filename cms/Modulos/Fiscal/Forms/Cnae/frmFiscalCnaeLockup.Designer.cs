namespace cms.Modulos.Fiscal.Forms.Cnae
{
    partial class frmFiscalCnaeLockup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiscalCnaeLockup));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.txtSubClasse = new System.Windows.Forms.TextBox();
            this.lbCfop = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDenominacao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.gvCNAE = new System.Windows.Forms.DataGridView();
            this.colSecao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDivisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClasse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubClasse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDenominacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.gbPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCNAE)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOk,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(970, 39);
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
            this.btOk.Text = "Selecionar CNAE";
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
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.txtSubClasse);
            this.gbPesquisa.Controls.Add(this.lbCfop);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtDenominacao);
            this.gbPesquisa.Controls.Add(this.lbDescricao);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(946, 49);
            this.gbPesquisa.TabIndex = 17;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar CNAE";
            // 
            // txtSubClasse
            // 
            this.txtSubClasse.Location = new System.Drawing.Point(78, 17);
            this.txtSubClasse.MaxLength = 4;
            this.txtSubClasse.Name = "txtSubClasse";
            this.txtSubClasse.Size = new System.Drawing.Size(73, 20);
            this.txtSubClasse.TabIndex = 1;
            // 
            // lbCfop
            // 
            this.lbCfop.AutoSize = true;
            this.lbCfop.Location = new System.Drawing.Point(9, 20);
            this.lbCfop.Name = "lbCfop";
            this.lbCfop.Size = new System.Drawing.Size(63, 13);
            this.lbCfop.TabIndex = 5;
            this.lbCfop.Text = "Sub-Classe:";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(843, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtDenominacao
            // 
            this.txtDenominacao.Location = new System.Drawing.Point(239, 17);
            this.txtDenominacao.Name = "txtDenominacao";
            this.txtDenominacao.Size = new System.Drawing.Size(284, 20);
            this.txtDenominacao.TabIndex = 2;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(157, 20);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(76, 13);
            this.lbDescricao.TabIndex = 0;
            this.lbDescricao.Text = "Denominação:";
            // 
            // gvCNAE
            // 
            this.gvCNAE.AllowUserToAddRows = false;
            this.gvCNAE.AllowUserToDeleteRows = false;
            this.gvCNAE.AllowUserToResizeColumns = false;
            this.gvCNAE.AllowUserToResizeRows = false;
            this.gvCNAE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCNAE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCNAE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSecao,
            this.colDivisao,
            this.colGrupo,
            this.colClasse,
            this.colSubClasse,
            this.colDenominacao});
            this.gvCNAE.Location = new System.Drawing.Point(12, 97);
            this.gvCNAE.MultiSelect = false;
            this.gvCNAE.Name = "gvCNAE";
            this.gvCNAE.ReadOnly = true;
            this.gvCNAE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCNAE.ShowEditingIcon = false;
            this.gvCNAE.ShowRowErrors = false;
            this.gvCNAE.Size = new System.Drawing.Size(946, 206);
            this.gvCNAE.TabIndex = 18;
            this.gvCNAE.VirtualMode = true;
            this.gvCNAE.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvCNAE_MouseDoubleClick);
            // 
            // colSecao
            // 
            this.colSecao.DataPropertyName = "secao";
            this.colSecao.HeaderText = "Seção";
            this.colSecao.Name = "colSecao";
            this.colSecao.ReadOnly = true;
            // 
            // colDivisao
            // 
            this.colDivisao.DataPropertyName = "divisao";
            this.colDivisao.HeaderText = "Divisão";
            this.colDivisao.Name = "colDivisao";
            this.colDivisao.ReadOnly = true;
            // 
            // colGrupo
            // 
            this.colGrupo.DataPropertyName = "grupo";
            this.colGrupo.HeaderText = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.ReadOnly = true;
            // 
            // colClasse
            // 
            this.colClasse.DataPropertyName = "classe";
            this.colClasse.HeaderText = "Classe";
            this.colClasse.Name = "colClasse";
            this.colClasse.ReadOnly = true;
            // 
            // colSubClasse
            // 
            this.colSubClasse.DataPropertyName = "subclasse";
            this.colSubClasse.HeaderText = "Sub-Classe";
            this.colSubClasse.Name = "colSubClasse";
            this.colSubClasse.ReadOnly = true;
            // 
            // colDenominacao
            // 
            this.colDenominacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDenominacao.DataPropertyName = "denominacao";
            this.colDenominacao.HeaderText = "Denominação";
            this.colDenominacao.Name = "colDenominacao";
            this.colDenominacao.ReadOnly = true;
            // 
            // frmFiscalCnaeLockup
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 315);
            this.Controls.Add(this.gvCNAE);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFiscalCnaeLockup";
            this.Text = "Pesquisar CNAE";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCNAE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtSubClasse;
        private System.Windows.Forms.Label lbCfop;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDenominacao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.DataGridView gvCNAE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDivisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClasse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubClasse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDenominacao;
    }
}