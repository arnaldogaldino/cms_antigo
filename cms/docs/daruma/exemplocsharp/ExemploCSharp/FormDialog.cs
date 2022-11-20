using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ExemploFiscal
{
	/// <summary>
	/// Summary description for FormDialog.
	/// </summary>
	public class FormDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TextBox textBoxRetorno;
		public System.Windows.Forms.Label LabelEditCaption;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.LabelEditCaption = new System.Windows.Forms.Label();
			this.textBoxRetorno = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.LabelEditCaption);
			this.panel1.Controls.Add(this.textBoxRetorno);
			this.panel1.Location = new System.Drawing.Point(0, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(352, 64);
			this.panel1.TabIndex = 0;
			// 
			// LabelEditCaption
			// 
			this.LabelEditCaption.Location = new System.Drawing.Point(16, 8);
			this.LabelEditCaption.Name = "LabelEditCaption";
			this.LabelEditCaption.Size = new System.Drawing.Size(280, 16);
			this.LabelEditCaption.TabIndex = 1;
			this.LabelEditCaption.Text = "label1";
			// 
			// textBoxRetorno
			// 
			this.textBoxRetorno.Location = new System.Drawing.Point(16, 27);
			this.textBoxRetorno.Name = "textBoxRetorno";
			this.textBoxRetorno.Size = new System.Drawing.Size(320, 20);
			this.textBoxRetorno.TabIndex = 0;
			this.textBoxRetorno.Text = "";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(76, 75);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "&OK";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(180, 74);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "&Cancelar";
			// 
			// FormDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 103);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormDialogs";
			this.Load += new System.EventHandler(this.FormDialog_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormDialog_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
