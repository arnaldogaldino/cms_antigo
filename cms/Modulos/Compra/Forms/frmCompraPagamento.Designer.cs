namespace cms.Modulos.Compra.Forms
{
    partial class frmCompraPagamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btCondicoesPagamento = new System.Windows.Forms.Button();
            this.gvPagamentos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCondicoesPagamento = new System.Windows.Forms.TextBox();
            this.txtTotalParcelas = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObservacaoComprador = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colIdCompraPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdFinanceiroContaPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdFinanceiroFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContaPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaPagamento = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagamentos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btCondicoesPagamento);
            this.groupBox2.Controls.Add(this.gvPagamentos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCondicoesPagamento);
            this.groupBox2.Controls.Add(this.txtTotalParcelas);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Location = new System.Drawing.Point(13, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 375);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condições de Pagamentos";
            // 
            // btCondicoesPagamento
            // 
            this.btCondicoesPagamento.FlatAppearance.BorderSize = 0;
            this.btCondicoesPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCondicoesPagamento.Image = global::cms.Properties.Resources.procurar;
            this.btCondicoesPagamento.Location = new System.Drawing.Point(486, 16);
            this.btCondicoesPagamento.Name = "btCondicoesPagamento";
            this.btCondicoesPagamento.Size = new System.Drawing.Size(22, 22);
            this.btCondicoesPagamento.TabIndex = 14;
            this.btCondicoesPagamento.UseVisualStyleBackColor = true;
            this.btCondicoesPagamento.Click += new System.EventHandler(this.btCondicoesPagamento_Click);
            // 
            // gvPagamentos
            // 
            this.gvPagamentos.AllowUserToAddRows = false;
            this.gvPagamentos.AllowUserToDeleteRows = false;
            this.gvPagamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPagamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompraPagamento,
            this.colIdCompra,
            this.colIdFinanceiroContaPagar,
            this.colIdFinanceiroFormaPagamento,
            this.colContaPagar,
            this.colFormaPagamento,
            this.colNumeroDocumento,
            this.colValor,
            this.colDataVencimento});
            this.gvPagamentos.Location = new System.Drawing.Point(8, 44);
            this.gvPagamentos.MultiSelect = false;
            this.gvPagamentos.Name = "gvPagamentos";
            this.gvPagamentos.Size = new System.Drawing.Size(874, 325);
            this.gvPagamentos.TabIndex = 0;
            this.gvPagamentos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPagamentos_CellEndEdit);
            this.gvPagamentos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvPagamentos_CellValidating);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(699, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Valor Total Parcelas:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Condições de Pagamento:";
            // 
            // txtCondicoesPagamento
            // 
            this.txtCondicoesPagamento.Location = new System.Drawing.Point(143, 18);
            this.txtCondicoesPagamento.Name = "txtCondicoesPagamento";
            this.txtCondicoesPagamento.ReadOnly = true;
            this.txtCondicoesPagamento.Size = new System.Drawing.Size(337, 20);
            this.txtCondicoesPagamento.TabIndex = 10;
            this.txtCondicoesPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicoesPagamento_KeyDown);
            // 
            // txtTotalParcelas
            // 
            this.txtTotalParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalParcelas.Location = new System.Drawing.Point(810, 16);
            this.txtTotalParcelas.MaxLength = 10;
            this.txtTotalParcelas.Name = "txtTotalParcelas";
            this.txtTotalParcelas.ReadOnly = true;
            this.txtTotalParcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalParcelas.Size = new System.Drawing.Size(72, 20);
            this.txtTotalParcelas.TabIndex = 10;
            this.txtTotalParcelas.Text = "0,00";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(621, 16);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(72, 20);
            this.txtTotal.TabIndex = 10;
            this.txtTotal.Text = "0,00";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtObservacaoComprador);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFornecedor);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDataCadastro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 113);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compra";
            // 
            // txtObservacaoComprador
            // 
            this.txtObservacaoComprador.Location = new System.Drawing.Point(368, 45);
            this.txtObservacaoComprador.Multiline = true;
            this.txtObservacaoComprador.Name = "txtObservacaoComprador";
            this.txtObservacaoComprador.ReadOnly = true;
            this.txtObservacaoComprador.Size = new System.Drawing.Size(200, 60);
            this.txtObservacaoComprador.TabIndex = 10;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(80, 45);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ReadOnly = true;
            this.txtObservacao.Size = new System.Drawing.Size(200, 60);
            this.txtObservacao.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fornecedor:";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(393, 19);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(337, 20);
            this.txtFornecedor.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(286, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 26);
            this.label11.TabIndex = 0;
            this.label11.Text = "Observação \r\ndo Comprador:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Observação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Cadastro:";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Location = new System.Drawing.Point(245, 19);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(72, 20);
            this.txtDataCadastro.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // colIdCompraPagamento
            // 
            this.colIdCompraPagamento.DataPropertyName = "id_compra_pagamento";
            this.colIdCompraPagamento.HeaderText = "id_compra_pagamento";
            this.colIdCompraPagamento.Name = "colIdCompraPagamento";
            this.colIdCompraPagamento.Visible = false;
            // 
            // colIdCompra
            // 
            this.colIdCompra.DataPropertyName = "id_compra";
            this.colIdCompra.HeaderText = "id_compra";
            this.colIdCompra.Name = "colIdCompra";
            this.colIdCompra.Visible = false;
            // 
            // colIdFinanceiroContaPagar
            // 
            this.colIdFinanceiroContaPagar.DataPropertyName = "id_financeiro_conta_pagar";
            this.colIdFinanceiroContaPagar.HeaderText = "id_financeiro_conta_pagar";
            this.colIdFinanceiroContaPagar.Name = "colIdFinanceiroContaPagar";
            this.colIdFinanceiroContaPagar.Visible = false;
            // 
            // colIdFinanceiroFormaPagamento
            // 
            this.colIdFinanceiroFormaPagamento.DataPropertyName = "id_financeiro_forma_pagamento";
            this.colIdFinanceiroFormaPagamento.HeaderText = "id_forma_pagamento";
            this.colIdFinanceiroFormaPagamento.Name = "colIdFinanceiroFormaPagamento";
            this.colIdFinanceiroFormaPagamento.Visible = false;
            // 
            // colContaPagar
            // 
            this.colContaPagar.DataPropertyName = "id_financeiro_conta_pagar";
            this.colContaPagar.HeaderText = "Código";
            this.colContaPagar.Name = "colContaPagar";
            this.colContaPagar.ReadOnly = true;
            this.colContaPagar.Width = 120;
            // 
            // colFormaPagamento
            // 
            this.colFormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormaPagamento.HeaderText = "Forma de Pagamento";
            this.colFormaPagamento.Name = "colFormaPagamento";
            this.colFormaPagamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFormaPagamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colNumeroDocumento
            // 
            this.colNumeroDocumento.DataPropertyName = "numero_documento";
            this.colNumeroDocumento.HeaderText = "Num. Doc.";
            this.colNumeroDocumento.Name = "colNumeroDocumento";
            this.colNumeroDocumento.Width = 130;
            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0,00";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.Width = 130;
            // 
            // colDataVencimento
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colDataVencimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataVencimento.HeaderText = "Data Vencimento";
            this.colDataVencimento.Name = "colDataVencimento";
            this.colDataVencimento.Width = 130;
            // 
            // frmCompraPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCompraPagamento";
            this.Text = "Condições de pagamento da compra.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCompraPagamento_FormClosing);
            this.Load += new System.EventHandler(this.frmCompraPagamento_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagamentos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservacaoComprador;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCondicoesPagamento;
        private System.Windows.Forms.Button btCondicoesPagamento;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalParcelas;
        private System.Windows.Forms.DataGridView gvPagamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompraPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFinanceiroContaPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFinanceiroFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContaPagar;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVencimento;
    }
}