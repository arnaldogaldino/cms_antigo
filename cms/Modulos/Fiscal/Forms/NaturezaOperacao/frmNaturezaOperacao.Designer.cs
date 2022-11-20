namespace cms.Modulos.Fiscal.Forms.NaturezaOperacao
{
    partial class frmNaturezaOperacao
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
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCFOPnoEstado = new System.Windows.Forms.TextBox();
            this.txtCFOPforaEstado = new System.Windows.Forms.TextBox();
            this.txtCFOPcomCST = new System.Windows.Forms.TextBox();
            this.txtCFOPcomCSTforaEstado = new System.Windows.Forms.TextBox();
            this.txtCFOPAux1 = new System.Windows.Forms.TextBox();
            this.txtCFOPAux2 = new System.Windows.Forms.TextBox();
            this.txtCodigoNaturezaOperacao = new System.Windows.Forms.TextBox();
            this.txtCentroCustos = new System.Windows.Forms.TextBox();
            this.txtDistDespesa = new System.Windows.Forms.TextBox();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.gbNaturezaOperacao = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btCFOPAux2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btCFOPAux1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btCFOPcomCSTforaEstado = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btCFOPcomCST = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btCFOPforaEstado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btCFOPnoEstado = new System.Windows.Forms.Button();
            this.lbFornecedor = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rbSaida = new System.Windows.Forms.RadioButton();
            this.rbEntrada = new System.Windows.Forms.RadioButton();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.bgAcoes = new System.Windows.Forms.GroupBox();
            this.chkCalculaCusto = new System.Windows.Forms.CheckBox();
            this.chkMovimentaEstoque = new System.Windows.Forms.CheckBox();
            this.chkDevolucao = new System.Windows.Forms.CheckBox();
            this.chkGerenciaComissao = new System.Windows.Forms.CheckBox();
            this.chkVenda = new System.Windows.Forms.CheckBox();
            this.chkAtualizaValoresCompra = new System.Windows.Forms.CheckBox();
            this.chkTabelaCompra = new System.Windows.Forms.CheckBox();
            this.chkGeraTitulo = new System.Windows.Forms.CheckBox();
            this.bgOutros = new System.Windows.Forms.GroupBox();
            this.btDistDespesa = new System.Windows.Forms.Button();
            this.btCentroCustos = new System.Windows.Forms.Button();
            this.btCodigoNaturezaOperacao = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCFOPcomIEIsento = new System.Windows.Forms.TextBox();
            this.btCFOPcomIEIsento = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCFOPcomIEISENTOforaEstado = new System.Windows.Forms.TextBox();
            this.btCFOPcomIEISENTOforaEstado = new System.Windows.Forms.Button();
            this.tsMenu.SuspendLayout();
            this.gbNaturezaOperacao.SuspendLayout();
            this.bgAcoes.SuspendLayout();
            this.bgOutros.SuspendLayout();
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
            this.tsMenu.Size = new System.Drawing.Size(1000, 39);
            this.tsMenu.TabIndex = 34;
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
            this.btNovo.Text = "Nova Natureza da Operação";
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
            this.btEditar.Text = "Editar Natureza da Operação";
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
            this.btExcluir.Text = "Excluir Natureza da Operação";
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
            this.btGravar.Text = "Gravar Natureza da Operação";
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
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(382, 19);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(326, 20);
            this.txtDescricao.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(92, 20);
            this.txtCodigo.TabIndex = 0;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // txtCFOPnoEstado
            // 
            this.txtCFOPnoEstado.Location = new System.Drawing.Point(100, 45);
            this.txtCFOPnoEstado.MaxLength = 50;
            this.txtCFOPnoEstado.Name = "txtCFOPnoEstado";
            this.txtCFOPnoEstado.ReadOnly = true;
            this.txtCFOPnoEstado.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPnoEstado.TabIndex = 5;
            this.TextMaskedit.SetTextMasked(this.txtCFOPnoEstado, ToolMasked.TextMask.Formats.None);
            this.txtCFOPnoEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPnoEstado_KeyDown);
            // 
            // txtCFOPforaEstado
            // 
            this.txtCFOPforaEstado.Location = new System.Drawing.Point(545, 45);
            this.txtCFOPforaEstado.MaxLength = 50;
            this.txtCFOPforaEstado.Name = "txtCFOPforaEstado";
            this.txtCFOPforaEstado.ReadOnly = true;
            this.txtCFOPforaEstado.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPforaEstado.TabIndex = 7;
            this.TextMaskedit.SetTextMasked(this.txtCFOPforaEstado, ToolMasked.TextMask.Formats.None);
            this.txtCFOPforaEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPforaEstado_KeyDown);
            // 
            // txtCFOPcomCST
            // 
            this.txtCFOPcomCST.Location = new System.Drawing.Point(97, 71);
            this.txtCFOPcomCST.MaxLength = 50;
            this.txtCFOPcomCST.Name = "txtCFOPcomCST";
            this.txtCFOPcomCST.ReadOnly = true;
            this.txtCFOPcomCST.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPcomCST.TabIndex = 9;
            this.TextMaskedit.SetTextMasked(this.txtCFOPcomCST, ToolMasked.TextMask.Formats.None);
            this.txtCFOPcomCST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPcomCST_KeyDown);
            // 
            // txtCFOPcomCSTforaEstado
            // 
            this.txtCFOPcomCSTforaEstado.Location = new System.Drawing.Point(580, 71);
            this.txtCFOPcomCSTforaEstado.MaxLength = 50;
            this.txtCFOPcomCSTforaEstado.Name = "txtCFOPcomCSTforaEstado";
            this.txtCFOPcomCSTforaEstado.ReadOnly = true;
            this.txtCFOPcomCSTforaEstado.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPcomCSTforaEstado.TabIndex = 11;
            this.TextMaskedit.SetTextMasked(this.txtCFOPcomCSTforaEstado, ToolMasked.TextMask.Formats.None);
            this.txtCFOPcomCSTforaEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPcomCSTforaEstado_KeyDown);
            // 
            // txtCFOPAux1
            // 
            this.txtCFOPAux1.Location = new System.Drawing.Point(80, 124);
            this.txtCFOPAux1.MaxLength = 50;
            this.txtCFOPAux1.Name = "txtCFOPAux1";
            this.txtCFOPAux1.ReadOnly = true;
            this.txtCFOPAux1.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPAux1.TabIndex = 13;
            this.TextMaskedit.SetTextMasked(this.txtCFOPAux1, ToolMasked.TextMask.Formats.None);
            this.txtCFOPAux1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPAux1_KeyDown);
            // 
            // txtCFOPAux2
            // 
            this.txtCFOPAux2.Location = new System.Drawing.Point(484, 124);
            this.txtCFOPAux2.MaxLength = 50;
            this.txtCFOPAux2.Name = "txtCFOPAux2";
            this.txtCFOPAux2.ReadOnly = true;
            this.txtCFOPAux2.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPAux2.TabIndex = 15;
            this.TextMaskedit.SetTextMasked(this.txtCFOPAux2, ToolMasked.TextMask.Formats.None);
            this.txtCFOPAux2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPAux2_KeyDown);
            // 
            // txtCodigoNaturezaOperacao
            // 
            this.txtCodigoNaturezaOperacao.Location = new System.Drawing.Point(166, 14);
            this.txtCodigoNaturezaOperacao.MaxLength = 50;
            this.txtCodigoNaturezaOperacao.Name = "txtCodigoNaturezaOperacao";
            this.txtCodigoNaturezaOperacao.ReadOnly = true;
            this.txtCodigoNaturezaOperacao.Size = new System.Drawing.Size(296, 20);
            this.txtCodigoNaturezaOperacao.TabIndex = 25;
            this.TextMaskedit.SetTextMasked(this.txtCodigoNaturezaOperacao, ToolMasked.TextMask.Formats.None);
            // 
            // txtCentroCustos
            // 
            this.txtCentroCustos.Location = new System.Drawing.Point(88, 40);
            this.txtCentroCustos.MaxLength = 50;
            this.txtCentroCustos.Name = "txtCentroCustos";
            this.txtCentroCustos.ReadOnly = true;
            this.txtCentroCustos.Size = new System.Drawing.Size(296, 20);
            this.txtCentroCustos.TabIndex = 27;
            this.TextMaskedit.SetTextMasked(this.txtCentroCustos, ToolMasked.TextMask.Formats.None);
            // 
            // txtDistDespesa
            // 
            this.txtDistDespesa.Location = new System.Drawing.Point(88, 66);
            this.txtDistDespesa.MaxLength = 50;
            this.txtDistDespesa.Name = "txtDistDespesa";
            this.txtDistDespesa.ReadOnly = true;
            this.txtDistDespesa.Size = new System.Drawing.Size(296, 20);
            this.txtDistDespesa.TabIndex = 29;
            this.TextMaskedit.SetTextMasked(this.txtDistDespesa, ToolMasked.TextMask.Formats.None);
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(237, 19);
            this.txtDataCadastro.MaxLength = 4;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(75, 20);
            this.txtDataCadastro.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtDataCadastro, ToolMasked.TextMask.Formats.None);
            // 
            // ValidarForm
            // 
            this.ValidarForm.AutomaticDelay = 50;
            this.ValidarForm.AutoPopDelay = 500;
            this.ValidarForm.InitialDelay = 50;
            this.ValidarForm.IsBalloon = true;
            this.ValidarForm.OwnerDraw = true;
            this.ValidarForm.ReshowDelay = 5;
            this.ValidarForm.ShowAlways = true;
            this.ValidarForm.StripAmpersands = true;
            this.ValidarForm.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.ValidarForm.ToolTipTitle = "Campo Inválido.";
            // 
            // gbNaturezaOperacao
            // 
            this.gbNaturezaOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNaturezaOperacao.Controls.Add(this.label6);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPcomIEISENTOforaEstado);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPAux2);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPcomIEISENTOforaEstado);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPAux2);
            this.gbNaturezaOperacao.Controls.Add(this.label8);
            this.gbNaturezaOperacao.Controls.Add(this.label5);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPcomIEIsento);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPAux1);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPcomIEIsento);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPAux1);
            this.gbNaturezaOperacao.Controls.Add(this.label7);
            this.gbNaturezaOperacao.Controls.Add(this.label4);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPcomCSTforaEstado);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPcomCSTforaEstado);
            this.gbNaturezaOperacao.Controls.Add(this.label3);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPcomCST);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPcomCST);
            this.gbNaturezaOperacao.Controls.Add(this.label2);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPforaEstado);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPforaEstado);
            this.gbNaturezaOperacao.Controls.Add(this.label1);
            this.gbNaturezaOperacao.Controls.Add(this.btCFOPnoEstado);
            this.gbNaturezaOperacao.Controls.Add(this.txtCFOPnoEstado);
            this.gbNaturezaOperacao.Controls.Add(this.lbFornecedor);
            this.gbNaturezaOperacao.Controls.Add(this.txtDescricao);
            this.gbNaturezaOperacao.Controls.Add(this.lblDescricao);
            this.gbNaturezaOperacao.Controls.Add(this.lblTipo);
            this.gbNaturezaOperacao.Controls.Add(this.rbSaida);
            this.gbNaturezaOperacao.Controls.Add(this.rbEntrada);
            this.gbNaturezaOperacao.Controls.Add(this.txtDataCadastro);
            this.gbNaturezaOperacao.Controls.Add(this.txtCodigo);
            this.gbNaturezaOperacao.Controls.Add(this.lblCodigo);
            this.gbNaturezaOperacao.Location = new System.Drawing.Point(12, 42);
            this.gbNaturezaOperacao.Name = "gbNaturezaOperacao";
            this.gbNaturezaOperacao.Size = new System.Drawing.Size(976, 157);
            this.gbNaturezaOperacao.TabIndex = 35;
            this.gbNaturezaOperacao.TabStop = false;
            this.gbNaturezaOperacao.Text = "Natureza da Operação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Data Cadastro:";
            // 
            // btCFOPAux2
            // 
            this.btCFOPAux2.FlatAppearance.BorderSize = 0;
            this.btCFOPAux2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPAux2.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPAux2.Location = new System.Drawing.Point(786, 122);
            this.btCFOPAux2.Name = "btCFOPAux2";
            this.btCFOPAux2.Size = new System.Drawing.Size(22, 22);
            this.btCFOPAux2.TabIndex = 16;
            this.btCFOPAux2.UseVisualStyleBackColor = true;
            this.btCFOPAux2.Click += new System.EventHandler(this.btCFOPAux2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "CFOP Aux 2:";
            // 
            // btCFOPAux1
            // 
            this.btCFOPAux1.FlatAppearance.BorderSize = 0;
            this.btCFOPAux1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPAux1.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPAux1.Location = new System.Drawing.Point(382, 122);
            this.btCFOPAux1.Name = "btCFOPAux1";
            this.btCFOPAux1.Size = new System.Drawing.Size(22, 22);
            this.btCFOPAux1.TabIndex = 14;
            this.btCFOPAux1.UseVisualStyleBackColor = true;
            this.btCFOPAux1.Click += new System.EventHandler(this.btCFOPAux1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "CFOP Aux 1:";
            // 
            // btCFOPcomCSTforaEstado
            // 
            this.btCFOPcomCSTforaEstado.FlatAppearance.BorderSize = 0;
            this.btCFOPcomCSTforaEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPcomCSTforaEstado.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPcomCSTforaEstado.Location = new System.Drawing.Point(882, 69);
            this.btCFOPcomCSTforaEstado.Name = "btCFOPcomCSTforaEstado";
            this.btCFOPcomCSTforaEstado.Size = new System.Drawing.Size(22, 22);
            this.btCFOPcomCSTforaEstado.TabIndex = 12;
            this.btCFOPcomCSTforaEstado.UseVisualStyleBackColor = true;
            this.btCFOPcomCSTforaEstado.Click += new System.EventHandler(this.btCFOPcomCSTforaEstado_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "CFOP c/ CST fora do estado:";
            // 
            // btCFOPcomCST
            // 
            this.btCFOPcomCST.FlatAppearance.BorderSize = 0;
            this.btCFOPcomCST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPcomCST.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPcomCST.Location = new System.Drawing.Point(399, 69);
            this.btCFOPcomCST.Name = "btCFOPcomCST";
            this.btCFOPcomCST.Size = new System.Drawing.Size(22, 22);
            this.btCFOPcomCST.TabIndex = 10;
            this.btCFOPcomCST.UseVisualStyleBackColor = true;
            this.btCFOPcomCST.Click += new System.EventHandler(this.btCFOPcomCST_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "CFOP com CST:";
            // 
            // btCFOPforaEstado
            // 
            this.btCFOPforaEstado.FlatAppearance.BorderSize = 0;
            this.btCFOPforaEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPforaEstado.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPforaEstado.Location = new System.Drawing.Point(847, 43);
            this.btCFOPforaEstado.Name = "btCFOPforaEstado";
            this.btCFOPforaEstado.Size = new System.Drawing.Size(22, 22);
            this.btCFOPforaEstado.TabIndex = 8;
            this.btCFOPforaEstado.UseVisualStyleBackColor = true;
            this.btCFOPforaEstado.Click += new System.EventHandler(this.btCFOPforaEstado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "CFOP fora do estado:";
            // 
            // btCFOPnoEstado
            // 
            this.btCFOPnoEstado.FlatAppearance.BorderSize = 0;
            this.btCFOPnoEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPnoEstado.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPnoEstado.Location = new System.Drawing.Point(402, 43);
            this.btCFOPnoEstado.Name = "btCFOPnoEstado";
            this.btCFOPnoEstado.Size = new System.Drawing.Size(22, 22);
            this.btCFOPnoEstado.TabIndex = 6;
            this.btCFOPnoEstado.UseVisualStyleBackColor = true;
            this.btCFOPnoEstado.Click += new System.EventHandler(this.btCFOPnoEstado_Click);
            // 
            // lbFornecedor
            // 
            this.lbFornecedor.AutoSize = true;
            this.lbFornecedor.Location = new System.Drawing.Point(6, 48);
            this.lbFornecedor.Name = "lbFornecedor";
            this.lbFornecedor.Size = new System.Drawing.Size(88, 13);
            this.lbFornecedor.TabIndex = 17;
            this.lbFornecedor.Text = "CFOP no estado:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(318, 22);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 13;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(714, 22);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 10;
            this.lblTipo.Text = "Tipo:";
            // 
            // rbSaida
            // 
            this.rbSaida.AutoSize = true;
            this.rbSaida.Location = new System.Drawing.Point(819, 20);
            this.rbSaida.Name = "rbSaida";
            this.rbSaida.Size = new System.Drawing.Size(52, 17);
            this.rbSaida.TabIndex = 4;
            this.rbSaida.TabStop = true;
            this.rbSaida.Text = "Saida";
            this.rbSaida.UseVisualStyleBackColor = true;
            // 
            // rbEntrada
            // 
            this.rbEntrada.AutoSize = true;
            this.rbEntrada.Checked = true;
            this.rbEntrada.Location = new System.Drawing.Point(751, 20);
            this.rbEntrada.Name = "rbEntrada";
            this.rbEntrada.Size = new System.Drawing.Size(62, 17);
            this.rbEntrada.TabIndex = 3;
            this.rbEntrada.TabStop = true;
            this.rbEntrada.Text = "Entrada";
            this.rbEntrada.UseVisualStyleBackColor = true;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 22);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código:";
            // 
            // bgAcoes
            // 
            this.bgAcoes.Controls.Add(this.chkCalculaCusto);
            this.bgAcoes.Controls.Add(this.chkMovimentaEstoque);
            this.bgAcoes.Controls.Add(this.chkDevolucao);
            this.bgAcoes.Controls.Add(this.chkGerenciaComissao);
            this.bgAcoes.Controls.Add(this.chkVenda);
            this.bgAcoes.Controls.Add(this.chkAtualizaValoresCompra);
            this.bgAcoes.Controls.Add(this.chkTabelaCompra);
            this.bgAcoes.Controls.Add(this.chkGeraTitulo);
            this.bgAcoes.Location = new System.Drawing.Point(12, 205);
            this.bgAcoes.Name = "bgAcoes";
            this.bgAcoes.Size = new System.Drawing.Size(328, 116);
            this.bgAcoes.TabIndex = 36;
            this.bgAcoes.TabStop = false;
            this.bgAcoes.Text = "Ações";
            // 
            // chkCalculaCusto
            // 
            this.chkCalculaCusto.AutoSize = true;
            this.chkCalculaCusto.Location = new System.Drawing.Point(167, 65);
            this.chkCalculaCusto.Name = "chkCalculaCusto";
            this.chkCalculaCusto.Size = new System.Drawing.Size(126, 17);
            this.chkCalculaCusto.TabIndex = 23;
            this.chkCalculaCusto.Text = "Calcular Custo Médio";
            this.chkCalculaCusto.UseVisualStyleBackColor = true;
            // 
            // chkMovimentaEstoque
            // 
            this.chkMovimentaEstoque.AutoSize = true;
            this.chkMovimentaEstoque.Location = new System.Drawing.Point(6, 42);
            this.chkMovimentaEstoque.Name = "chkMovimentaEstoque";
            this.chkMovimentaEstoque.Size = new System.Drawing.Size(120, 17);
            this.chkMovimentaEstoque.TabIndex = 18;
            this.chkMovimentaEstoque.Text = "Movimenta Estoque";
            this.chkMovimentaEstoque.UseVisualStyleBackColor = true;
            // 
            // chkDevolucao
            // 
            this.chkDevolucao.AutoSize = true;
            this.chkDevolucao.Location = new System.Drawing.Point(167, 42);
            this.chkDevolucao.Name = "chkDevolucao";
            this.chkDevolucao.Size = new System.Drawing.Size(78, 17);
            this.chkDevolucao.TabIndex = 22;
            this.chkDevolucao.Text = "Devolução";
            this.chkDevolucao.UseVisualStyleBackColor = true;
            // 
            // chkGerenciaComissao
            // 
            this.chkGerenciaComissao.AutoSize = true;
            this.chkGerenciaComissao.Location = new System.Drawing.Point(167, 88);
            this.chkGerenciaComissao.Name = "chkGerenciaComissao";
            this.chkGerenciaComissao.Size = new System.Drawing.Size(120, 17);
            this.chkGerenciaComissao.TabIndex = 24;
            this.chkGerenciaComissao.Text = "Gerenciar Comissão";
            this.chkGerenciaComissao.UseVisualStyleBackColor = true;
            // 
            // chkVenda
            // 
            this.chkVenda.AutoSize = true;
            this.chkVenda.Location = new System.Drawing.Point(167, 19);
            this.chkVenda.Name = "chkVenda";
            this.chkVenda.Size = new System.Drawing.Size(60, 17);
            this.chkVenda.TabIndex = 21;
            this.chkVenda.Text = "Venda ";
            this.chkVenda.UseVisualStyleBackColor = true;
            // 
            // chkAtualizaValoresCompra
            // 
            this.chkAtualizaValoresCompra.AutoSize = true;
            this.chkAtualizaValoresCompra.Location = new System.Drawing.Point(6, 65);
            this.chkAtualizaValoresCompra.Name = "chkAtualizaValoresCompra";
            this.chkAtualizaValoresCompra.Size = new System.Drawing.Size(155, 17);
            this.chkAtualizaValoresCompra.TabIndex = 19;
            this.chkAtualizaValoresCompra.Text = "Atualiza Valores de Compra";
            this.chkAtualizaValoresCompra.UseVisualStyleBackColor = true;
            // 
            // chkTabelaCompra
            // 
            this.chkTabelaCompra.AutoSize = true;
            this.chkTabelaCompra.Location = new System.Drawing.Point(6, 88);
            this.chkTabelaCompra.Name = "chkTabelaCompra";
            this.chkTabelaCompra.Size = new System.Drawing.Size(128, 17);
            this.chkTabelaCompra.TabIndex = 20;
            this.chkTabelaCompra.Text = "Verificar Tab. Compra";
            this.chkTabelaCompra.UseVisualStyleBackColor = true;
            // 
            // chkGeraTitulo
            // 
            this.chkGeraTitulo.AutoSize = true;
            this.chkGeraTitulo.Location = new System.Drawing.Point(6, 19);
            this.chkGeraTitulo.Name = "chkGeraTitulo";
            this.chkGeraTitulo.Size = new System.Drawing.Size(132, 17);
            this.chkGeraTitulo.TabIndex = 17;
            this.chkGeraTitulo.Text = "Gera Título Financeiro";
            this.chkGeraTitulo.UseVisualStyleBackColor = true;
            // 
            // bgOutros
            // 
            this.bgOutros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bgOutros.Controls.Add(this.btDistDespesa);
            this.bgOutros.Controls.Add(this.btCentroCustos);
            this.bgOutros.Controls.Add(this.txtDistDespesa);
            this.bgOutros.Controls.Add(this.txtCentroCustos);
            this.bgOutros.Controls.Add(this.btCodigoNaturezaOperacao);
            this.bgOutros.Controls.Add(this.txtCodigoNaturezaOperacao);
            this.bgOutros.Controls.Add(this.label11);
            this.bgOutros.Controls.Add(this.label10);
            this.bgOutros.Controls.Add(this.label9);
            this.bgOutros.Location = new System.Drawing.Point(346, 205);
            this.bgOutros.Name = "bgOutros";
            this.bgOutros.Size = new System.Drawing.Size(642, 116);
            this.bgOutros.TabIndex = 37;
            this.bgOutros.TabStop = false;
            this.bgOutros.Text = "Outros";
            // 
            // btDistDespesa
            // 
            this.btDistDespesa.FlatAppearance.BorderSize = 0;
            this.btDistDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDistDespesa.Image = global::cms.Properties.Resources.procurar;
            this.btDistDespesa.Location = new System.Drawing.Point(390, 64);
            this.btDistDespesa.Name = "btDistDespesa";
            this.btDistDespesa.Size = new System.Drawing.Size(22, 22);
            this.btDistDespesa.TabIndex = 30;
            this.btDistDespesa.UseVisualStyleBackColor = true;
            // 
            // btCentroCustos
            // 
            this.btCentroCustos.FlatAppearance.BorderSize = 0;
            this.btCentroCustos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCentroCustos.Image = global::cms.Properties.Resources.procurar;
            this.btCentroCustos.Location = new System.Drawing.Point(390, 38);
            this.btCentroCustos.Name = "btCentroCustos";
            this.btCentroCustos.Size = new System.Drawing.Size(22, 22);
            this.btCentroCustos.TabIndex = 28;
            this.btCentroCustos.UseVisualStyleBackColor = true;
            // 
            // btCodigoNaturezaOperacao
            // 
            this.btCodigoNaturezaOperacao.FlatAppearance.BorderSize = 0;
            this.btCodigoNaturezaOperacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCodigoNaturezaOperacao.Image = global::cms.Properties.Resources.procurar;
            this.btCodigoNaturezaOperacao.Location = new System.Drawing.Point(468, 12);
            this.btCodigoNaturezaOperacao.Name = "btCodigoNaturezaOperacao";
            this.btCodigoNaturezaOperacao.Size = new System.Drawing.Size(22, 22);
            this.btCodigoNaturezaOperacao.TabIndex = 26;
            this.btCodigoNaturezaOperacao.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Dist. Despesa:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Centro Custos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Código Natureza de Operação:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "CFOP IE Isento no estado:";
            // 
            // txtCFOPcomIEIsento
            // 
            this.txtCFOPcomIEIsento.Location = new System.Drawing.Point(143, 97);
            this.txtCFOPcomIEIsento.MaxLength = 50;
            this.txtCFOPcomIEIsento.Name = "txtCFOPcomIEIsento";
            this.txtCFOPcomIEIsento.ReadOnly = true;
            this.txtCFOPcomIEIsento.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPcomIEIsento.TabIndex = 13;
            this.TextMaskedit.SetTextMasked(this.txtCFOPcomIEIsento, ToolMasked.TextMask.Formats.None);
            this.txtCFOPcomIEIsento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPcomIEIsento_KeyDown);
            // 
            // btCFOPcomIEIsento
            // 
            this.btCFOPcomIEIsento.FlatAppearance.BorderSize = 0;
            this.btCFOPcomIEIsento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPcomIEIsento.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPcomIEIsento.Location = new System.Drawing.Point(445, 95);
            this.btCFOPcomIEIsento.Name = "btCFOPcomIEIsento";
            this.btCFOPcomIEIsento.Size = new System.Drawing.Size(22, 22);
            this.btCFOPcomIEIsento.TabIndex = 14;
            this.btCFOPcomIEIsento.UseVisualStyleBackColor = true;
            this.btCFOPcomIEIsento.Click += new System.EventHandler(this.btCFOPcomIEIsento_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(476, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "CFOP IE Isento fora do estado:";
            // 
            // txtCFOPcomIEISENTOforaEstado
            // 
            this.txtCFOPcomIEISENTOforaEstado.Location = new System.Drawing.Point(635, 97);
            this.txtCFOPcomIEISENTOforaEstado.MaxLength = 50;
            this.txtCFOPcomIEISENTOforaEstado.Name = "txtCFOPcomIEISENTOforaEstado";
            this.txtCFOPcomIEISENTOforaEstado.ReadOnly = true;
            this.txtCFOPcomIEISENTOforaEstado.Size = new System.Drawing.Size(296, 20);
            this.txtCFOPcomIEISENTOforaEstado.TabIndex = 15;
            this.TextMaskedit.SetTextMasked(this.txtCFOPcomIEISENTOforaEstado, ToolMasked.TextMask.Formats.None);
            this.txtCFOPcomIEISENTOforaEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCFOPcomIEISENTOforaEstado_KeyDown);
            // 
            // btCFOPcomIEISENTOforaEstado
            // 
            this.btCFOPcomIEISENTOforaEstado.FlatAppearance.BorderSize = 0;
            this.btCFOPcomIEISENTOforaEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCFOPcomIEISENTOforaEstado.Image = global::cms.Properties.Resources.procurar;
            this.btCFOPcomIEISENTOforaEstado.Location = new System.Drawing.Point(937, 95);
            this.btCFOPcomIEISENTOforaEstado.Name = "btCFOPcomIEISENTOforaEstado";
            this.btCFOPcomIEISENTOforaEstado.Size = new System.Drawing.Size(22, 22);
            this.btCFOPcomIEISENTOforaEstado.TabIndex = 16;
            this.btCFOPcomIEISENTOforaEstado.UseVisualStyleBackColor = true;
            this.btCFOPcomIEISENTOforaEstado.Click += new System.EventHandler(this.btCFOPcomIEISENTOforaEstado_Click);
            // 
            // frmNaturezaOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 331);
            this.Controls.Add(this.bgOutros);
            this.Controls.Add(this.bgAcoes);
            this.Controls.Add(this.gbNaturezaOperacao);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNaturezaOperacao";
            this.Text = "Natureza da Operação";
            this.Load += new System.EventHandler(this.frmNaturezaOperacao_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbNaturezaOperacao.ResumeLayout(false);
            this.gbNaturezaOperacao.PerformLayout();
            this.bgAcoes.ResumeLayout(false);
            this.bgAcoes.PerformLayout();
            this.bgOutros.ResumeLayout(false);
            this.bgOutros.PerformLayout();
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
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.GroupBox gbNaturezaOperacao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton rbSaida;
        private System.Windows.Forms.RadioButton rbEntrada;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btCFOPnoEstado;
        private System.Windows.Forms.TextBox txtCFOPnoEstado;
        private System.Windows.Forms.Label lbFornecedor;
        private System.Windows.Forms.Button btCFOPforaEstado;
        private System.Windows.Forms.TextBox txtCFOPforaEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCFOPcomCST;
        private System.Windows.Forms.TextBox txtCFOPcomCST;
        private System.Windows.Forms.TextBox txtCFOPcomCSTforaEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btCFOPcomCSTforaEstado;
        private System.Windows.Forms.Button btCFOPAux1;
        private System.Windows.Forms.TextBox txtCFOPAux1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCFOPAux2;
        private System.Windows.Forms.TextBox txtCFOPAux2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox bgAcoes;
        private System.Windows.Forms.CheckBox chkCalculaCusto;
        private System.Windows.Forms.CheckBox chkMovimentaEstoque;
        private System.Windows.Forms.CheckBox chkDevolucao;
        private System.Windows.Forms.CheckBox chkGerenciaComissao;
        private System.Windows.Forms.CheckBox chkVenda;
        private System.Windows.Forms.CheckBox chkAtualizaValoresCompra;
        private System.Windows.Forms.CheckBox chkTabelaCompra;
        private System.Windows.Forms.CheckBox chkGeraTitulo;
        private System.Windows.Forms.GroupBox bgOutros;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btDistDespesa;
        private System.Windows.Forms.Button btCentroCustos;
        private System.Windows.Forms.TextBox txtDistDespesa;
        private System.Windows.Forms.TextBox txtCentroCustos;
        private System.Windows.Forms.Button btCodigoNaturezaOperacao;
        private System.Windows.Forms.TextBox txtCodigoNaturezaOperacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Button btCFOPcomIEISENTOforaEstado;
        private System.Windows.Forms.TextBox txtCFOPcomIEISENTOforaEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btCFOPcomIEIsento;
        private System.Windows.Forms.TextBox txtCFOPcomIEIsento;
        private System.Windows.Forms.Label label7;
    }
}