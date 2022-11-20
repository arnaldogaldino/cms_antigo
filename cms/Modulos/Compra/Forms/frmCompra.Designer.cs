namespace cms.Modulos.Compra.Forms
{
    partial class frmCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.gvCompraItens = new System.Windows.Forms.DataGridView();
            this.colIdCompraItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdSolicitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdRecebida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIcms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIpi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataConferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstqAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstqMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstqMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvStatus = new System.Windows.Forms.DataGridView();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbFilial = new cms.Modulos.Util.ctrlFilial();
            this.txtObservacaoComprador = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.dtaRecebimento = new System.Windows.Forms.DateTimePicker();
            this.dtaPrevisaoEntrega = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btFornecedor = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtTotalItens = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtCompraOrigem = new System.Windows.Forms.TextBox();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btAdicionarItens = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btAprovar = new System.Windows.Forms.ToolStripButton();
            this.btCancelarCompra = new System.Windows.Forms.ToolStripButton();
            this.btCopiarItem = new System.Windows.Forms.ToolStripButton();
            this.btEntrega = new System.Windows.Forms.ToolStripButton();
            this.btConferir = new System.Windows.Forms.ToolStripButton();
            this.btContasPagar = new System.Windows.Forms.ToolStripButton();
            this.btFinalizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btArquivoXml = new System.Windows.Forms.ToolStripButton();
            this.btGravarXml = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.TextMasked = new ToolMasked.TextMask(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvCompraItens)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStatus)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
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
            // OpenFile
            // 
            this.OpenFile.Filter = "Arquivo XML|*.xml";
            // 
            // SaveFile
            // 
            this.SaveFile.Filter = "\"Arquivo XML|*.xml\"";
            // 
            // gvCompraItens
            // 
            this.gvCompraItens.AllowUserToAddRows = false;
            this.gvCompraItens.AllowUserToDeleteRows = false;
            this.gvCompraItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCompraItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCompraItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompraItem,
            this.colIdProduto,
            this.colCodigo,
            this.colDescricao,
            this.colQtdSolicitada,
            this.colQtdRecebida,
            this.colValorUnit,
            this.colValorDesc,
            this.colTotalPagar,
            this.colIcms,
            this.colIpi,
            this.colDataConferencia,
            this.colEstqAtual,
            this.colEstqMin,
            this.colEstqMax,
            this.colUltimoPreco});
            this.gvCompraItens.Location = new System.Drawing.Point(13, 238);
            this.gvCompraItens.Name = "gvCompraItens";
            this.gvCompraItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCompraItens.Size = new System.Drawing.Size(1283, 125);
            this.gvCompraItens.TabIndex = 4;
            this.gvCompraItens.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCompraItens_CellEndEdit);
            this.gvCompraItens.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvCompraItens_CellValidating);
            this.gvCompraItens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvCompraItens_KeyDown);
            // 
            // colIdCompraItem
            // 
            this.colIdCompraItem.HeaderText = "id_compra_item";
            this.colIdCompraItem.Name = "colIdCompraItem";
            this.colIdCompraItem.Visible = false;
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "id_produto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 90;
            // 
            // colDescricao
            // 
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Width = 500;
            // 
            // colQtdSolicitada
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colQtdSolicitada.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQtdSolicitada.HeaderText = "Qtd. Solicitada";
            this.colQtdSolicitada.Name = "colQtdSolicitada";
            this.colQtdSolicitada.Width = 150;
            // 
            // colQtdRecebida
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colQtdRecebida.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtdRecebida.HeaderText = "Qtd. Recebida";
            this.colQtdRecebida.Name = "colQtdRecebida";
            this.colQtdRecebida.Width = 130;
            // 
            // colValorUnit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.colValorUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValorUnit.HeaderText = "Valor Unit.";
            this.colValorUnit.Name = "colValorUnit";
            // 
            // colValorDesc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colValorDesc.DefaultCellStyle = dataGridViewCellStyle4;
            this.colValorDesc.HeaderText = "Valor Desc";
            this.colValorDesc.Name = "colValorDesc";
            // 
            // colTotalPagar
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colTotalPagar.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotalPagar.HeaderText = "Total";
            this.colTotalPagar.Name = "colTotalPagar";
            // 
            // colIcms
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colIcms.DefaultCellStyle = dataGridViewCellStyle6;
            this.colIcms.HeaderText = "ICMS";
            this.colIcms.Name = "colIcms";
            this.colIcms.Width = 90;
            // 
            // colIpi
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.colIpi.DefaultCellStyle = dataGridViewCellStyle7;
            this.colIpi.HeaderText = "IPI";
            this.colIpi.Name = "colIpi";
            this.colIpi.Width = 90;
            // 
            // colDataConferencia
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.colDataConferencia.DefaultCellStyle = dataGridViewCellStyle8;
            this.colDataConferencia.HeaderText = "Data Conferencia";
            this.colDataConferencia.Name = "colDataConferencia";
            this.colDataConferencia.Width = 170;
            // 
            // colEstqAtual
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.colEstqAtual.DefaultCellStyle = dataGridViewCellStyle9;
            this.colEstqAtual.HeaderText = "Estq Atual";
            this.colEstqAtual.Name = "colEstqAtual";
            // 
            // colEstqMin
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.colEstqMin.DefaultCellStyle = dataGridViewCellStyle10;
            this.colEstqMin.HeaderText = "Estq Min";
            this.colEstqMin.Name = "colEstqMin";
            // 
            // colEstqMax
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.colEstqMax.DefaultCellStyle = dataGridViewCellStyle11;
            this.colEstqMax.HeaderText = "Estq Max";
            this.colEstqMax.Name = "colEstqMax";
            // 
            // colUltimoPreco
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.colUltimoPreco.DefaultCellStyle = dataGridViewCellStyle12;
            this.colUltimoPreco.HeaderText = "Ultimo Preço";
            this.colUltimoPreco.Name = "colUltimoPreco";
            this.colUltimoPreco.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gvStatus);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.cbFilial);
            this.groupBox1.Controls.Add(this.txtObservacaoComprador);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.dtaRecebimento);
            this.groupBox1.Controls.Add(this.dtaPrevisaoEntrega);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btFornecedor);
            this.groupBox1.Controls.Add(this.txtFornecedor);
            this.groupBox1.Controls.Add(this.txtTotalItens);
            this.groupBox1.Controls.Add(this.txtValorTotal);
            this.groupBox1.Controls.Add(this.txtCompraOrigem);
            this.groupBox1.Controls.Add(this.txtDataCadastro);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1283, 189);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compra";
            // 
            // gvStatus
            // 
            this.gvStatus.AllowUserToAddRows = false;
            this.gvStatus.AllowUserToDeleteRows = false;
            this.gvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colDataStatus,
            this.colUsuario});
            this.gvStatus.Location = new System.Drawing.Point(562, 19);
            this.gvStatus.MultiSelect = false;
            this.gvStatus.Name = "gvStatus";
            this.gvStatus.ReadOnly = true;
            this.gvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvStatus.Size = new System.Drawing.Size(333, 93);
            this.gvStatus.TabIndex = 19;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 70;
            // 
            // colDataStatus
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.colDataStatus.DefaultCellStyle = dataGridViewCellStyle13;
            this.colDataStatus.HeaderText = "Data";
            this.colDataStatus.Name = "colDataStatus";
            this.colDataStatus.ReadOnly = true;
            this.colDataStatus.Width = 80;
            // 
            // colUsuario
            // 
            this.colUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUsuario.HeaderText = "Usuário";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DisplayMember = "display";
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(1130, 19);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(147, 21);
            this.cbStatus.TabIndex = 17;
            this.cbStatus.ValueMember = "value";
            // 
            // cbFilial
            // 
            this.cbFilial.LabelSelecione = false;
            this.cbFilial.Location = new System.Drawing.Point(325, 18);
            this.cbFilial.Name = "cbFilial";
            this.cbFilial.SelectedDefault = false;
            this.cbFilial.Size = new System.Drawing.Size(204, 21);
            this.cbFilial.TabIndex = 16;
            // 
            // txtObservacaoComprador
            // 
            this.txtObservacaoComprador.Location = new System.Drawing.Point(562, 123);
            this.txtObservacaoComprador.Multiline = true;
            this.txtObservacaoComprador.Name = "txtObservacaoComprador";
            this.txtObservacaoComprador.Size = new System.Drawing.Size(333, 60);
            this.txtObservacaoComprador.TabIndex = 15;
            this.TextMasked.SetTextMasked(this.txtObservacaoComprador, ToolMasked.TextMask.Formats.None);
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(80, 123);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(333, 60);
            this.txtObservacao.TabIndex = 15;
            this.TextMasked.SetTextMasked(this.txtObservacao, ToolMasked.TextMask.Formats.None);
            // 
            // dtaRecebimento
            // 
            this.dtaRecebimento.Checked = false;
            this.dtaRecebimento.CustomFormat = "dd/MM/yyyy";
            this.dtaRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaRecebimento.Location = new System.Drawing.Point(111, 97);
            this.dtaRecebimento.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaRecebimento.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaRecebimento.Name = "dtaRecebimento";
            this.dtaRecebimento.ShowCheckBox = true;
            this.dtaRecebimento.Size = new System.Drawing.Size(112, 20);
            this.dtaRecebimento.TabIndex = 14;
            this.dtaRecebimento.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaPrevisaoEntrega
            // 
            this.dtaPrevisaoEntrega.Checked = false;
            this.dtaPrevisaoEntrega.CustomFormat = "dd/MM/yyyy";
            this.dtaPrevisaoEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaPrevisaoEntrega.Location = new System.Drawing.Point(118, 71);
            this.dtaPrevisaoEntrega.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaPrevisaoEntrega.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaPrevisaoEntrega.Name = "dtaPrevisaoEntrega";
            this.dtaPrevisaoEntrega.ShowCheckBox = true;
            this.dtaPrevisaoEntrega.Size = new System.Drawing.Size(112, 20);
            this.dtaPrevisaoEntrega.TabIndex = 14;
            this.dtaPrevisaoEntrega.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fornecedor:";
            // 
            // btFornecedor
            // 
            this.btFornecedor.FlatAppearance.BorderSize = 0;
            this.btFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFornecedor.Image = global::cms.Properties.Resources.procurar;
            this.btFornecedor.Location = new System.Drawing.Point(419, 43);
            this.btFornecedor.Name = "btFornecedor";
            this.btFornecedor.Size = new System.Drawing.Size(22, 22);
            this.btFornecedor.TabIndex = 12;
            this.btFornecedor.UseVisualStyleBackColor = true;
            this.btFornecedor.Click += new System.EventHandler(this.btFornecedor_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(76, 45);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(337, 20);
            this.txtFornecedor.TabIndex = 11;
            this.TextMasked.SetTextMasked(this.txtFornecedor, ToolMasked.TextMask.Formats.None);
            this.txtFornecedor.TextChanged += new System.EventHandler(this.txtFornecedor_TextChanged);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecedor_KeyDown);
            // 
            // txtTotalItens
            // 
            this.txtTotalItens.Location = new System.Drawing.Point(967, 149);
            this.txtTotalItens.MaxLength = 10;
            this.txtTotalItens.Name = "txtTotalItens";
            this.txtTotalItens.ReadOnly = true;
            this.txtTotalItens.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalItens.Size = new System.Drawing.Size(88, 20);
            this.txtTotalItens.TabIndex = 3;
            this.txtTotalItens.Text = "0";
            this.TextMasked.SetTextMasked(this.txtTotalItens, ToolMasked.TextMask.Formats.None);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(968, 123);
            this.txtValorTotal.MaxLength = 10;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorTotal.Size = new System.Drawing.Size(119, 20);
            this.txtValorTotal.TabIndex = 3;
            this.txtValorTotal.Text = "0,00";
            this.TextMasked.SetTextMasked(this.txtValorTotal, ToolMasked.TextMask.Formats.None);
            // 
            // txtCompraOrigem
            // 
            this.txtCompraOrigem.Location = new System.Drawing.Point(325, 71);
            this.txtCompraOrigem.MaxLength = 10;
            this.txtCompraOrigem.Name = "txtCompraOrigem";
            this.txtCompraOrigem.ReadOnly = true;
            this.txtCompraOrigem.Size = new System.Drawing.Size(60, 20);
            this.txtCompraOrigem.TabIndex = 3;
            this.TextMasked.SetTextMasked(this.txtCompraOrigem, ToolMasked.TextMask.Formats.None);
            this.txtCompraOrigem.Visible = false;
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(245, 19);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(72, 20);
            this.txtDataCadastro.TabIndex = 3;
            this.TextMasked.SetTextMasked(this.txtDataCadastro, ToolMasked.TextMask.Formats.None);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            this.TextMasked.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1084, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Status:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(901, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Total Itens:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(901, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Valor Total:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Observação do Comprador:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Observação:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Data Recebimento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Previsão de Entrega:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(237, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Compra Origem:";
            this.label12.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Cadastro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btEditar,
            this.btExcluir,
            this.btGravar,
            this.btCancelar,
            this.toolStripSeparator2,
            this.btAdicionarItens,
            this.toolStripSeparator3,
            this.btAprovar,
            this.btCancelarCompra,
            this.btCopiarItem,
            this.btEntrega,
            this.btConferir,
            this.btContasPagar,
            this.btFinalizar,
            this.toolStripSeparator4,
            this.btArquivoXml,
            this.btGravarXml,
            this.toolStripSeparator1,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1308, 39);
            this.tsMenu.TabIndex = 1;
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
            this.btNovo.Text = "Nova Compra";
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btEditar
            // 
            this.btEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEditar.Image = global::cms.Properties.Resources.editar;
            this.btEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(36, 36);
            this.btEditar.Text = "Editar Compra";
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btExcluir.Image = global::cms.Properties.Resources.excluir;
            this.btExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(36, 36);
            this.btExcluir.Text = "Excluir Compra";
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btGravar
            // 
            this.btGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGravar.Image = global::cms.Properties.Resources.gravar;
            this.btGravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(36, 36);
            this.btGravar.Text = "Gravar Compra";
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelar.Image = global::cms.Properties.Resources.cancelar;
            this.btCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(36, 36);
            this.btCancelar.Text = "Cancelar Ação";
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btAdicionarItens
            // 
            this.btAdicionarItens.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAdicionarItens.Image = global::cms.Properties.Resources.carrinho;
            this.btAdicionarItens.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAdicionarItens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdicionarItens.Name = "btAdicionarItens";
            this.btAdicionarItens.Size = new System.Drawing.Size(36, 36);
            this.btAdicionarItens.Text = "Adicionar Itens";
            this.btAdicionarItens.Click += new System.EventHandler(this.btAdicionarItens_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btAprovar
            // 
            this.btAprovar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAprovar.Image = global::cms.Properties.Resources.compra_aprovar;
            this.btAprovar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAprovar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAprovar.Name = "btAprovar";
            this.btAprovar.Size = new System.Drawing.Size(36, 36);
            this.btAprovar.Text = "Aprovar compra";
            this.btAprovar.Click += new System.EventHandler(this.btAprovar_Click);
            // 
            // btCancelarCompra
            // 
            this.btCancelarCompra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelarCompra.Image = global::cms.Properties.Resources.compra_cancelar;
            this.btCancelarCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCancelarCompra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelarCompra.Name = "btCancelarCompra";
            this.btCancelarCompra.Size = new System.Drawing.Size(36, 36);
            this.btCancelarCompra.Text = "Cancelar compra";
            this.btCancelarCompra.Click += new System.EventHandler(this.btCancelarCompra_Click);
            // 
            // btCopiarItem
            // 
            this.btCopiarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCopiarItem.Image = global::cms.Properties.Resources.compra_duplicar;
            this.btCopiarItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCopiarItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCopiarItem.Name = "btCopiarItem";
            this.btCopiarItem.Size = new System.Drawing.Size(36, 36);
            this.btCopiarItem.Text = "Copiar itens de outra compra";
            this.btCopiarItem.Click += new System.EventHandler(this.btCopiarItem_Click);
            // 
            // btEntrega
            // 
            this.btEntrega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEntrega.Image = global::cms.Properties.Resources.entrega;
            this.btEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEntrega.Name = "btEntrega";
            this.btEntrega.Size = new System.Drawing.Size(36, 36);
            this.btEntrega.Text = "Informar recebimento";
            this.btEntrega.Click += new System.EventHandler(this.btEntrega_Click);
            // 
            // btConferir
            // 
            this.btConferir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btConferir.Image = global::cms.Properties.Resources.compra_conferencia;
            this.btConferir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btConferir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btConferir.Name = "btConferir";
            this.btConferir.Size = new System.Drawing.Size(36, 36);
            this.btConferir.Text = "Conferir compra";
            this.btConferir.Click += new System.EventHandler(this.btConferir_Click);
            // 
            // btContasPagar
            // 
            this.btContasPagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btContasPagar.Image = global::cms.Properties.Resources.lancamento;
            this.btContasPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btContasPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btContasPagar.Name = "btContasPagar";
            this.btContasPagar.Size = new System.Drawing.Size(36, 36);
            this.btContasPagar.Text = "Contas a Pagar";
            this.btContasPagar.Click += new System.EventHandler(this.btContasPagar_Click);
            // 
            // btFinalizar
            // 
            this.btFinalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btFinalizar.Image = global::cms.Properties.Resources.arquivar;
            this.btFinalizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btFinalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFinalizar.Name = "btFinalizar";
            this.btFinalizar.Size = new System.Drawing.Size(36, 36);
            this.btFinalizar.Text = "Finalizar Compra";
            this.btFinalizar.Click += new System.EventHandler(this.btFinalizar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // btArquivoXml
            // 
            this.btArquivoXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btArquivoXml.Image = global::cms.Properties.Resources.arquivo_xml;
            this.btArquivoXml.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btArquivoXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btArquivoXml.Name = "btArquivoXml";
            this.btArquivoXml.Size = new System.Drawing.Size(36, 36);
            this.btArquivoXml.Text = "toolStripButton2";
            this.btArquivoXml.Click += new System.EventHandler(this.btArquivoXml_Click);
            // 
            // btGravarXml
            // 
            this.btGravarXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGravarXml.Image = global::cms.Properties.Resources.gravar_arquivo;
            this.btGravarXml.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btGravarXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGravarXml.Name = "btGravarXml";
            this.btGravarXml.Size = new System.Drawing.Size(36, 36);
            this.btGravarXml.Text = "Download do Xml";
            this.btGravarXml.Click += new System.EventHandler(this.btGravarXml_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            // TextMasked
            // 
            this.TextMasked.Text = null;
            // 
            // frmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 375);
            this.Controls.Add(this.gvCompraItens);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCompra";
            this.Text = "Cadastro de Compra";
            this.Load += new System.EventHandler(this.frmCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCompraItens)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStatus)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btEditar;
        private System.Windows.Forms.ToolStripButton btExcluir;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtaPrevisaoEntrega;
        private System.Windows.Forms.DateTimePicker dtaRecebimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservacaoComprador;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Util.ctrlFilial cbFilial;
        private System.Windows.Forms.TextBox txtCompraOrigem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripButton btAdicionarItens;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btAprovar;
        private System.Windows.Forms.ToolStripButton btCancelarCompra;
        private System.Windows.Forms.ToolStripButton btCopiarItem;
        private System.Windows.Forms.ToolStripButton btConferir;
        private System.Windows.Forms.ToolStripButton btArquivoXml;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btGravarXml;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label13;
        private ToolMasked.TextMask TextMasked;
        private System.Windows.Forms.TextBox txtTotalItens;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripButton btEntrega;
        private System.Windows.Forms.DataGridView gvCompraItens;
        private System.Windows.Forms.DataGridView gvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.ToolStripButton btContasPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompraItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdSolicitada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdRecebida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIcms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIpi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataConferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstqAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstqMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstqMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoPreco;
        private System.Windows.Forms.ToolStripButton btFinalizar;
    }
}