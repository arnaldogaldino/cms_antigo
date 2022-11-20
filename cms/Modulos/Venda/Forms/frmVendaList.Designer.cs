namespace cms.Modulos.Venda.Forms
{
    partial class frmVendaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendaList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCliente = new System.Windows.Forms.Button();
            this.cbStatusVenda = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtaDataCadastroAte = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtaDataCadastroDe = new System.Windows.Forms.DateTimePicker();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.gvPedidos = new System.Windows.Forms.DataGridView();
            this.TextMasked = new ToolMasked.TextMask(this.components);
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidadeItens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(974, 39);
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
            this.btNovo.Text = "Novo pedido";
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btCliente);
            this.groupBox1.Controls.Add(this.cbStatusVenda);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtaDataCadastroAte);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtaDataCadastroDe);
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 73);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar Pedido";
            // 
            // btCliente
            // 
            this.btCliente.FlatAppearance.BorderSize = 0;
            this.btCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliente.Image = global::cms.Properties.Resources.procurar;
            this.btCliente.Location = new System.Drawing.Point(511, 17);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(22, 22);
            this.btCliente.TabIndex = 14;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // cbStatusVenda
            // 
            this.cbStatusVenda.DisplayMember = "display";
            this.cbStatusVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusVenda.FormattingEnabled = true;
            this.cbStatusVenda.Location = new System.Drawing.Point(585, 19);
            this.cbStatusVenda.Name = "cbStatusVenda";
            this.cbStatusVenda.Size = new System.Drawing.Size(163, 21);
            this.cbStatusVenda.TabIndex = 4;
            this.cbStatusVenda.ValueMember = "value";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(168, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(337, 20);
            this.txtCliente.TabIndex = 13;
            this.TextMasked.SetTextMasked(this.txtCliente, ToolMasked.TextMask.Formats.None);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(59, 20);
            this.txtCodigo.TabIndex = 11;
            this.TextMasked.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.Numero);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data Cadastro:";
            // 
            // dtaDataCadastroAte
            // 
            this.dtaDataCadastroAte.Checked = false;
            this.dtaDataCadastroAte.CustomFormat = "dd/MM/yyyy";
            this.dtaDataCadastroAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaDataCadastroAte.Location = new System.Drawing.Point(235, 45);
            this.dtaDataCadastroAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaDataCadastroAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaDataCadastroAte.Name = "dtaDataCadastroAte";
            this.dtaDataCadastroAte.ShowCheckBox = true;
            this.dtaDataCadastroAte.Size = new System.Drawing.Size(112, 20);
            this.dtaDataCadastroAte.TabIndex = 6;
            this.dtaDataCadastroAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status:";
            // 
            // dtaDataCadastroDe
            // 
            this.dtaDataCadastroDe.Checked = false;
            this.dtaDataCadastroDe.CustomFormat = "dd/MM/yyyy";
            this.dtaDataCadastroDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaDataCadastroDe.Location = new System.Drawing.Point(89, 45);
            this.dtaDataCadastroDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaDataCadastroDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaDataCadastroDe.Name = "dtaDataCadastroDe";
            this.dtaDataCadastroDe.ShowCheckBox = true;
            this.dtaDataCadastroDe.Size = new System.Drawing.Size(112, 20);
            this.dtaDataCadastroDe.TabIndex = 5;
            this.dtaDataCadastroDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(847, 19);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 11;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // gvPedidos
            // 
            this.gvPedidos.AllowUserToAddRows = false;
            this.gvPedidos.AllowUserToDeleteRows = false;
            this.gvPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colData,
            this.colCliente,
            this.colQuantidadeItens,
            this.colValorPagar,
            this.colValorBruto,
            this.colDesconto,
            this.colValorLiquido,
            this.colStatus});
            this.gvPedidos.Location = new System.Drawing.Point(12, 121);
            this.gvPedidos.MultiSelect = false;
            this.gvPedidos.Name = "gvPedidos";
            this.gvPedidos.ReadOnly = true;
            this.gvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPedidos.Size = new System.Drawing.Size(950, 265);
            this.gvPedidos.TabIndex = 11;
            this.gvPedidos.DoubleClick += new System.EventHandler(this.gvPedidos_DoubleClick);
            // 
            // TextMasked
            // 
            this.TextMasked.Text = null;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "id_venda";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colData
            // 
            this.colData.DataPropertyName = "data_cadastro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle1;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.DataPropertyName = "nome_fantasia";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colQuantidadeItens
            // 
            this.colQuantidadeItens.DataPropertyName = "quantidade_itens";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0,00";
            this.colQuantidadeItens.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQuantidadeItens.HeaderText = "Qtd. Itens";
            this.colQuantidadeItens.Name = "colQuantidadeItens";
            this.colQuantidadeItens.ReadOnly = true;
            // 
            // colValorPagar
            // 
            this.colValorPagar.DataPropertyName = "valor_pagar";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0,00";
            this.colValorPagar.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValorPagar.HeaderText = "Vlr. Pagar";
            this.colValorPagar.Name = "colValorPagar";
            this.colValorPagar.ReadOnly = true;
            // 
            // colValorBruto
            // 
            this.colValorBruto.DataPropertyName = "valor_bruto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0,00";
            this.colValorBruto.DefaultCellStyle = dataGridViewCellStyle4;
            this.colValorBruto.HeaderText = "Vlr. Bruto";
            this.colValorBruto.Name = "colValorBruto";
            this.colValorBruto.ReadOnly = true;
            // 
            // colDesconto
            // 
            this.colDesconto.DataPropertyName = "valor_desconto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0,00";
            this.colDesconto.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDesconto.HeaderText = "Desc.";
            this.colDesconto.Name = "colDesconto";
            this.colDesconto.ReadOnly = true;
            // 
            // colValorLiquido
            // 
            this.colValorLiquido.DataPropertyName = "valor_liquido";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0,00";
            this.colValorLiquido.DefaultCellStyle = dataGridViewCellStyle6;
            this.colValorLiquido.HeaderText = "Vlr. Liq.";
            this.colValorLiquido.Name = "colValorLiquido";
            this.colValorLiquido.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // frmVendaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 398);
            this.Controls.Add(this.gvPedidos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmVendaList";
            this.Text = "Pequisar Pedidos";
            this.Load += new System.EventHandler(this.frmVendaList_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvPedidos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtaDataCadastroAte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtaDataCadastroDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cbStatusVenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btPesquisar;
        private ToolMasked.TextMask TextMasked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidadeItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorLiquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}