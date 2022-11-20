namespace cms.Modulos.Fiscal.Forms.Cfop
{
    partial class frmFiscalCfopLockup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiscalCfopLockup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.rbTipoSaida = new System.Windows.Forms.RadioButton();
            this.rbTipoEntrada = new System.Windows.Forms.RadioButton();
            this.lbTipo = new System.Windows.Forms.Label();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.lbCfop = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.gvCFOP = new System.Windows.Forms.DataGridView();
            this.ColCFOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.gbPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCFOP)).BeginInit();
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
            this.btOk.Text = "Selecionar CFOP";
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
            this.gbPesquisa.Controls.Add(this.rbTipoSaida);
            this.gbPesquisa.Controls.Add(this.rbTipoEntrada);
            this.gbPesquisa.Controls.Add(this.lbTipo);
            this.gbPesquisa.Controls.Add(this.txtCFOP);
            this.gbPesquisa.Controls.Add(this.lbCfop);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtDescricao);
            this.gbPesquisa.Controls.Add(this.lbDescricao);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(946, 49);
            this.gbPesquisa.TabIndex = 17;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar CFOP";
            // 
            // rbTipoSaida
            // 
            this.rbTipoSaida.AutoSize = true;
            this.rbTipoSaida.Location = new System.Drawing.Point(558, 17);
            this.rbTipoSaida.Name = "rbTipoSaida";
            this.rbTipoSaida.Size = new System.Drawing.Size(54, 17);
            this.rbTipoSaida.TabIndex = 9;
            this.rbTipoSaida.Text = "Saída";
            this.rbTipoSaida.UseVisualStyleBackColor = true;
            // 
            // rbTipoEntrada
            // 
            this.rbTipoEntrada.AutoSize = true;
            this.rbTipoEntrada.Location = new System.Drawing.Point(490, 17);
            this.rbTipoEntrada.Name = "rbTipoEntrada";
            this.rbTipoEntrada.Size = new System.Drawing.Size(62, 17);
            this.rbTipoEntrada.TabIndex = 8;
            this.rbTipoEntrada.Text = "Entrada";
            this.rbTipoEntrada.UseVisualStyleBackColor = true;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(453, 20);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(31, 13);
            this.lbTipo.TabIndex = 6;
            this.lbTipo.Text = "Tipo:";
            // 
            // txtCFOP
            // 
            this.txtCFOP.Location = new System.Drawing.Point(53, 17);
            this.txtCFOP.MaxLength = 4;
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCFOP.Size = new System.Drawing.Size(52, 20);
            this.txtCFOP.TabIndex = 1;
            // 
            // lbCfop
            // 
            this.lbCfop.AutoSize = true;
            this.lbCfop.Location = new System.Drawing.Point(9, 20);
            this.lbCfop.Name = "lbCfop";
            this.lbCfop.Size = new System.Drawing.Size(38, 13);
            this.lbCfop.TabIndex = 5;
            this.lbCfop.Text = "CFOP:";
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
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(179, 17);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(268, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(111, 19);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(58, 13);
            this.lbDescricao.TabIndex = 0;
            this.lbDescricao.Text = "Descrição:";
            // 
            // gvCFOP
            // 
            this.gvCFOP.AllowUserToAddRows = false;
            this.gvCFOP.AllowUserToDeleteRows = false;
            this.gvCFOP.AllowUserToOrderColumns = true;
            this.gvCFOP.AllowUserToResizeColumns = false;
            this.gvCFOP.AllowUserToResizeRows = false;
            this.gvCFOP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCFOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCFOP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCFOP,
            this.tipo,
            this.descricao});
            this.gvCFOP.Location = new System.Drawing.Point(12, 97);
            this.gvCFOP.MultiSelect = false;
            this.gvCFOP.Name = "gvCFOP";
            this.gvCFOP.ReadOnly = true;
            this.gvCFOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCFOP.ShowEditingIcon = false;
            this.gvCFOP.ShowRowErrors = false;
            this.gvCFOP.Size = new System.Drawing.Size(946, 206);
            this.gvCFOP.TabIndex = 18;
            this.gvCFOP.VirtualMode = true;
            this.gvCFOP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvCFOP_MouseDoubleClick);
            // 
            // ColCFOP
            // 
            this.ColCFOP.DataPropertyName = "cfop";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColCFOP.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColCFOP.FillWeight = 50F;
            this.ColCFOP.HeaderText = "CFOP";
            this.ColCFOP.Name = "ColCFOP";
            this.ColCFOP.ReadOnly = true;
            this.ColCFOP.Width = 50;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.FillWeight = 60F;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 60;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.FillWeight = 130F;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // frmFiscalCfopLockup
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 315);
            this.Controls.Add(this.gvCFOP);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFiscalCfopLockup";
            this.Text = "Pesquisar CFOP";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCFOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.RadioButton rbTipoSaida;
        private System.Windows.Forms.RadioButton rbTipoEntrada;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.Label lbCfop;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.DataGridView gvCFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}