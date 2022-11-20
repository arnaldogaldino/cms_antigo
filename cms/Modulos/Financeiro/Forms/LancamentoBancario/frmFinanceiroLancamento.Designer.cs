namespace cms.Modulos.Financeiro.Forms.LancamentoBancario
{
    partial class frmFinanceiroLancamento
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
            this.lbFormaPagamento = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btEditar = new System.Windows.Forms.ToolStripButton();
            this.btExcluir = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btContaPagar = new System.Windows.Forms.ToolStripButton();
            this.btContaReceber = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtDataLancamento = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValorDebito = new System.Windows.Forms.TextBox();
            this.txtValorCredito = new System.Windows.Forms.TextBox();
            this.ValidarForm = new System.Windows.Forms.ToolTip(this.components);
            this.gbLancamento = new System.Windows.Forms.GroupBox();
            this.dtaDataConciliado = new System.Windows.Forms.DateTimePicker();
            this.btContaCorrente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDataLancamento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbValorDebito = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbContaCorrente = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ctrlFilial = new cms.Modulos.Util.ctrlFilial();
            this.lbFormaPagamento.SuspendLayout();
            this.gbLancamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFormaPagamento
            // 
            this.lbFormaPagamento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btEditar,
            this.btExcluir,
            this.btGravar,
            this.btCancelar,
            this.toolStripSeparator1,
            this.btContaPagar,
            this.btContaReceber,
            this.toolStripSeparator2,
            this.btFechar});
            this.lbFormaPagamento.Location = new System.Drawing.Point(0, 0);
            this.lbFormaPagamento.Name = "lbFormaPagamento";
            this.lbFormaPagamento.Size = new System.Drawing.Size(645, 39);
            this.lbFormaPagamento.TabIndex = 38;
            this.lbFormaPagamento.Text = "toolStrip1";
            // 
            // btNovo
            // 
            this.btNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btNovo.Image = global::cms.Properties.Resources.novo;
            this.btNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(36, 36);
            this.btNovo.Text = "Novo Lançamento Bancario";
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
            this.btEditar.Text = "Editar Lançamento Bancario";
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
            this.btExcluir.Text = "Excluir Lançamento Bancario";
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
            this.btGravar.Text = "Gravar Lançamento Bancario";
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
            // btContaPagar
            // 
            this.btContaPagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btContaPagar.Image = global::cms.Properties.Resources.contas_pagar;
            this.btContaPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btContaPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btContaPagar.Name = "btContaPagar";
            this.btContaPagar.Size = new System.Drawing.Size(36, 36);
            this.btContaPagar.Text = "Abrir Conta a Pagar";
            this.btContaPagar.Click += new System.EventHandler(this.btContaPagar_Click);
            // 
            // btContaReceber
            // 
            this.btContaReceber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btContaReceber.Image = global::cms.Properties.Resources.contas_receber;
            this.btContaReceber.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btContaReceber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btContaReceber.Name = "btContaReceber";
            this.btContaReceber.Size = new System.Drawing.Size(36, 36);
            this.btContaReceber.Text = "Abrir Conta a Receber";
            this.btContaReceber.Click += new System.EventHandler(this.btContaReceber_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
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
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(55, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(64, 20);
            this.txtCodigo.TabIndex = 0;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.Location = new System.Drawing.Point(93, 45);
            this.txtContaCorrente.MaxLength = 50;
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.ReadOnly = true;
            this.txtContaCorrente.Size = new System.Drawing.Size(204, 20);
            this.txtContaCorrente.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtContaCorrente, ToolMasked.TextMask.Formats.None);
            this.txtContaCorrente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContaCorrente_KeyDown);
            // 
            // txtDataLancamento
            // 
            this.txtDataLancamento.Location = new System.Drawing.Point(226, 19);
            this.txtDataLancamento.MaxLength = 10;
            this.txtDataLancamento.Name = "txtDataLancamento";
            this.txtDataLancamento.ReadOnly = true;
            this.txtDataLancamento.Size = new System.Drawing.Size(71, 20);
            this.txtDataLancamento.TabIndex = 0;
            this.TextMaskedit.SetTextMasked(this.txtDataLancamento, ToolMasked.TextMask.Formats.None);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(70, 71);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(290, 20);
            this.txtDescricao.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtDescricao, ToolMasked.TextMask.Formats.None);
            // 
            // txtValorDebito
            // 
            this.txtValorDebito.Location = new System.Drawing.Point(95, 97);
            this.txtValorDebito.MaxLength = 50;
            this.txtValorDebito.Name = "txtValorDebito";
            this.txtValorDebito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorDebito.Size = new System.Drawing.Size(92, 20);
            this.txtValorDebito.TabIndex = 2;
            this.txtValorDebito.Text = "0,00";
            this.TextMaskedit.SetTextMasked(this.txtValorDebito, ToolMasked.TextMask.Formats.Dinheiro);
            // 
            // txtValorCredito
            // 
            this.txtValorCredito.Location = new System.Drawing.Point(284, 97);
            this.txtValorCredito.MaxLength = 50;
            this.txtValorCredito.Name = "txtValorCredito";
            this.txtValorCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorCredito.Size = new System.Drawing.Size(92, 20);
            this.txtValorCredito.TabIndex = 2;
            this.txtValorCredito.Text = "0,00";
            this.TextMaskedit.SetTextMasked(this.txtValorCredito, ToolMasked.TextMask.Formats.Dinheiro);
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
            // gbLancamento
            // 
            this.gbLancamento.Controls.Add(this.ctrlFilial);
            this.gbLancamento.Controls.Add(this.dtaDataConciliado);
            this.gbLancamento.Controls.Add(this.btContaCorrente);
            this.gbLancamento.Controls.Add(this.txtValorCredito);
            this.gbLancamento.Controls.Add(this.txtValorDebito);
            this.gbLancamento.Controls.Add(this.txtDescricao);
            this.gbLancamento.Controls.Add(this.txtContaCorrente);
            this.gbLancamento.Controls.Add(this.label1);
            this.gbLancamento.Controls.Add(this.lbDataLancamento);
            this.gbLancamento.Controls.Add(this.label3);
            this.gbLancamento.Controls.Add(this.lbValorDebito);
            this.gbLancamento.Controls.Add(this.label2);
            this.gbLancamento.Controls.Add(this.lbContaCorrente);
            this.gbLancamento.Controls.Add(this.lbCodigo);
            this.gbLancamento.Controls.Add(this.txtDataLancamento);
            this.gbLancamento.Controls.Add(this.txtCodigo);
            this.gbLancamento.Location = new System.Drawing.Point(12, 42);
            this.gbLancamento.Name = "gbLancamento";
            this.gbLancamento.Size = new System.Drawing.Size(621, 129);
            this.gbLancamento.TabIndex = 39;
            this.gbLancamento.TabStop = false;
            this.gbLancamento.Text = "Lançamento Bancario";
            // 
            // dtaDataConciliado
            // 
            this.dtaDataConciliado.Checked = false;
            this.dtaDataConciliado.CustomFormat = "dd/MM/yyyy";
            this.dtaDataConciliado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaDataConciliado.Location = new System.Drawing.Point(422, 45);
            this.dtaDataConciliado.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtaDataConciliado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtaDataConciliado.Name = "dtaDataConciliado";
            this.dtaDataConciliado.ShowCheckBox = true;
            this.dtaDataConciliado.Size = new System.Drawing.Size(112, 20);
            this.dtaDataConciliado.TabIndex = 11;
            this.dtaDataConciliado.Value = new System.DateTime(2010, 10, 7, 0, 0, 0, 0);
            // 
            // btContaCorrente
            // 
            this.btContaCorrente.FlatAppearance.BorderSize = 0;
            this.btContaCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContaCorrente.Image = global::cms.Properties.Resources.procurar;
            this.btContaCorrente.Location = new System.Drawing.Point(303, 43);
            this.btContaCorrente.Name = "btContaCorrente";
            this.btContaCorrente.Size = new System.Drawing.Size(22, 22);
            this.btContaCorrente.TabIndex = 10;
            this.btContaCorrente.UseVisualStyleBackColor = true;
            this.btContaCorrente.Click += new System.EventHandler(this.btContaCorrente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Conciliado:";
            // 
            // lbDataLancamento
            // 
            this.lbDataLancamento.AutoSize = true;
            this.lbDataLancamento.Location = new System.Drawing.Point(125, 22);
            this.lbDataLancamento.Name = "lbDataLancamento";
            this.lbDataLancamento.Size = new System.Drawing.Size(95, 13);
            this.lbDataLancamento.TabIndex = 1;
            this.lbDataLancamento.Text = "Data Lançamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Valor do Crédito:";
            // 
            // lbValorDebito
            // 
            this.lbValorDebito.AutoSize = true;
            this.lbValorDebito.Location = new System.Drawing.Point(6, 100);
            this.lbValorDebito.Name = "lbValorDebito";
            this.lbValorDebito.Size = new System.Drawing.Size(83, 13);
            this.lbValorDebito.TabIndex = 1;
            this.lbValorDebito.Text = "Valor do Débito:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição:";
            // 
            // lbContaCorrente
            // 
            this.lbContaCorrente.AutoSize = true;
            this.lbContaCorrente.Location = new System.Drawing.Point(6, 48);
            this.lbContaCorrente.Name = "lbContaCorrente";
            this.lbContaCorrente.Size = new System.Drawing.Size(81, 13);
            this.lbContaCorrente.TabIndex = 1;
            this.lbContaCorrente.Text = "Conta Corrente:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(6, 22);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(43, 13);
            this.lbCodigo.TabIndex = 1;
            this.lbCodigo.Text = "Código:";
            // 
            // ctrlFilial
            // 
            this.ctrlFilial.LabelSelecione = false;
            this.ctrlFilial.Location = new System.Drawing.Point(303, 19);
            this.ctrlFilial.Name = "ctrlFilial";
            this.ctrlFilial.SelectedDefault = true;
            this.ctrlFilial.Size = new System.Drawing.Size(211, 21);
            this.ctrlFilial.TabIndex = 12;
            // 
            // frmFinanceiroLancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 262);
            this.Controls.Add(this.gbLancamento);
            this.Controls.Add(this.lbFormaPagamento);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFinanceiroLancamento";
            this.Text = "Lançamento Bancario";
            this.Load += new System.EventHandler(this.frmFinanceiroLancamento_Load);
            this.lbFormaPagamento.ResumeLayout(false);
            this.lbFormaPagamento.PerformLayout();
            this.gbLancamento.ResumeLayout(false);
            this.gbLancamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip lbFormaPagamento;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStripButton btEditar;
        private System.Windows.Forms.ToolStripButton btExcluir;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btFechar;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.ToolTip ValidarForm;
        private System.Windows.Forms.GroupBox gbLancamento;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbDataLancamento;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.Label lbContaCorrente;
        private System.Windows.Forms.Button btContaCorrente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataLancamento;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorDebito;
        private System.Windows.Forms.TextBox txtValorCredito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbValorDebito;
        private System.Windows.Forms.DateTimePicker dtaDataConciliado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btContaReceber;
        private System.Windows.Forms.ToolStripButton btContaPagar;
        private Util.ctrlFilial ctrlFilial;
    }
}