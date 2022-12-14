namespace cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento
{
    partial class frmFinanceiroCondicaoPagamentoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceiroCondicaoPagamentoList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvFinanceiroCondicaoPagamento = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btAtualizar = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcrecimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCompra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colVendaOrcameno = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWeb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPdv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroCondicaoPagamento)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvFinanceiroCondicaoPagamento
            // 
            this.gvFinanceiroCondicaoPagamento.AllowUserToAddRows = false;
            this.gvFinanceiroCondicaoPagamento.AllowUserToDeleteRows = false;
            this.gvFinanceiroCondicaoPagamento.AllowUserToResizeColumns = false;
            this.gvFinanceiroCondicaoPagamento.AllowUserToResizeRows = false;
            this.gvFinanceiroCondicaoPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFinanceiroCondicaoPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinanceiroCondicaoPagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colDescricao,
            this.colAcrecimo,
            this.ColCompra,
            this.colVendaOrcameno,
            this.colWeb,
            this.colPdv});
            this.gvFinanceiroCondicaoPagamento.Location = new System.Drawing.Point(12, 42);
            this.gvFinanceiroCondicaoPagamento.MultiSelect = false;
            this.gvFinanceiroCondicaoPagamento.Name = "gvFinanceiroCondicaoPagamento";
            this.gvFinanceiroCondicaoPagamento.ReadOnly = true;
            this.gvFinanceiroCondicaoPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFinanceiroCondicaoPagamento.ShowEditingIcon = false;
            this.gvFinanceiroCondicaoPagamento.ShowRowErrors = false;
            this.gvFinanceiroCondicaoPagamento.Size = new System.Drawing.Size(895, 342);
            this.gvFinanceiroCondicaoPagamento.TabIndex = 15;
            this.gvFinanceiroCondicaoPagamento.DoubleClick += new System.EventHandler(this.gvFinanceiroCondicaoPagamento_DoubleClick);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btAtualizar,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(919, 39);
            this.tsMenu.TabIndex = 14;
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
            this.btNovo.Text = "Nova Condição de Pagamento";
            this.btNovo.ToolTipText = "Nova Condição de Pagamento";
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btAtualizar
            // 
            this.btAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btAtualizar.Image")));
            this.btAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(36, 36);
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
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
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "id_financeiro_condicao_pagamento";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 90;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.DataPropertyName = "descricao";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            // 
            // colAcrecimo
            // 
            this.colAcrecimo.DataPropertyName = "acrecimo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colAcrecimo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAcrecimo.HeaderText = "Acrécimo";
            this.colAcrecimo.Name = "colAcrecimo";
            this.colAcrecimo.ReadOnly = true;
            this.colAcrecimo.Width = 90;
            // 
            // ColCompra
            // 
            this.ColCompra.DataPropertyName = "pedido_compra";
            this.ColCompra.HeaderText = "Compra";
            this.ColCompra.Name = "ColCompra";
            this.ColCompra.ReadOnly = true;
            this.ColCompra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCompra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCompra.Width = 90;
            // 
            // colVendaOrcameno
            // 
            this.colVendaOrcameno.DataPropertyName = "pedido_venda_orcamento";
            this.colVendaOrcameno.HeaderText = "Venda e Orçamento";
            this.colVendaOrcameno.Name = "colVendaOrcameno";
            this.colVendaOrcameno.ReadOnly = true;
            this.colVendaOrcameno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVendaOrcameno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colVendaOrcameno.Width = 120;
            // 
            // colWeb
            // 
            this.colWeb.DataPropertyName = "web";
            this.colWeb.HeaderText = "Web";
            this.colWeb.Name = "colWeb";
            this.colWeb.ReadOnly = true;
            this.colWeb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWeb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colWeb.Width = 90;
            // 
            // colPdv
            // 
            this.colPdv.DataPropertyName = "pdv";
            this.colPdv.HeaderText = "PDV";
            this.colPdv.Name = "colPdv";
            this.colPdv.ReadOnly = true;
            this.colPdv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPdv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPdv.Width = 90;
            // 
            // frmFinanceiroCondicaoPagamentoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 396);
            this.Controls.Add(this.gvFinanceiroCondicaoPagamento);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroCondicaoPagamentoList";
            this.Text = "Pesquisar Condições de Pagamentos.";
            this.Load += new System.EventHandler(this.frmFinanceiroCondicaoPagamentoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFinanceiroCondicaoPagamento)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btAtualizar;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridView gvFinanceiroCondicaoPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcrecimo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVendaOrcameno;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colWeb;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPdv;
    }
}