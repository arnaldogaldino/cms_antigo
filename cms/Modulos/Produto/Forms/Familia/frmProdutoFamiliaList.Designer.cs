namespace cms.Modulos.Produto.Forms.Familia
{
    partial class frmProdutoFamiliaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutoFamiliaList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gvProdutoFamilia = new System.Windows.Forms.DataGridView();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblSubGrupo = new System.Windows.Forms.Label();
            this.btGrupo = new System.Windows.Forms.Button();
            this.btSubGrupo = new System.Windows.Forms.Button();
            this.txtSubGrupo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.lbFamilia = new System.Windows.Forms.Label();
            this.id_produto_familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoFamilia)).BeginInit();
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
            this.tsMenu.Size = new System.Drawing.Size(922, 39);
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
            // gvProdutoFamilia
            // 
            this.gvProdutoFamilia.AllowUserToAddRows = false;
            this.gvProdutoFamilia.AllowUserToDeleteRows = false;
            this.gvProdutoFamilia.AllowUserToResizeColumns = false;
            this.gvProdutoFamilia.AllowUserToResizeRows = false;
            this.gvProdutoFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvProdutoFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProdutoFamilia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_produto_familia,
            this.colGrupo,
            this.colSubGrupo,
            this.familia});
            this.gvProdutoFamilia.Location = new System.Drawing.Point(12, 119);
            this.gvProdutoFamilia.MultiSelect = false;
            this.gvProdutoFamilia.Name = "gvProdutoFamilia";
            this.gvProdutoFamilia.ReadOnly = true;
            this.gvProdutoFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProdutoFamilia.ShowEditingIcon = false;
            this.gvProdutoFamilia.ShowRowErrors = false;
            this.gvProdutoFamilia.Size = new System.Drawing.Size(898, 333);
            this.gvProdutoFamilia.TabIndex = 14;
            this.gvProdutoFamilia.DoubleClick += new System.EventHandler(this.gvProdutoFamilia_DoubleClick);
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.lblGrupo);
            this.gbPesquisa.Controls.Add(this.txtGrupo);
            this.gbPesquisa.Controls.Add(this.lblSubGrupo);
            this.gbPesquisa.Controls.Add(this.btGrupo);
            this.gbPesquisa.Controls.Add(this.btSubGrupo);
            this.gbPesquisa.Controls.Add(this.txtSubGrupo);
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtFamilia);
            this.gbPesquisa.Controls.Add(this.lbFamilia);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(898, 71);
            this.gbPesquisa.TabIndex = 15;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Familia de Produto";
            // 
            // lblGrupo
            // 
            this.lblGrupo.Location = new System.Drawing.Point(9, 45);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 19;
            this.lblGrupo.Text = "Grupo:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(54, 42);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtGrupo.TabIndex = 20;
            this.txtGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrupo_KeyDown);
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Location = new System.Drawing.Point(388, 45);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(61, 13);
            this.lblSubGrupo.TabIndex = 18;
            this.lblSubGrupo.Text = "Sub-Grupo:";
            // 
            // btGrupo
            // 
            this.btGrupo.FlatAppearance.BorderSize = 0;
            this.btGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btGrupo.Location = new System.Drawing.Point(360, 40);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(22, 22);
            this.btGrupo.TabIndex = 21;
            this.btGrupo.UseVisualStyleBackColor = true;
            this.btGrupo.Click += new System.EventHandler(this.btGrupo_Click);
            // 
            // btSubGrupo
            // 
            this.btSubGrupo.FlatAppearance.BorderSize = 0;
            this.btSubGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btSubGrupo.Location = new System.Drawing.Point(761, 40);
            this.btSubGrupo.Name = "btSubGrupo";
            this.btSubGrupo.Size = new System.Drawing.Size(22, 22);
            this.btSubGrupo.TabIndex = 23;
            this.btSubGrupo.UseVisualStyleBackColor = true;
            this.btSubGrupo.Click += new System.EventHandler(this.btSubGrupo_Click);
            // 
            // txtSubGrupo
            // 
            this.txtSubGrupo.Location = new System.Drawing.Point(455, 42);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtSubGrupo.TabIndex = 22;
            this.txtSubGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubGrupo_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(58, 17);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(73, 20);
            this.txtCodigo.TabIndex = 1;
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
            this.btPesquisar.Location = new System.Drawing.Point(795, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 3;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(182, 17);
            this.txtFamilia.MaxLength = 50;
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(315, 20);
            this.txtFamilia.TabIndex = 2;
            // 
            // lbFamilia
            // 
            this.lbFamilia.AutoSize = true;
            this.lbFamilia.Location = new System.Drawing.Point(137, 20);
            this.lbFamilia.Name = "lbFamilia";
            this.lbFamilia.Size = new System.Drawing.Size(42, 13);
            this.lbFamilia.TabIndex = 0;
            this.lbFamilia.Text = "Familia:";
            // 
            // id_produto_familia
            // 
            this.id_produto_familia.DataPropertyName = "id_produto_familia";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id_produto_familia.DefaultCellStyle = dataGridViewCellStyle1;
            this.id_produto_familia.HeaderText = "Código";
            this.id_produto_familia.Name = "id_produto_familia";
            this.id_produto_familia.ReadOnly = true;
            // 
            // colGrupo
            // 
            this.colGrupo.DataPropertyName = "grupo";
            this.colGrupo.HeaderText = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.ReadOnly = true;
            this.colGrupo.Width = 150;
            // 
            // colSubGrupo
            // 
            this.colSubGrupo.DataPropertyName = "subgrupo";
            this.colSubGrupo.HeaderText = "SubGrupo";
            this.colSubGrupo.Name = "colSubGrupo";
            this.colSubGrupo.ReadOnly = true;
            this.colSubGrupo.Width = 200;
            // 
            // familia
            // 
            this.familia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.familia.DataPropertyName = "familia";
            this.familia.HeaderText = "Familia";
            this.familia.Name = "familia";
            this.familia.ReadOnly = true;
            // 
            // frmProdutoFamiliaList
            // 
            this.ClientSize = new System.Drawing.Size(922, 464);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.gvProdutoFamilia);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoFamiliaList";
            this.Text = "Pesquisar Familia de Produto";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoFamilia)).EndInit();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvProdutoFamilia;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.Label lbFamilia;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblSubGrupo;
        private System.Windows.Forms.Button btGrupo;
        private System.Windows.Forms.Button btSubGrupo;
        private System.Windows.Forms.TextBox txtSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_produto_familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
    }
}
