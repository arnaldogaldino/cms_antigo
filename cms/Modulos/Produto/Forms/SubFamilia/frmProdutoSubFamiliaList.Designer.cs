namespace cms.Modulos.Produto.Forms.SubFamilia
{
    partial class frmProdutoSubFamiliaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutoSubFamiliaList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblSubGrupo = new System.Windows.Forms.Label();
            this.btGrupo = new System.Windows.Forms.Button();
            this.btSubGrupo = new System.Windows.Forms.Button();
            this.txtSubGrupo = new System.Windows.Forms.TextBox();
            this.btFamilia = new System.Windows.Forms.Button();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtSubFamilia = new System.Windows.Forms.TextBox();
            this.lbFamilia = new System.Windows.Forms.Label();
            this.gvProdutoSubFamilia = new System.Windows.Forms.DataGridView();
            this.id_produto_subfamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subfamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.gbPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoSubFamilia)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(999, 39);
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
            this.gbPesquisa.Controls.Add(this.btFamilia);
            this.gbPesquisa.Controls.Add(this.txtFamilia);
            this.gbPesquisa.Controls.Add(this.label1);
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtSubFamilia);
            this.gbPesquisa.Controls.Add(this.lbFamilia);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(975, 124);
            this.gbPesquisa.TabIndex = 16;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Sub-Familia de Produto";
            // 
            // lblGrupo
            // 
            this.lblGrupo.Location = new System.Drawing.Point(10, 46);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 31;
            this.lblGrupo.Text = "Grupo:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(55, 43);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtGrupo.TabIndex = 32;
            this.txtGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrupo_KeyDown);
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Location = new System.Drawing.Point(8, 72);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(61, 13);
            this.lblSubGrupo.TabIndex = 30;
            this.lblSubGrupo.Text = "Sub-Grupo:";
            // 
            // btGrupo
            // 
            this.btGrupo.FlatAppearance.BorderSize = 0;
            this.btGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btGrupo.Location = new System.Drawing.Point(361, 41);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(22, 22);
            this.btGrupo.TabIndex = 33;
            this.btGrupo.UseVisualStyleBackColor = true;
            this.btGrupo.Click += new System.EventHandler(this.btGrupo_Click);
            // 
            // btSubGrupo
            // 
            this.btSubGrupo.FlatAppearance.BorderSize = 0;
            this.btSubGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btSubGrupo.Location = new System.Drawing.Point(381, 67);
            this.btSubGrupo.Name = "btSubGrupo";
            this.btSubGrupo.Size = new System.Drawing.Size(22, 22);
            this.btSubGrupo.TabIndex = 35;
            this.btSubGrupo.UseVisualStyleBackColor = true;
            this.btSubGrupo.Click += new System.EventHandler(this.btSubGrupo_Click);
            // 
            // txtSubGrupo
            // 
            this.txtSubGrupo.Location = new System.Drawing.Point(75, 69);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtSubGrupo.TabIndex = 34;
            this.txtSubGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubGrupo_KeyDown);
            // 
            // btFamilia
            // 
            this.btFamilia.FlatAppearance.BorderSize = 0;
            this.btFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFamilia.Image = global::cms.Properties.Resources.procurar;
            this.btFamilia.Location = new System.Drawing.Point(285, 93);
            this.btFamilia.Name = "btFamilia";
            this.btFamilia.Size = new System.Drawing.Size(22, 22);
            this.btFamilia.TabIndex = 8;
            this.btFamilia.UseVisualStyleBackColor = true;
            this.btFamilia.Click += new System.EventHandler(this.btFamilia_Click);
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(55, 95);
            this.txtFamilia.MaxLength = 50;
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(224, 20);
            this.txtFamilia.TabIndex = 7;
            this.txtFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFamilia_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Familia:";
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
            this.btPesquisar.Location = new System.Drawing.Point(872, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 3;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.Location = new System.Drawing.Point(204, 17);
            this.txtSubFamilia.MaxLength = 50;
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.Size = new System.Drawing.Size(224, 20);
            this.txtSubFamilia.TabIndex = 2;
            // 
            // lbFamilia
            // 
            this.lbFamilia.AutoSize = true;
            this.lbFamilia.Location = new System.Drawing.Point(137, 20);
            this.lbFamilia.Name = "lbFamilia";
            this.lbFamilia.Size = new System.Drawing.Size(64, 13);
            this.lbFamilia.TabIndex = 0;
            this.lbFamilia.Text = "Sub-Familia:";
            // 
            // gvProdutoSubFamilia
            // 
            this.gvProdutoSubFamilia.AllowUserToAddRows = false;
            this.gvProdutoSubFamilia.AllowUserToDeleteRows = false;
            this.gvProdutoSubFamilia.AllowUserToResizeColumns = false;
            this.gvProdutoSubFamilia.AllowUserToResizeRows = false;
            this.gvProdutoSubFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvProdutoSubFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProdutoSubFamilia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_produto_subfamilia,
            this.colGrupo,
            this.colSubGrupo,
            this.familia,
            this.subfamilia});
            this.gvProdutoSubFamilia.Location = new System.Drawing.Point(12, 172);
            this.gvProdutoSubFamilia.MultiSelect = false;
            this.gvProdutoSubFamilia.Name = "gvProdutoSubFamilia";
            this.gvProdutoSubFamilia.ReadOnly = true;
            this.gvProdutoSubFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProdutoSubFamilia.ShowEditingIcon = false;
            this.gvProdutoSubFamilia.ShowRowErrors = false;
            this.gvProdutoSubFamilia.Size = new System.Drawing.Size(975, 204);
            this.gvProdutoSubFamilia.TabIndex = 17;
            this.gvProdutoSubFamilia.DoubleClick += new System.EventHandler(this.gvProdutoSubFamilia_DoubleClick);
            // 
            // id_produto_subfamilia
            // 
            this.id_produto_subfamilia.DataPropertyName = "id_produto_subfamilia";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id_produto_subfamilia.DefaultCellStyle = dataGridViewCellStyle2;
            this.id_produto_subfamilia.HeaderText = "Código";
            this.id_produto_subfamilia.Name = "id_produto_subfamilia";
            this.id_produto_subfamilia.ReadOnly = true;
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
            // familia
            // 
            this.familia.DataPropertyName = "familia";
            this.familia.FillWeight = 10.30928F;
            this.familia.HeaderText = "Familia";
            this.familia.Name = "familia";
            this.familia.ReadOnly = true;
            this.familia.Width = 200;
            // 
            // subfamilia
            // 
            this.subfamilia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subfamilia.DataPropertyName = "subfamilia";
            this.subfamilia.FillWeight = 189.6907F;
            this.subfamilia.HeaderText = "Sub-Familia";
            this.subfamilia.Name = "subfamilia";
            this.subfamilia.ReadOnly = true;
            // 
            // frmProdutoSubFamiliaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 388);
            this.Controls.Add(this.gvProdutoSubFamilia);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoSubFamiliaList";
            this.Text = "Pesquisar Sub-Familia de Produto";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoSubFamilia)).EndInit();
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
        private System.Windows.Forms.TextBox txtSubFamilia;
        private System.Windows.Forms.Label lbFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.DataGridView gvProdutoSubFamilia;
        private System.Windows.Forms.Button btFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_produto_subfamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn subfamilia;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblSubGrupo;
        private System.Windows.Forms.Button btGrupo;
        private System.Windows.Forms.Button btSubGrupo;
        private System.Windows.Forms.TextBox txtSubGrupo;
    }
}