namespace cms.Modulos.Util
{
    partial class Lockup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btLockup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(0, 0);
            this.txtID.Margin = new System.Windows.Forms.Padding(0);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.AcceptsReturn = true;
            this.txtDescricao.AcceptsTab = true;
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDescricao.Location = new System.Drawing.Point(56, 0);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(219, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // btLockup
            // 
            this.btLockup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLockup.FlatAppearance.BorderSize = 0;
            this.btLockup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLockup.Image = global::cms.Properties.Resources.procurar;
            this.btLockup.Location = new System.Drawing.Point(281, 0);
            this.btLockup.Name = "btLockup";
            this.btLockup.Size = new System.Drawing.Size(20, 20);
            this.btLockup.TabIndex = 10;
            this.btLockup.UseVisualStyleBackColor = true;
            // 
            // Lockup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btLockup);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtID);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Lockup";
            this.Size = new System.Drawing.Size(306, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btLockup;
    }
}
