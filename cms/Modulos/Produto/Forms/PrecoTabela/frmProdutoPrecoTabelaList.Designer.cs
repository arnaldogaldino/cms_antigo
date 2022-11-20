namespace cms.Modulos.Produto.Forms.PrecoTabela
{
    partial class frmProdutoPrecoTabelaList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutoPrecoTabelaList));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gvProdutoPrecoTabela = new System.Windows.Forms.DataGridView();
            this.id_produto_preco_tabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco_tabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtPrecoTabela = new System.Windows.Forms.TextBox();
            this.lbPrecoTabela = new System.Windows.Forms.Label();
            this.TextMasked = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoPrecoTabela)).BeginInit();
            this.gbPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(749, 39);
            this.tsMenu.TabIndex = 12;
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
            // gvProdutoPrecoTabela
            // 
            this.gvProdutoPrecoTabela.AllowUserToAddRows = false;
            this.gvProdutoPrecoTabela.AllowUserToDeleteRows = false;
            this.gvProdutoPrecoTabela.AllowUserToResizeColumns = false;
            this.gvProdutoPrecoTabela.AllowUserToResizeRows = false;
            this.gvProdutoPrecoTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvProdutoPrecoTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProdutoPrecoTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_produto_preco_tabela,
            this.preco_tabela});
            this.gvProdutoPrecoTabela.Location = new System.Drawing.Point(12, 95);
            this.gvProdutoPrecoTabela.MultiSelect = false;
            this.gvProdutoPrecoTabela.Name = "gvProdutoPrecoTabela";
            this.gvProdutoPrecoTabela.ReadOnly = true;
            this.gvProdutoPrecoTabela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProdutoPrecoTabela.ShowEditingIcon = false;
            this.gvProdutoPrecoTabela.ShowRowErrors = false;
            this.gvProdutoPrecoTabela.Size = new System.Drawing.Size(725, 357);
            this.gvProdutoPrecoTabela.TabIndex = 14;
            this.gvProdutoPrecoTabela.DoubleClick += new System.EventHandler(this.gvProdutoPrecoTabela_DoubleClick);
            // 
            // id_produto_preco_tabela
            // 
            this.id_produto_preco_tabela.DataPropertyName = "id_produto_preco_tabela";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id_produto_preco_tabela.DefaultCellStyle = dataGridViewCellStyle2;
            this.id_produto_preco_tabela.HeaderText = "Código";
            this.id_produto_preco_tabela.Name = "id_produto_preco_tabela";
            this.id_produto_preco_tabela.ReadOnly = true;
            // 
            // preco_tabela
            // 
            this.preco_tabela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.preco_tabela.DataPropertyName = "preco_tabela";
            this.preco_tabela.HeaderText = "Tabela de Preço";
            this.preco_tabela.Name = "preco_tabela";
            this.preco_tabela.ReadOnly = true;
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtPrecoTabela);
            this.gbPesquisa.Controls.Add(this.lbPrecoTabela);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(725, 47);
            this.gbPesquisa.TabIndex = 15;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Tabela de Preço de Produto";
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
            this.TextMasked.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.Numero);
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
            this.btPesquisar.Location = new System.Drawing.Point(622, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 3;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtPrecoTabela
            // 
            this.txtPrecoTabela.Location = new System.Drawing.Point(232, 17);
            this.txtPrecoTabela.MaxLength = 50;
            this.txtPrecoTabela.Name = "txtPrecoTabela";
            this.txtPrecoTabela.Size = new System.Drawing.Size(315, 20);
            this.txtPrecoTabela.TabIndex = 2;
            this.TextMasked.SetTextMasked(this.txtPrecoTabela, ToolMasked.TextMask.Formats.None);
            // 
            // lbPrecoTabela
            // 
            this.lbPrecoTabela.AutoSize = true;
            this.lbPrecoTabela.Location = new System.Drawing.Point(137, 20);
            this.lbPrecoTabela.Name = "lbPrecoTabela";
            this.lbPrecoTabela.Size = new System.Drawing.Size(89, 13);
            this.lbPrecoTabela.TabIndex = 0;
            this.lbPrecoTabela.Text = "Tabela de Preço:";
            // 
            // TextMasked
            // 
            this.TextMasked.Text = null;
            // 
            // frmProdutoPrecoTabelaList
            // 
            this.ClientSize = new System.Drawing.Size(749, 464);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.gvProdutoPrecoTabela);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoPrecoTabelaList";
            this.Text = "Pesquisar Tabela de Preço de Produto";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoPrecoTabela)).EndInit();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvProdutoPrecoTabela;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtPrecoTabela;
        private System.Windows.Forms.Label lbPrecoTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_produto_preco_tabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco_tabela;
        private ToolMasked.TextMask TextMasked;
    }
}
