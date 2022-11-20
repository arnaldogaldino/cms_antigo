namespace cms.Modulos.Produto.Forms.SubFamilia
{
    partial class frmProdutoSubFamiliaLockup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutoSubFamiliaLockup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
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
            this.btOk,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(877, 39);
            this.tsMenu.TabIndex = 16;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btOk
            // 
            this.btOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOk.Image = global::cms.Properties.Resources.ok;
            this.btOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(36, 36);
            this.btOk.Text = "Selecionar Sub-Familia de Produto";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
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
            this.gbPesquisa.Controls.Add(this.txtFamilia);
            this.gbPesquisa.Controls.Add(this.label1);
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtSubFamilia);
            this.gbPesquisa.Controls.Add(this.lbFamilia);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(853, 47);
            this.gbPesquisa.TabIndex = 17;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Sub-Familia de Produto";
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(182, 17);
            this.txtFamilia.MaxLength = 50;
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(224, 20);
            this.txtFamilia.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 20);
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
            this.btPesquisar.Location = new System.Drawing.Point(750, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 4;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.Location = new System.Drawing.Point(479, 17);
            this.txtSubFamilia.MaxLength = 50;
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.Size = new System.Drawing.Size(224, 20);
            this.txtSubFamilia.TabIndex = 3;
            // 
            // lbFamilia
            // 
            this.lbFamilia.AutoSize = true;
            this.lbFamilia.Location = new System.Drawing.Point(412, 20);
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
            this.gvProdutoSubFamilia.Location = new System.Drawing.Point(12, 95);
            this.gvProdutoSubFamilia.MultiSelect = false;
            this.gvProdutoSubFamilia.Name = "gvProdutoSubFamilia";
            this.gvProdutoSubFamilia.ReadOnly = true;
            this.gvProdutoSubFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProdutoSubFamilia.ShowEditingIcon = false;
            this.gvProdutoSubFamilia.ShowRowErrors = false;
            this.gvProdutoSubFamilia.Size = new System.Drawing.Size(853, 277);
            this.gvProdutoSubFamilia.TabIndex = 18;
            this.gvProdutoSubFamilia.DoubleClick += new System.EventHandler(this.gvProdutoSubFamilia_DoubleClick);
            // 
            // id_produto_subfamilia
            // 
            this.id_produto_subfamilia.DataPropertyName = "id_produto_subfamilia";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id_produto_subfamilia.DefaultCellStyle = dataGridViewCellStyle1;
            this.id_produto_subfamilia.HeaderText = "Código";
            this.id_produto_subfamilia.Name = "id_produto_subfamilia";
            this.id_produto_subfamilia.ReadOnly = true;
            // 
            // colGrupo
            // 
            this.colGrupo.DataPropertyName = "Grupo";
            this.colGrupo.HeaderText = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.ReadOnly = true;
            this.colGrupo.Width = 130;
            // 
            // colSubGrupo
            // 
            this.colSubGrupo.DataPropertyName = "SubGrupo";
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
            // frmProdutoSubFamiliaLockup
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 384);
            this.Controls.Add(this.gvProdutoSubFamilia);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoSubFamiliaLockup";
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
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtSubFamilia;
        private System.Windows.Forms.Label lbFamilia;
        private System.Windows.Forms.DataGridView gvProdutoSubFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_produto_subfamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn subfamilia;
    }
}