namespace cms.Modulos.Cliente.Forms
{
    partial class frmClienteContatoLockup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvContato = new System.Windows.Forms.DataGridView();
            this.colIdClienteContato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextel_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_cadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContato)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOk,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(968, 39);
            this.tsMenu.TabIndex = 16;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btOk
            // 
            this.btOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOk.Image = global::cms.Properties.Resources.ok;
            this.btOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(36, 36);
            this.btOk.Text = "Selecionar Contato de Cliente";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 49);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisa de contatos";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(54, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(346, 20);
            this.txtCliente.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // gvContato
            // 
            this.gvContato.AllowUserToAddRows = false;
            this.gvContato.AllowUserToDeleteRows = false;
            this.gvContato.AllowUserToResizeColumns = false;
            this.gvContato.AllowUserToResizeRows = false;
            this.gvContato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvContato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdClienteContato,
            this.nome,
            this.cargo,
            this.descricao,
            this.email,
            this.telefone,
            this.celular,
            this.nextel,
            this.nextel_id,
            this.data_cadastro});
            this.gvContato.Location = new System.Drawing.Point(12, 104);
            this.gvContato.MultiSelect = false;
            this.gvContato.Name = "gvContato";
            this.gvContato.ReadOnly = true;
            this.gvContato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvContato.ShowEditingIcon = false;
            this.gvContato.ShowRowErrors = false;
            this.gvContato.Size = new System.Drawing.Size(944, 126);
            this.gvContato.TabIndex = 44;
            this.gvContato.DoubleClick += new System.EventHandler(this.gvContato_DoubleClick);
            // 
            // colIdClienteContato
            // 
            this.colIdClienteContato.DataPropertyName = "id_cliente_contato";
            this.colIdClienteContato.HeaderText = "id_cliente_contato";
            this.colIdClienteContato.Name = "colIdClienteContato";
            this.colIdClienteContato.ReadOnly = true;
            this.colIdClienteContato.Visible = false;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome.DataPropertyName = "nome";
            this.nome.FillWeight = 150F;
            this.nome.HeaderText = "Nome";
            this.nome.MinimumWidth = 140;
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "cargo";
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 150;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "E-Mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // telefone
            // 
            this.telefone.DataPropertyName = "telefone";
            this.telefone.HeaderText = "Telefone";
            this.telefone.Name = "telefone";
            this.telefone.ReadOnly = true;
            // 
            // celular
            // 
            this.celular.DataPropertyName = "celular";
            this.celular.HeaderText = "Celular";
            this.celular.Name = "celular";
            this.celular.ReadOnly = true;
            // 
            // nextel
            // 
            this.nextel.DataPropertyName = "nextel";
            this.nextel.HeaderText = "Nextel";
            this.nextel.Name = "nextel";
            this.nextel.ReadOnly = true;
            // 
            // nextel_id
            // 
            this.nextel_id.DataPropertyName = "nextel_id";
            this.nextel_id.HeaderText = "ID";
            this.nextel_id.Name = "nextel_id";
            this.nextel_id.ReadOnly = true;
            // 
            // data_cadastro
            // 
            this.data_cadastro.DataPropertyName = "data_cadastro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.data_cadastro.DefaultCellStyle = dataGridViewCellStyle5;
            this.data_cadastro.HeaderText = "Data Cadastro";
            this.data_cadastro.Name = "data_cadastro";
            this.data_cadastro.ReadOnly = true;
            // 
            // frmClienteContatoLockup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 242);
            this.Controls.Add(this.gvContato);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmClienteContatoLockup";
            this.Text = "Pesquisa de contatos de cliente";
            this.Load += new System.EventHandler(this.frmClienteContatoLockup_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DataGridView gvContato;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdClienteContato;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextel_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_cadastro;
    }
}