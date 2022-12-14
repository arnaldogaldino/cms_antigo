namespace cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas
{
    partial class frmFinanceiroPlanoContasList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceiroPlanoContasList));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gvFinanceiroPlanoContas = new System.Windows.Forms.DataGridView();
            this.plano_conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroPlanoContas)).BeginInit();
            this.gbPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(555, 39);
            this.tsMenu.TabIndex = 12;
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
            this.btNovo.Text = "Novo Cliente";
            this.btNovo.ToolTipText = "Novo Cliente";
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
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
            // gvFinanceiroPlanoContas
            // 
            this.gvFinanceiroPlanoContas.AllowUserToAddRows = false;
            this.gvFinanceiroPlanoContas.AllowUserToDeleteRows = false;
            this.gvFinanceiroPlanoContas.AllowUserToResizeColumns = false;
            this.gvFinanceiroPlanoContas.AllowUserToResizeRows = false;
            this.gvFinanceiroPlanoContas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroPlanoContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroPlanoContas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plano_conta,
            this.descricao});
            this.gvFinanceiroPlanoContas.Location = new System.Drawing.Point(12, 95);
            this.gvFinanceiroPlanoContas.MultiSelect = false;
            this.gvFinanceiroPlanoContas.Name = "gvFinanceiroPlanoContas";
            this.gvFinanceiroPlanoContas.ReadOnly = true;
            this.gvFinanceiroPlanoContas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroPlanoContas.ShowEditingIcon = false;
            this.gvFinanceiroPlanoContas.ShowRowErrors = false;
            this.gvFinanceiroPlanoContas.Size = new System.Drawing.Size(531, 238);
            this.gvFinanceiroPlanoContas.TabIndex = 14;
            this.gvFinanceiroPlanoContas.DoubleClick += new System.EventHandler(this.gvFinanceiroPlanoContas_DoubleClick);
            // 
            // plano_conta
            // 
            this.plano_conta.DataPropertyName = "plano_conta";
            this.plano_conta.HeaderText = "Plano Contas";
            this.plano_conta.Name = "plano_conta";
            this.plano_conta.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtDescricao);
            this.gbPesquisa.Controls.Add(this.lblDescricao);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(531, 47);
            this.gbPesquisa.TabIndex = 15;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Cliente";
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
            this.txtDescricao.Location = new System.Drawing.Point(70, 16);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(315, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 19);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição:";
            // 
            // frmFinanceiroPlanoContasList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 345);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.gvFinanceiroPlanoContas);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroPlanoContasList";
            this.Text = "Pesquisar Plano de Contas";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroPlanoContas)).EndInit();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvFinanceiroPlanoContas;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano_conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
    }
}