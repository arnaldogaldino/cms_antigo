namespace cms.Modulos.Produto.Forms.Produto
{
    partial class frmProdutoFoto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btConcluir = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrdem = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLargura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btCarregarFoto = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textMasked = new ToolMasked.TextMask(this.components);
            this.txtTamanho = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btCarregarFoto);
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Controls.Add(this.btConcluir);
            this.panel1.Location = new System.Drawing.Point(12, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 29);
            this.panel1.TabIndex = 0;
            // 
            // btConcluir
            // 
            this.btConcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btConcluir.Location = new System.Drawing.Point(203, 3);
            this.btConcluir.Name = "btConcluir";
            this.btConcluir.Size = new System.Drawing.Size(116, 23);
            this.btConcluir.TabIndex = 0;
            this.btConcluir.Text = "Concluir";
            this.btConcluir.UseVisualStyleBackColor = true;
            this.btConcluir.Click += new System.EventHandler(this.btConcluir_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCancelar.Location = new System.Drawing.Point(325, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(116, 23);
            this.btCancelar.TabIndex = 0;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.White;
            this.imgFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgFoto.Location = new System.Drawing.Point(13, 13);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(100, 97);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFoto.TabIndex = 1;
            this.imgFoto.TabStop = false;
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.AutoSize = true;
            this.chkPrincipal.Location = new System.Drawing.Point(120, 20);
            this.chkPrincipal.Name = "chkPrincipal";
            this.chkPrincipal.Size = new System.Drawing.Size(90, 17);
            this.chkPrincipal.TabIndex = 2;
            this.chkPrincipal.Text = "Foto Principal";
            this.chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ordem:";
            // 
            // txtOrdem
            // 
            this.txtOrdem.Location = new System.Drawing.Point(166, 41);
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrdem.Size = new System.Drawing.Size(44, 20);
            this.txtOrdem.TabIndex = 4;
            this.txtOrdem.Text = "0";
            this.textMasked.SetTextMasked(this.txtOrdem, ToolMasked.TextMask.Formats.Numero);
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(162, 84);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.ReadOnly = true;
            this.txtAltura.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAltura.Size = new System.Drawing.Size(61, 20);
            this.txtAltura.TabIndex = 4;
            this.txtAltura.Text = "0";
            this.textMasked.SetTextMasked(this.txtAltura, ToolMasked.TextMask.Formats.None);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tamanho:";
            // 
            // txtLargura
            // 
            this.txtLargura.Location = new System.Drawing.Point(281, 84);
            this.txtLargura.Name = "txtLargura";
            this.txtLargura.ReadOnly = true;
            this.txtLargura.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLargura.Size = new System.Drawing.Size(61, 20);
            this.txtLargura.TabIndex = 4;
            this.txtLargura.Text = "0";
            this.textMasked.SetTextMasked(this.txtLargura, ToolMasked.TextMask.Formats.None);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Altura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Largura:";
            // 
            // btCarregarFoto
            // 
            this.btCarregarFoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCarregarFoto.Location = new System.Drawing.Point(81, 3);
            this.btCarregarFoto.Name = "btCarregarFoto";
            this.btCarregarFoto.Size = new System.Drawing.Size(116, 23);
            this.btCarregarFoto.TabIndex = 0;
            this.btCarregarFoto.Text = "Carregar Foto";
            this.btCarregarFoto.UseVisualStyleBackColor = true;
            this.btCarregarFoto.Click += new System.EventHandler(this.btCarregarFoto_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // textMasked
            // 
            this.textMasked.Text = null;
            // 
            // txtTamanho
            // 
            this.txtTamanho.Location = new System.Drawing.Point(348, 84);
            this.txtTamanho.Name = "txtTamanho";
            this.txtTamanho.ReadOnly = true;
            this.txtTamanho.Size = new System.Drawing.Size(79, 20);
            this.txtTamanho.TabIndex = 4;
            this.txtTamanho.Text = "0 Kb";
            this.txtTamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMasked.SetTextMasked(this.txtTamanho, ToolMasked.TextMask.Formats.None);
            // 
            // frmProdutoFoto
            // 
            this.AcceptButton = this.btConcluir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 157);
            this.ControlBox = false;
            this.Controls.Add(this.txtTamanho);
            this.Controls.Add(this.txtLargura);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtOrdem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPrincipal);
            this.Controls.Add(this.imgFoto);
            this.Controls.Add(this.panel1);
            this.Name = "frmProdutoFoto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carregar Fotos";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btConcluir;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.PictureBox imgFoto;
        private ToolMasked.TextMask textMasked;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrdem;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLargura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCarregarFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtTamanho;
    }
}