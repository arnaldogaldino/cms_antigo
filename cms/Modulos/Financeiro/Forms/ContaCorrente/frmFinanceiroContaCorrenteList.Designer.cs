namespace cms.Modulos.Financeiro.Forms.ContaCorrente
{
    partial class frmFinanceiroContaCorrenteList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceiroContaCorrenteList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btAtualizar = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gvFinanceiroContaCorrente = new System.Windows.Forms.DataGridView();
            this.id_conta_corrente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gerente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta_corrente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boleto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.data_cadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroContaCorrente)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btAtualizar,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(885, 39);
            this.tsMenu.TabIndex = 13;
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
            // btAtualizar
            // 
            this.btAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btAtualizar.Image")));
            this.btAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(36, 36);
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
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
            // gvFinanceiroContaCorrente
            // 
            this.gvFinanceiroContaCorrente.AllowUserToAddRows = false;
            this.gvFinanceiroContaCorrente.AllowUserToDeleteRows = false;
            this.gvFinanceiroContaCorrente.AllowUserToResizeColumns = false;
            this.gvFinanceiroContaCorrente.AllowUserToResizeRows = false;
            this.gvFinanceiroContaCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroContaCorrente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroContaCorrente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_conta_corrente,
            this.banco,
            this.gerente,
            this.agencia,
            this.conta_corrente,
            this.boleto,
            this.data_cadastro});
            this.gvFinanceiroContaCorrente.Location = new System.Drawing.Point(12, 42);
            this.gvFinanceiroContaCorrente.MultiSelect = false;
            this.gvFinanceiroContaCorrente.Name = "gvFinanceiroContaCorrente";
            this.gvFinanceiroContaCorrente.ReadOnly = true;
            this.gvFinanceiroContaCorrente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroContaCorrente.ShowEditingIcon = false;
            this.gvFinanceiroContaCorrente.ShowRowErrors = false;
            this.gvFinanceiroContaCorrente.Size = new System.Drawing.Size(861, 208);
            this.gvFinanceiroContaCorrente.TabIndex = 14;
            this.gvFinanceiroContaCorrente.DoubleClick += new System.EventHandler(this.gvFinanceiroContaCorrente_DoubleClick);
            // 
            // id_conta_corrente
            // 
            this.id_conta_corrente.DataPropertyName = "id_financeiro_conta_corrente";
            this.id_conta_corrente.HeaderText = "Código";
            this.id_conta_corrente.Name = "id_conta_corrente";
            this.id_conta_corrente.ReadOnly = true;
            // 
            // banco
            // 
            this.banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.banco.DataPropertyName = "banco";
            this.banco.HeaderText = "Banco";
            this.banco.Name = "banco";
            this.banco.ReadOnly = true;
            // 
            // gerente
            // 
            this.gerente.DataPropertyName = "gerente";
            this.gerente.HeaderText = "Gerente";
            this.gerente.Name = "gerente";
            this.gerente.ReadOnly = true;
            this.gerente.Width = 200;
            // 
            // agencia
            // 
            this.agencia.DataPropertyName = "agencia";
            this.agencia.HeaderText = "Agencia";
            this.agencia.Name = "agencia";
            this.agencia.ReadOnly = true;
            this.agencia.Width = 150;
            // 
            // conta_corrente
            // 
            this.conta_corrente.DataPropertyName = "conta";
            this.conta_corrente.HeaderText = "Conta Corrente";
            this.conta_corrente.Name = "conta_corrente";
            this.conta_corrente.ReadOnly = true;
            this.conta_corrente.Width = 150;
            // 
            // boleto
            // 
            this.boleto.DataPropertyName = "boleto";
            this.boleto.HeaderText = "Boleto";
            this.boleto.Name = "boleto";
            this.boleto.ReadOnly = true;
            this.boleto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.boleto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // data_cadastro
            // 
            this.data_cadastro.DataPropertyName = "data_cadastro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.data_cadastro.DefaultCellStyle = dataGridViewCellStyle1;
            this.data_cadastro.HeaderText = "Data Cadastro";
            this.data_cadastro.Name = "data_cadastro";
            this.data_cadastro.ReadOnly = true;
            this.data_cadastro.Width = 120;
            // 
            // frmFinanceiroContaCorrenteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 262);
            this.Controls.Add(this.gvFinanceiroContaCorrente);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroContaCorrenteList";
            this.Text = "Pesquisar Conta Corrente";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroContaCorrente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvFinanceiroContaCorrente;
        private System.Windows.Forms.ToolStripButton btAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_conta_corrente;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn gerente;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_corrente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn boleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_cadastro;
    }
}