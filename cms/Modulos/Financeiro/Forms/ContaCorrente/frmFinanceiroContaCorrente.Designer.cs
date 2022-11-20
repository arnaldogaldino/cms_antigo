namespace cms.Modulos.Financeiro.Forms.ContaCorrente
{
    partial class frmFinanceiroContaCorrente
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
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbContaCorrente = new System.Windows.Forms.GroupBox();
            this.ctrlFilial = new cms.Modulos.Util.ctrlFilial();
            this.lblTelefones = new System.Windows.Forms.Label();
            this.lblGerente = new System.Windows.Forms.Label();
            this.cbBanco = new System.Windows.Forms.ComboBox();
            this.txtTelefone4 = new System.Windows.Forms.TextBox();
            this.txtTelefone3 = new System.Windows.Forms.TextBox();
            this.txtTelefone2 = new System.Windows.Forms.TextBox();
            this.txtTelefone1 = new System.Windows.Forms.TextBox();
            this.txtGerente = new System.Windows.Forms.TextBox();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.txtContaDigito = new System.Windows.Forms.TextBox();
            this.txtAgenciaDigito = new System.Windows.Forms.TextBox();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.lblConta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblAgencia = new System.Windows.Forms.Label();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.gbBoleto = new System.Windows.Forms.GroupBox();
            this.rbCnabNenhum = new System.Windows.Forms.RadioButton();
            this.rbCnab240 = new System.Windows.Forms.RadioButton();
            this.rbCnab400 = new System.Windows.Forms.RadioButton();
            this.chkBoleto = new System.Windows.Forms.CheckBox();
            this.lblCarteira = new System.Windows.Forms.Label();
            this.lblCodigoCedente = new System.Windows.Forms.Label();
            this.lblInstrucaoLinha3 = new System.Windows.Forms.Label();
            this.lblInstrucaoLinha2 = new System.Windows.Forms.Label();
            this.lblInstrucaoLinha1 = new System.Windows.Forms.Label();
            this.lblCnab = new System.Windows.Forms.Label();
            this.lblCpfCnpj = new System.Windows.Forms.Label();
            this.lblNomeRazaoSocial = new System.Windows.Forms.Label();
            this.txtNomeRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtCarteira = new System.Windows.Forms.TextBox();
            this.txtCodigoCedente = new System.Windows.Forms.TextBox();
            this.txtInstrucaoLinha3 = new System.Windows.Forms.TextBox();
            this.txtInstrucaoLinha2 = new System.Windows.Forms.TextBox();
            this.txtInstrucaoLinha1 = new System.Windows.Forms.TextBox();
            this.txtCpfCnpj = new System.Windows.Forms.TextBox();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            this.gbContaCorrente.SuspendLayout();
            this.gbBoleto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btEditar,
            this.btExcluir,
            this.btGravar,
            this.btCancelar,
            this.toolStripSeparator1,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(773, 39);
            this.tsMenu.TabIndex = 36;
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
            // gbContaCorrente
            // 
            this.gbContaCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContaCorrente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbContaCorrente.Controls.Add(this.ctrlFilial);
            this.gbContaCorrente.Controls.Add(this.lblTelefones);
            this.gbContaCorrente.Controls.Add(this.lblGerente);
            this.gbContaCorrente.Controls.Add(this.cbBanco);
            this.gbContaCorrente.Controls.Add(this.txtTelefone4);
            this.gbContaCorrente.Controls.Add(this.txtTelefone3);
            this.gbContaCorrente.Controls.Add(this.txtTelefone2);
            this.gbContaCorrente.Controls.Add(this.txtTelefone1);
            this.gbContaCorrente.Controls.Add(this.txtGerente);
            this.gbContaCorrente.Controls.Add(this.txtDataCadastro);
            this.gbContaCorrente.Controls.Add(this.txtContaDigito);
            this.gbContaCorrente.Controls.Add(this.txtAgenciaDigito);
            this.gbContaCorrente.Controls.Add(this.txtConta);
            this.gbContaCorrente.Controls.Add(this.txtAgencia);
            this.gbContaCorrente.Controls.Add(this.lblConta);
            this.gbContaCorrente.Controls.Add(this.label1);
            this.gbContaCorrente.Controls.Add(this.lbl);
            this.gbContaCorrente.Controls.Add(this.lblAgencia);
            this.gbContaCorrente.Controls.Add(this.lblDataCadastro);
            this.gbContaCorrente.Controls.Add(this.lblBanco);
            this.gbContaCorrente.Location = new System.Drawing.Point(12, 42);
            this.gbContaCorrente.Name = "gbContaCorrente";
            this.gbContaCorrente.Size = new System.Drawing.Size(749, 126);
            this.gbContaCorrente.TabIndex = 37;
            this.gbContaCorrente.TabStop = false;
            this.gbContaCorrente.Text = "Conta Corrente";
            // 
            // ctrlFilial
            // 
            this.ctrlFilial.LabelSelecione = false;
            this.ctrlFilial.Location = new System.Drawing.Point(521, 18);
            this.ctrlFilial.Name = "ctrlFilial";
            this.ctrlFilial.SelectedDefault = false;
            this.ctrlFilial.Size = new System.Drawing.Size(211, 21);
            this.ctrlFilial.TabIndex = 12;
            // 
            // lblTelefones
            // 
            this.lblTelefones.AutoSize = true;
            this.lblTelefones.Location = new System.Drawing.Point(6, 101);
            this.lblTelefones.Name = "lblTelefones";
            this.lblTelefones.Size = new System.Drawing.Size(57, 13);
            this.lblTelefones.TabIndex = 7;
            this.lblTelefones.Text = "Telefones:";
            // 
            // lblGerente
            // 
            this.lblGerente.AutoSize = true;
            this.lblGerente.Location = new System.Drawing.Point(6, 75);
            this.lblGerente.Name = "lblGerente";
            this.lblGerente.Size = new System.Drawing.Size(48, 13);
            this.lblGerente.TabIndex = 7;
            this.lblGerente.Text = "Gerente:";
            // 
            // cbBanco
            // 
            this.cbBanco.DisplayMember = "nome";
            this.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBanco.Location = new System.Drawing.Point(53, 19);
            this.cbBanco.Name = "cbBanco";
            this.cbBanco.Size = new System.Drawing.Size(277, 21);
            this.cbBanco.TabIndex = 1;
            this.cbBanco.ValueMember = "id_financeiro_banco";
            this.cbBanco.SelectedValueChanged += new System.EventHandler(this.cbBanco_SelectedValueChanged);
            // 
            // txtTelefone4
            // 
            this.txtTelefone4.Location = new System.Drawing.Point(344, 98);
            this.txtTelefone4.MaxLength = 15;
            this.txtTelefone4.Name = "txtTelefone4";
            this.txtTelefone4.Size = new System.Drawing.Size(86, 20);
            this.txtTelefone4.TabIndex = 11;
            this.TextMaskedit.SetTextMasked(this.txtTelefone4, ToolMasked.TextMask.Formats.Telefone);
            // 
            // txtTelefone3
            // 
            this.txtTelefone3.Location = new System.Drawing.Point(252, 98);
            this.txtTelefone3.MaxLength = 15;
            this.txtTelefone3.Name = "txtTelefone3";
            this.txtTelefone3.Size = new System.Drawing.Size(86, 20);
            this.txtTelefone3.TabIndex = 10;
            this.TextMaskedit.SetTextMasked(this.txtTelefone3, ToolMasked.TextMask.Formats.Telefone);
            // 
            // txtTelefone2
            // 
            this.txtTelefone2.Location = new System.Drawing.Point(160, 98);
            this.txtTelefone2.MaxLength = 15;
            this.txtTelefone2.Name = "txtTelefone2";
            this.txtTelefone2.Size = new System.Drawing.Size(86, 20);
            this.txtTelefone2.TabIndex = 9;
            this.TextMaskedit.SetTextMasked(this.txtTelefone2, ToolMasked.TextMask.Formats.Telefone);
            // 
            // txtTelefone1
            // 
            this.txtTelefone1.Location = new System.Drawing.Point(69, 98);
            this.txtTelefone1.MaxLength = 15;
            this.txtTelefone1.Name = "txtTelefone1";
            this.txtTelefone1.Size = new System.Drawing.Size(86, 20);
            this.txtTelefone1.TabIndex = 8;
            this.TextMaskedit.SetTextMasked(this.txtTelefone1, ToolMasked.TextMask.Formats.Telefone);
            // 
            // txtGerente
            // 
            this.txtGerente.Location = new System.Drawing.Point(60, 72);
            this.txtGerente.MaxLength = 30;
            this.txtGerente.Name = "txtGerente";
            this.txtGerente.Size = new System.Drawing.Size(247, 20);
            this.txtGerente.TabIndex = 7;
            this.TextMaskedit.SetTextMasked(this.txtGerente, ToolMasked.TextMask.Formats.None);
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(420, 19);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(94, 20);
            this.txtDataCadastro.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtDataCadastro, ToolMasked.TextMask.Formats.None);
            // 
            // txtContaDigito
            // 
            this.txtContaDigito.Location = new System.Drawing.Point(313, 46);
            this.txtContaDigito.MaxLength = 2;
            this.txtContaDigito.Name = "txtContaDigito";
            this.txtContaDigito.Size = new System.Drawing.Size(26, 20);
            this.txtContaDigito.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtContaDigito, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtAgenciaDigito
            // 
            this.txtAgenciaDigito.Location = new System.Drawing.Point(149, 46);
            this.txtAgenciaDigito.MaxLength = 2;
            this.txtAgenciaDigito.Name = "txtAgenciaDigito";
            this.txtAgenciaDigito.Size = new System.Drawing.Size(26, 20);
            this.txtAgenciaDigito.TabIndex = 4;
            this.TextMaskedit.SetTextMasked(this.txtAgenciaDigito, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtConta
            // 
            this.txtConta.Location = new System.Drawing.Point(225, 46);
            this.txtConta.MaxLength = 10;
            this.txtConta.Name = "txtConta";
            this.txtConta.Size = new System.Drawing.Size(66, 20);
            this.txtConta.TabIndex = 5;
            this.TextMaskedit.SetTextMasked(this.txtConta, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(61, 46);
            this.txtAgencia.MaxLength = 10;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(66, 20);
            this.txtAgencia.TabIndex = 3;
            this.TextMaskedit.SetTextMasked(this.txtAgencia, ToolMasked.TextMask.Formats.Numero);
            // 
            // lblConta
            // 
            this.lblConta.AutoSize = true;
            this.lblConta.Location = new System.Drawing.Point(181, 49);
            this.lblConta.Name = "lblConta";
            this.lblConta.Size = new System.Drawing.Size(38, 13);
            this.lblConta.TabIndex = 5;
            this.lblConta.Text = "Conta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "-";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(133, 49);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(10, 13);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "-";
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.Location = new System.Drawing.Point(6, 49);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(49, 13);
            this.lblAgencia.TabIndex = 5;
            this.lblAgencia.Text = "Agência:";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Location = new System.Drawing.Point(336, 22);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(78, 13);
            this.lblDataCadastro.TabIndex = 2;
            this.lblDataCadastro.Text = "Data Cadastro:";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(6, 22);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 2;
            this.lblBanco.Text = "Banco:";
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
            // gbBoleto
            // 
            this.gbBoleto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBoleto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbBoleto.Controls.Add(this.rbCnabNenhum);
            this.gbBoleto.Controls.Add(this.rbCnab240);
            this.gbBoleto.Controls.Add(this.rbCnab400);
            this.gbBoleto.Controls.Add(this.chkBoleto);
            this.gbBoleto.Controls.Add(this.lblCarteira);
            this.gbBoleto.Controls.Add(this.lblCodigoCedente);
            this.gbBoleto.Controls.Add(this.lblInstrucaoLinha3);
            this.gbBoleto.Controls.Add(this.lblInstrucaoLinha2);
            this.gbBoleto.Controls.Add(this.lblInstrucaoLinha1);
            this.gbBoleto.Controls.Add(this.lblCnab);
            this.gbBoleto.Controls.Add(this.lblCpfCnpj);
            this.gbBoleto.Controls.Add(this.lblNomeRazaoSocial);
            this.gbBoleto.Controls.Add(this.txtNomeRazaoSocial);
            this.gbBoleto.Controls.Add(this.txtCarteira);
            this.gbBoleto.Controls.Add(this.txtCodigoCedente);
            this.gbBoleto.Controls.Add(this.txtInstrucaoLinha3);
            this.gbBoleto.Controls.Add(this.txtInstrucaoLinha2);
            this.gbBoleto.Controls.Add(this.txtInstrucaoLinha1);
            this.gbBoleto.Controls.Add(this.txtCpfCnpj);
            this.gbBoleto.Location = new System.Drawing.Point(12, 174);
            this.gbBoleto.Name = "gbBoleto";
            this.gbBoleto.Size = new System.Drawing.Size(749, 194);
            this.gbBoleto.TabIndex = 38;
            this.gbBoleto.TabStop = false;
            this.gbBoleto.Text = "Boleto";
            // 
            // rbCnabNenhum
            // 
            this.rbCnabNenhum.AutoSize = true;
            this.rbCnabNenhum.Location = new System.Drawing.Point(149, 88);
            this.rbCnabNenhum.Name = "rbCnabNenhum";
            this.rbCnabNenhum.Size = new System.Drawing.Size(65, 17);
            this.rbCnabNenhum.TabIndex = 19;
            this.rbCnabNenhum.TabStop = true;
            this.rbCnabNenhum.Text = "Nenhum";
            this.rbCnabNenhum.UseVisualStyleBackColor = true;
            // 
            // rbCnab240
            // 
            this.rbCnab240.AutoSize = true;
            this.rbCnab240.Location = new System.Drawing.Point(100, 88);
            this.rbCnab240.Name = "rbCnab240";
            this.rbCnab240.Size = new System.Drawing.Size(43, 17);
            this.rbCnab240.TabIndex = 18;
            this.rbCnab240.TabStop = true;
            this.rbCnab240.Text = "240";
            this.rbCnab240.UseVisualStyleBackColor = true;
            // 
            // rbCnab400
            // 
            this.rbCnab400.AutoSize = true;
            this.rbCnab400.Location = new System.Drawing.Point(51, 88);
            this.rbCnab400.Name = "rbCnab400";
            this.rbCnab400.Size = new System.Drawing.Size(43, 17);
            this.rbCnab400.TabIndex = 17;
            this.rbCnab400.TabStop = true;
            this.rbCnab400.Text = "400";
            this.rbCnab400.UseVisualStyleBackColor = true;
            // 
            // chkBoleto
            // 
            this.chkBoleto.AutoSize = true;
            this.chkBoleto.Location = new System.Drawing.Point(6, 19);
            this.chkBoleto.Name = "chkBoleto";
            this.chkBoleto.Size = new System.Drawing.Size(56, 17);
            this.chkBoleto.TabIndex = 12;
            this.chkBoleto.Text = "Boleto";
            this.chkBoleto.UseVisualStyleBackColor = true;
            this.chkBoleto.CheckedChanged += new System.EventHandler(this.chkBoleto_CheckedChanged);
            // 
            // lblCarteira
            // 
            this.lblCarteira.AutoSize = true;
            this.lblCarteira.Location = new System.Drawing.Point(372, 65);
            this.lblCarteira.Name = "lblCarteira";
            this.lblCarteira.Size = new System.Drawing.Size(46, 13);
            this.lblCarteira.TabIndex = 7;
            this.lblCarteira.Text = "Carteira:";
            // 
            // lblCodigoCedente
            // 
            this.lblCodigoCedente.AutoSize = true;
            this.lblCodigoCedente.Location = new System.Drawing.Point(220, 65);
            this.lblCodigoCedente.Name = "lblCodigoCedente";
            this.lblCodigoCedente.Size = new System.Drawing.Size(86, 13);
            this.lblCodigoCedente.TabIndex = 7;
            this.lblCodigoCedente.Text = "Código Cedente:";
            // 
            // lblInstrucaoLinha3
            // 
            this.lblInstrucaoLinha3.AutoSize = true;
            this.lblInstrucaoLinha3.Location = new System.Drawing.Point(6, 166);
            this.lblInstrucaoLinha3.Name = "lblInstrucaoLinha3";
            this.lblInstrucaoLinha3.Size = new System.Drawing.Size(92, 13);
            this.lblInstrucaoLinha3.TabIndex = 7;
            this.lblInstrucaoLinha3.Text = "Instrução Linha 3:";
            // 
            // lblInstrucaoLinha2
            // 
            this.lblInstrucaoLinha2.AutoSize = true;
            this.lblInstrucaoLinha2.Location = new System.Drawing.Point(6, 140);
            this.lblInstrucaoLinha2.Name = "lblInstrucaoLinha2";
            this.lblInstrucaoLinha2.Size = new System.Drawing.Size(92, 13);
            this.lblInstrucaoLinha2.TabIndex = 7;
            this.lblInstrucaoLinha2.Text = "Instrução Linha 2:";
            // 
            // lblInstrucaoLinha1
            // 
            this.lblInstrucaoLinha1.AutoSize = true;
            this.lblInstrucaoLinha1.Location = new System.Drawing.Point(6, 114);
            this.lblInstrucaoLinha1.Name = "lblInstrucaoLinha1";
            this.lblInstrucaoLinha1.Size = new System.Drawing.Size(92, 13);
            this.lblInstrucaoLinha1.TabIndex = 7;
            this.lblInstrucaoLinha1.Text = "Instrução Linha 1:";
            // 
            // lblCnab
            // 
            this.lblCnab.AutoSize = true;
            this.lblCnab.Location = new System.Drawing.Point(6, 90);
            this.lblCnab.Name = "lblCnab";
            this.lblCnab.Size = new System.Drawing.Size(39, 13);
            this.lblCnab.TabIndex = 7;
            this.lblCnab.Text = "CNAB:";
            // 
            // lblCpfCnpj
            // 
            this.lblCpfCnpj.AutoSize = true;
            this.lblCpfCnpj.Location = new System.Drawing.Point(6, 65);
            this.lblCpfCnpj.Name = "lblCpfCnpj";
            this.lblCpfCnpj.Size = new System.Drawing.Size(37, 13);
            this.lblCpfCnpj.TabIndex = 7;
            this.lblCpfCnpj.Text = "CNPJ:";
            // 
            // lblNomeRazaoSocial
            // 
            this.lblNomeRazaoSocial.AutoSize = true;
            this.lblNomeRazaoSocial.Location = new System.Drawing.Point(6, 39);
            this.lblNomeRazaoSocial.Name = "lblNomeRazaoSocial";
            this.lblNomeRazaoSocial.Size = new System.Drawing.Size(73, 13);
            this.lblNomeRazaoSocial.TabIndex = 5;
            this.lblNomeRazaoSocial.Text = "Razão Social:";
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.Location = new System.Drawing.Point(85, 36);
            this.txtNomeRazaoSocial.MaxLength = 50;
            this.txtNomeRazaoSocial.Name = "txtNomeRazaoSocial";
            this.txtNomeRazaoSocial.Size = new System.Drawing.Size(274, 20);
            this.txtNomeRazaoSocial.TabIndex = 13;
            this.TextMaskedit.SetTextMasked(this.txtNomeRazaoSocial, ToolMasked.TextMask.Formats.None);
            // 
            // txtCarteira
            // 
            this.txtCarteira.Location = new System.Drawing.Point(424, 62);
            this.txtCarteira.MaxLength = 3;
            this.txtCarteira.Name = "txtCarteira";
            this.txtCarteira.Size = new System.Drawing.Size(54, 20);
            this.txtCarteira.TabIndex = 3;
            this.TextMaskedit.SetTextMasked(this.txtCarteira, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtCodigoCedente
            // 
            this.txtCodigoCedente.Location = new System.Drawing.Point(312, 62);
            this.txtCodigoCedente.MaxLength = 50;
            this.txtCodigoCedente.Name = "txtCodigoCedente";
            this.txtCodigoCedente.Size = new System.Drawing.Size(54, 20);
            this.txtCodigoCedente.TabIndex = 3;
            this.TextMaskedit.SetTextMasked(this.txtCodigoCedente, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtInstrucaoLinha3
            // 
            this.txtInstrucaoLinha3.Location = new System.Drawing.Point(104, 163);
            this.txtInstrucaoLinha3.MaxLength = 60;
            this.txtInstrucaoLinha3.Name = "txtInstrucaoLinha3";
            this.txtInstrucaoLinha3.Size = new System.Drawing.Size(346, 20);
            this.txtInstrucaoLinha3.TabIndex = 22;
            this.TextMaskedit.SetTextMasked(this.txtInstrucaoLinha3, ToolMasked.TextMask.Formats.None);
            // 
            // txtInstrucaoLinha2
            // 
            this.txtInstrucaoLinha2.Location = new System.Drawing.Point(104, 137);
            this.txtInstrucaoLinha2.MaxLength = 60;
            this.txtInstrucaoLinha2.Name = "txtInstrucaoLinha2";
            this.txtInstrucaoLinha2.Size = new System.Drawing.Size(346, 20);
            this.txtInstrucaoLinha2.TabIndex = 21;
            this.TextMaskedit.SetTextMasked(this.txtInstrucaoLinha2, ToolMasked.TextMask.Formats.None);
            // 
            // txtInstrucaoLinha1
            // 
            this.txtInstrucaoLinha1.Location = new System.Drawing.Point(104, 111);
            this.txtInstrucaoLinha1.MaxLength = 60;
            this.txtInstrucaoLinha1.Name = "txtInstrucaoLinha1";
            this.txtInstrucaoLinha1.Size = new System.Drawing.Size(346, 20);
            this.txtInstrucaoLinha1.TabIndex = 20;
            this.TextMaskedit.SetTextMasked(this.txtInstrucaoLinha1, ToolMasked.TextMask.Formats.None);
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.Location = new System.Drawing.Point(48, 62);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(166, 20);
            this.txtCpfCnpj.TabIndex = 14;
            this.TextMaskedit.SetTextMasked(this.txtCpfCnpj, ToolMasked.TextMask.Formats.Cnpj);
            // 
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // frmFinanceiroContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 396);
            this.Controls.Add(this.gbBoleto);
            this.Controls.Add(this.gbContaCorrente);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroContaCorrente";
            this.Text = "Conta Corrente";
            this.Load += new System.EventHandler(this.frmFinanceiroContaCorrente_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbContaCorrente.ResumeLayout(false);
            this.gbContaCorrente.PerformLayout();
            this.gbBoleto.ResumeLayout(false);
            this.gbBoleto.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbContaCorrente;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.Label lblAgencia;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.ComboBox cbBanco;
        private System.Windows.Forms.Label lblGerente;
        private System.Windows.Forms.TextBox txtGerente;
        private System.Windows.Forms.Label lblDataCadastro;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.TextBox txtContaDigito;
        private System.Windows.Forms.TextBox txtAgenciaDigito;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Label lblConta;
        private System.Windows.Forms.Label lblTelefones;
        private System.Windows.Forms.TextBox txtTelefone3;
        private System.Windows.Forms.TextBox txtTelefone2;
        private System.Windows.Forms.TextBox txtTelefone1;
        private System.Windows.Forms.TextBox txtTelefone4;
        private System.Windows.Forms.GroupBox gbBoleto;
        private System.Windows.Forms.Label lblCpfCnpj;
        private System.Windows.Forms.Label lblNomeRazaoSocial;
        private System.Windows.Forms.CheckBox chkBoleto;
        private System.Windows.Forms.TextBox txtNomeRazaoSocial;
        private System.Windows.Forms.TextBox txtCpfCnpj;
        private System.Windows.Forms.Label lblCodigoCedente;
        private System.Windows.Forms.Label lblCarteira;
        private System.Windows.Forms.TextBox txtCarteira;
        private System.Windows.Forms.TextBox txtCodigoCedente;
        private System.Windows.Forms.RadioButton rbCnab400;
        private System.Windows.Forms.Label lblCnab;
        private System.Windows.Forms.RadioButton rbCnab240;
        private System.Windows.Forms.RadioButton rbCnabNenhum;
        private System.Windows.Forms.Label lblInstrucaoLinha3;
        private System.Windows.Forms.Label lblInstrucaoLinha2;
        private System.Windows.Forms.Label lblInstrucaoLinha1;
        private System.Windows.Forms.TextBox txtInstrucaoLinha3;
        private System.Windows.Forms.TextBox txtInstrucaoLinha2;
        private System.Windows.Forms.TextBox txtInstrucaoLinha1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl;
        private ToolMasked.TextMask TextMaskedit;
        private Util.ctrlFilial ctrlFilial;

    }
}