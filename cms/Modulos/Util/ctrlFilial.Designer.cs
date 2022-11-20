namespace cms.Modulos.Util
{
    partial class ctrlFilial
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
            this.cbFilial = new System.Windows.Forms.ComboBox();
            this.lblFilial = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbFilial
            // 
            this.cbFilial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilial.DisplayMember = "display";
            this.cbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilial.Location = new System.Drawing.Point(39, 0);
            this.cbFilial.Name = "cbFilial";
            this.cbFilial.Size = new System.Drawing.Size(172, 21);
            this.cbFilial.TabIndex = 17;
            this.cbFilial.ValueMember = "value";
            this.cbFilial.SelectedValueChanged += new System.EventHandler(this.cbFilial_SelectedValueChanged);
            // 
            // lblFilial
            // 
            this.lblFilial.AutoSize = true;
            this.lblFilial.Location = new System.Drawing.Point(0, 3);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(30, 13);
            this.lblFilial.TabIndex = 16;
            this.lblFilial.Text = "Filial:";
            // 
            // ctrlFilial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbFilial);
            this.Controls.Add(this.lblFilial);
            this.Name = "ctrlFilial";
            this.Size = new System.Drawing.Size(211, 21);
            this.Load += new System.EventHandler(this.ctrlFilial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFilial;
        private System.Windows.Forms.Label lblFilial;
    }
}
