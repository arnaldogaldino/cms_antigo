namespace cms.Modulos.Produto.Forms.Grupo
{
    partial class frmProdutoGrupo
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
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelarAcao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbGrupo = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.gvProdutoSubGrupo = new System.Windows.Forms.DataGridView();
            this.id_produto_subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.gbGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoSubGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btEditar,
            this.btExcluir,
            this.btGravar,
            this.btCancelarAcao,
            this.toolStripSeparator1,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(676, 39);
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
            this.btNovo.Text = "Novo Grupo";
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
            this.btEditar.Text = "Editar Grupo";
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
            this.btExcluir.Text = "Excluir Grupo";
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
            this.btGravar.Text = "Gravar Grupo";
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btCancelarAcao
            // 
            this.btCancelarAcao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelarAcao.Image = global::cms.Properties.Resources.cancelar;
            this.btCancelarAcao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCancelarAcao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelarAcao.Name = "btCancelarAcao";
            this.btCancelarAcao.Size = new System.Drawing.Size(36, 36);
            this.btCancelarAcao.Text = "Cancelar Ação";
            this.btCancelarAcao.Click += new System.EventHandler(this.btCancelar_Click);
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
            // gbGrupo
            // 
            this.gbGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGrupo.Controls.Add(this.txtCodigo);
            this.gbGrupo.Controls.Add(this.lblDescricao);
            this.gbGrupo.Controls.Add(this.lblCodigo);
            this.gbGrupo.Controls.Add(this.txtGrupo);
            this.gbGrupo.Location = new System.Drawing.Point(12, 42);
            this.gbGrupo.Name = "gbGrupo";
            this.gbGrupo.Size = new System.Drawing.Size(652, 49);
            this.gbGrupo.TabIndex = 35;
            this.gbGrupo.TabStop = false;
            this.gbGrupo.Text = "Grupo de Produtos";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(59, 20);
            this.txtCodigo.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(120, 22);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(39, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Grupo:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 22);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(165, 19);
            this.txtGrupo.MaxLength = 50;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(314, 20);
            this.txtGrupo.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtGrupo, ToolMasked.TextMask.Formats.None);
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
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // gvProdutoSubGrupo
            // 
            this.gvProdutoSubGrupo.AllowUserToAddRows = false;
            this.gvProdutoSubGrupo.AllowUserToDeleteRows = false;
            this.gvProdutoSubGrupo.AllowUserToResizeColumns = false;
            this.gvProdutoSubGrupo.AllowUserToResizeRows = false;
            this.gvProdutoSubGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvProdutoSubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProdutoSubGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_produto_subgrupo,
            this.grupo,
            this.subgrupo});
            this.gvProdutoSubGrupo.Location = new System.Drawing.Point(12, 97);
            this.gvProdutoSubGrupo.MultiSelect = false;
            this.gvProdutoSubGrupo.Name = "gvProdutoSubGrupo";
            this.gvProdutoSubGrupo.ReadOnly = true;
            this.gvProdutoSubGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProdutoSubGrupo.ShowEditingIcon = false;
            this.gvProdutoSubGrupo.ShowRowErrors = false;
            this.gvProdutoSubGrupo.Size = new System.Drawing.Size(652, 222);
            this.gvProdutoSubGrupo.TabIndex = 36;
            this.gvProdutoSubGrupo.DoubleClick += new System.EventHandler(this.gvProdutoSubGrupo_DoubleClick);
            // 
            // id_produto_subgrupo
            // 
            this.id_produto_subgrupo.DataPropertyName = "id_produto_subgrupo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id_produto_subgrupo.DefaultCellStyle = dataGridViewCellStyle1;
            this.id_produto_subgrupo.HeaderText = "Código";
            this.id_produto_subgrupo.Name = "id_produto_subgrupo";
            this.id_produto_subgrupo.ReadOnly = true;
            // 
            // grupo
            // 
            this.grupo.DataPropertyName = "grupo";
            this.grupo.FillWeight = 10.30928F;
            this.grupo.HeaderText = "Grupo";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            this.grupo.Width = 200;
            // 
            // subgrupo
            // 
            this.subgrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subgrupo.DataPropertyName = "subgrupo";
            this.subgrupo.FillWeight = 189.6907F;
            this.subgrupo.HeaderText = "Sub-Grupo";
            this.subgrupo.Name = "subgrupo";
            this.subgrupo.ReadOnly = true;
            // 
            // frmProdutoGrupo
            // 
            this.ClientSize = new System.Drawing.Size(676, 331);
            this.Controls.Add(this.gvProdutoSubGrupo);
            this.Controls.Add(this.gbGrupo);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoGrupo";
            this.Text = "Grupo de Produto";
            this.Load += new System.EventHandler(this.frmProdutoGrupo_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbGrupo.ResumeLayout(false);
            this.gbGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdutoSubGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btEditar;
        private System.Windows.Forms.ToolStripButton btExcluir;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelarAcao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox gbGrupo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.ToolTip ValidarForm;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.DataGridView gvProdutoSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_produto_subgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn subgrupo;
    }
}
