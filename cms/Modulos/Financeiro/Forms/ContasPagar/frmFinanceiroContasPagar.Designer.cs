namespace cms.Modulos.Financeiro.Forms.ContasPagar
{
    partial class frmFinanceiroContasPagar
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
            this.lbFormaPagamento = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btDuplicarConta = new System.Windows.Forms.ToolStripButton();
            this.btLancarConta = new System.Windows.Forms.ToolStripButton();
            this.btEstornarLancamento = new System.Windows.Forms.ToolStripButton();
            this.btLancamento = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbContasPagar = new System.Windows.Forms.GroupBox();
            this.dtaDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.dtaVencimentoData = new System.Windows.Forms.DateTimePicker();
            this.btFormaPagamento = new System.Windows.Forms.Button();
            this.btContaCorrente = new System.Windows.Forms.Button();
            this.btPlanoContas = new System.Windows.Forms.Button();
            this.lbValorPagamento = new System.Windows.Forms.Label();
            this.btFornecedor = new System.Windows.Forms.Button();
            this.lbDataPagamento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lbDataVencimento = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lbValorVencimento = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValorPagamento = new System.Windows.Forms.TextBox();
            this.txtValorVencimento = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtPlanoContas = new System.Windows.Forms.TextBox();
            this.txtDataLancamento = new System.Windows.Forms.TextBox();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbDataLancamento = new System.Windows.Forms.Label();
            this.lbDataCadastro = new System.Windows.Forms.Label();
            this.lbDocumento = new System.Windows.Forms.Label();
            this.lbObservacao = new System.Windows.Forms.Label();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbContaCorrente = new System.Windows.Forms.Label();
            this.lbPlanoContas = new System.Windows.Forms.Label();
            this.lbFornecedor = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.ctrlFilial = new cms.Modulos.Util.ctrlFilial();
            this.lbFormaPagamento.SuspendLayout();
            this.gbContasPagar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFormaPagamento
            // 
            this.lbFormaPagamento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btEditar,
            this.btExcluir,
            this.btGravar,
            this.btCancelar,
            this.toolStripSeparator2,
            this.btDuplicarConta,
            this.btLancarConta,
            this.btEstornarLancamento,
            this.btLancamento,
            this.toolStripSeparator1,
            this.btFechar});
            this.lbFormaPagamento.Location = new System.Drawing.Point(0, 0);
            this.lbFormaPagamento.Name = "lbFormaPagamento";
            this.lbFormaPagamento.Size = new System.Drawing.Size(766, 39);
            this.lbFormaPagamento.TabIndex = 37;
            this.lbFormaPagamento.Text = "toolStrip1";
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
            this.btEditar.Text = "Editar Cliente";
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
            this.btExcluir.Text = "Excluir Cliente";
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
            this.btGravar.Text = "Gravar Cliente";
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
            // btDuplicarConta
            // 
            this.btDuplicarConta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDuplicarConta.Image = global::cms.Properties.Resources.duplicar_conta;
            this.btDuplicarConta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btDuplicarConta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDuplicarConta.Name = "btDuplicarConta";
            this.btDuplicarConta.Size = new System.Drawing.Size(36, 36);
            this.btDuplicarConta.Text = "Duplicar Contas a Pagar";
            this.btDuplicarConta.Click += new System.EventHandler(this.btDuplicarConta_Click);
            // 
            // btLancarConta
            // 
            this.btLancarConta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btLancarConta.Image = global::cms.Properties.Resources.lancar_conta;
            this.btLancarConta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btLancarConta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLancarConta.Name = "btLancarConta";
            this.btLancarConta.Size = new System.Drawing.Size(36, 36);
            this.btLancarConta.Text = "Lançar Conta Corrente";
            this.btLancarConta.Click += new System.EventHandler(this.btLancarConta_Click);
            // 
            // btEstornarLancamento
            // 
            this.btEstornarLancamento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEstornarLancamento.Image = global::cms.Properties.Resources.estornar_lancamento;
            this.btEstornarLancamento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btEstornarLancamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEstornarLancamento.Name = "btEstornarLancamento";
            this.btEstornarLancamento.Size = new System.Drawing.Size(36, 36);
            this.btEstornarLancamento.Text = "Estornar Lançamento Bancario";
            this.btEstornarLancamento.Click += new System.EventHandler(this.btEstornarLancamento_Click);
            // 
            // btLancamento
            // 
            this.btLancamento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btLancamento.Image = global::cms.Properties.Resources.lancamento;
            this.btLancamento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btLancamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLancamento.Name = "btLancamento";
            this.btLancamento.Size = new System.Drawing.Size(36, 36);
            this.btLancamento.Text = "Abrir Lançamento Bancario";
            this.btLancamento.Click += new System.EventHandler(this.btLancamento_Click);
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
            // gbContasPagar
            // 
            this.gbContasPagar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContasPagar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbContasPagar.Controls.Add(this.ctrlFilial);
            this.gbContasPagar.Controls.Add(this.dtaDataPagamento);
            this.gbContasPagar.Controls.Add(this.dtaVencimentoData);
            this.gbContasPagar.Controls.Add(this.btFormaPagamento);
            this.gbContasPagar.Controls.Add(this.btContaCorrente);
            this.gbContasPagar.Controls.Add(this.btPlanoContas);
            this.gbContasPagar.Controls.Add(this.lbValorPagamento);
            this.gbContasPagar.Controls.Add(this.btFornecedor);
            this.gbContasPagar.Controls.Add(this.lbDataPagamento);
            this.gbContasPagar.Controls.Add(this.txtDocumento);
            this.gbContasPagar.Controls.Add(this.lbDataVencimento);
            this.gbContasPagar.Controls.Add(this.txtObservacao);
            this.gbContasPagar.Controls.Add(this.lbValorVencimento);
            this.gbContasPagar.Controls.Add(this.txtDescricao);
            this.gbContasPagar.Controls.Add(this.txtValorPagamento);
            this.gbContasPagar.Controls.Add(this.txtValorVencimento);
            this.gbContasPagar.Controls.Add(this.txtFormaPagamento);
            this.gbContasPagar.Controls.Add(this.txtContaCorrente);
            this.gbContasPagar.Controls.Add(this.txtPlanoContas);
            this.gbContasPagar.Controls.Add(this.txtDataLancamento);
            this.gbContasPagar.Controls.Add(this.txtDataCadastro);
            this.gbContasPagar.Controls.Add(this.txtFornecedor);
            this.gbContasPagar.Controls.Add(this.txtCodigo);
            this.gbContasPagar.Controls.Add(this.lbDataLancamento);
            this.gbContasPagar.Controls.Add(this.lbDataCadastro);
            this.gbContasPagar.Controls.Add(this.lbDocumento);
            this.gbContasPagar.Controls.Add(this.lbObservacao);
            this.gbContasPagar.Controls.Add(this.lbDescricao);
            this.gbContasPagar.Controls.Add(this.label1);
            this.gbContasPagar.Controls.Add(this.lbContaCorrente);
            this.gbContasPagar.Controls.Add(this.lbPlanoContas);
            this.gbContasPagar.Controls.Add(this.lbFornecedor);
            this.gbContasPagar.Controls.Add(this.lbCodigo);
            this.gbContasPagar.Location = new System.Drawing.Point(12, 42);
            this.gbContasPagar.Name = "gbContasPagar";
            this.gbContasPagar.Size = new System.Drawing.Size(742, 261);
            this.gbContasPagar.TabIndex = 17;
            this.gbContasPagar.TabStop = false;
            this.gbContasPagar.Text = "Contas a Pagar";
            // 
            // dtaDataPagamento
            // 
            this.dtaDataPagamento.Checked = false;
            this.dtaDataPagamento.CustomFormat = "dd/MM/yyyy";
            this.dtaDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaDataPagamento.Location = new System.Drawing.Point(335, 227);
            this.dtaDataPagamento.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaDataPagamento.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaDataPagamento.Name = "dtaDataPagamento";
            this.dtaDataPagamento.ShowCheckBox = true;
            this.dtaDataPagamento.Size = new System.Drawing.Size(112, 20);
            this.dtaDataPagamento.TabIndex = 16;
            this.dtaDataPagamento.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // dtaVencimentoData
            // 
            this.dtaVencimentoData.Checked = false;
            this.dtaVencimentoData.CustomFormat = "dd/MM/yyyy";
            this.dtaVencimentoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaVencimentoData.Location = new System.Drawing.Point(335, 201);
            this.dtaVencimentoData.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaVencimentoData.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaVencimentoData.Name = "dtaVencimentoData";
            this.dtaVencimentoData.ShowCheckBox = true;
            this.dtaVencimentoData.Size = new System.Drawing.Size(112, 20);
            this.dtaVencimentoData.TabIndex = 14;
            this.dtaVencimentoData.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // btFormaPagamento
            // 
            this.btFormaPagamento.FlatAppearance.BorderSize = 0;
            this.btFormaPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFormaPagamento.Image = global::cms.Properties.Resources.procurar;
            this.btFormaPagamento.Location = new System.Drawing.Point(514, 95);
            this.btFormaPagamento.Name = "btFormaPagamento";
            this.btFormaPagamento.Size = new System.Drawing.Size(22, 22);
            this.btFormaPagamento.TabIndex = 9;
            this.btFormaPagamento.UseVisualStyleBackColor = true;
            this.btFormaPagamento.Click += new System.EventHandler(this.btFormaPagamento_Click);
            // 
            // btContaCorrente
            // 
            this.btContaCorrente.FlatAppearance.BorderSize = 0;
            this.btContaCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContaCorrente.Image = global::cms.Properties.Resources.procurar;
            this.btContaCorrente.Location = new System.Drawing.Point(229, 95);
            this.btContaCorrente.Name = "btContaCorrente";
            this.btContaCorrente.Size = new System.Drawing.Size(22, 22);
            this.btContaCorrente.TabIndex = 9;
            this.btContaCorrente.UseVisualStyleBackColor = true;
            this.btContaCorrente.Click += new System.EventHandler(this.btContaCorrente_Click);
            // 
            // btPlanoContas
            // 
            this.btPlanoContas.FlatAppearance.BorderSize = 0;
            this.btPlanoContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPlanoContas.Image = global::cms.Properties.Resources.procurar;
            this.btPlanoContas.Location = new System.Drawing.Point(365, 69);
            this.btPlanoContas.Name = "btPlanoContas";
            this.btPlanoContas.Size = new System.Drawing.Size(22, 22);
            this.btPlanoContas.TabIndex = 7;
            this.btPlanoContas.UseVisualStyleBackColor = true;
            this.btPlanoContas.Click += new System.EventHandler(this.btPlanoContas_Click);
            // 
            // lbValorPagamento
            // 
            this.lbValorPagamento.AutoSize = true;
            this.lbValorPagamento.Location = new System.Drawing.Point(6, 230);
            this.lbValorPagamento.Name = "lbValorPagamento";
            this.lbValorPagamento.Size = new System.Drawing.Size(106, 13);
            this.lbValorPagamento.TabIndex = 7;
            this.lbValorPagamento.Text = "Valor de Pagamento:";
            // 
            // btFornecedor
            // 
            this.btFornecedor.FlatAppearance.BorderSize = 0;
            this.btFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFornecedor.Image = global::cms.Properties.Resources.procurar;
            this.btFornecedor.Location = new System.Drawing.Point(328, 43);
            this.btFornecedor.Name = "btFornecedor";
            this.btFornecedor.Size = new System.Drawing.Size(22, 22);
            this.btFornecedor.TabIndex = 5;
            this.btFornecedor.UseVisualStyleBackColor = true;
            this.btFornecedor.Click += new System.EventHandler(this.btFornecedor_Click);
            // 
            // lbDataPagamento
            // 
            this.lbDataPagamento.AutoSize = true;
            this.lbDataPagamento.Location = new System.Drawing.Point(224, 230);
            this.lbDataPagamento.Name = "lbDataPagamento";
            this.lbDataPagamento.Size = new System.Drawing.Size(105, 13);
            this.lbDataPagamento.TabIndex = 7;
            this.lbDataPagamento.Text = "Data de Pagamento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(77, 175);
            this.txtDocumento.MaxLength = 30;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(81, 20);
            this.txtDocumento.TabIndex = 12;
            this.TextMaskedit.SetTextMasked(this.txtDocumento, ToolMasked.TextMask.Formats.None);
            // 
            // lbDataVencimento
            // 
            this.lbDataVencimento.AutoSize = true;
            this.lbDataVencimento.Location = new System.Drawing.Point(226, 204);
            this.lbDataVencimento.Name = "lbDataVencimento";
            this.lbDataVencimento.Size = new System.Drawing.Size(107, 13);
            this.lbDataVencimento.TabIndex = 7;
            this.lbDataVencimento.Text = "Data de Vencimento:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(80, 149);
            this.txtObservacao.MaxLength = 50;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(307, 20);
            this.txtObservacao.TabIndex = 11;
            this.TextMaskedit.SetTextMasked(this.txtObservacao, ToolMasked.TextMask.Formats.None);
            // 
            // lbValorVencimento
            // 
            this.lbValorVencimento.AutoSize = true;
            this.lbValorVencimento.Location = new System.Drawing.Point(6, 204);
            this.lbValorVencimento.Name = "lbValorVencimento";
            this.lbValorVencimento.Size = new System.Drawing.Size(108, 13);
            this.lbValorVencimento.TabIndex = 7;
            this.lbValorVencimento.Text = "Valor de Vencimento:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(70, 123);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(280, 20);
            this.txtDescricao.TabIndex = 10;
            this.TextMaskedit.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // txtValorPagamento
            // 
            this.txtValorPagamento.Location = new System.Drawing.Point(118, 227);
            this.txtValorPagamento.MaxLength = 15;
            this.txtValorPagamento.Name = "txtValorPagamento";
            this.txtValorPagamento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorPagamento.Size = new System.Drawing.Size(100, 20);
            this.txtValorPagamento.TabIndex = 15;
            this.txtValorPagamento.Text = "0,00";
            this.TextMaskedit.SetTextMasked(this.txtValorPagamento, ToolMasked.TextMask.Formats.Dinheiro);
            // 
            // txtValorVencimento
            // 
            this.txtValorVencimento.Location = new System.Drawing.Point(120, 201);
            this.txtValorVencimento.MaxLength = 15;
            this.txtValorVencimento.Name = "txtValorVencimento";
            this.txtValorVencimento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorVencimento.Size = new System.Drawing.Size(100, 20);
            this.txtValorVencimento.TabIndex = 13;
            this.txtValorVencimento.Text = "0,00";
            this.TextMaskedit.SetTextMasked(this.txtValorVencimento, ToolMasked.TextMask.Formats.Dinheiro);
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Location = new System.Drawing.Point(374, 97);
            this.txtFormaPagamento.MaxLength = 50;
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.ReadOnly = true;
            this.txtFormaPagamento.Size = new System.Drawing.Size(134, 20);
            this.txtFormaPagamento.TabIndex = 8;
            this.TextMaskedit.SetTextMasked(this.txtFormaPagamento, ToolMasked.TextMask.Formats.None);
            this.txtFormaPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormaPagamento_KeyDown);
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.Location = new System.Drawing.Point(86, 97);
            this.txtContaCorrente.MaxLength = 50;
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.ReadOnly = true;
            this.txtContaCorrente.Size = new System.Drawing.Size(134, 20);
            this.txtContaCorrente.TabIndex = 8;
            this.TextMaskedit.SetTextMasked(this.txtContaCorrente, ToolMasked.TextMask.Formats.None);
            this.txtContaCorrente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContaCorrente_KeyDown);
            // 
            // txtPlanoContas
            // 
            this.txtPlanoContas.Location = new System.Drawing.Point(100, 71);
            this.txtPlanoContas.MaxLength = 50;
            this.txtPlanoContas.Name = "txtPlanoContas";
            this.txtPlanoContas.ReadOnly = true;
            this.txtPlanoContas.Size = new System.Drawing.Size(259, 20);
            this.txtPlanoContas.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtPlanoContas, ToolMasked.TextMask.Formats.None);
            this.txtPlanoContas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlanoContas_KeyDown);
            // 
            // txtDataLancamento
            // 
            this.txtDataLancamento.Location = new System.Drawing.Point(410, 19);
            this.txtDataLancamento.Name = "txtDataLancamento";
            this.txtDataLancamento.ReadOnly = true;
            this.txtDataLancamento.Size = new System.Drawing.Size(70, 20);
            this.txtDataLancamento.TabIndex = 3;
            this.TextMaskedit.SetTextMasked(this.txtDataLancamento, ToolMasked.TextMask.Formats.None);
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(218, 19);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(70, 20);
            this.txtDataCadastro.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtDataCadastro, ToolMasked.TextMask.Formats.None);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(76, 45);
            this.txtFornecedor.MaxLength = 50;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(246, 20);
            this.txtFornecedor.TabIndex = 4;
            this.TextMaskedit.SetTextMasked(this.txtFornecedor, ToolMasked.TextMask.Formats.None);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecedor_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(60, 20);
            this.txtCodigo.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // lbDataLancamento
            // 
            this.lbDataLancamento.AutoSize = true;
            this.lbDataLancamento.Location = new System.Drawing.Point(294, 22);
            this.lbDataLancamento.Name = "lbDataLancamento";
            this.lbDataLancamento.Size = new System.Drawing.Size(110, 13);
            this.lbDataLancamento.TabIndex = 7;
            this.lbDataLancamento.Text = "Data de Lançamento:";
            // 
            // lbDataCadastro
            // 
            this.lbDataCadastro.AutoSize = true;
            this.lbDataCadastro.Location = new System.Drawing.Point(119, 22);
            this.lbDataCadastro.Name = "lbDataCadastro";
            this.lbDataCadastro.Size = new System.Drawing.Size(93, 13);
            this.lbDataCadastro.TabIndex = 7;
            this.lbDataCadastro.Text = "Data de Cadastro:";
            // 
            // lbDocumento
            // 
            this.lbDocumento.AutoSize = true;
            this.lbDocumento.Location = new System.Drawing.Point(6, 178);
            this.lbDocumento.Name = "lbDocumento";
            this.lbDocumento.Size = new System.Drawing.Size(65, 13);
            this.lbDocumento.TabIndex = 7;
            this.lbDocumento.Text = "Documento:";
            // 
            // lbObservacao
            // 
            this.lbObservacao.AutoSize = true;
            this.lbObservacao.Location = new System.Drawing.Point(6, 152);
            this.lbObservacao.Name = "lbObservacao";
            this.lbObservacao.Size = new System.Drawing.Size(68, 13);
            this.lbObservacao.TabIndex = 7;
            this.lbObservacao.Text = "Observação:";
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(6, 126);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(58, 13);
            this.lbDescricao.TabIndex = 7;
            this.lbDescricao.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Forma de Pagamento:";
            // 
            // lbContaCorrente
            // 
            this.lbContaCorrente.AutoSize = true;
            this.lbContaCorrente.Location = new System.Drawing.Point(6, 100);
            this.lbContaCorrente.Name = "lbContaCorrente";
            this.lbContaCorrente.Size = new System.Drawing.Size(81, 13);
            this.lbContaCorrente.TabIndex = 7;
            this.lbContaCorrente.Text = "Conta Corrente:";
            // 
            // lbPlanoContas
            // 
            this.lbPlanoContas.AutoSize = true;
            this.lbPlanoContas.Location = new System.Drawing.Point(6, 74);
            this.lbPlanoContas.Name = "lbPlanoContas";
            this.lbPlanoContas.Size = new System.Drawing.Size(88, 13);
            this.lbPlanoContas.TabIndex = 7;
            this.lbPlanoContas.Text = "Plano de Contas:";
            // 
            // lbFornecedor
            // 
            this.lbFornecedor.AutoSize = true;
            this.lbFornecedor.Location = new System.Drawing.Point(6, 48);
            this.lbFornecedor.Name = "lbFornecedor";
            this.lbFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lbFornecedor.TabIndex = 7;
            this.lbFornecedor.Text = "Fornecedor:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(6, 22);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(43, 13);
            this.lbCodigo.TabIndex = 7;
            this.lbCodigo.Text = "Código:";
            // 
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
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
            // ctrlFilial
            // 
            this.ctrlFilial.LabelSelecione = false;
            this.ctrlFilial.Location = new System.Drawing.Point(486, 18);
            this.ctrlFilial.Name = "ctrlFilial";
            this.ctrlFilial.SelectedDefault = true;
            this.ctrlFilial.Size = new System.Drawing.Size(208, 21);
            this.ctrlFilial.TabIndex = 17;
            // 
            // frmFinanceiroContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 339);
            this.Controls.Add(this.gbContasPagar);
            this.Controls.Add(this.lbFormaPagamento);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroContasPagar";
            this.Text = "Duplicar Contas a Pagar";
            this.Load += new System.EventHandler(this.frmFinanceiroContaPagar_Load);
            this.lbFormaPagamento.ResumeLayout(false);
            this.lbFormaPagamento.PerformLayout();
            this.gbContasPagar.ResumeLayout(false);
            this.gbContasPagar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip lbFormaPagamento;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btEditar;
        private System.Windows.Forms.ToolStripButton btExcluir;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbContasPagar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label lbDataLancamento;
        private System.Windows.Forms.Label lbDataCadastro;
        private System.Windows.Forms.TextBox txtDataLancamento;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lbFornecedor;
        private System.Windows.Forms.Button btFornecedor;
        private System.Windows.Forms.Label lbPlanoContas;
        private System.Windows.Forms.TextBox txtPlanoContas;
        private System.Windows.Forms.Button btPlanoContas;
        private System.Windows.Forms.Label lbContaCorrente;
        private System.Windows.Forms.Button btContaCorrente;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbObservacao;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lbValorVencimento;
        private System.Windows.Forms.TextBox txtValorVencimento;
        private System.Windows.Forms.Label lbValorPagamento;
        private System.Windows.Forms.TextBox txtValorPagamento;
        private System.Windows.Forms.Label lbDataVencimento;
        private System.Windows.Forms.Label lbDataPagamento;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.DateTimePicker dtaDataPagamento;
        private System.Windows.Forms.DateTimePicker dtaVencimentoData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFormaPagamento;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btDuplicarConta;
        private System.Windows.Forms.ToolStripButton btLancarConta;
        private System.Windows.Forms.ToolStripButton btEstornarLancamento;
        private System.Windows.Forms.ToolStripButton btLancamento;
        private Util.ctrlFilial ctrlFilial;
    }
}