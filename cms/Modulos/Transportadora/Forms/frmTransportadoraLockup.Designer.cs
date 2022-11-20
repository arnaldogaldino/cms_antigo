namespace cms.Modulos.Transportadora.Forms
{
    partial class frmTransportadoraLockup
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
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btOk = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gvTransportadora = new System.Windows.Forms.DataGridView();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCnpj = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.lbRazaoSocial = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_razao_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpf_cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_estadual_rg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransportadora)).BeginInit();
            this.gbPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOk,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1031, 39);
            this.tsMenu.TabIndex = 15;
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
            this.btOk.Text = "Selecionar Cliente";
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
            // gvTransportadora
            // 
            this.gvTransportadora.AllowUserToAddRows = false;
            this.gvTransportadora.AllowUserToDeleteRows = false;
            this.gvTransportadora.AllowUserToResizeColumns = false;
            this.gvTransportadora.AllowUserToResizeRows = false;
            this.gvTransportadora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvTransportadora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTransportadora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nome_razao_social,
            this.tipo_pessoa,
            this.cpf_cnpj,
            this.i_estadual_rg,
            this.cidade,
            this.estado});
            this.gvTransportadora.Location = new System.Drawing.Point(12, 95);
            this.gvTransportadora.MultiSelect = false;
            this.gvTransportadora.Name = "gvTransportadora";
            this.gvTransportadora.ReadOnly = true;
            this.gvTransportadora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTransportadora.ShowEditingIcon = false;
            this.gvTransportadora.ShowRowErrors = false;
            this.gvTransportadora.Size = new System.Drawing.Size(1007, 236);
            this.gvTransportadora.TabIndex = 17;
            this.gvTransportadora.DoubleClick += new System.EventHandler(this.gvTransportadora_DoubleClick);
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtRG);
            this.gbPesquisa.Controls.Add(this.txtCnpj);
            this.gbPesquisa.Controls.Add(this.label1);
            this.gbPesquisa.Controls.Add(this.lbCnpj);
            this.gbPesquisa.Controls.Add(this.txtRazaoSocial);
            this.gbPesquisa.Controls.Add(this.lbRazaoSocial);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(1007, 47);
            this.gbPesquisa.TabIndex = 18;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Transportadora";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(57, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(59, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(9, 20);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(43, 13);
            this.lbCodigo.TabIndex = 5;
            this.lbCodigo.Text = "Código:";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPesquisar.Location = new System.Drawing.Point(904, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(772, 17);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(108, 20);
            this.txtRG.TabIndex = 4;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(626, 17);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(108, 20);
            this.txtCnpj.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(740, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "RG:";
            // 
            // lbCnpj
            // 
            this.lbCnpj.AutoSize = true;
            this.lbCnpj.Location = new System.Drawing.Point(552, 20);
            this.lbCnpj.Name = "lbCnpj";
            this.lbCnpj.Size = new System.Drawing.Size(68, 13);
            this.lbCnpj.TabIndex = 2;
            this.lbCnpj.Text = "CPF / CNPJ:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(240, 17);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(306, 20);
            this.txtRazaoSocial.TabIndex = 2;
            // 
            // lbRazaoSocial
            // 
            this.lbRazaoSocial.AutoSize = true;
            this.lbRazaoSocial.Location = new System.Drawing.Point(122, 20);
            this.lbRazaoSocial.Name = "lbRazaoSocial";
            this.lbRazaoSocial.Size = new System.Drawing.Size(112, 13);
            this.lbRazaoSocial.TabIndex = 0;
            this.lbRazaoSocial.Text = "Nome / Razão Social:";
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "id_transportadora";
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nome_razao_social
            // 
            this.nome_razao_social.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome_razao_social.DataPropertyName = "nome_fantasia";
            this.nome_razao_social.HeaderText = "Nome / Razão Socail";
            this.nome_razao_social.Name = "nome_razao_social";
            this.nome_razao_social.ReadOnly = true;
            // 
            // tipo_pessoa
            // 
            this.tipo_pessoa.DataPropertyName = "tipo_pessoa";
            this.tipo_pessoa.HeaderText = "Tipo Pessoa";
            this.tipo_pessoa.Name = "tipo_pessoa";
            this.tipo_pessoa.ReadOnly = true;
            // 
            // cpf_cnpj
            // 
            this.cpf_cnpj.DataPropertyName = "cnpj";
            this.cpf_cnpj.HeaderText = "CPF / CNPJ";
            this.cpf_cnpj.Name = "cpf_cnpj";
            this.cpf_cnpj.ReadOnly = true;
            // 
            // i_estadual_rg
            // 
            this.i_estadual_rg.DataPropertyName = "i_estadual";
            this.i_estadual_rg.HeaderText = "RG / Insc. Est.";
            this.i_estadual_rg.Name = "i_estadual_rg";
            this.i_estadual_rg.ReadOnly = true;
            this.i_estadual_rg.Width = 150;
            // 
            // cidade
            // 
            this.cidade.DataPropertyName = "end_cidade";
            this.cidade.HeaderText = "Cidade";
            this.cidade.Name = "cidade";
            this.cidade.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "end_estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // frmTransportadoraLockup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 343);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.gvTransportadora);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransportadoraLockup";
            this.ShowInTaskbar = false;
            this.Text = "Pesquisar Clientes";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransportadora)).EndInit();
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.ToolStripButton btOk;
        private System.Windows.Forms.DataGridView gvTransportadora;
        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCnpj;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label lbRazaoSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_razao_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpf_cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_estadual_rg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}