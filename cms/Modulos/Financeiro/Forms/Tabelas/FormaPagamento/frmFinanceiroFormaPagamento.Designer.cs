namespace cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento
{
    partial class frmFinanceiroFormaPagamento
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
            this.gbPlanoContas = new System.Windows.Forms.GroupBox();
            this.btPlanoContas = new System.Windows.Forms.Button();
            this.txtPlanoContas = new System.Windows.Forms.TextBox();
            this.lblTaxaAdmin = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtTaxaAdmin = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlanoContas = new System.Windows.Forms.Label();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            this.gbPlanoContas.SuspendLayout();
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
            this.tsMenu.Size = new System.Drawing.Size(736, 39);
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
            // gbPlanoContas
            // 
            this.gbPlanoContas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPlanoContas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbPlanoContas.Controls.Add(this.btPlanoContas);
            this.gbPlanoContas.Controls.Add(this.txtPlanoContas);
            this.gbPlanoContas.Controls.Add(this.lblTaxaAdmin);
            this.gbPlanoContas.Controls.Add(this.lblDescricao);
            this.gbPlanoContas.Controls.Add(this.txtTaxaAdmin);
            this.gbPlanoContas.Controls.Add(this.txtDescricao);
            this.gbPlanoContas.Controls.Add(this.txtDataCadastro);
            this.gbPlanoContas.Controls.Add(this.txtNome);
            this.gbPlanoContas.Controls.Add(this.lblNome);
            this.gbPlanoContas.Controls.Add(this.label1);
            this.gbPlanoContas.Controls.Add(this.lblPlanoContas);
            this.gbPlanoContas.Location = new System.Drawing.Point(12, 42);
            this.gbPlanoContas.Name = "gbPlanoContas";
            this.gbPlanoContas.Size = new System.Drawing.Size(712, 126);
            this.gbPlanoContas.TabIndex = 37;
            this.gbPlanoContas.TabStop = false;
            this.gbPlanoContas.Text = "Forma de Pagamento";
            // 
            // btPlanoContas
            // 
            this.btPlanoContas.FlatAppearance.BorderSize = 0;
            this.btPlanoContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPlanoContas.Image = global::cms.Properties.Resources.procurar;
            this.btPlanoContas.Location = new System.Drawing.Point(365, 17);
            this.btPlanoContas.Name = "btPlanoContas";
            this.btPlanoContas.Size = new System.Drawing.Size(22, 22);
            this.btPlanoContas.TabIndex = 9;
            this.btPlanoContas.UseVisualStyleBackColor = true;
            this.btPlanoContas.Click += new System.EventHandler(this.btPlanoContas_Click);
            // 
            // txtPlanoContas
            // 
            this.txtPlanoContas.Location = new System.Drawing.Point(100, 19);
            this.txtPlanoContas.MaxLength = 50;
            this.txtPlanoContas.Name = "txtPlanoContas";
            this.txtPlanoContas.ReadOnly = true;
            this.txtPlanoContas.Size = new System.Drawing.Size(259, 20);
            this.txtPlanoContas.TabIndex = 0;
            this.TextMaskedit.SetTextMasked(this.txtPlanoContas, ToolMasked.TextMask.Formats.None);
            this.txtPlanoContas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlanoContas_KeyDown);
            // 
            // lblTaxaAdmin
            // 
            this.lblTaxaAdmin.AutoSize = true;
            this.lblTaxaAdmin.Location = new System.Drawing.Point(6, 100);
            this.lblTaxaAdmin.Name = "lblTaxaAdmin";
            this.lblTaxaAdmin.Size = new System.Drawing.Size(48, 13);
            this.lblTaxaAdmin.TabIndex = 7;
            this.lblTaxaAdmin.Text = "Taxa(%):";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 75);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 7;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtTaxaAdmin
            // 
            this.txtTaxaAdmin.Location = new System.Drawing.Point(60, 98);
            this.txtTaxaAdmin.MaxLength = 5;
            this.txtTaxaAdmin.Name = "txtTaxaAdmin";
            this.txtTaxaAdmin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxaAdmin.Size = new System.Drawing.Size(44, 20);
            this.txtTaxaAdmin.TabIndex = 4;
            this.TextMaskedit.SetTextMasked(this.txtTaxaAdmin, ToolMasked.TextMask.Formats.Dinheiro);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(70, 72);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(305, 20);
            this.txtDescricao.TabIndex = 3;
            this.TextMaskedit.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(477, 19);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(94, 20);
            this.txtDataCadastro.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtDataCadastro, ToolMasked.TextMask.Formats.None);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(50, 46);
            this.txtNome.MaxLength = 20;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(178, 20);
            this.txtNome.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtNome, ToolMasked.TextMask.Formats.None);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 49);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 5;
            this.lblNome.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Cadastro:";
            // 
            // lblPlanoContas
            // 
            this.lblPlanoContas.AutoSize = true;
            this.lblPlanoContas.Location = new System.Drawing.Point(6, 22);
            this.lblPlanoContas.Name = "lblPlanoContas";
            this.lblPlanoContas.Size = new System.Drawing.Size(88, 13);
            this.lblPlanoContas.TabIndex = 2;
            this.lblPlanoContas.Text = "Plano de Contas:";
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
            // frmFinanceiroFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 262);
            this.Controls.Add(this.gbPlanoContas);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroFormaPagamento";
            this.Text = "Forma de Pagamento";
            this.Load += new System.EventHandler(this.frmFinanceiroFormaPagamento_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbPlanoContas.ResumeLayout(false);
            this.gbPlanoContas.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbPlanoContas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblPlanoContas;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblTaxaAdmin;
        private System.Windows.Forms.TextBox txtTaxaAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.ToolTip ValidarForm;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.Button btPlanoContas;
        private System.Windows.Forms.TextBox txtPlanoContas;

    }
}