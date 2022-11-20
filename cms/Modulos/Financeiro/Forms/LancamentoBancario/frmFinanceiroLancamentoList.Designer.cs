namespace cms.Modulos.Financeiro.Forms.LancamentoBancario
{
    partial class frmFinanceiroLancamentoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceiroLancamentoList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtContaPagar = new System.Windows.Forms.TextBox();
            this.txtContaReceber = new System.Windows.Forms.TextBox();
            this.gvFinanceiroLancamento = new System.Windows.Forms.DataGridView();
            this.gbPesquisaLancamento = new System.Windows.Forms.GroupBox();
            this.ctrlFilial = new cms.Modulos.Util.ctrlFilial();
            this.btFornecedor = new System.Windows.Forms.Button();
            this.btCliente = new System.Windows.Forms.Button();
            this.btContaCorrente = new System.Windows.Forms.Button();
            this.dtaConciliacaoDataAte = new System.Windows.Forms.DateTimePicker();
            this.dtaLancamentoDataAte = new System.Windows.Forms.DateTimePicker();
            this.dtaConciliacaoDataDe = new System.Windows.Forms.DateTimePicker();
            this.dtaLancamentoDataDe = new System.Windows.Forms.DateTimePicker();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.lbDataPagamentoAte = new System.Windows.Forms.Label();
            this.lbDataVencimentoAte = new System.Windows.Forms.Label();
            this.lbDataPagamentoDe = new System.Windows.Forms.Label();
            this.lbDataVencimentoDe = new System.Windows.Forms.Label();
            this.lbContaCorrente = new System.Windows.Forms.Label();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.lbDocumento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbContaPagar = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbFornecedor = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta_corrente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_conciliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroLancamento)).BeginInit();
            this.gbPesquisaLancamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1122, 39);
            this.tsMenu.TabIndex = 15;
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
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(80, 97);
            this.txtDocumento.MaxLength = 30;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 12;
            this.TextMaskedit.SetTextMasked(this.txtDocumento, ToolMasked.TextMask.Formats.None);
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.Location = new System.Drawing.Point(537, 71);
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.ReadOnly = true;
            this.txtContaCorrente.Size = new System.Drawing.Size(209, 20);
            this.txtContaCorrente.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtContaCorrente, ToolMasked.TextMask.Formats.None);
            this.txtContaCorrente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContaCorrente_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(59, 19);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(58, 20);
            this.txtCodigo.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(171, 18);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(337, 20);
            this.txtCliente.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtCliente, ToolMasked.TextMask.Formats.None);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(79, 71);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(337, 20);
            this.txtFornecedor.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtFornecedor, ToolMasked.TextMask.Formats.None);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecedor_KeyDown);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(73, 123);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(206, 20);
            this.txtDescricao.TabIndex = 12;
            this.TextMaskedit.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // txtContaPagar
            // 
            this.txtContaPagar.Location = new System.Drawing.Point(93, 45);
            this.txtContaPagar.MaxLength = 10;
            this.txtContaPagar.Name = "txtContaPagar";
            this.txtContaPagar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContaPagar.Size = new System.Drawing.Size(58, 20);
            this.txtContaPagar.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtContaPagar, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtContaReceber
            // 
            this.txtContaReceber.Location = new System.Drawing.Point(254, 45);
            this.txtContaReceber.MaxLength = 10;
            this.txtContaReceber.Name = "txtContaReceber";
            this.txtContaReceber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContaReceber.Size = new System.Drawing.Size(58, 20);
            this.txtContaReceber.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtContaReceber, ToolMasked.TextMask.Formats.Numero);
            // 
            // gvFinanceiroLancamento
            // 
            this.gvFinanceiroLancamento.AllowUserToAddRows = false;
            this.gvFinanceiroLancamento.AllowUserToDeleteRows = false;
            this.gvFinanceiroLancamento.AllowUserToResizeColumns = false;
            this.gvFinanceiroLancamento.AllowUserToResizeRows = false;
            this.gvFinanceiroLancamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroLancamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroLancamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.cliente_fornecedor,
            this.conta_corrente,
            this.data_lancamento,
            this.data_conciliado,
            this.descricao,
            this.valor_debito,
            this.valor_credito,
            this.valor_saldo});
            this.gvFinanceiroLancamento.Location = new System.Drawing.Point(12, 199);
            this.gvFinanceiroLancamento.MultiSelect = false;
            this.gvFinanceiroLancamento.Name = "gvFinanceiroLancamento";
            this.gvFinanceiroLancamento.ReadOnly = true;
            this.gvFinanceiroLancamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroLancamento.ShowEditingIcon = false;
            this.gvFinanceiroLancamento.ShowRowErrors = false;
            this.gvFinanceiroLancamento.Size = new System.Drawing.Size(1098, 181);
            this.gvFinanceiroLancamento.TabIndex = 16;
            this.gvFinanceiroLancamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvFinanceiroLancamento_CellFormatting);
            this.gvFinanceiroLancamento.DoubleClick += new System.EventHandler(this.gvFinanceiroLancamento_DoubleClick);
            // 
            // gbPesquisaLancamento
            // 
            this.gbPesquisaLancamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisaLancamento.Controls.Add(this.ctrlFilial);
            this.gbPesquisaLancamento.Controls.Add(this.btFornecedor);
            this.gbPesquisaLancamento.Controls.Add(this.btCliente);
            this.gbPesquisaLancamento.Controls.Add(this.btContaCorrente);
            this.gbPesquisaLancamento.Controls.Add(this.dtaConciliacaoDataAte);
            this.gbPesquisaLancamento.Controls.Add(this.dtaLancamentoDataAte);
            this.gbPesquisaLancamento.Controls.Add(this.dtaConciliacaoDataDe);
            this.gbPesquisaLancamento.Controls.Add(this.dtaLancamentoDataDe);
            this.gbPesquisaLancamento.Controls.Add(this.btPesquisar);
            this.gbPesquisaLancamento.Controls.Add(this.txtDescricao);
            this.gbPesquisaLancamento.Controls.Add(this.txtDocumento);
            this.gbPesquisaLancamento.Controls.Add(this.txtContaCorrente);
            this.gbPesquisaLancamento.Controls.Add(this.txtContaReceber);
            this.gbPesquisaLancamento.Controls.Add(this.txtContaPagar);
            this.gbPesquisaLancamento.Controls.Add(this.txtCodigo);
            this.gbPesquisaLancamento.Controls.Add(this.lbDataPagamentoAte);
            this.gbPesquisaLancamento.Controls.Add(this.lbDataVencimentoAte);
            this.gbPesquisaLancamento.Controls.Add(this.lbDataPagamentoDe);
            this.gbPesquisaLancamento.Controls.Add(this.lbDataVencimentoDe);
            this.gbPesquisaLancamento.Controls.Add(this.lbContaCorrente);
            this.gbPesquisaLancamento.Controls.Add(this.lbDescricao);
            this.gbPesquisaLancamento.Controls.Add(this.lbDocumento);
            this.gbPesquisaLancamento.Controls.Add(this.label1);
            this.gbPesquisaLancamento.Controls.Add(this.lbContaPagar);
            this.gbPesquisaLancamento.Controls.Add(this.lbCodigo);
            this.gbPesquisaLancamento.Controls.Add(this.txtFornecedor);
            this.gbPesquisaLancamento.Controls.Add(this.txtCliente);
            this.gbPesquisaLancamento.Controls.Add(this.lbFornecedor);
            this.gbPesquisaLancamento.Controls.Add(this.lbCliente);
            this.gbPesquisaLancamento.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisaLancamento.Name = "gbPesquisaLancamento";
            this.gbPesquisaLancamento.Size = new System.Drawing.Size(1098, 151);
            this.gbPesquisaLancamento.TabIndex = 17;
            this.gbPesquisaLancamento.TabStop = false;
            this.gbPesquisaLancamento.Text = "Pesquisar Lançamento Bancario";
            // 
            // ctrlFilial
            // 
            this.ctrlFilial.LabelSelecione = false;
            this.ctrlFilial.Location = new System.Drawing.Point(543, 16);
            this.ctrlFilial.Name = "ctrlFilial";
            this.ctrlFilial.SelectedDefault = false;
            this.ctrlFilial.Size = new System.Drawing.Size(211, 21);
            this.ctrlFilial.TabIndex = 13;
            // 
            // btFornecedor
            // 
            this.btFornecedor.FlatAppearance.BorderSize = 0;
            this.btFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFornecedor.Image = global::cms.Properties.Resources.procurar;
            this.btFornecedor.Location = new System.Drawing.Point(422, 70);
            this.btFornecedor.Name = "btFornecedor";
            this.btFornecedor.Size = new System.Drawing.Size(22, 23);
            this.btFornecedor.TabIndex = 3;
            this.btFornecedor.UseVisualStyleBackColor = true;
            this.btFornecedor.Click += new System.EventHandler(this.btFornecedor_Click);
            // 
            // btCliente
            // 
            this.btCliente.FlatAppearance.BorderSize = 0;
            this.btCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliente.Image = global::cms.Properties.Resources.procurar;
            this.btCliente.Location = new System.Drawing.Point(514, 17);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(22, 23);
            this.btCliente.TabIndex = 3;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // btContaCorrente
            // 
            this.btContaCorrente.FlatAppearance.BorderSize = 0;
            this.btContaCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContaCorrente.Image = global::cms.Properties.Resources.procurar;
            this.btContaCorrente.Location = new System.Drawing.Point(752, 70);
            this.btContaCorrente.Name = "btContaCorrente";
            this.btContaCorrente.Size = new System.Drawing.Size(22, 23);
            this.btContaCorrente.TabIndex = 7;
            this.btContaCorrente.UseVisualStyleBackColor = true;
            this.btContaCorrente.Click += new System.EventHandler(this.btContaCorrente_Click);
            // 
            // dtaConciliacaoDataAte
            // 
            this.dtaConciliacaoDataAte.Checked = false;
            this.dtaConciliacaoDataAte.CustomFormat = "dd/MM/yyyy";
            this.dtaConciliacaoDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaConciliacaoDataAte.Location = new System.Drawing.Point(565, 123);
            this.dtaConciliacaoDataAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaConciliacaoDataAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaConciliacaoDataAte.Name = "dtaConciliacaoDataAte";
            this.dtaConciliacaoDataAte.ShowCheckBox = true;
            this.dtaConciliacaoDataAte.Size = new System.Drawing.Size(112, 20);
            this.dtaConciliacaoDataAte.TabIndex = 11;
            this.dtaConciliacaoDataAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaLancamentoDataAte
            // 
            this.dtaLancamentoDataAte.Checked = false;
            this.dtaLancamentoDataAte.CustomFormat = "dd/MM/yyyy";
            this.dtaLancamentoDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaLancamentoDataAte.Location = new System.Drawing.Point(565, 97);
            this.dtaLancamentoDataAte.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaLancamentoDataAte.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaLancamentoDataAte.Name = "dtaLancamentoDataAte";
            this.dtaLancamentoDataAte.ShowCheckBox = true;
            this.dtaLancamentoDataAte.Size = new System.Drawing.Size(112, 20);
            this.dtaLancamentoDataAte.TabIndex = 9;
            this.dtaLancamentoDataAte.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaConciliacaoDataDe
            // 
            this.dtaConciliacaoDataDe.Checked = false;
            this.dtaConciliacaoDataDe.CustomFormat = "dd/MM/yyyy";
            this.dtaConciliacaoDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaConciliacaoDataDe.Location = new System.Drawing.Point(419, 123);
            this.dtaConciliacaoDataDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaConciliacaoDataDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaConciliacaoDataDe.Name = "dtaConciliacaoDataDe";
            this.dtaConciliacaoDataDe.ShowCheckBox = true;
            this.dtaConciliacaoDataDe.Size = new System.Drawing.Size(112, 20);
            this.dtaConciliacaoDataDe.TabIndex = 10;
            this.dtaConciliacaoDataDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaLancamentoDataDe
            // 
            this.dtaLancamentoDataDe.Checked = false;
            this.dtaLancamentoDataDe.CustomFormat = "dd/MM/yyyy";
            this.dtaLancamentoDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaLancamentoDataDe.Location = new System.Drawing.Point(419, 97);
            this.dtaLancamentoDataDe.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaLancamentoDataDe.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaLancamentoDataDe.Name = "dtaLancamentoDataDe";
            this.dtaLancamentoDataDe.ShowCheckBox = true;
            this.dtaLancamentoDataDe.Size = new System.Drawing.Size(112, 20);
            this.dtaLancamentoDataDe.TabIndex = 8;
            this.dtaLancamentoDataDe.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(995, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 6;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // lbDataPagamentoAte
            // 
            this.lbDataPagamentoAte.AutoSize = true;
            this.lbDataPagamentoAte.Location = new System.Drawing.Point(537, 126);
            this.lbDataPagamentoAte.Name = "lbDataPagamentoAte";
            this.lbDataPagamentoAte.Size = new System.Drawing.Size(22, 13);
            this.lbDataPagamentoAte.TabIndex = 5;
            this.lbDataPagamentoAte.Text = "até";
            // 
            // lbDataVencimentoAte
            // 
            this.lbDataVencimentoAte.AutoSize = true;
            this.lbDataVencimentoAte.Location = new System.Drawing.Point(537, 100);
            this.lbDataVencimentoAte.Name = "lbDataVencimentoAte";
            this.lbDataVencimentoAte.Size = new System.Drawing.Size(22, 13);
            this.lbDataVencimentoAte.TabIndex = 5;
            this.lbDataVencimentoAte.Text = "até";
            // 
            // lbDataPagamentoDe
            // 
            this.lbDataPagamentoDe.AutoSize = true;
            this.lbDataPagamentoDe.Location = new System.Drawing.Point(307, 126);
            this.lbDataPagamentoDe.Name = "lbDataPagamentoDe";
            this.lbDataPagamentoDe.Size = new System.Drawing.Size(106, 13);
            this.lbDataPagamentoDe.TabIndex = 5;
            this.lbDataPagamentoDe.Text = "Data de Conciliação:";
            // 
            // lbDataVencimentoDe
            // 
            this.lbDataVencimentoDe.AutoSize = true;
            this.lbDataVencimentoDe.Location = new System.Drawing.Point(306, 100);
            this.lbDataVencimentoDe.Name = "lbDataVencimentoDe";
            this.lbDataVencimentoDe.Size = new System.Drawing.Size(110, 13);
            this.lbDataVencimentoDe.TabIndex = 5;
            this.lbDataVencimentoDe.Text = "Data de Lançamento:";
            // 
            // lbContaCorrente
            // 
            this.lbContaCorrente.AutoSize = true;
            this.lbContaCorrente.Location = new System.Drawing.Point(450, 75);
            this.lbContaCorrente.Name = "lbContaCorrente";
            this.lbContaCorrente.Size = new System.Drawing.Size(81, 13);
            this.lbContaCorrente.TabIndex = 5;
            this.lbContaCorrente.Text = "Conta Corrente:";
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(9, 126);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(58, 13);
            this.lbDescricao.TabIndex = 5;
            this.lbDescricao.Text = "Descrição:";
            // 
            // lbDocumento
            // 
            this.lbDocumento.AutoSize = true;
            this.lbDocumento.Location = new System.Drawing.Point(9, 100);
            this.lbDocumento.Name = "lbDocumento";
            this.lbDocumento.Size = new System.Drawing.Size(65, 13);
            this.lbDocumento.TabIndex = 5;
            this.lbDocumento.Text = "Documento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Conta a Receber:";
            // 
            // lbContaPagar
            // 
            this.lbContaPagar.AutoSize = true;
            this.lbContaPagar.Location = new System.Drawing.Point(9, 48);
            this.lbContaPagar.Name = "lbContaPagar";
            this.lbContaPagar.Size = new System.Drawing.Size(78, 13);
            this.lbContaPagar.TabIndex = 5;
            this.lbContaPagar.Text = "Conta a Pagar:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(10, 22);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(43, 13);
            this.lbCodigo.TabIndex = 5;
            this.lbCodigo.Text = "Código:";
            // 
            // lbFornecedor
            // 
            this.lbFornecedor.AutoSize = true;
            this.lbFornecedor.Location = new System.Drawing.Point(9, 75);
            this.lbFornecedor.Name = "lbFornecedor";
            this.lbFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lbFornecedor.TabIndex = 0;
            this.lbFornecedor.Text = "Fornecedor:";
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Location = new System.Drawing.Point(123, 22);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(42, 13);
            this.lbCliente.TabIndex = 0;
            this.lbCliente.Text = "Cliente:";
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "id_financeiro_lancamento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = null;
            this.codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // cliente_fornecedor
            // 
            this.cliente_fornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente_fornecedor.DataPropertyName = "cliente_fornecedor";
            this.cliente_fornecedor.HeaderText = "Cliente / Fornecedor";
            this.cliente_fornecedor.Name = "cliente_fornecedor";
            this.cliente_fornecedor.ReadOnly = true;
            // 
            // conta_corrente
            // 
            this.conta_corrente.DataPropertyName = "conta_corrente";
            this.conta_corrente.HeaderText = "Conta Corrente";
            this.conta_corrente.Name = "conta_corrente";
            this.conta_corrente.ReadOnly = true;
            this.conta_corrente.Width = 130;
            // 
            // data_lancamento
            // 
            this.data_lancamento.DataPropertyName = "data_lancamento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.data_lancamento.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_lancamento.HeaderText = "Data Lançamento";
            this.data_lancamento.Name = "data_lancamento";
            this.data_lancamento.ReadOnly = true;
            this.data_lancamento.Width = 120;
            // 
            // data_conciliado
            // 
            this.data_conciliado.DataPropertyName = "data_conciliado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.data_conciliado.DefaultCellStyle = dataGridViewCellStyle3;
            this.data_conciliado.HeaderText = "Data Conc.";
            this.data_conciliado.Name = "data_conciliado";
            this.data_conciliado.ReadOnly = true;
            this.data_conciliado.Width = 130;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 150;
            // 
            // valor_debito
            // 
            this.valor_debito.DataPropertyName = "valor_debito";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.valor_debito.DefaultCellStyle = dataGridViewCellStyle4;
            this.valor_debito.HeaderText = "Vlr. Débito";
            this.valor_debito.Name = "valor_debito";
            this.valor_debito.ReadOnly = true;
            // 
            // valor_credito
            // 
            this.valor_credito.DataPropertyName = "valor_credito";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.valor_credito.DefaultCellStyle = dataGridViewCellStyle5;
            this.valor_credito.HeaderText = "Vlr. Crédito";
            this.valor_credito.Name = "valor_credito";
            this.valor_credito.ReadOnly = true;
            // 
            // valor_saldo
            // 
            this.valor_saldo.DataPropertyName = "valor_saldo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.valor_saldo.DefaultCellStyle = dataGridViewCellStyle6;
            this.valor_saldo.HeaderText = "Vlr. Saldo";
            this.valor_saldo.Name = "valor_saldo";
            this.valor_saldo.ReadOnly = true;
            this.valor_saldo.Width = 80;
            // 
            // frmFinanceiroLancamentoList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 392);
            this.Controls.Add(this.gbPesquisaLancamento);
            this.Controls.Add(this.gvFinanceiroLancamento);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroLancamentoList";
            this.Text = "Pesquisar Lancamento Bancario";
            this.Load += new System.EventHandler(this.frmFinanceiroLancamentoList_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroLancamento)).EndInit();
            this.gbPesquisaLancamento.ResumeLayout(false);
            this.gbPesquisaLancamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.DataGridView gvFinanceiroLancamento;
        private System.Windows.Forms.GroupBox gbPesquisaLancamento;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Button btContaCorrente;
        private System.Windows.Forms.DateTimePicker dtaConciliacaoDataAte;
        private System.Windows.Forms.DateTimePicker dtaLancamentoDataAte;
        private System.Windows.Forms.DateTimePicker dtaConciliacaoDataDe;
        private System.Windows.Forms.DateTimePicker dtaLancamentoDataDe;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbDataPagamentoAte;
        private System.Windows.Forms.Label lbDataVencimentoAte;
        private System.Windows.Forms.Label lbDataPagamentoDe;
        private System.Windows.Forms.Label lbDataVencimentoDe;
        private System.Windows.Forms.Label lbContaCorrente;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.Button btFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lbFornecedor;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.TextBox txtContaReceber;
        private System.Windows.Forms.TextBox txtContaPagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbContaPagar;
        private Util.ctrlFilial ctrlFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_corrente;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_lancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_conciliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_saldo;
    }
}