namespace cms.Modulos.Financeiro.Forms.Boletos
{
    partial class frmBoletoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoletoList));
            this.sfdRemessa = new System.Windows.Forms.SaveFileDialog();
            this.ofdRetorno = new System.Windows.Forms.OpenFileDialog();
            this.gvFinanceiroBoleto = new System.Windows.Forms.DataGridView();
            this.chkLinha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nosso_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razao_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRetorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPesquisaContaPagar = new System.Windows.Forms.GroupBox();
            this.ctrlFilial = new cms.Modulos.Util.ctrlFilial();
            this.btCliente = new System.Windows.Forms.Button();
            this.btContaCorrente = new System.Windows.Forms.Button();
            this.dtaPagamentoDataAte = new System.Windows.Forms.DateTimePicker();
            this.dtaVencimentoDataAte = new System.Windows.Forms.DateTimePicker();
            this.dtaPagamentoDataDe = new System.Windows.Forms.DateTimePicker();
            this.dtaVencimentoDataDe = new System.Windows.Forms.DateTimePicker();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtNossoNumero = new System.Windows.Forms.TextBox();
            this.lbDataPagamentoAte = new System.Windows.Forms.Label();
            this.lbDataVencimentoAte = new System.Windows.Forms.Label();
            this.lbDataPagamentoDe = new System.Windows.Forms.Label();
            this.lbDataVencimentoDe = new System.Windows.Forms.Label();
            this.lbContaCorrente = new System.Windows.Forms.Label();
            this.lbDocumento = new System.Windows.Forms.Label();
            this.lbNossoNumero = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lbCliente = new System.Windows.Forms.Label();
            this.btGerarRemessa = new System.Windows.Forms.ToolStrip();
            this.btGerarArquivoRemessa = new System.Windows.Forms.ToolStripButton();
            this.btProcessarArquivoRetorno = new System.Windows.Forms.ToolStripButton();
            this.btImprimir = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroBoleto)).BeginInit();
            this.gbPesquisaContaPagar.SuspendLayout();
            this.btGerarRemessa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvFinanceiroBoleto
            // 
            this.gvFinanceiroBoleto.AllowUserToAddRows = false;
            this.gvFinanceiroBoleto.AllowUserToDeleteRows = false;
            this.gvFinanceiroBoleto.AllowUserToResizeColumns = false;
            this.gvFinanceiroBoleto.AllowUserToResizeRows = false;
            this.gvFinanceiroBoleto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroBoleto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroBoleto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkLinha,
            this.codigo,
            this.numero_documento,
            this.nosso_numero,
            this.razao_social,
            this.nome,
            this.data_vencimento,
            this.valor_vencimento,
            this.data_pagamento,
            this.valor_pagamento,
            this.status,
            this.colDataRetorno});
            this.gvFinanceiroBoleto.Location = new System.Drawing.Point(12, 172);
            this.gvFinanceiroBoleto.MultiSelect = false;
            this.gvFinanceiroBoleto.Name = "gvFinanceiroBoleto";
            this.gvFinanceiroBoleto.ReadOnly = true;
            this.gvFinanceiroBoleto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroBoleto.ShowEditingIcon = false;
            this.gvFinanceiroBoleto.ShowRowErrors = false;
            this.gvFinanceiroBoleto.Size = new System.Drawing.Size(1238, 262);
            this.gvFinanceiroBoleto.TabIndex = 18;
            this.gvFinanceiroBoleto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFinanceiroBoleto_CellClick);
            this.gvFinanceiroBoleto.DoubleClick += new System.EventHandler(this.gvFinanceiroBoleto_DoubleClick);
            // 
            // chkLinha
            // 
            this.chkLinha.Frozen = true;
            this.chkLinha.HeaderText = "";
            this.chkLinha.MinimumWidth = 20;
            this.chkLinha.Name = "chkLinha";
            this.chkLinha.ReadOnly = true;
            this.chkLinha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chkLinha.Width = 20;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "id_financeiro_conta_receber";
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // numero_documento
            // 
            this.numero_documento.DataPropertyName = "numero_documento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = null;
            this.numero_documento.DefaultCellStyle = dataGridViewCellStyle1;
            this.numero_documento.HeaderText = "N° Documento";
            this.numero_documento.Name = "numero_documento";
            this.numero_documento.ReadOnly = true;
            // 
            // nosso_numero
            // 
            this.nosso_numero.DataPropertyName = "nosso_numero";
            this.nosso_numero.HeaderText = "Nosso Número";
            this.nosso_numero.Name = "nosso_numero";
            this.nosso_numero.ReadOnly = true;
            this.nosso_numero.Width = 150;
            // 
            // razao_social
            // 
            this.razao_social.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.razao_social.DataPropertyName = "razao_social";
            this.razao_social.HeaderText = "Cliente";
            this.razao_social.Name = "razao_social";
            this.razao_social.ReadOnly = true;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome.DataPropertyName = "nome";
            this.nome.HeaderText = "Conta Corrente";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
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
            this.valor_vencimento.DataPropertyName = "valor_boleto";
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
            this.valor_pagamento.DataPropertyName = "data_pagamento";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.valor_pagamento.DefaultCellStyle = dataGridViewCellStyle5;
            this.valor_pagamento.HeaderText = "Valor Pagamento";
            this.valor_pagamento.Name = "valor_pagamento";
            this.valor_pagamento.ReadOnly = true;
            this.valor_pagamento.Visible = false;
            this.valor_pagamento.Width = 130;
            // 
            // status
            // 
            this.status.DataPropertyName = "status_retorno";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // colDataRetorno
            // 
            this.colDataRetorno.DataPropertyName = "status_retorno";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.colDataRetorno.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDataRetorno.HeaderText = "Data Retorno";
            this.colDataRetorno.Name = "colDataRetorno";
            this.colDataRetorno.ReadOnly = true;
            // 
            // gbPesquisaContaPagar
            // 
            this.gbPesquisaContaPagar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisaContaPagar.Controls.Add(this.ctrlFilial);
            this.gbPesquisaContaPagar.Controls.Add(this.btCliente);
            this.gbPesquisaContaPagar.Controls.Add(this.btContaCorrente);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaPagamentoDataAte);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaVencimentoDataAte);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaPagamentoDataDe);
            this.gbPesquisaContaPagar.Controls.Add(this.dtaVencimentoDataDe);
            this.gbPesquisaContaPagar.Controls.Add(this.btPesquisar);
            this.gbPesquisaContaPagar.Controls.Add(this.txtDocumento);
            this.gbPesquisaContaPagar.Controls.Add(this.txtContaCorrente);
            this.gbPesquisaContaPagar.Controls.Add(this.txtNossoNumero);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataPagamentoAte);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataVencimentoAte);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataPagamentoDe);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDataVencimentoDe);
            this.gbPesquisaContaPagar.Controls.Add(this.lbContaCorrente);
            this.gbPesquisaContaPagar.Controls.Add(this.lbDocumento);
            this.gbPesquisaContaPagar.Controls.Add(this.lbNossoNumero);
            this.gbPesquisaContaPagar.Controls.Add(this.txtCliente);
            this.gbPesquisaContaPagar.Controls.Add(this.lbCliente);
            this.gbPesquisaContaPagar.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisaContaPagar.Name = "gbPesquisaContaPagar";
            this.gbPesquisaContaPagar.Size = new System.Drawing.Size(1238, 124);
            this.gbPesquisaContaPagar.TabIndex = 17;
            this.gbPesquisaContaPagar.TabStop = false;
            this.gbPesquisaContaPagar.Text = "Pesquisar Contas a Pagar";
            // 
            // ctrlFilial
            // 
            this.ctrlFilial.LabelSelecione = false;
            this.ctrlFilial.Location = new System.Drawing.Point(589, 13);
            this.ctrlFilial.Name = "ctrlFilial";
            this.ctrlFilial.SelectedDefault = true;
            this.ctrlFilial.Size = new System.Drawing.Size(220, 21);
            this.ctrlFilial.TabIndex = 13;
            // 
            // btCliente
            // 
            this.btCliente.FlatAppearance.BorderSize = 0;
            this.btCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliente.Image = global::cms.Properties.Resources.procurar;
            this.btCliente.Location = new System.Drawing.Point(560, 13);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(22, 22);
            this.btCliente.TabIndex = 3;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // btContaCorrente
            // 
            this.btContaCorrente.FlatAppearance.BorderSize = 0;
            this.btContaCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContaCorrente.Image = global::cms.Properties.Resources.procurar;
            this.btContaCorrente.Location = new System.Drawing.Point(309, 40);
            this.btContaCorrente.Name = "btContaCorrente";
            this.btContaCorrente.Size = new System.Drawing.Size(22, 22);
            this.btContaCorrente.TabIndex = 7;
            this.btContaCorrente.UseVisualStyleBackColor = true;
            this.btContaCorrente.Click += new System.EventHandler(this.btContaCorrente_Click);
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
            this.btPesquisar.Location = new System.Drawing.Point(1135, 15);
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
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.Location = new System.Drawing.Point(94, 42);
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.ReadOnly = true;
            this.txtContaCorrente.Size = new System.Drawing.Size(209, 20);
            this.txtContaCorrente.TabIndex = 6;
            this.txtContaCorrente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContaCorrente_KeyDown);
            // 
            // txtNossoNumero
            // 
            this.txtNossoNumero.Location = new System.Drawing.Point(92, 16);
            this.txtNossoNumero.Name = "txtNossoNumero";
            this.txtNossoNumero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNossoNumero.Size = new System.Drawing.Size(119, 20);
            this.txtNossoNumero.TabIndex = 1;
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
            this.lbContaCorrente.Location = new System.Drawing.Point(7, 46);
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
            // lbNossoNumero
            // 
            this.lbNossoNumero.AutoSize = true;
            this.lbNossoNumero.Location = new System.Drawing.Point(6, 20);
            this.lbNossoNumero.Name = "lbNossoNumero";
            this.lbNossoNumero.Size = new System.Drawing.Size(80, 13);
            this.lbNossoNumero.TabIndex = 5;
            this.lbNossoNumero.Text = "Nosso Número:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(265, 15);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(289, 20);
            this.txtCliente.TabIndex = 2;
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Location = new System.Drawing.Point(217, 19);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(42, 13);
            this.lbCliente.TabIndex = 0;
            this.lbCliente.Text = "Cliente:";
            // 
            // btGerarRemessa
            // 
            this.btGerarRemessa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btGerarArquivoRemessa,
            this.btProcessarArquivoRetorno,
            this.btImprimir,
            this.btFechar});
            this.btGerarRemessa.Location = new System.Drawing.Point(0, 0);
            this.btGerarRemessa.Name = "btGerarRemessa";
            this.btGerarRemessa.Size = new System.Drawing.Size(1262, 39);
            this.btGerarRemessa.TabIndex = 15;
            this.btGerarRemessa.Text = "toolStrip1";
            // 
            // btGerarArquivoRemessa
            // 
            this.btGerarArquivoRemessa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGerarArquivoRemessa.Image = global::cms.Properties.Resources.download;
            this.btGerarArquivoRemessa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btGerarArquivoRemessa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGerarArquivoRemessa.Name = "btGerarArquivoRemessa";
            this.btGerarArquivoRemessa.Size = new System.Drawing.Size(36, 36);
            this.btGerarArquivoRemessa.Text = "Gerar Arquivo Remessa";
            this.btGerarArquivoRemessa.Click += new System.EventHandler(this.btGerarArquivoRemessa_Click);
            // 
            // btProcessarArquivoRetorno
            // 
            this.btProcessarArquivoRetorno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btProcessarArquivoRetorno.Image = global::cms.Properties.Resources.arquivo_remessa;
            this.btProcessarArquivoRetorno.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btProcessarArquivoRetorno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btProcessarArquivoRetorno.Name = "btProcessarArquivoRetorno";
            this.btProcessarArquivoRetorno.Size = new System.Drawing.Size(36, 36);
            this.btProcessarArquivoRetorno.Text = "Processar Arquivo Retorno";
            this.btProcessarArquivoRetorno.Click += new System.EventHandler(this.btProcessarArquivoRetorno_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btImprimir.Image = global::cms.Properties.Resources.imprimir;
            this.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(36, 36);
            this.btImprimir.Text = "toolStripButton1";
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
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
            // ValidarForm
            // 
            this.ValidarForm.AutomaticDelay = 50;
            this.ValidarForm.IsBalloon = true;
            this.ValidarForm.ShowAlways = true;
            this.ValidarForm.StripAmpersands = true;
            this.ValidarForm.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.ValidarForm.ToolTipTitle = "Campo Inválido.";
            // 
            // frmBoletoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 446);
            this.Controls.Add(this.gvFinanceiroBoleto);
            this.Controls.Add(this.gbPesquisaContaPagar);
            this.Controls.Add(this.btGerarRemessa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBoletoList";
            this.Text = "Pesquisar Boletos";
            this.Load += new System.EventHandler(this.frmBoletoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroBoleto)).EndInit();
            this.gbPesquisaContaPagar.ResumeLayout(false);
            this.gbPesquisaContaPagar.PerformLayout();
            this.btGerarRemessa.ResumeLayout(false);
            this.btGerarRemessa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip btGerarRemessa;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbPesquisaContaPagar;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Button btContaCorrente;
        private System.Windows.Forms.DateTimePicker dtaPagamentoDataAte;
        private System.Windows.Forms.DateTimePicker dtaVencimentoDataAte;
        private System.Windows.Forms.DateTimePicker dtaPagamentoDataDe;
        private System.Windows.Forms.DateTimePicker dtaVencimentoDataDe;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.TextBox txtNossoNumero;
        private System.Windows.Forms.Label lbDataPagamentoAte;
        private System.Windows.Forms.Label lbDataVencimentoAte;
        private System.Windows.Forms.Label lbDataPagamentoDe;
        private System.Windows.Forms.Label lbDataVencimentoDe;
        private System.Windows.Forms.Label lbContaCorrente;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.Label lbNossoNumero;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.DataGridView gvFinanceiroBoleto;
        private System.Windows.Forms.ToolStripButton btGerarArquivoRemessa;
        private System.Windows.Forms.ToolStripButton btProcessarArquivoRetorno;
        private System.Windows.Forms.SaveFileDialog sfdRemessa;
        private System.Windows.Forms.OpenFileDialog ofdRetorno;
        private Util.ctrlFilial ctrlFilial;
        private System.Windows.Forms.ToolStripButton btImprimir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nosso_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn razao_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRetorno;
        private System.Windows.Forms.ToolTip ValidarForm;
    }
}