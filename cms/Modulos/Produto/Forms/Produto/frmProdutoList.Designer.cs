namespace cms.Modulos.Produto.Forms.Produto
{
    partial class frmProdutoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutoList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvProduto = new System.Windows.Forms.DataGridView();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.cbFilial = new cms.Modulos.Util.ctrlFilial();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblSubFamilia = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblSubGrupo = new System.Windows.Forms.Label();
            this.btGrupo = new System.Windows.Forms.Button();
            this.txtSubFamilia = new System.Windows.Forms.TextBox();
            this.btProdutoPrecoTabela = new System.Windows.Forms.Button();
            this.btSubGrupo = new System.Windows.Forms.Button();
            this.btSubFamilia = new System.Windows.Forms.Button();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.txtProdutoPrecoTabela = new System.Windows.Forms.TextBox();
            this.txtSubGrupo = new System.Windows.Forms.TextBox();
            this.btFamilia = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbGrupo = new System.Windows.Forms.Label();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.TextMasked = new ToolMasked.TextMask(this.components);
            this.colFoto = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodigoFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefFornec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidadeEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidadeReservada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidadeLiberada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduto)).BeginInit();
            this.gbPesquisa.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvProduto
            // 
            this.gvProduto.AllowUserToAddRows = false;
            this.gvProduto.AllowUserToDeleteRows = false;
            this.gvProduto.AllowUserToResizeColumns = false;
            this.gvProduto.AllowUserToResizeRows = false;
            this.gvProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFoto,
            this.ColIdProduto,
            this.ColDescricao,
            this.ColCodigoBarras,
            this.ColCodigoFornecedor,
            this.ColRefFornec,
            this.colTabela,
            this.colPreco,
            this.colGrupo,
            this.colSubGrupo,
            this.colFamilia,
            this.colSubFamilia,
            this.colFilial,
            this.colQuantidadeEstoque,
            this.colQuantidadeReservada,
            this.colQuantidadeLiberada,
            this.colEstoqueMinimo,
            this.colEstoqueMaximo,
            this.colLocalizacao});
            this.gvProduto.Location = new System.Drawing.Point(12, 171);
            this.gvProduto.MultiSelect = false;
            this.gvProduto.Name = "gvProduto";
            this.gvProduto.ReadOnly = true;
            this.gvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProduto.ShowEditingIcon = false;
            this.gvProduto.ShowRowErrors = false;
            this.gvProduto.Size = new System.Drawing.Size(1135, 199);
            this.gvProduto.TabIndex = 17;
            this.gvProduto.DoubleClick += new System.EventHandler(this.gvProduto_DoubleClick);
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.cbFilial);
            this.gbPesquisa.Controls.Add(this.lblGrupo);
            this.gbPesquisa.Controls.Add(this.lblSubFamilia);
            this.gbPesquisa.Controls.Add(this.lblFamilia);
            this.gbPesquisa.Controls.Add(this.txtGrupo);
            this.gbPesquisa.Controls.Add(this.lblSubGrupo);
            this.gbPesquisa.Controls.Add(this.btGrupo);
            this.gbPesquisa.Controls.Add(this.txtSubFamilia);
            this.gbPesquisa.Controls.Add(this.btProdutoPrecoTabela);
            this.gbPesquisa.Controls.Add(this.btSubGrupo);
            this.gbPesquisa.Controls.Add(this.btSubFamilia);
            this.gbPesquisa.Controls.Add(this.txtFamilia);
            this.gbPesquisa.Controls.Add(this.txtProdutoPrecoTabela);
            this.gbPesquisa.Controls.Add(this.txtSubGrupo);
            this.gbPesquisa.Controls.Add(this.btFamilia);
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.label2);
            this.gbPesquisa.Controls.Add(this.label1);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.textBox2);
            this.gbPesquisa.Controls.Add(this.textBox3);
            this.gbPesquisa.Controls.Add(this.textBox1);
            this.gbPesquisa.Controls.Add(this.txtDescricao);
            this.gbPesquisa.Controls.Add(this.label4);
            this.gbPesquisa.Controls.Add(this.label3);
            this.gbPesquisa.Controls.Add(this.lbGrupo);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(1135, 123);
            this.gbPesquisa.TabIndex = 16;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Produto";
            // 
            // cbFilial
            // 
            this.cbFilial.LabelSelecione = true;
            this.cbFilial.Location = new System.Drawing.Point(597, 42);
            this.cbFilial.Name = "cbFilial";
            this.cbFilial.SelectedDefault = false;
            this.cbFilial.Size = new System.Drawing.Size(210, 21);
            this.cbFilial.TabIndex = 49;
            // 
            // lblGrupo
            // 
            this.lblGrupo.Location = new System.Drawing.Point(9, 72);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 38;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblSubFamilia
            // 
            this.lblSubFamilia.AutoSize = true;
            this.lblSubFamilia.Location = new System.Drawing.Point(385, 98);
            this.lblSubFamilia.Name = "lblSubFamilia";
            this.lblSubFamilia.Size = new System.Drawing.Size(64, 13);
            this.lblSubFamilia.TabIndex = 48;
            this.lblSubFamilia.Text = "Sub-Familia:";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(9, 98);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(42, 13);
            this.lblFamilia.TabIndex = 37;
            this.lblFamilia.Text = "Familia:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(54, 69);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtGrupo.TabIndex = 6;
            this.TextMasked.SetTextMasked(this.txtGrupo, ToolMasked.TextMask.Formats.None);
            this.txtGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrupo_KeyDown);
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Location = new System.Drawing.Point(388, 72);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(61, 13);
            this.lblSubGrupo.TabIndex = 47;
            this.lblSubGrupo.Text = "Sub-Grupo:";
            // 
            // btGrupo
            // 
            this.btGrupo.FlatAppearance.BorderSize = 0;
            this.btGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btGrupo.Location = new System.Drawing.Point(360, 67);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(22, 22);
            this.btGrupo.TabIndex = 7;
            this.btGrupo.UseVisualStyleBackColor = true;
            this.btGrupo.Click += new System.EventHandler(this.btGrupo_Click);
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.Location = new System.Drawing.Point(455, 95);
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.ReadOnly = true;
            this.txtSubFamilia.Size = new System.Drawing.Size(300, 20);
            this.txtSubFamilia.TabIndex = 12;
            this.TextMasked.SetTextMasked(this.txtSubFamilia, ToolMasked.TextMask.Formats.None);
            this.txtSubFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubFamilia_KeyDown);
            // 
            // btProdutoPrecoTabela
            // 
            this.btProdutoPrecoTabela.FlatAppearance.BorderSize = 0;
            this.btProdutoPrecoTabela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProdutoPrecoTabela.Image = global::cms.Properties.Resources.procurar;
            this.btProdutoPrecoTabela.Location = new System.Drawing.Point(991, 15);
            this.btProdutoPrecoTabela.Name = "btProdutoPrecoTabela";
            this.btProdutoPrecoTabela.Size = new System.Drawing.Size(22, 22);
            this.btProdutoPrecoTabela.TabIndex = 5;
            this.btProdutoPrecoTabela.UseVisualStyleBackColor = true;
            this.btProdutoPrecoTabela.Click += new System.EventHandler(this.btProdutoPrecoTabela_Click);
            // 
            // btSubGrupo
            // 
            this.btSubGrupo.FlatAppearance.BorderSize = 0;
            this.btSubGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btSubGrupo.Location = new System.Drawing.Point(761, 67);
            this.btSubGrupo.Name = "btSubGrupo";
            this.btSubGrupo.Size = new System.Drawing.Size(22, 22);
            this.btSubGrupo.TabIndex = 9;
            this.btSubGrupo.UseVisualStyleBackColor = true;
            this.btSubGrupo.Click += new System.EventHandler(this.btSubGrupo_Click);
            // 
            // btSubFamilia
            // 
            this.btSubFamilia.FlatAppearance.BorderSize = 0;
            this.btSubFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubFamilia.Image = global::cms.Properties.Resources.procurar;
            this.btSubFamilia.Location = new System.Drawing.Point(761, 95);
            this.btSubFamilia.Name = "btSubFamilia";
            this.btSubFamilia.Size = new System.Drawing.Size(22, 22);
            this.btSubFamilia.TabIndex = 13;
            this.btSubFamilia.UseVisualStyleBackColor = true;
            this.btSubFamilia.Click += new System.EventHandler(this.btSubFamilia_Click);
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(54, 95);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(300, 20);
            this.txtFamilia.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtFamilia, ToolMasked.TextMask.Formats.None);
            this.txtFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFamilia_KeyDown);
            // 
            // txtProdutoPrecoTabela
            // 
            this.txtProdutoPrecoTabela.Location = new System.Drawing.Point(828, 17);
            this.txtProdutoPrecoTabela.Name = "txtProdutoPrecoTabela";
            this.txtProdutoPrecoTabela.ReadOnly = true;
            this.txtProdutoPrecoTabela.Size = new System.Drawing.Size(157, 20);
            this.txtProdutoPrecoTabela.TabIndex = 4;
            this.TextMasked.SetTextMasked(this.txtProdutoPrecoTabela, ToolMasked.TextMask.Formats.None);
            this.txtProdutoPrecoTabela.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProdutoPrecoTabela_KeyDown);
            // 
            // txtSubGrupo
            // 
            this.txtSubGrupo.Location = new System.Drawing.Point(455, 69);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtSubGrupo.TabIndex = 8;
            this.TextMasked.SetTextMasked(this.txtSubGrupo, ToolMasked.TextMask.Formats.None);
            this.txtSubGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubGrupo_KeyDown);
            // 
            // btFamilia
            // 
            this.btFamilia.FlatAppearance.BorderSize = 0;
            this.btFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFamilia.Image = global::cms.Properties.Resources.procurar;
            this.btFamilia.Location = new System.Drawing.Point(360, 93);
            this.btFamilia.Name = "btFamilia";
            this.btFamilia.Size = new System.Drawing.Size(22, 22);
            this.btFamilia.TabIndex = 11;
            this.btFamilia.UseVisualStyleBackColor = true;
            this.btFamilia.Click += new System.EventHandler(this.btFamilia_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(58, 17);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(73, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextMasked.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cód. Barras do Fornecedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código Barras:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(9, 20);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(43, 13);
            this.lbCodigo.TabIndex = 5;
            this.lbCodigo.Text = "Código:";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(1032, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 3;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(413, 43);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(177, 20);
            this.textBox2.TabIndex = 2;
            this.TextMasked.SetTextMasked(this.textBox2, ToolMasked.TextMask.Formats.None);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(596, 17);
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(177, 20);
            this.textBox3.TabIndex = 3;
            this.TextMasked.SetTextMasked(this.textBox3, ToolMasked.TextMask.Formats.None);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 43);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 2;
            this.TextMasked.SetTextMasked(this.textBox1, ToolMasked.TextMask.Formats.None);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(201, 17);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(315, 20);
            this.txtDescricao.TabIndex = 2;
            this.TextMasked.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tabela:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ref. Fabrica:";
            // 
            // lbGrupo
            // 
            this.lbGrupo.AutoSize = true;
            this.lbGrupo.Location = new System.Drawing.Point(137, 20);
            this.lbGrupo.Name = "lbGrupo";
            this.lbGrupo.Size = new System.Drawing.Size(58, 13);
            this.lbGrupo.TabIndex = 0;
            this.lbGrupo.Text = "Descrição:";
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1159, 39);
            this.tsMenu.TabIndex = 13;
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
            this.btNovo.Text = "Novo Produto";
            this.btNovo.ToolTipText = "Novo Produto";
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
            // TextMasked
            // 
            this.TextMasked.Text = null;
            // 
            // colFoto
            // 
            this.colFoto.DataPropertyName = "imagem";
            this.colFoto.HeaderText = "Foto";
            this.colFoto.Name = "colFoto";
            this.colFoto.ReadOnly = true;
            // 
            // ColIdProduto
            // 
            this.ColIdProduto.DataPropertyName = "id_produto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColIdProduto.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColIdProduto.HeaderText = "Código";
            this.ColIdProduto.MinimumWidth = 100;
            this.ColIdProduto.Name = "ColIdProduto";
            this.ColIdProduto.ReadOnly = true;
            // 
            // ColDescricao
            // 
            this.ColDescricao.DataPropertyName = "descricao";
            this.ColDescricao.HeaderText = "Descrição";
            this.ColDescricao.MinimumWidth = 350;
            this.ColDescricao.Name = "ColDescricao";
            this.ColDescricao.ReadOnly = true;
            this.ColDescricao.Width = 350;
            // 
            // ColCodigoBarras
            // 
            this.ColCodigoBarras.DataPropertyName = "codigo_barra";
            this.ColCodigoBarras.HeaderText = "Cód. Barras";
            this.ColCodigoBarras.Name = "ColCodigoBarras";
            this.ColCodigoBarras.ReadOnly = true;
            this.ColCodigoBarras.Width = 120;
            // 
            // ColCodigoFornecedor
            // 
            this.ColCodigoFornecedor.DataPropertyName = "codigo_barra_fornecedor";
            this.ColCodigoFornecedor.HeaderText = "Cód. Barras Fornec.";
            this.ColCodigoFornecedor.Name = "ColCodigoFornecedor";
            this.ColCodigoFornecedor.ReadOnly = true;
            this.ColCodigoFornecedor.Width = 120;
            // 
            // ColRefFornec
            // 
            this.ColRefFornec.DataPropertyName = "referencia_fabrica";
            this.ColRefFornec.HeaderText = "Ref. Fornec.";
            this.ColRefFornec.Name = "ColRefFornec";
            this.ColRefFornec.ReadOnly = true;
            // 
            // colTabela
            // 
            this.colTabela.DataPropertyName = "preco_tabela";
            this.colTabela.HeaderText = "Tabela";
            this.colTabela.Name = "colTabela";
            this.colTabela.ReadOnly = true;
            // 
            // colPreco
            // 
            this.colPreco.DataPropertyName = "preco_venda";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0,00";
            this.colPreco.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPreco.HeaderText = "Preço";
            this.colPreco.Name = "colPreco";
            this.colPreco.ReadOnly = true;
            // 
            // colGrupo
            // 
            this.colGrupo.DataPropertyName = "grupo";
            this.colGrupo.HeaderText = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.ReadOnly = true;
            this.colGrupo.Width = 130;
            // 
            // colSubGrupo
            // 
            this.colSubGrupo.DataPropertyName = "subgrupo";
            this.colSubGrupo.HeaderText = "Sub-Grupo";
            this.colSubGrupo.Name = "colSubGrupo";
            this.colSubGrupo.ReadOnly = true;
            this.colSubGrupo.Width = 130;
            // 
            // colFamilia
            // 
            this.colFamilia.DataPropertyName = "familia";
            this.colFamilia.HeaderText = "Familia";
            this.colFamilia.Name = "colFamilia";
            this.colFamilia.ReadOnly = true;
            this.colFamilia.Width = 130;
            // 
            // colSubFamilia
            // 
            this.colSubFamilia.DataPropertyName = "subfamilia";
            this.colSubFamilia.HeaderText = "Sub-Familia";
            this.colSubFamilia.Name = "colSubFamilia";
            this.colSubFamilia.ReadOnly = true;
            this.colSubFamilia.Width = 130;
            // 
            // colFilial
            // 
            this.colFilial.DataPropertyName = "empresa";
            this.colFilial.HeaderText = "Filial";
            this.colFilial.Name = "colFilial";
            this.colFilial.ReadOnly = true;
            // 
            // colQuantidadeEstoque
            // 
            this.colQuantidadeEstoque.DataPropertyName = "quantidade_estoque";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colQuantidadeEstoque.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQuantidadeEstoque.HeaderText = "Qdt. Estoque";
            this.colQuantidadeEstoque.Name = "colQuantidadeEstoque";
            this.colQuantidadeEstoque.ReadOnly = true;
            this.colQuantidadeEstoque.Width = 130;
            // 
            // colQuantidadeReservada
            // 
            this.colQuantidadeReservada.DataPropertyName = "quantidade_reservada";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colQuantidadeReservada.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQuantidadeReservada.HeaderText = "Qtd. Reservada";
            this.colQuantidadeReservada.Name = "colQuantidadeReservada";
            this.colQuantidadeReservada.ReadOnly = true;
            this.colQuantidadeReservada.Width = 130;
            // 
            // colQuantidadeLiberada
            // 
            this.colQuantidadeLiberada.DataPropertyName = "quantidade_liberada";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colQuantidadeLiberada.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQuantidadeLiberada.HeaderText = "Qtd. Disponivel";
            this.colQuantidadeLiberada.Name = "colQuantidadeLiberada";
            this.colQuantidadeLiberada.ReadOnly = true;
            this.colQuantidadeLiberada.Width = 130;
            // 
            // colEstoqueMinimo
            // 
            this.colEstoqueMinimo.DataPropertyName = "estoque_minino";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colEstoqueMinimo.DefaultCellStyle = dataGridViewCellStyle6;
            this.colEstoqueMinimo.HeaderText = "Estoque Min";
            this.colEstoqueMinimo.Name = "colEstoqueMinimo";
            this.colEstoqueMinimo.ReadOnly = true;
            this.colEstoqueMinimo.Width = 120;
            // 
            // colEstoqueMaximo
            // 
            this.colEstoqueMaximo.DataPropertyName = "estoque_maximo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0,00";
            this.colEstoqueMaximo.DefaultCellStyle = dataGridViewCellStyle7;
            this.colEstoqueMaximo.HeaderText = "Estoque Max";
            this.colEstoqueMaximo.Name = "colEstoqueMaximo";
            this.colEstoqueMaximo.ReadOnly = true;
            this.colEstoqueMaximo.Width = 120;
            // 
            // colLocalizacao
            // 
            this.colLocalizacao.DataPropertyName = "estoque_localizacao";
            this.colLocalizacao.HeaderText = "Localização";
            this.colLocalizacao.Name = "colLocalizacao";
            this.colLocalizacao.ReadOnly = true;
            this.colLocalizacao.Width = 130;
            // 
            // frmProdutoList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 382);
            this.Controls.Add(this.gvProduto);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoList";
            this.Text = "Pesquisar Produtos";
            this.Load += new System.EventHandler(this.frmProdutoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvProduto)).EndInit();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbGrupo;
        private System.Windows.Forms.DataGridView gvProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblSubFamilia;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblSubGrupo;
        private System.Windows.Forms.Button btGrupo;
        private System.Windows.Forms.TextBox txtSubFamilia;
        private System.Windows.Forms.Button btSubGrupo;
        private System.Windows.Forms.Button btSubFamilia;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.TextBox txtSubGrupo;
        private System.Windows.Forms.Button btFamilia;
        private ToolMasked.TextMask TextMasked;
        private Util.ctrlFilial cbFilial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btProdutoPrecoTabela;
        private System.Windows.Forms.TextBox txtProdutoPrecoTabela;
        private System.Windows.Forms.DataGridViewImageColumn colFoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigoFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefFornec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidadeEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidadeReservada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidadeLiberada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueMaximo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalizacao;
        

    }
}