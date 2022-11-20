namespace cms.Modulos.Produto.Forms.SubFamilia
{
    partial class frmProdutoSubFamilia
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
            this.gbNcm = new System.Windows.Forms.GroupBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblSubGrupo = new System.Windows.Forms.Label();
            this.btGrupo = new System.Windows.Forms.Button();
            this.btSubGrupo = new System.Windows.Forms.Button();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.txtSubGrupo = new System.Windows.Forms.TextBox();
            this.btFamilia = new System.Windows.Forms.Button();
            this.txtSubFamilia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            this.gbNcm.SuspendLayout();
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
            this.tsMenu.Size = new System.Drawing.Size(1148, 39);
            this.tsMenu.TabIndex = 35;
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
            this.btNovo.Text = "Novo Familia";
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
            this.btEditar.Text = "Editar Familia";
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
            this.btExcluir.Text = "Excluir Familia";
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
            this.btGravar.Text = "Gravar Familia";
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
            // gbNcm
            // 
            this.gbNcm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNcm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbNcm.Controls.Add(this.lblGrupo);
            this.gbNcm.Controls.Add(this.lblFamilia);
            this.gbNcm.Controls.Add(this.txtGrupo);
            this.gbNcm.Controls.Add(this.lblSubGrupo);
            this.gbNcm.Controls.Add(this.btGrupo);
            this.gbNcm.Controls.Add(this.btSubGrupo);
            this.gbNcm.Controls.Add(this.txtFamilia);
            this.gbNcm.Controls.Add(this.txtSubGrupo);
            this.gbNcm.Controls.Add(this.btFamilia);
            this.gbNcm.Controls.Add(this.txtSubFamilia);
            this.gbNcm.Controls.Add(this.label1);
            this.gbNcm.Controls.Add(this.txtCodigo);
            this.gbNcm.Controls.Add(this.lblCodigo);
            this.gbNcm.Location = new System.Drawing.Point(12, 42);
            this.gbNcm.Name = "gbNcm";
            this.gbNcm.Size = new System.Drawing.Size(1124, 100);
            this.gbNcm.TabIndex = 36;
            this.gbNcm.TabStop = false;
            this.gbNcm.Text = "Familia de Produtos";
            // 
            // lblGrupo
            // 
            this.lblGrupo.Location = new System.Drawing.Point(120, 22);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 49;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(7, 48);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(42, 13);
            this.lblFamilia.TabIndex = 48;
            this.lblFamilia.Text = "Familia:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(165, 19);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtGrupo.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtGrupo, ToolMasked.TextMask.Formats.None);
            this.txtGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrupo_KeyDown);
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Location = new System.Drawing.Point(499, 22);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(61, 13);
            this.lblSubGrupo.TabIndex = 56;
            this.lblSubGrupo.Text = "Sub-Grupo:";
            // 
            // btGrupo
            // 
            this.btGrupo.FlatAppearance.BorderSize = 0;
            this.btGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btGrupo.Location = new System.Drawing.Point(471, 17);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(22, 22);
            this.btGrupo.TabIndex = 3;
            this.btGrupo.UseVisualStyleBackColor = true;
            this.btGrupo.Click += new System.EventHandler(this.btGrupo_Click);
            // 
            // btSubGrupo
            // 
            this.btSubGrupo.FlatAppearance.BorderSize = 0;
            this.btSubGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubGrupo.Image = global::cms.Properties.Resources.procurar;
            this.btSubGrupo.Location = new System.Drawing.Point(872, 17);
            this.btSubGrupo.Name = "btSubGrupo";
            this.btSubGrupo.Size = new System.Drawing.Size(22, 22);
            this.btSubGrupo.TabIndex = 5;
            this.btSubGrupo.UseVisualStyleBackColor = true;
            this.btSubGrupo.Click += new System.EventHandler(this.btSubGrupo_Click);
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(52, 45);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(300, 20);
            this.txtFamilia.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtFamilia, ToolMasked.TextMask.Formats.None);
            this.txtFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFamilia_KeyDown);
            // 
            // txtSubGrupo
            // 
            this.txtSubGrupo.Location = new System.Drawing.Point(566, 19);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.Size = new System.Drawing.Size(300, 20);
            this.txtSubGrupo.TabIndex = 4;
            this.TextMaskedit.SetTextMasked(this.txtSubGrupo, ToolMasked.TextMask.Formats.None);
            this.txtSubGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubGrupo_KeyDown);
            // 
            // btFamilia
            // 
            this.btFamilia.FlatAppearance.BorderSize = 0;
            this.btFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFamilia.Image = global::cms.Properties.Resources.procurar;
            this.btFamilia.Location = new System.Drawing.Point(358, 43);
            this.btFamilia.Name = "btFamilia";
            this.btFamilia.Size = new System.Drawing.Size(22, 22);
            this.btFamilia.TabIndex = 7;
            this.btFamilia.UseVisualStyleBackColor = true;
            this.btFamilia.Click += new System.EventHandler(this.btFamilia_Click);
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.Location = new System.Drawing.Point(73, 71);
            this.txtSubFamilia.MaxLength = 50;
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.Size = new System.Drawing.Size(279, 20);
            this.txtSubFamilia.TabIndex = 8;
            this.TextMaskedit.SetTextMasked(this.txtSubFamilia, ToolMasked.TextMask.Formats.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sub-Familia:";
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
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 22);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código:";
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
            // frmProdutoSubFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 389);
            this.Controls.Add(this.gbNcm);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProdutoSubFamilia";
            this.Text = "Sub-Familia de Produto";
            this.Load += new System.EventHandler(this.frmProdutoFamilia_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbNcm.ResumeLayout(false);
            this.gbNcm.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbNcm;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubFamilia;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblSubGrupo;
        private System.Windows.Forms.Button btGrupo;
        private System.Windows.Forms.Button btSubGrupo;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.TextBox txtSubGrupo;
        private System.Windows.Forms.Button btFamilia;

    }
}