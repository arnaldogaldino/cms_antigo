namespace cms.Modulos.Compra.Forms
{
    partial class frmCompraConferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompraConferencia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObservacaoConferencia = new System.Windows.Forms.TextBox();
            this.txtObservacaoComprador = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btConfirma = new System.Windows.Forms.Button();
            this.imgProduto = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalNaoConferido = new System.Windows.Forms.TextBox();
            this.txtTotalNaoAtendidos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalAtendidos = new System.Windows.Forms.TextBox();
            this.txtQtdRecebida = new System.Windows.Forms.TextBox();
            this.txtQtdSolicitada = new System.Windows.Forms.TextBox();
            this.txtTotalItens = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gvItens = new System.Windows.Forms.DataGridView();
            this.colIdCompraItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdSolicitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdRecebida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiferenca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextMasked = new ToolMasked.TextMask(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItens)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtObservacaoConferencia);
            this.groupBox1.Controls.Add(this.txtObservacaoComprador);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFornecedor);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDataCadastro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1291, 113);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compra";
            // 
            // txtObservacaoConferencia
            // 
            this.txtObservacaoConferencia.Location = new System.Drawing.Point(662, 45);
            this.txtObservacaoConferencia.Multiline = true;
            this.txtObservacaoConferencia.Name = "txtObservacaoConferencia";
            this.txtObservacaoConferencia.Size = new System.Drawing.Size(200, 60);
            this.txtObservacaoConferencia.TabIndex = 4;
            this.TextMasked.SetTextMasked(this.txtObservacaoConferencia, ToolMasked.TextMask.Formats.None);
            this.txtObservacaoConferencia.WordWrap = false;
            this.txtObservacaoConferencia.Leave += new System.EventHandler(this.txtObservacaoConferencia_Leave);
            // 
            // txtObservacaoComprador
            // 
            this.txtObservacaoComprador.Location = new System.Drawing.Point(368, 45);
            this.txtObservacaoComprador.Multiline = true;
            this.txtObservacaoComprador.Name = "txtObservacaoComprador";
            this.txtObservacaoComprador.ReadOnly = true;
            this.txtObservacaoComprador.Size = new System.Drawing.Size(200, 60);
            this.txtObservacaoComprador.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtObservacaoComprador, ToolMasked.TextMask.Formats.None);
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(80, 45);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ReadOnly = true;
            this.txtObservacao.Size = new System.Drawing.Size(200, 60);
            this.txtObservacao.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtObservacao, ToolMasked.TextMask.Formats.None);
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
            this.TextMasked.SetTextMasked(this.txtFornecedor, ToolMasked.TextMask.Formats.None);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Observação\r\nda Conferencia:";
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
            this.TextMasked.SetTextMasked(this.txtDataCadastro, ToolMasked.TextMask.Formats.None);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btConfirma);
            this.groupBox2.Controls.Add(this.imgProduto);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTotalNaoConferido);
            this.groupBox2.Controls.Add(this.txtTotalNaoAtendidos);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTotalAtendidos);
            this.groupBox2.Controls.Add(this.txtQtdRecebida);
            this.groupBox2.Controls.Add(this.txtQtdSolicitada);
            this.groupBox2.Controls.Add(this.txtTotalItens);
            this.groupBox2.Controls.Add(this.txtDescricao);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtCodigoBarras);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1291, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produto";
            // 
            // btConfirma
            // 
            this.btConfirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConfirma.Image = ((System.Drawing.Image)(resources.GetObject("btConfirma.Image")));
            this.btConfirma.Location = new System.Drawing.Point(662, 36);
            this.btConfirma.Name = "btConfirma";
            this.btConfirma.Size = new System.Drawing.Size(97, 23);
            this.btConfirma.TabIndex = 3;
            this.btConfirma.Text = "Confirma";
            this.btConfirma.UseVisualStyleBackColor = true;
            this.btConfirma.Click += new System.EventHandler(this.btConfirma_Click);
            // 
            // imgProduto
            // 
            this.imgProduto.Location = new System.Drawing.Point(798, 13);
            this.imgProduto.Name = "imgProduto";
            this.imgProduto.Size = new System.Drawing.Size(173, 98);
            this.imgProduto.TabIndex = 2;
            this.imgProduto.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Qtd. Recebida:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Qtd. Solicitada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Descrição:";
            // 
            // txtTotalNaoConferido
            // 
            this.txtTotalNaoConferido.Location = new System.Drawing.Point(1213, 91);
            this.txtTotalNaoConferido.MaxLength = 10;
            this.txtTotalNaoConferido.Name = "txtTotalNaoConferido";
            this.txtTotalNaoConferido.ReadOnly = true;
            this.txtTotalNaoConferido.Size = new System.Drawing.Size(72, 20);
            this.txtTotalNaoConferido.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtTotalNaoConferido, ToolMasked.TextMask.Formats.None);
            // 
            // txtTotalNaoAtendidos
            // 
            this.txtTotalNaoAtendidos.Location = new System.Drawing.Point(1213, 65);
            this.txtTotalNaoAtendidos.MaxLength = 10;
            this.txtTotalNaoAtendidos.Name = "txtTotalNaoAtendidos";
            this.txtTotalNaoAtendidos.ReadOnly = true;
            this.txtTotalNaoAtendidos.Size = new System.Drawing.Size(72, 20);
            this.txtTotalNaoAtendidos.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtTotalNaoAtendidos, ToolMasked.TextMask.Formats.None);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Código de Barras:";
            // 
            // txtTotalAtendidos
            // 
            this.txtTotalAtendidos.Location = new System.Drawing.Point(1213, 39);
            this.txtTotalAtendidos.MaxLength = 10;
            this.txtTotalAtendidos.Name = "txtTotalAtendidos";
            this.txtTotalAtendidos.ReadOnly = true;
            this.txtTotalAtendidos.Size = new System.Drawing.Size(72, 20);
            this.txtTotalAtendidos.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtTotalAtendidos, ToolMasked.TextMask.Formats.None);
            // 
            // txtQtdRecebida
            // 
            this.txtQtdRecebida.Location = new System.Drawing.Point(594, 39);
            this.txtQtdRecebida.Name = "txtQtdRecebida";
            this.txtQtdRecebida.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQtdRecebida.Size = new System.Drawing.Size(60, 20);
            this.txtQtdRecebida.TabIndex = 2;
            this.txtQtdRecebida.Text = "0,00";
            this.TextMasked.SetTextMasked(this.txtQtdRecebida, ToolMasked.TextMask.Formats.Dinheiro);
            this.txtQtdRecebida.Leave += new System.EventHandler(this.txtQtdRecebida_Leave);
            // 
            // txtQtdSolicitada
            // 
            this.txtQtdSolicitada.Location = new System.Drawing.Point(443, 39);
            this.txtQtdSolicitada.Name = "txtQtdSolicitada";
            this.txtQtdSolicitada.ReadOnly = true;
            this.txtQtdSolicitada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQtdSolicitada.Size = new System.Drawing.Size(60, 20);
            this.txtQtdSolicitada.TabIndex = 10;
            this.txtQtdSolicitada.Text = "0,00";
            this.TextMasked.SetTextMasked(this.txtQtdSolicitada, ToolMasked.TextMask.Formats.None);
            // 
            // txtTotalItens
            // 
            this.txtTotalItens.Location = new System.Drawing.Point(1213, 13);
            this.txtTotalItens.MaxLength = 10;
            this.txtTotalItens.Name = "txtTotalItens";
            this.txtTotalItens.ReadOnly = true;
            this.txtTotalItens.Size = new System.Drawing.Size(72, 20);
            this.txtTotalItens.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtTotalItens, ToolMasked.TextMask.Formats.None);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(70, 39);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(282, 20);
            this.txtDescricao.TabIndex = 10;
            this.TextMasked.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1060, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Total de itens não conferidos:";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(103, 13);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(177, 20);
            this.txtCodigoBarras.TabIndex = 1;
            this.TextMasked.SetTextMasked(this.txtCodigoBarras, ToolMasked.TextMask.Formats.None);
            this.txtCodigoBarras.Leave += new System.EventHandler(this.txtCodigoBarras_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1063, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Total de itens não atendidos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1133, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total de itens:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1084, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Total de itens atendidos:";
            // 
            // gvItens
            // 
            this.gvItens.AllowUserToAddRows = false;
            this.gvItens.AllowUserToDeleteRows = false;
            this.gvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompraItem,
            this.colIdProduto,
            this.colCodigo,
            this.colDescricao,
            this.colQtdSolicitada,
            this.colQtdRecebida,
            this.colDiferenca});
            this.gvItens.Location = new System.Drawing.Point(12, 254);
            this.gvItens.Name = "gvItens";
            this.gvItens.ReadOnly = true;
            this.gvItens.Size = new System.Drawing.Size(1291, 156);
            this.gvItens.TabIndex = 5;
            // 
            // colIdCompraItem
            // 
            this.colIdCompraItem.DataPropertyName = "id_compra_item";
            this.colIdCompraItem.HeaderText = "id_compra_item";
            this.colIdCompraItem.Name = "colIdCompraItem";
            this.colIdCompraItem.Visible = false;
            // 
            // colIdProduto
            // 
            this.colIdProduto.DataPropertyName = "id_produto";
            this.colIdProduto.HeaderText = "id_produto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "id_produto";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.DataPropertyName = "descricao";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            // 
            // colQtdSolicitada
            // 
            this.colQtdSolicitada.DataPropertyName = "quantidade_solicitada";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0,00";
            this.colQtdSolicitada.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQtdSolicitada.HeaderText = "Qtd Solicitada";
            this.colQtdSolicitada.Name = "colQtdSolicitada";
            this.colQtdSolicitada.ReadOnly = true;
            this.colQtdSolicitada.Width = 120;
            // 
            // colQtdRecebida
            // 
            this.colQtdRecebida.DataPropertyName = "quantidade_recebida";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0,00";
            this.colQtdRecebida.DefaultCellStyle = dataGridViewCellStyle8;
            this.colQtdRecebida.HeaderText = "Qtd Recebida";
            this.colQtdRecebida.Name = "colQtdRecebida";
            this.colQtdRecebida.ReadOnly = true;
            this.colQtdRecebida.Width = 120;
            // 
            // colDiferenca
            // 
            this.colDiferenca.DataPropertyName = "diferenca";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0,00";
            this.colDiferenca.DefaultCellStyle = dataGridViewCellStyle9;
            this.colDiferenca.HeaderText = "Diferença";
            this.colDiferenca.Name = "colDiferenca";
            this.colDiferenca.ReadOnly = true;
            // 
            // TextMasked
            // 
            this.TextMasked.Text = null;
            // 
            // frmCompraConferencia
            // 
            this.AcceptButton = this.btConfirma;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 422);
            this.Controls.Add(this.gvItens);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompraConferencia";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Conferencia itens de compra.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCompraConferencia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservacaoComprador;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacaoConferencia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvItens;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.PictureBox imgProduto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQtdSolicitada;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQtdRecebida;
        private System.Windows.Forms.Button btConfirma;
        private ToolMasked.TextMask TextMasked;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTotalNaoConferido;
        private System.Windows.Forms.TextBox txtTotalNaoAtendidos;
        private System.Windows.Forms.TextBox txtTotalAtendidos;
        private System.Windows.Forms.TextBox txtTotalItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompraItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdSolicitada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdRecebida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferenca;
    }
}