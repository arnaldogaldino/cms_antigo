namespace cms.Modulos.Util
{
    partial class frmErroException
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
            this.btEnviarEmail = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btEnviarEmail
            // 
            this.btEnviarEmail.Location = new System.Drawing.Point(12, 290);
            this.btEnviarEmail.Name = "btEnviarEmail";
            this.btEnviarEmail.Size = new System.Drawing.Size(164, 32);
            this.btEnviarEmail.TabIndex = 1;
            this.btEnviarEmail.Text = "&Enviar E-Mail";
            this.btEnviarEmail.UseVisualStyleBackColor = true;
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(251, 290);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(164, 32);
            this.btFechar.TabIndex = 2;
            this.btFechar.Text = "&Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // txtError
            // 
            this.txtError.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(8, 12);
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(403, 272);
            this.txtError.TabIndex = 3;
            this.txtError.Text = "";
            // 
            // frmErroException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 330);
            this.ControlBox = false;
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btEnviarEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmErroException";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMS - Exception";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEnviarEmail;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.RichTextBox txtError;
    }
}