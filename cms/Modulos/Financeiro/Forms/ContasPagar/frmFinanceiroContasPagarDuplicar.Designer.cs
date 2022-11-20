namespace cms.Modulos.Financeiro.Forms.ContasPagar
{
    partial class frmFinanceiroContasPagarDuplicar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceiroContasPagarDuplicar));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtValorParcela = new System.Windows.Forms.TextBox();
            this.txtQtdParcelas = new System.Windows.Forms.TextBox();
            this.txtIntervaloDias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gvParcelas = new System.Windows.Forms.DataGridView();
            this.Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btPreview = new System.Windows.Forms.Button();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOk,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(404, 39);
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
            this.btOk.Text = "Selecionar Cliente";
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
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(80, 42);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorTotal.Size = new System.Drawing.Size(130, 20);
            this.txtValorTotal.TabIndex = 19;
            this.txtValorTotal.Text = "0,00";
            this.TextMaskedit.SetTextMasked(this.txtValorTotal, ToolMasked.TextMask.Formats.Dinheiro);
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(109, 68);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorParcela.Size = new System.Drawing.Size(130, 20);
            this.txtValorParcela.TabIndex = 19;
            this.txtValorParcela.Text = "0,00";
            this.TextMaskedit.SetTextMasked(this.txtValorParcela, ToolMasked.TextMask.Formats.Dinheiro);
            this.txtValorParcela.Leave += new System.EventHandler(this.txtValorParcela_Leave);
            // 
            // txtQtdParcelas
            // 
            this.txtQtdParcelas.Location = new System.Drawing.Point(108, 94);
            this.txtQtdParcelas.Name = "txtQtdParcelas";
            this.txtQtdParcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQtdParcelas.Size = new System.Drawing.Size(54, 20);
            this.txtQtdParcelas.TabIndex = 19;
            this.txtQtdParcelas.Text = "0";
            this.TextMaskedit.SetTextMasked(this.txtQtdParcelas, ToolMasked.TextMask.Formats.Numero);
            this.txtQtdParcelas.Leave += new System.EventHandler(this.txtQtdParcelas_Leave);
            // 
            // txtIntervaloDias
            // 
            this.txtIntervaloDias.Location = new System.Drawing.Point(264, 94);
            this.txtIntervaloDias.Name = "txtIntervaloDias";
            this.txtIntervaloDias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIntervaloDias.Size = new System.Drawing.Size(54, 20);
            this.txtIntervaloDias.TabIndex = 19;
            this.txtIntervaloDias.Text = "0";
            this.TextMaskedit.SetTextMasked(this.txtIntervaloDias, ToolMasked.TextMask.Formats.Numero);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Valor Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valor por parcela:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Qtd. de Parcelas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Intervalo de Dias:";
            // 
            // gvParcelas
            // 
            this.gvParcelas.AllowUserToAddRows = false;
            this.gvParcelas.AllowUserToDeleteRows = false;
            this.gvParcelas.AllowUserToResizeColumns = false;
            this.gvParcelas.AllowUserToResizeRows = false;
            this.gvParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parcela,
            this.DataParcela,
            this.ValorParcela});
            this.gvParcelas.Location = new System.Drawing.Point(12, 120);
            this.gvParcelas.MultiSelect = false;
            this.gvParcelas.Name = "gvParcelas";
            this.gvParcelas.ReadOnly = true;
            this.gvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvParcelas.ShowEditingIcon = false;
            this.gvParcelas.ShowRowErrors = false;
            this.gvParcelas.Size = new System.Drawing.Size(380, 330);
            this.gvParcelas.TabIndex = 18;
            // 
            // Parcela
            // 
            this.Parcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Parcela.DataPropertyName = "Parcela";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Parcela.DefaultCellStyle = dataGridViewCellStyle1;
            this.Parcela.HeaderText = "Parcela";
            this.Parcela.Name = "Parcela";
            this.Parcela.ReadOnly = true;
            // 
            // DataParcela
            // 
            this.DataParcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataParcela.DataPropertyName = "Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.DataParcela.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataParcela.HeaderText = "Data da Parcela";
            this.DataParcela.Name = "DataParcela";
            this.DataParcela.ReadOnly = true;
            // 
            // ValorParcela
            // 
            this.ValorParcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValorParcela.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ValorParcela.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorParcela.HeaderText = "Valor da Parcela";
            this.ValorParcela.Name = "ValorParcela";
            this.ValorParcela.ReadOnly = true;
            // 
            // btPreview
            // 
            this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPreview.Image = ((System.Drawing.Image)(resources.GetObject("btPreview.Image")));
            this.btPreview.Location = new System.Drawing.Point(295, 42);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(97, 23);
            this.btPreview.TabIndex = 20;
            this.btPreview.Text = "Previsualizar";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // frmFinanceiroContasPagarDuplicar
            // 
            this.AcceptButton = this.btPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 462);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.txtIntervaloDias);
            this.Controls.Add(this.txtQtdParcelas);
            this.Controls.Add(this.txtValorParcela);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.gvParcelas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(420, 500);
            this.MinimumSize = new System.Drawing.Size(420, 500);
            this.Name = "frmFinanceiroContasPagarDuplicar";
            this.Text = "Duplicar Contas a Pagar";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.ToolStripButton btFechar;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gvParcelas;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.TextBox txtValorParcela;
        private System.Windows.Forms.TextBox txtQtdParcelas;
        private System.Windows.Forms.TextBox txtIntervaloDias;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorParcela;
    }
}