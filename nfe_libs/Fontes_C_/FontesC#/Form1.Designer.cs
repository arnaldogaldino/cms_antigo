namespace DemoNFeUtil
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tbChave = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Versao";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Certificado";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(443, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 33);
            this.button3.TabIndex = 2;
            this.button3.Text = "Consulta Status";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbChave
            // 
            this.tbChave.Location = new System.Drawing.Point(12, 211);
            this.tbChave.Name = "tbChave";
            this.tbChave.Size = new System.Drawing.Size(382, 20);
            this.tbChave.TabIndex = 4;
            this.tbChave.Text = "35081199999090910270550010000000017260299152";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(443, 198);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 33);
            this.button5.TabIndex = 5;
            this.button5.Text = "Consulta Status NFe";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 393);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tbChave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbChave;
        private System.Windows.Forms.Button button5;
    }
}

