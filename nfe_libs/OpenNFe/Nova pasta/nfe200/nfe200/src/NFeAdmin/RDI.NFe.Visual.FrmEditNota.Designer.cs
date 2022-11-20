namespace RDI.NFe.Visual
{
    partial class FrmEditNota
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
            this.label8 = new System.Windows.Forms.Label();
            this.btCancela = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvProcCancelamento = new System.Windows.Forms.TreeView();
            this.label13 = new System.Windows.Forms.Label();
            this.tvXmlCancelamento = new System.Windows.Forms.TreeView();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txnProtCanc = new System.Windows.Forms.TextBox();
            this.tbProcFinal = new System.Windows.Forms.TextBox();
            this.tvProcFinal = new System.Windows.Forms.TreeView();
            this.label10 = new System.Windows.Forms.Label();
            this.txcStat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txxMotivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txnProt = new System.Windows.Forms.TextBox();
            this.tvXmlNota = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txDesSit = new System.Windows.Forms.TextBox();
            this.txDatSit = new System.Windows.Forms.TextBox();
            this.txCodSit = new System.Windows.Forms.TextBox();
            this.txLote = new System.Windows.Forms.TextBox();
            this.txChaveNota = new System.Windows.Forms.TextBox();
            this.btGeraProcNFe = new System.Windows.Forms.Button();
            this.btDoCancel = new System.Windows.Forms.Button();
            this.btImprime = new System.Windows.Forms.Button();
            this.btRefreshId = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Xml da Nota";
            // 
            // btCancela
            // 
            this.btCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancela.Location = new System.Drawing.Point(736, 3);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(75, 44);
            this.btCancela.TabIndex = 1;
            this.btCancela.Text = "Fechar";
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Descrição da Situação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Data da Situação";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Código da Situação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Lote";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvProcCancelamento);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.tvXmlCancelamento);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.txnProtCanc);
            this.splitContainer1.Panel1.Controls.Add(this.tbProcFinal);
            this.splitContainer1.Panel1.Controls.Add(this.tvProcFinal);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.txcStat);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txxMotivo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txnProt);
            this.splitContainer1.Panel1.Controls.Add(this.tvXmlNota);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txDesSit);
            this.splitContainer1.Panel1.Controls.Add(this.txDatSit);
            this.splitContainer1.Panel1.Controls.Add(this.txCodSit);
            this.splitContainer1.Panel1.Controls.Add(this.txLote);
            this.splitContainer1.Panel1.Controls.Add(this.txChaveNota);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btRefreshId);
            this.splitContainer1.Panel2.Controls.Add(this.btGeraProcNFe);
            this.splitContainer1.Panel2.Controls.Add(this.btDoCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btImprime);
            this.splitContainer1.Panel2.Controls.Add(this.btCancela);
            this.splitContainer1.Size = new System.Drawing.Size(814, 570);
            this.splitContainer1.SplitterDistance = 514;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvProcCancelamento
            // 
            this.tvProcCancelamento.Location = new System.Drawing.Point(437, 333);
            this.tvProcCancelamento.Name = "tvProcCancelamento";
            this.tvProcCancelamento.Size = new System.Drawing.Size(363, 178);
            this.tvProcCancelamento.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(434, 314);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(172, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Xml do Processo de Cancelamento";
            // 
            // tvXmlCancelamento
            // 
            this.tvXmlCancelamento.Location = new System.Drawing.Point(437, 188);
            this.tvXmlCancelamento.Name = "tvXmlCancelamento";
            this.tvXmlCancelamento.Size = new System.Drawing.Size(363, 123);
            this.tvXmlCancelamento.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(434, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Xml da Cancelamento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(434, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Prot. Cancelamento";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txnProtCanc
            // 
            this.txnProtCanc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txnProtCanc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txnProtCanc.Location = new System.Drawing.Point(543, 138);
            this.txnProtCanc.MaxLength = 100;
            this.txnProtCanc.Name = "txnProtCanc";
            this.txnProtCanc.ReadOnly = true;
            this.txnProtCanc.Size = new System.Drawing.Size(256, 20);
            this.txnProtCanc.TabIndex = 31;
            this.txnProtCanc.TextChanged += new System.EventHandler(this.txnProtCanc_TextChanged);
            // 
            // tbProcFinal
            // 
            this.tbProcFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbProcFinal.Location = new System.Drawing.Point(12, 333);
            this.tbProcFinal.MaxLength = 100;
            this.tbProcFinal.Multiline = true;
            this.tbProcFinal.Name = "tbProcFinal";
            this.tbProcFinal.Size = new System.Drawing.Size(380, 178);
            this.tbProcFinal.TabIndex = 30;
            this.tbProcFinal.Visible = false;
            // 
            // tvProcFinal
            // 
            this.tvProcFinal.Location = new System.Drawing.Point(12, 333);
            this.tvProcFinal.Name = "tvProcFinal";
            this.tvProcFinal.Size = new System.Drawing.Size(380, 178);
            this.tvProcFinal.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "cStat (SEFAZ)";
            // 
            // txcStat
            // 
            this.txcStat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txcStat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txcStat.Location = new System.Drawing.Point(129, 86);
            this.txcStat.MaxLength = 100;
            this.txcStat.Name = "txcStat";
            this.txcStat.ReadOnly = true;
            this.txcStat.Size = new System.Drawing.Size(302, 20);
            this.txcStat.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "xMotivo (SEFAZ)";
            // 
            // txxMotivo
            // 
            this.txxMotivo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txxMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txxMotivo.Location = new System.Drawing.Point(129, 112);
            this.txxMotivo.MaxLength = 100;
            this.txxMotivo.Name = "txxMotivo";
            this.txxMotivo.ReadOnly = true;
            this.txxMotivo.Size = new System.Drawing.Size(670, 20);
            this.txxMotivo.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Prot. de Autorização";
            // 
            // txnProt
            // 
            this.txnProt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txnProt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txnProt.Location = new System.Drawing.Point(129, 139);
            this.txnProt.MaxLength = 100;
            this.txnProt.Name = "txnProt";
            this.txnProt.ReadOnly = true;
            this.txnProt.Size = new System.Drawing.Size(302, 20);
            this.txnProt.TabIndex = 23;
            // 
            // tvXmlNota
            // 
            this.tvXmlNota.Location = new System.Drawing.Point(12, 188);
            this.tvXmlNota.Name = "tvXmlNota";
            this.tvXmlNota.Size = new System.Drawing.Size(380, 123);
            this.tvXmlNota.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Xml do Processo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chave da Nota";
            // 
            // txDesSit
            // 
            this.txDesSit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txDesSit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txDesSit.Location = new System.Drawing.Point(129, 60);
            this.txDesSit.MaxLength = 100;
            this.txDesSit.Name = "txDesSit";
            this.txDesSit.ReadOnly = true;
            this.txDesSit.Size = new System.Drawing.Size(670, 20);
            this.txDesSit.TabIndex = 6;
            // 
            // txDatSit
            // 
            this.txDatSit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txDatSit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txDatSit.Location = new System.Drawing.Point(543, 34);
            this.txDatSit.MaxLength = 100;
            this.txDatSit.Name = "txDatSit";
            this.txDatSit.ReadOnly = true;
            this.txDatSit.Size = new System.Drawing.Size(256, 20);
            this.txDatSit.TabIndex = 5;
            // 
            // txCodSit
            // 
            this.txCodSit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txCodSit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txCodSit.Location = new System.Drawing.Point(129, 34);
            this.txCodSit.MaxLength = 300;
            this.txCodSit.Name = "txCodSit";
            this.txCodSit.ReadOnly = true;
            this.txCodSit.Size = new System.Drawing.Size(302, 20);
            this.txCodSit.TabIndex = 4;
            // 
            // txLote
            // 
            this.txLote.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txLote.Location = new System.Drawing.Point(543, 8);
            this.txLote.MaxLength = 50;
            this.txLote.Name = "txLote";
            this.txLote.ReadOnly = true;
            this.txLote.Size = new System.Drawing.Size(256, 20);
            this.txLote.TabIndex = 3;
            // 
            // txChaveNota
            // 
            this.txChaveNota.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txChaveNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txChaveNota.Location = new System.Drawing.Point(129, 8);
            this.txChaveNota.MaxLength = 11;
            this.txChaveNota.Name = "txChaveNota";
            this.txChaveNota.ReadOnly = true;
            this.txChaveNota.Size = new System.Drawing.Size(302, 20);
            this.txChaveNota.TabIndex = 2;
            this.txChaveNota.Text = "NFE99999999999999999999999999999999999999999999";
            // 
            // btGeraProcNFe
            // 
            this.btGeraProcNFe.Location = new System.Drawing.Point(493, 3);
            this.btGeraProcNFe.Name = "btGeraProcNFe";
            this.btGeraProcNFe.Size = new System.Drawing.Size(75, 44);
            this.btGeraProcNFe.TabIndex = 5;
            this.btGeraProcNFe.Text = "Gerar ProcNFe";
            this.btGeraProcNFe.UseVisualStyleBackColor = true;
            this.btGeraProcNFe.Click += new System.EventHandler(this.btGeraProcNFe_Click);
            // 
            // btDoCancel
            // 
            this.btDoCancel.Location = new System.Drawing.Point(574, 3);
            this.btDoCancel.Name = "btDoCancel";
            this.btDoCancel.Size = new System.Drawing.Size(75, 44);
            this.btDoCancel.TabIndex = 3;
            this.btDoCancel.Text = "Cancelar Nota";
            this.btDoCancel.UseVisualStyleBackColor = true;
            this.btDoCancel.Click += new System.EventHandler(this.btDoCancel_Click);
            // 
            // btImprime
            // 
            this.btImprime.Location = new System.Drawing.Point(655, 3);
            this.btImprime.Name = "btImprime";
            this.btImprime.Size = new System.Drawing.Size(75, 44);
            this.btImprime.TabIndex = 2;
            this.btImprime.Text = "Imprimir";
            this.btImprime.UseVisualStyleBackColor = true;
            this.btImprime.Click += new System.EventHandler(this.btImprime_Click);
            // 
            // btRefreshId
            // 
            this.btRefreshId.Location = new System.Drawing.Point(412, 3);
            this.btRefreshId.Name = "btRefreshId";
            this.btRefreshId.Size = new System.Drawing.Size(75, 44);
            this.btRefreshId.TabIndex = 6;
            this.btRefreshId.Text = "Atualizar pelo NFe Id";
            this.btRefreshId.UseVisualStyleBackColor = true;
            this.btRefreshId.Visible = false;
            this.btRefreshId.Click += new System.EventHandler(this.btRefreshId_Click);
            // 
            // FrmEditNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancela;
            this.ClientSize = new System.Drawing.Size(814, 570);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditNota";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhamento de Nota Fiscal";
            this.Load += new System.EventHandler(this.FrmEditNota_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btCancela;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txDesSit;
        private System.Windows.Forms.TextBox txDatSit;
        private System.Windows.Forms.TextBox txCodSit;
        private System.Windows.Forms.TextBox txLote;
        private System.Windows.Forms.TextBox txChaveNota;
        private System.Windows.Forms.Button btImprime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvXmlNota;
        private System.Windows.Forms.Button btDoCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txcStat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txxMotivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txnProt;
        private System.Windows.Forms.TreeView tvProcFinal;
        private System.Windows.Forms.TextBox tbProcFinal;
        private System.Windows.Forms.Button btGeraProcNFe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txnProtCanc;
        private System.Windows.Forms.TreeView tvXmlCancelamento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TreeView tvProcCancelamento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btRefreshId;
    }
}