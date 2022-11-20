namespace cms.Modulos.Financeiro.Forms.ContasPagar
{
    partial class frmFinanceiroContasPagarList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceiroContasPagarList));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gvFinanceiroContasPagar = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forma_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta_corrente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPesquisaContaPagar = new System.Windows.Forms.GroupBox();
            this.ctrlFilial = new cms.Modulos.Util.ctrlFilial();
            this.btFornecedor = new System.Windows.Forms.Button();
            this.btContaCorrente = new System.Windows.Forms.Button();
            this.btFormaPagamento = new System.Windows.Forms.Button();
            this.dtaPagamentoDataAte = new System.Windows.Forms.DateTimePicker();
            this.dtaVencimentoDataAte = new System.Windows.Forms.DateTimePicker();
            this.dtaPagamentoDataDe = new System.Windows.Forms.DateTimePicker();
            this.dtaVencimentoDataDe = new System.Windows.Forms.DateTimePicker();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbDataPagamentoAte = new System.Windows.Forms.Label();
            this.lbDataVencimentoAte = new System.Windows.Forms.Label();
            this.lbDataPagamentoDe = new System.Windows.Forms.Label();
            this.lbDataVencimentoDe = new System.Windows.Forms.Label();
            this.lbContaCorrente = new System.Windows.Forms.Label();
            this.lbDocumento = new System.Windows.Forms.Label();
            this.lbFormaPagamento = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.lbFornecedor = new System.Windows.Forms.Label();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroContasPagar)).BeginInit();
            this.gbPesquisaContaPagar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1129, 39);
            this.tsMenu.TabIndex = 14;
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
            this.btNovo.Text = "Novo Fornecedor";
            this.btNovo.ToolTipText = "Novo Fornecedor";
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
            // gvFinanceiroContasPagar
            // 
            this.gvFinanceiroContasPagar.AllowUserToAddRows = false;
            this.gvFinanceiroContasPagar.AllowUserToDeleteRows = false;
            this.gvFinanceiroContasPagar.AllowUserToResizeColumns = false;
            this.gvFinanceiroContasPagar.AllowUserToResizeRows = false;
            this.gvFinanceiroContasPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroContasPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroContasPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.fornecedor,
            this.descricao,
            this.forma_pagamento,
            this.conta_corrente,
            this.data_vencimento,
            this.valor_vencimento,
            this.data_pagamento,
            this.valor_pagamento,
            this.data_lancamento});
            this.gvFinanceiroContasPagar.Location = new System.Drawing.Point(12, 172);
            this.gvFinanceiroContasPagar.MultiSelect = false;
            this.gvFinanceiroContasPagar.Name = "gvFinanceiroContasPagar";
            this.gvFinanceiroContasPagar.ReadOnly = true;
            this.gvFinanceiroContasPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroContasPagar.ShowEditingIcon = false;
            this.gvFinanceiroContasPagar.ShowRowErrors = false;
            this.gvFinanceiroContasPagar.Size = new System.Drawing.Size(1105, 240);
            this.gvFinanceiroContasPagar.TabIndex = 15;
            this.gvFinanceiroContasPagar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvFinanceiroContasPagar_CellFormatting);
            this.gvFinanceiroContasPagar.DoubleClick += new System.EventHandler(this.gvFinanceiroContasPagar_DoubleClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "id_financeiro_conta_pagar";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = null;
            this.codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // fornecedor
            // 
            this.fornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fornecedor.DataPropertyName = "fornecedor";
            this.fornecedor.HeaderText = "Fornecedor";
            this.fornecedor.Name = "fornecedor";
            this.fornecedor.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // forma_pagamento
            // 
            this.forma_pagamento.DataPropertyName = "forma_pagamento";
            this.forma_pagamento.HeaderText = "Forma de Pagamento";
            this.forma_pagamento.Name = "forma_pagamento";
            this.forma_pagamento.ReadOnly = true;
            this.forma_pagamento.Width = 150;
            // 
            // conta_corrente
            // 
            this.conta_corrente.DataPropertyName = "banco";
            this.conta_corrente.HeaderText = "Conta Corrente";
            this.conta_corrente.Name = "conta_corrente";
            this.conta_corrente.ReadOnly = true;
            this.conta_corrente.Width = 130;
            // 
            // data_vencimento
            // 
            this.data_vencimento.DataPropertyName = "data_vencimento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.data_vencimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_vencimento.HeaderText = "Data Vencimento";
            this.data_vencimento.Name = "data_vencimento";
            this.data_vencimento.ReadOnly = true;
            this.data_vencimento.Width = 130;
            // 
            // valor_vencimento
            // 
            this.valor_vencimento.DataPropertyName = "valor_vencimento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.valor_vencimento.DefaultCellStyle = dataGridViewCellStyle3;
            this.valor_vencimento.HeaderText = "Valor Vencimento";
            this.valor_vencimento.Name = "valor_vencimento";
            this.valor_vencimento.ReadOnly = true;
            this.valor_vencimento.Width = 130;
            // 
            // data_pagamento
            // 
            this.data_pagamento.DataPropertyName = "data_pagamento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.data_pagamento.DefaultCellStyle = dataGridViewCellStyle4;
            this.data_pagamento.HeaderText = "Data Pagamento";
            this.data_pagamento.Name = "data_pagamento";
            this.data_pagamento.ReadOnly = true;
            this.data_pagamento.Width = 130;
            // 
            // valor_pagamento
            // 
            this.valor_pagamento.DataPropertyName = "valor_pagamento";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.valor_pagamento.DefaultCellStyle = dataGridViewCellStyle5;
            this.valor_pagamento.HeaderText = "Valor Pagamento";
            this.valor_pagamento.Name = "valor_pagamento";
            this.valor_pagamento.ReadOnly = true;
            this.valor_pagamento.Width = 130;
            // 
            // data_lancamento
            // 
            this.data_lancamento.DataPropertyName = "data_lancamento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_lancamento.DefaultCellStyle = dataGridViewCellStyle6;
            this.data_lancamento.HeaderText = "Data Lançamento";
            this.data_lancamento.Name = "data_lancamento";
            this.data_lancamento.ReadOnly = true;
            this.data_lancamento.Visible = false;
            // 
            // gbPesquisaContaPagar
            // 
            this.gbPesquisaContaPagar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisaContaPagar.Controls.Add(this.ctrlFilial);
            this.gbPesquisaContaPagar.Controls.Add(this.btFornecedor);
            this.gbPesquisaContaPagar.Controls.Add(this.btContaCorrente);
            this.gbPesquisaContaPagar.Controls.Add(this.btFormaPagamento);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaPagamentoDataAte);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaVencimentoDataAte);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaPagamentoDataDe);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaVencimentoDataDe);
            this.gbPesquisaContaPagar.Controls.Add(this.btPesquisar);
            this.gbPesquisaContaPagar.Controls.Add(this.txtDocumento);
            this.gbPesquisaContaPagar.Controls.Add(this.txtContaCorrente);
            this.gbPesquisaContaPagar.Controls.Add(this.txtFormaPagamento);
            this.gbPesquisaContaPagar.Controls.Add(this.txtCodigo);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataPagamentoAte);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataVencimentoAte);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataPagamentoDe);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataVencimentoDe);
            this.gbPesquisaContaPagar.Controls.Add(this.lbContaCorrente);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDocumento);
            this.gbPesquisaContaPagar.Controls.Add(this.lbFormaPagamento);
            this.gbPesquisaContaPagar.Controls.Add(this.lbCodigo);
            this.gbPesquisaContaPagar.Controls.Add(this.txtFornecedor);
            this.gbPesquisaContaPagar.Controls.Add(this.lbFornecedor);
            this.gbPesquisaContaPagar.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisaContaPagar.Name = "gbPesquisaContaPagar";
            this.gbPesquisaContaPagar.Size = new System.Drawing.Size(1105, 124);
            this.gbPesquisaContaPagar.TabIndex = 16;
            this.gbPesquisaContaPagar.TabStop = false;
            this.gbPesquisaContaPagar.Text = "Pesquisar Contas a Pagar";
            // 
            // ctrlFilial
            // 
            this.ctrlFilial.LabelSelecione = false;
            this.ctrlFilial.Location = new System.Drawing.Point(538, 15);
            this.ctrlFilial.Name = "ctrlFilial";
            this.ctrlFilial.SelectedDefault = false;
            this.ctrlFilial.Size = new System.Drawing.Size(212, 21);
            this.ctrlFilial.TabIndex = 13;
            // 
            // btFornecedor
            // 
            this.btFornecedor.FlatAppearance.BorderSize = 0;
            this.btFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFornecedor.Image = global::cms.Properties.Resources.procurar;
            this.btFornecedor.Location = new System.Drawing.Point(510, 15);
            this.btFornecedor.Name = "btFornecedor";
            this.btFornecedor.Size = new System.Drawing.Size(22, 22);
            this.btFornecedor.TabIndex = 3;
            this.btFornecedor.UseVisualStyleBackColor = true;
            this.btFornecedor.Click += new System.EventHandler(this.btFornecedor_Click);
            // 
            // btContaCorrente
            // 
            this.btContaCorrente.FlatAppearance.BorderSize = 0;
            this.btContaCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContaCorrente.Image = global::cms.Properties.Resources.procurar;
            this.btContaCorrente.Location = new System.Drawing.Point(601, 41);
            this.btContaCorrente.Name = "btContaCorrente";
            this.btContaCorrente.Size = new System.Drawing.Size(22, 22);
            this.btContaCorrente.TabIndex = 7;
            this.btContaCorrente.UseVisualStyleBackColor = true;
            this.btContaCorrente.Click += new System.EventHandler(this.btContaCorrente_Click);
            // 
            // btFormaPagamento
            // 
            this.btFormaPagamento.FlatAppearance.BorderSize = 0;
            this.btFormaPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFormaPagamento.Image = global::cms.Properties.Resources.procurar;
            this.btFormaPagamento.Location = new System.Drawing.Point(271, 40);
            this.btFormaPagamento.Name = "btFormaPagamento";
            this.btFormaPagamento.Size = new System.Drawing.Size(22, 22);
            this.btFormaPagamento.TabIndex = 5;
            this.btFormaPagamento.UseVisualStyleBackColor = true;
            this.btFormaPagamento.Click += new System.EventHandler(this.btFormaPagamento_Click);
            // 
            // dtaPagamentoDataAte
            // 
            this.dtaPagamentoDataAte.Checked = false;
            this.dtaPagamentoDataAte.CustomFormat = "dd/MM/yyyy";
            this.dtaPagamentoDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaPagamentoDataAte.Location = new System.Drawing.Point(265, 95);
            this.dtaPagamentoDataAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaPagamentoDataAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaPagamentoDataAte.Name = "dtaPagamentoDataAte";
            this.dtaPagamentoDataAte.ShowCheckBox = true;
            this.dtaPagamentoDataAte.Size = new System.Drawing.Size(112, 20);
            this.dtaPagamentoDataAte.TabIndex = 11;
            this.dtaPagamentoDataAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaVencimentoDataAte
            // 
            this.dtaVencimentoDataAte.Checked = false;
            this.dtaVencimentoDataAte.CustomFormat = "dd/MM/yyyy";
            this.dtaVencimentoDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaVencimentoDataAte.Location = new System.Drawing.Point(265, 69);
            this.dtaVencimentoDataAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaVencimentoDataAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaVencimentoDataAte.Name = "dtaVencimentoDataAte";
            this.dtaVencimentoDataAte.ShowCheckBox = true;
            this.dtaVencimentoDataAte.Size = new System.Drawing.Size(112, 20);
            this.dtaVencimentoDataAte.TabIndex = 9;
            this.dtaVencimentoDataAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaPagamentoDataDe
            // 
            this.dtaPagamentoDataDe.Checked = false;
            this.dtaPagamentoDataDe.CustomFormat = "dd/MM/yyyy";
            this.dtaPagamentoDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaPagamentoDataDe.Location = new System.Drawing.Point(119, 95);
            this.dtaPagamentoDataDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaPagamentoDataDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaPagamentoDataDe.Name = "dtaPagamentoDataDe";
            this.dtaPagamentoDataDe.ShowCheckBox = true;
            this.dtaPagamentoDataDe.Size = new System.Drawing.Size(112, 20);
            this.dtaPagamentoDataDe.TabIndex = 10;
            this.dtaPagamentoDataDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaVencimentoDataDe
            // 
            this.dtaVencimentoDataDe.Checked = false;
            this.dtaVencimentoDataDe.CustomFormat = "dd/MM/yyyy";
            this.dtaVencimentoDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaVencimentoDataDe.Location = new System.Drawing.Point(119, 69);
            this.dtaVencimentoDataDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaVencimentoDataDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaVencimentoDataDe.Name = "dtaVencimentoDataDe";
            this.dtaVencimentoDataDe.ShowCheckBox = true;
            this.dtaVencimentoDataDe.Size = new System.Drawing.Size(112, 20);
            this.dtaVencimentoDataDe.TabIndex = 8;
            this.dtaVencimentoDataDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(1002, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 6;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(454, 69);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 12;
            this.TextMaskedit.SetTextMasked(this.txtDocumento, ToolMasked.TextMask.Formats.None);
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.Location = new System.Drawing.Point(386, 42);
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.ReadOnly = true;
            this.txtContaCorrente.Size = new System.Drawing.Size(209, 20);
            this.txtContaCorrente.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtContaCorrente, ToolMasked.TextMask.Formats.None);
            this.txtContaCorrente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContaCorrente_KeyDown);
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Location = new System.Drawing.Point(117, 43);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.ReadOnly = true;
            this.txtFormaPagamento.Size = new System.Drawing.Size(148, 20);
            this.txtFormaPagamento.TabIndex = 4;
            this.TextMaskedit.SetTextMasked(this.txtFormaPagamento, ToolMasked.TextMask.Formats.None);
            this.txtFormaPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormaPagamento_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(58, 20);
            this.txtCodigo.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // lbDataPagamentoAte
            // 
            this.lbDataPagamentoAte.AutoSize = true;
            this.lbDataPagamentoAte.Location = new System.Drawing.Point(237, 98);
            this.lbDataPagamentoAte.Name = "lbDataPagamentoAte";
            this.lbDataPagamentoAte.Size = new System.Drawing.Size(22, 13);
            this.lbDataPagamentoAte.TabIndex = 5;
            this.lbDataPagamentoAte.Text = "até";
            // 
            // lbDataVencimentoAte
            // 
            this.lbDataVencimentoAte.AutoSize = true;
            this.lbDataVencimentoAte.Location = new System.Drawing.Point(237, 72);
            this.lbDataVencimentoAte.Name = "lbDataVencimentoAte";
            this.lbDataVencimentoAte.Size = new System.Drawing.Size(22, 13);
            this.lbDataVencimentoAte.TabIndex = 5;
            this.lbDataVencimentoAte.Text = "até";
            // 
            // lbDataPagamentoDe
            // 
            this.lbDataPagamentoDe.AutoSize = true;
            this.lbDataPagamentoDe.Location = new System.Drawing.Point(7, 98);
            this.lbDataPagamentoDe.Name = "lbDataPagamentoDe";
            this.lbDataPagamentoDe.Size = new System.Drawing.Size(105, 13);
            this.lbDataPagamentoDe.TabIndex = 5;
            this.lbDataPagamentoDe.Text = "Data de Pagamento:";
            // 
            // lbDataVencimentoDe
            // 
            this.lbDataVencimentoDe.AutoSize = true;
            this.lbDataVencimentoDe.Location = new System.Drawing.Point(6, 72);
            this.lbDataVencimentoDe.Name = "lbDataVencimentoDe";
            this.lbDataVencimentoDe.Size = new System.Drawing.Size(107, 13);
            this.lbDataVencimentoDe.TabIndex = 5;
            this.lbDataVencimentoDe.Text = "Data de Vencimento:";
            // 
            // lbContaCorrente
            // 
            this.lbContaCorrente.AutoSize = true;
            this.lbContaCorrente.Location = new System.Drawing.Point(299, 46);
            this.lbContaCorrente.Name = "lbContaCorrente";
            this.lbContaCorrente.Size = new System.Drawing.Size(81, 13);
            this.lbContaCorrente.TabIndex = 5;
            this.lbContaCorrente.Text = "Conta Corrente:";
            // 
            // lbDocumento
            // 
            this.lbDocumento.AutoSize = true;
            this.lbDocumento.Location = new System.Drawing.Point(383, 72);
            this.lbDocumento.Name = "lbDocumento";
            this.lbDocumento.Size = new System.Drawing.Size(65, 13);
            this.lbDocumento.TabIndex = 5;
            this.lbDocumento.Text = "Documento:";
            // 
            // lbFormaPagamento
            // 
            this.lbFormaPagamento.AutoSize = true;
            this.lbFormaPagamento.Location = new System.Drawing.Point(6, 46);
            this.lbFormaPagamento.Name = "lbFormaPagamento";
            this.lbFormaPagamento.Size = new System.Drawing.Size(105, 13);
            this.lbFormaPagamento.TabIndex = 5;
            this.lbFormaPagamento.Text = "Forma de Pagameto:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(6, 20);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(43, 13);
            this.lbCodigo.TabIndex = 5;
            this.lbCodigo.Text = "Código:";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(189, 16);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(315, 20);
            this.txtFornecedor.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtFornecedor, ToolMasked.TextMask.Formats.None);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecedor_KeyDown);
            // 
            // lbFornecedor
            // 
            this.lbFornecedor.AutoSize = true;
            this.lbFornecedor.Location = new System.Drawing.Point(119, 20);
            this.lbFornecedor.Name = "lbFornecedor";
            this.lbFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lbFornecedor.TabIndex = 0;
            this.lbFornecedor.Text = "Fornecedor:";
            // 
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // frmFinanceiroContasPagarList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 424);
            this.Controls.Add(this.gbPesquisaContaPagar);
            this.Controls.Add(this.gvFinanceiroContasPagar);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroContasPagarList";
            this.Text = "Pesquisar Contas Pagar";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroContasPagar)).EndInit();
            this.gbPesquisaContaPagar.ResumeLayout(false);
            this.gbPesquisaContaPagar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvFinanceiroContasPagar;
        private System.Windows.Forms.GroupBox gbPesquisaContaPagar;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lbFornecedor;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.Label lbFormaPagamento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.DateTimePicker dtaVencimentoDataDe;
        private System.Windows.Forms.Label lbDataVencimentoDe;
        private System.Windows.Forms.Label lbContaCorrente;
        private System.Windows.Forms.Label lbDataVencimentoAte;
        private System.Windows.Forms.DateTimePicker dtaVencimentoDataAte;
        private System.Windows.Forms.DateTimePicker dtaPagamentoDataAte;
        private System.Windows.Forms.DateTimePicker dtaPagamentoDataDe;
        private System.Windows.Forms.Label lbDataPagamentoAte;
        private System.Windows.Forms.Label lbDataPagamentoDe;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.Button btFormaPagamento;
        private System.Windows.Forms.Button btContaCorrente;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.Button btFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn forma_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_corrente;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_lancamento;
        private Util.ctrlFilial ctrlFilial;

    }
}