namespace cms.Modulos.Fiscal.Forms.Ncm
{
    partial class frmFiscalNcm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbNcm = new System.Windows.Forms.GroupBox();
            this.txtNcm = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.tpIva = new System.Windows.Forms.TabPage();
            this.gvIvaAliquota = new System.Windows.Forms.DataGridView();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliquota_interna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reducao_bc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imposto_st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbAderecos = new System.Windows.Forms.TabControl();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.tsMenu.SuspendLayout();
            this.gbNcm.SuspendLayout();
            this.tpIva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvIvaAliquota)).BeginInit();
            this.tbAderecos.SuspendLayout();
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
            this.tsMenu.Size = new System.Drawing.Size(860, 39);
            this.tsMenu.TabIndex = 33;
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
            // gbNcm
            // 
            this.gbNcm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNcm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbNcm.Controls.Add(this.txtNcm);
            this.gbNcm.Controls.Add(this.lblDescricao);
            this.gbNcm.Controls.Add(this.lblCodigo);
            this.gbNcm.Controls.Add(this.txtDescricao);
            this.gbNcm.Location = new System.Drawing.Point(12, 42);
            this.gbNcm.Name = "gbNcm";
            this.gbNcm.Size = new System.Drawing.Size(836, 45);
            this.gbNcm.TabIndex = 34;
            this.gbNcm.TabStop = false;
            this.gbNcm.Text = "Ncm";
            // 
            // txtNcm
            // 
            this.txtNcm.Location = new System.Drawing.Point(44, 18);
            this.txtNcm.MaxLength = 15;
            this.txtNcm.Name = "txtNcm";
            this.txtNcm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNcm.Size = new System.Drawing.Size(100, 20);
            this.txtNcm.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtNcm, ToolMasked.TextMask.Formats.Ncm);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(150, 21);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 21);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(32, 13);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Ncm:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(214, 18);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(314, 20);
            this.txtDescricao.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
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
            // tpIva
            // 
            this.tpIva.Controls.Add(this.gvIvaAliquota);
            this.tpIva.Location = new System.Drawing.Point(4, 22);
            this.tpIva.Name = "tpIva";
            this.tpIva.Padding = new System.Windows.Forms.Padding(3);
            this.tpIva.Size = new System.Drawing.Size(831, 324);
            this.tpIva.TabIndex = 0;
            this.tpIva.Text = "Alíquotas Iva";
            this.tpIva.UseVisualStyleBackColor = true;
            // 
            // gvIvaAliquota
            // 
            this.gvIvaAliquota.AllowUserToAddRows = false;
            this.gvIvaAliquota.AllowUserToDeleteRows = false;
            this.gvIvaAliquota.AllowUserToResizeColumns = false;
            this.gvIvaAliquota.AllowUserToResizeRows = false;
            this.gvIvaAliquota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvIvaAliquota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIvaAliquota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estado,
            this.aliquota_interna,
            this.iva,
            this.reducao_bc,
            this.imposto_st});
            this.gvIvaAliquota.Location = new System.Drawing.Point(6, 6);
            this.gvIvaAliquota.MultiSelect = false;
            this.gvIvaAliquota.Name = "gvIvaAliquota";
            this.gvIvaAliquota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvIvaAliquota.ShowEditingIcon = false;
            this.gvIvaAliquota.ShowRowErrors = false;
            this.gvIvaAliquota.Size = new System.Drawing.Size(819, 312);
            this.gvIvaAliquota.TabIndex = 5;
            this.gvIvaAliquota.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvIvaAliquota_CellLeave);
            this.gvIvaAliquota.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvIvaAliquota_CellValidated);
            this.gvIvaAliquota.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvIvaAliquota_CellValidating);
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 150;
            // 
            // aliquota_interna
            // 
            this.aliquota_interna.DataPropertyName = "aliquota_interna";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.aliquota_interna.DefaultCellStyle = dataGridViewCellStyle9;
            this.aliquota_interna.HeaderText = "% Alíq. Interna";
            this.aliquota_interna.Name = "aliquota_interna";
            this.aliquota_interna.Width = 120;
            // 
            // iva
            // 
            this.iva.DataPropertyName = "iva";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.iva.DefaultCellStyle = dataGridViewCellStyle10;
            this.iva.HeaderText = "% Margem (IVA-ST)";
            this.iva.Name = "iva";
            this.iva.Width = 120;
            // 
            // reducao_bc
            // 
            this.reducao_bc.DataPropertyName = "reducao_bc";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.reducao_bc.DefaultCellStyle = dataGridViewCellStyle11;
            this.reducao_bc.HeaderText = "% Redução BC";
            this.reducao_bc.Name = "reducao_bc";
            this.reducao_bc.Width = 120;
            // 
            // imposto_st
            // 
            this.imposto_st.DataPropertyName = "imposto_st";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.imposto_st.DefaultCellStyle = dataGridViewCellStyle12;
            this.imposto_st.HeaderText = "% Imposto ST";
            this.imposto_st.Name = "imposto_st";
            this.imposto_st.Width = 120;
            // 
            // tbAderecos
            // 
            this.tbAderecos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAderecos.Controls.Add(this.tpIva);
            this.tbAderecos.Location = new System.Drawing.Point(12, 93);
            this.tbAderecos.Name = "tbAderecos";
            this.tbAderecos.SelectedIndex = 0;
            this.tbAderecos.Size = new System.Drawing.Size(839, 350);
            this.tbAderecos.TabIndex = 35;
            // 
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // frmFiscalNcm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 455);
            this.Controls.Add(this.tbAderecos);
            this.Controls.Add(this.gbNcm);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFiscalNcm";
            this.Text = "Ncm";
            this.Load += new System.EventHandler(this.frmFiscalNcm_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbNcm.ResumeLayout(false);
            this.gbNcm.PerformLayout();
            this.tpIva.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvIvaAliquota)).EndInit();
            this.tbAderecos.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtNcm;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.TabPage tpIva;
        private System.Windows.Forms.TabControl tbAderecos;
        private System.Windows.Forms.DataGridView gvIvaAliquota;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliquota_interna;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn reducao_bc;
        private System.Windows.Forms.DataGridViewTextBoxColumn imposto_st;
    }
}