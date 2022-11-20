namespace cms.Modulos.Fiscal.Forms.NaturezaOperacao
{
    partial class frmNaturezaOperacaoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNaturezaOperacaoList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.rbTipoSaida = new System.Windows.Forms.RadioButton();
            this.rbTipoEntrada = new System.Windows.Forms.RadioButton();
            this.lbTipo = new System.Windows.Forms.Label();
            this.txtNatOp = new System.Windows.Forms.TextBox();
            this.lbCfop = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.gvNaturezaOperacao = new System.Windows.Forms.DataGridView();
            this.id_fiscal_natureza_operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextMask = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            this.gbPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvNaturezaOperacao)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(767, 39);
            this.tsMenu.TabIndex = 9;
            // 
            // btNovo
            // 
            this.btNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btNovo.Image = global::cms.Properties.Resources.novo;
            this.btNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(36, 36);
            this.btNovo.Text = "Nova Natureza da Operação";
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
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.rbTipoSaida);
            this.gbPesquisa.Controls.Add(this.rbTipoEntrada);
            this.gbPesquisa.Controls.Add(this.lbTipo);
            this.gbPesquisa.Controls.Add(this.txtNatOp);
            this.gbPesquisa.Controls.Add(this.lbCfop);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtDescricao);
            this.gbPesquisa.Controls.Add(this.lbDescricao);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(743, 46);
            this.gbPesquisa.TabIndex = 10;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Natureza da Operação";
            // 
            // rbTipoSaida
            // 
            this.rbTipoSaida.AutoSize = true;
            this.rbTipoSaida.Location = new System.Drawing.Point(546, 17);
            this.rbTipoSaida.Name = "rbTipoSaida";
            this.rbTipoSaida.Size = new System.Drawing.Size(54, 17);
            this.rbTipoSaida.TabIndex = 9;
            this.rbTipoSaida.Text = "Saída";
            this.rbTipoSaida.UseVisualStyleBackColor = true;
            // 
            // rbTipoEntrada
            // 
            this.rbTipoEntrada.AutoSize = true;
            this.rbTipoEntrada.Location = new System.Drawing.Point(478, 17);
            this.rbTipoEntrada.Name = "rbTipoEntrada";
            this.rbTipoEntrada.Size = new System.Drawing.Size(62, 17);
            this.rbTipoEntrada.TabIndex = 8;
            this.rbTipoEntrada.Text = "Entrada";
            this.rbTipoEntrada.UseVisualStyleBackColor = true;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(441, 19);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(31, 13);
            this.lbTipo.TabIndex = 6;
            this.lbTipo.Text = "Tipo:";
            // 
            // txtNatOp
            // 
            this.txtNatOp.Location = new System.Drawing.Point(45, 16);
            this.txtNatOp.MaxLength = 4;
            this.txtNatOp.Name = "txtNatOp";
            this.txtNatOp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNatOp.Size = new System.Drawing.Size(52, 20);
            this.txtNatOp.TabIndex = 1;
            this.TextMask.SetTextMasked(this.txtNatOp, ToolMasked.TextMask.Formats.Numero);
            // 
            // lbCfop
            // 
            this.lbCfop.AutoSize = true;
            this.lbCfop.Location = new System.Drawing.Point(9, 20);
            this.lbCfop.Name = "lbCfop";
            this.lbCfop.Size = new System.Drawing.Size(30, 13);
            this.lbCfop.TabIndex = 5;
            this.lbCfop.Text = "Nat.:";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(640, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(167, 16);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(268, 20);
            this.txtDescricao.TabIndex = 2;
            this.TextMask.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(103, 19);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(58, 13);
            this.lbDescricao.TabIndex = 0;
            this.lbDescricao.Text = "Descrição:";
            // 
            // gvNaturezaOperacao
            // 
            this.gvNaturezaOperacao.AllowUserToAddRows = false;
            this.gvNaturezaOperacao.AllowUserToDeleteRows = false;
            this.gvNaturezaOperacao.AllowUserToOrderColumns = true;
            this.gvNaturezaOperacao.AllowUserToResizeColumns = false;
            this.gvNaturezaOperacao.AllowUserToResizeRows = false;
            this.gvNaturezaOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvNaturezaOperacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNaturezaOperacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_fiscal_natureza_operacao,
            this.tipo,
            this.descricao});
            this.gvNaturezaOperacao.Location = new System.Drawing.Point(12, 94);
            this.gvNaturezaOperacao.MultiSelect = false;
            this.gvNaturezaOperacao.Name = "gvNaturezaOperacao";
            this.gvNaturezaOperacao.ReadOnly = true;
            this.gvNaturezaOperacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvNaturezaOperacao.ShowEditingIcon = false;
            this.gvNaturezaOperacao.ShowRowErrors = false;
            this.gvNaturezaOperacao.Size = new System.Drawing.Size(743, 156);
            this.gvNaturezaOperacao.TabIndex = 11;
            this.gvNaturezaOperacao.VirtualMode = true;
            this.gvNaturezaOperacao.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvNaturezaOperacao_MouseDoubleClick);
            // 
            // id_fiscal_natureza_operacao
            // 
            this.id_fiscal_natureza_operacao.DataPropertyName = "id_fiscal_natureza_operacao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id_fiscal_natureza_operacao.DefaultCellStyle = dataGridViewCellStyle1;
            this.id_fiscal_natureza_operacao.HeaderText = "Nat. Op.";
            this.id_fiscal_natureza_operacao.Name = "id_fiscal_natureza_operacao";
            this.id_fiscal_natureza_operacao.ReadOnly = true;
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
            // TextMask
            // 
            this.TextMask.Text = null;
            // 
            // frmNaturezaOperacaoList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 262);
            this.Controls.Add(this.gvNaturezaOperacao);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNaturezaOperacaoList";
            this.Text = "Pesquisar Natureza Operação";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvNaturezaOperacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.RadioButton rbTipoSaida;
        private System.Windows.Forms.RadioButton rbTipoEntrada;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.TextBox txtNatOp;
        private System.Windows.Forms.Label lbCfop;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.DataGridView gvNaturezaOperacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_fiscal_natureza_operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private ToolMasked.TextMask TextMask;
    }
}