namespace cms.Modulos.Compra.Forms
{
    partial class frmCompraList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompraList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.gbCompra = new System.Windows.Forms.GroupBox();
            this.cbStatusCompra = new System.Windows.Forms.ComboBox();
            this.dtaPrevisaoEntregaAte = new System.Windows.Forms.DateTimePicker();
            this.dtaRecebimentoAte = new System.Windows.Forms.DateTimePicker();
            this.dtaRecebimentoDe = new System.Windows.Forms.DateTimePicker();
            this.dtaPrevisaoEntregaDe = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btFornecedor = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.gvCompras = new System.Windows.Forms.DataGridView();
            this.colIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataPrevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.textMasked = new ToolMasked.TextMask(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dtaDataCadastroAte = new System.Windows.Forms.DateTimePicker();
            this.dtaDataCadastroDe = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompras)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(796, 19);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 11;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // gbCompra
            // 
            this.gbCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCompra.Controls.Add(this.txtCodigo);
            this.gbCompra.Controls.Add(this.cbStatusCompra);
            this.gbCompra.Controls.Add(this.dtaPrevisaoEntregaAte);
            this.gbCompra.Controls.Add(this.dtaDataCadastroAte);
            this.gbCompra.Controls.Add(this.dtaRecebimentoAte);
            this.gbCompra.Controls.Add(this.dtaRecebimentoDe);
            this.gbCompra.Controls.Add(this.dtaPrevisaoEntregaDe);
            this.gbCompra.Controls.Add(this.dtaDataCadastroDe);
            this.gbCompra.Controls.Add(this.label2);
            this.gbCompra.Controls.Add(this.label9);
            this.gbCompra.Controls.Add(this.label7);
            this.gbCompra.Controls.Add(this.label5);
            this.gbCompra.Controls.Add(this.label8);
            this.gbCompra.Controls.Add(this.label6);
            this.gbCompra.Controls.Add(this.label4);
            this.gbCompra.Controls.Add(this.label3);
            this.gbCompra.Controls.Add(this.label1);
            this.gbCompra.Controls.Add(this.btFornecedor);
            this.gbCompra.Controls.Add(this.txtFornecedor);
            this.gbCompra.Controls.Add(this.btPesquisar);
            this.gbCompra.Location = new System.Drawing.Point(12, 43);
            this.gbCompra.Name = "gbCompra";
            this.gbCompra.Size = new System.Drawing.Size(899, 123);
            this.gbCompra.TabIndex = 0;
            this.gbCompra.TabStop = false;
            this.gbCompra.Text = "Pesquisar Compra";
            // 
            // cbStatusCompra
            // 
            this.cbStatusCompra.DisplayMember = "display";
            this.cbStatusCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusCompra.FormattingEnabled = true;
            this.cbStatusCompra.Location = new System.Drawing.Point(607, 19);
            this.cbStatusCompra.Name = "cbStatusCompra";
            this.cbStatusCompra.Size = new System.Drawing.Size(163, 21);
            this.cbStatusCompra.TabIndex = 4;
            this.cbStatusCompra.ValueMember = "value";
            // 
            // dtaPrevisaoEntregaAte
            // 
            this.dtaPrevisaoEntregaAte.Checked = false;
            this.dtaPrevisaoEntregaAte.CustomFormat = "dd/MM/yyyy";
            this.dtaPrevisaoEntregaAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaPrevisaoEntregaAte.Location = new System.Drawing.Point(264, 71);
            this.dtaPrevisaoEntregaAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaPrevisaoEntregaAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaPrevisaoEntregaAte.Name = "dtaPrevisaoEntregaAte";
            this.dtaPrevisaoEntregaAte.ShowCheckBox = true;
            this.dtaPrevisaoEntregaAte.Size = new System.Drawing.Size(112, 20);
            this.dtaPrevisaoEntregaAte.TabIndex = 8;
            this.dtaPrevisaoEntregaAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaRecebimentoAte
            // 
            this.dtaRecebimentoAte.Checked = false;
            this.dtaRecebimentoAte.CustomFormat = "dd/MM/yyyy";
            this.dtaRecebimentoAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaRecebimentoAte.Location = new System.Drawing.Point(231, 97);
            this.dtaRecebimentoAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaRecebimentoAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaRecebimentoAte.Name = "dtaRecebimentoAte";
            this.dtaRecebimentoAte.ShowCheckBox = true;
            this.dtaRecebimentoAte.Size = new System.Drawing.Size(112, 20);
            this.dtaRecebimentoAte.TabIndex = 10;
            this.dtaRecebimentoAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaRecebimentoDe
            // 
            this.dtaRecebimentoDe.Checked = false;
            this.dtaRecebimentoDe.CustomFormat = "dd/MM/yyyy";
            this.dtaRecebimentoDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaRecebimentoDe.Location = new System.Drawing.Point(85, 97);
            this.dtaRecebimentoDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaRecebimentoDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaRecebimentoDe.Name = "dtaRecebimentoDe";
            this.dtaRecebimentoDe.ShowCheckBox = true;
            this.dtaRecebimentoDe.Size = new System.Drawing.Size(112, 20);
            this.dtaRecebimentoDe.TabIndex = 9;
            this.dtaRecebimentoDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaPrevisaoEntregaDe
            // 
            this.dtaPrevisaoEntregaDe.Checked = false;
            this.dtaPrevisaoEntregaDe.CustomFormat = "dd/MM/yyyy";
            this.dtaPrevisaoEntregaDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaPrevisaoEntregaDe.Location = new System.Drawing.Point(118, 71);
            this.dtaPrevisaoEntregaDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaPrevisaoEntregaDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaPrevisaoEntregaDe.Name = "dtaPrevisaoEntregaDe";
            this.dtaPrevisaoEntregaDe.ShowCheckBox = true;
            this.dtaPrevisaoEntregaDe.Size = new System.Drawing.Size(112, 20);
            this.dtaPrevisaoEntregaDe.TabIndex = 7;
            this.dtaPrevisaoEntregaDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "ate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Recebimento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Previsão de Entrega:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fornecedor:";
            // 
            // btFornecedor
            // 
            this.btFornecedor.FlatAppearance.BorderSize = 0;
            this.btFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFornecedor.Image = global::cms.Properties.Resources.procurar;
            this.btFornecedor.Location = new System.Drawing.Point(533, 17);
            this.btFornecedor.Name = "btFornecedor";
            this.btFornecedor.Size = new System.Drawing.Size(22, 22);
            this.btFornecedor.TabIndex = 3;
            this.btFornecedor.UseVisualStyleBackColor = true;
            this.btFornecedor.Click += new System.EventHandler(this.btFornecedor_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(190, 19);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(337, 20);
            this.txtFornecedor.TabIndex = 2;
            this.textMasked.SetTextMasked(this.txtFornecedor, ToolMasked.TextMask.Formats.None);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecedor_KeyDown);
            // 
            // gvCompras
            // 
            this.gvCompras.AllowUserToAddRows = false;
            this.gvCompras.AllowUserToDeleteRows = false;
            this.gvCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompra,
            this.colFornecedor,
            this.colDataCadastro,
            this.colDataPrevisao,
            this.colDataRecebimento,
            this.colStatus,
            this.colValorTotal});
            this.gvCompras.Location = new System.Drawing.Point(12, 172);
            this.gvCompras.MultiSelect = false;
            this.gvCompras.Name = "gvCompras";
            this.gvCompras.ReadOnly = true;
            this.gvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCompras.Size = new System.Drawing.Size(899, 245);
            this.gvCompras.TabIndex = 9;
            this.gvCompras.DoubleClick += new System.EventHandler(this.gvCompras_DoubleClick);
            // 
            // colIdCompra
            // 
            this.colIdCompra.DataPropertyName = "id_compra";
            this.colIdCompra.HeaderText = "Código";
            this.colIdCompra.Name = "colIdCompra";
            this.colIdCompra.ReadOnly = true;
            // 
            // colFornecedor
            // 
            this.colFornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFornecedor.DataPropertyName = "nome_fantasia";
            this.colFornecedor.HeaderText = "Fornecedor";
            this.colFornecedor.Name = "colFornecedor";
            this.colFornecedor.ReadOnly = true;
            // 
            // colDataCadastro
            // 
            this.colDataCadastro.DataPropertyName = "data_cadastro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.colDataCadastro.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDataCadastro.HeaderText = "Data Cadastro";
            this.colDataCadastro.Name = "colDataCadastro";
            this.colDataCadastro.ReadOnly = true;
            this.colDataCadastro.Width = 150;
            // 
            // colDataPrevisao
            // 
            this.colDataPrevisao.DataPropertyName = "data_previsao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.colDataPrevisao.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDataPrevisao.HeaderText = "Previsão Entrega";
            this.colDataPrevisao.Name = "colDataPrevisao";
            this.colDataPrevisao.ReadOnly = true;
            this.colDataPrevisao.Width = 150;
            // 
            // colDataRecebimento
            // 
            this.colDataRecebimento.DataPropertyName = "data_recebimento";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.colDataRecebimento.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDataRecebimento.HeaderText = "Data Recebimento";
            this.colDataRecebimento.Name = "colDataRecebimento";
            this.colDataRecebimento.ReadOnly = true;
            this.colDataRecebimento.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 120;
            // 
            // colValorTotal
            // 
            this.colValorTotal.DataPropertyName = "valor_total";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.colValorTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.colValorTotal.HeaderText = "Valor Total";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            this.colValorTotal.Width = 130;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(923, 39);
            this.tsMenu.TabIndex = 8;
            // 
            // btNovo
            // 
            this.btNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btNovo.Image = global::cms.Properties.Resources.novo;
            this.btNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(36, 36);
            this.btNovo.Text = "Nova Compra";
            this.btNovo.ToolTipText = "Nova Compra";
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
            // textMasked
            // 
            this.textMasked.Text = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(59, 20);
            this.txtCodigo.TabIndex = 1;
            this.textMasked.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.Numero);
            // 
            // dtaDataCadastroAte
            // 
            this.dtaDataCadastroAte.Checked = false;
            this.dtaDataCadastroAte.CustomFormat = "dd/MM/yyyy";
            this.dtaDataCadastroAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaDataCadastroAte.Location = new System.Drawing.Point(236, 45);
            this.dtaDataCadastroAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaDataCadastroAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaDataCadastroAte.Name = "dtaDataCadastroAte";
            this.dtaDataCadastroAte.ShowCheckBox = true;
            this.dtaDataCadastroAte.Size = new System.Drawing.Size(112, 20);
            this.dtaDataCadastroAte.TabIndex = 6;
            this.dtaDataCadastroAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaDataCadastroDe
            // 
            this.dtaDataCadastroDe.Checked = false;
            this.dtaDataCadastroDe.CustomFormat = "dd/MM/yyyy";
            this.dtaDataCadastroDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaDataCadastroDe.Location = new System.Drawing.Point(90, 45);
            this.dtaDataCadastroDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaDataCadastroDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaDataCadastroDe.Name = "dtaDataCadastroDe";
            this.dtaDataCadastroDe.ShowCheckBox = true;
            this.dtaDataCadastroDe.Size = new System.Drawing.Size(112, 20);
            this.dtaDataCadastroDe.TabIndex = 5;
            this.dtaDataCadastroDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data Cadastro:";
            // 
            // frmCompraList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 429);
            this.Controls.Add(this.gbCompra);
            this.Controls.Add(this.gvCompras);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCompraList";
            this.Text = "Pesquisar Compra";
            this.gbCompra.ResumeLayout(false);
            this.gbCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompras)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvCompras;
        private System.Windows.Forms.GroupBox gbCompra;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Button btFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStatusCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtaPrevisaoEntregaAte;
        private System.Windows.Forms.DateTimePicker dtaPrevisaoEntregaDe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtaRecebimentoDe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtaRecebimentoAte;
        private System.Windows.Forms.Label label9;
        private ToolMasked.TextMask textMasked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataPrevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtaDataCadastroAte;
        private System.Windows.Forms.DateTimePicker dtaDataCadastroDe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}