namespace cms.Modulos.Cliente.Forms
{
    partial class frmClienteList
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

            if(threadPreencherGrid != null)
                threadPreencherGrid.Abort();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClienteList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.cbTipoCliente = new System.Windows.Forms.ComboBox();
            this.rbJuridica = new System.Windows.Forms.RadioButton();
            this.rbFisica = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblContato = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.txtIE = new System.Windows.Forms.TextBox();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblIE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.lbCPF = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.lbRazaoSocial = new System.Windows.Forms.Label();
            this.gvCliente = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_razao_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpf_cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_estadual_rg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextMaskedit = new ToolMasked.TextMask(this.components);
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btNovo = new System.Windows.Forms.ToolStripButton();
            this.btFechar = new System.Windows.Forms.ToolStripButton();
            this.gbPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPesquisa.Controls.Add(this.cbTipoCliente);
            this.gbPesquisa.Controls.Add(this.rbJuridica);
            this.gbPesquisa.Controls.Add(this.rbFisica);
            this.gbPesquisa.Controls.Add(this.label2);
            this.gbPesquisa.Controls.Add(this.lblTipo);
            this.gbPesquisa.Controls.Add(this.lblContato);
            this.gbPesquisa.Controls.Add(this.txtCodigo);
            this.gbPesquisa.Controls.Add(this.lbCodigo);
            this.gbPesquisa.Controls.Add(this.btPesquisar);
            this.gbPesquisa.Controls.Add(this.txtContato);
            this.gbPesquisa.Controls.Add(this.txtIE);
            this.gbPesquisa.Controls.Add(this.txtRG);
            this.gbPesquisa.Controls.Add(this.txtCNPJ);
            this.gbPesquisa.Controls.Add(this.txtCPF);
            this.gbPesquisa.Controls.Add(this.lblIE);
            this.gbPesquisa.Controls.Add(this.label1);
            this.gbPesquisa.Controls.Add(this.lblCnpj);
            this.gbPesquisa.Controls.Add(this.lbCPF);
            this.gbPesquisa.Controls.Add(this.txtRazaoSocial);
            this.gbPesquisa.Controls.Add(this.lbRazaoSocial);
            this.gbPesquisa.Location = new System.Drawing.Point(12, 42);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(890, 70);
            this.gbPesquisa.TabIndex = 6;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisar Cliente";
            // 
            // cbTipoCliente
            // 
            this.cbTipoCliente.DisplayMember = "Display";
            this.cbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCliente.Location = new System.Drawing.Point(763, 42);
            this.cbTipoCliente.Name = "cbTipoCliente";
            this.cbTipoCliente.Size = new System.Drawing.Size(121, 21);
            this.cbTipoCliente.TabIndex = 10;
            this.cbTipoCliente.ValueMember = "Value";
            // 
            // rbJuridica
            // 
            this.rbJuridica.AutoSize = true;
            this.rbJuridica.Location = new System.Drawing.Point(624, 43);
            this.rbJuridica.Name = "rbJuridica";
            this.rbJuridica.Size = new System.Drawing.Size(61, 17);
            this.rbJuridica.TabIndex = 9;
            this.rbJuridica.Text = "Juridica";
            this.rbJuridica.UseVisualStyleBackColor = true;
            // 
            // rbFisica
            // 
            this.rbFisica.AutoSize = true;
            this.rbFisica.Location = new System.Drawing.Point(566, 43);
            this.rbFisica.Name = "rbFisica";
            this.rbFisica.Size = new System.Drawing.Size(52, 17);
            this.rbFisica.TabIndex = 8;
            this.rbFisica.Text = "Fisica";
            this.rbFisica.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo Cliente:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(491, 45);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(69, 13);
            this.lblTipo.TabIndex = 6;
            this.lblTipo.Text = "Tipo Pessoa:";
            // 
            // lblContato
            // 
            this.lblContato.AutoSize = true;
            this.lblContato.Location = new System.Drawing.Point(324, 45);
            this.lblContato.Name = "lblContato";
            this.lblContato.Size = new System.Drawing.Size(47, 13);
            this.lblContato.TabIndex = 6;
            this.lblContato.Text = "Contato:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(57, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigo.Size = new System.Drawing.Size(52, 20);
            this.txtCodigo.TabIndex = 1;
            this.TextMaskedit.SetTextMasked(this.txtCodigo, ToolMasked.TextMask.Formats.None);
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
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(787, 15);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(97, 23);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(377, 42);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(108, 20);
            this.txtContato.TabIndex = 7;
            this.TextMaskedit.SetTextMasked(this.txtContato, ToolMasked.TextMask.Formats.None);
            // 
            // txtIE
            // 
            this.txtIE.Location = new System.Drawing.Point(210, 42);
            this.txtIE.Name = "txtIE";
            this.txtIE.Size = new System.Drawing.Size(108, 20);
            this.txtIE.TabIndex = 6;
            this.TextMaskedit.SetTextMasked(this.txtIE, ToolMasked.TextMask.Formats.None);
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(676, 15);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(91, 20);
            this.txtRG.TabIndex = 4;
            this.TextMaskedit.SetTextMasked(this.txtRG, ToolMasked.TextMask.Formats.None);
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(57, 43);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(121, 20);
            this.txtCNPJ.TabIndex = 5;
            this.TextMaskedit.SetTextMasked(this.txtCNPJ, ToolMasked.TextMask.Formats.None);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(543, 15);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(95, 20);
            this.txtCPF.TabIndex = 3;
            this.TextMaskedit.SetTextMasked(this.txtCPF, ToolMasked.TextMask.Formats.None);
            // 
            // lblIE
            // 
            this.lblIE.AutoSize = true;
            this.lblIE.Location = new System.Drawing.Point(184, 46);
            this.lblIE.Name = "lblIE";
            this.lblIE.Size = new System.Drawing.Size(20, 13);
            this.lblIE.TabIndex = 2;
            this.lblIE.Text = "IE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "RG:";
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(9, 46);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(37, 13);
            this.lblCnpj.TabIndex = 2;
            this.lblCnpj.Text = "CNPJ:";
            // 
            // lbCPF
            // 
            this.lbCPF.AutoSize = true;
            this.lbCPF.Location = new System.Drawing.Point(507, 19);
            this.lbCPF.Name = "lbCPF";
            this.lbCPF.Size = new System.Drawing.Size(30, 13);
            this.lbCPF.TabIndex = 2;
            this.lbCPF.Text = "CPF:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(233, 17);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(268, 20);
            this.txtRazaoSocial.TabIndex = 2;
            this.TextMaskedit.SetTextMasked(this.txtRazaoSocial, ToolMasked.TextMask.Formats.None);
            // 
            // lbRazaoSocial
            // 
            this.lbRazaoSocial.AutoSize = true;
            this.lbRazaoSocial.Location = new System.Drawing.Point(115, 19);
            this.lbRazaoSocial.Name = "lbRazaoSocial";
            this.lbRazaoSocial.Size = new System.Drawing.Size(112, 13);
            this.lbRazaoSocial.TabIndex = 0;
            this.lbRazaoSocial.Text = "Nome / Razão Social:";
            // 
            // gvCliente
            // 
            this.gvCliente.AllowUserToAddRows = false;
            this.gvCliente.AllowUserToDeleteRows = false;
            this.gvCliente.AllowUserToOrderColumns = true;
            this.gvCliente.AllowUserToResizeColumns = false;
            this.gvCliente.AllowUserToResizeRows = false;
            this.gvCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nome_razao_social,
            this.tipo_pessoa,
            this.cpf_cnpj,
            this.i_estadual_rg,
            this.cidade,
            this.estado});
            this.gvCliente.Location = new System.Drawing.Point(12, 118);
            this.gvCliente.MultiSelect = false;
            this.gvCliente.Name = "gvCliente";
            this.gvCliente.ReadOnly = true;
            this.gvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCliente.ShowEditingIcon = false;
            this.gvCliente.ShowRowErrors = false;
            this.gvCliente.Size = new System.Drawing.Size(890, 234);
            this.gvCliente.TabIndex = 8;
            this.gvCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvCliente_MouseDoubleClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "id_cliente";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nome_razao_social
            // 
            this.nome_razao_social.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome_razao_social.DataPropertyName = "razao_social";
            this.nome_razao_social.HeaderText = "Nome / Razão Social";
            this.nome_razao_social.Name = "nome_razao_social";
            this.nome_razao_social.ReadOnly = true;
            // 
            // tipo_pessoa
            // 
            this.tipo_pessoa.DataPropertyName = "tipo_pessoa";
            this.tipo_pessoa.HeaderText = "Tipo Pessoa";
            this.tipo_pessoa.Name = "tipo_pessoa";
            this.tipo_pessoa.ReadOnly = true;
            this.tipo_pessoa.Width = 130;
            // 
            // cpf_cnpj
            // 
            this.cpf_cnpj.DataPropertyName = "cnpj";
            this.cpf_cnpj.HeaderText = "CPF / CNPJ";
            this.cpf_cnpj.Name = "cpf_cnpj";
            this.cpf_cnpj.ReadOnly = true;
            this.cpf_cnpj.Width = 130;
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
            // TextMaskedit
            // 
            this.TextMaskedit.Text = null;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNovo,
            this.btFechar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(914, 39);
            this.tsMenu.TabIndex = 7;
            // 
            // btNovo
            // 
            this.btNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btNovo.Image = global::cms.Properties.Resources.novo;
            this.btNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(36, 36);
            this.btNovo.Text = "Novo Cliente";
            this.btNovo.ToolTipText = "Novo Cliente";
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
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
            // frmClienteList
            // 
            this.AcceptButton = this.btPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 364);
            this.Controls.Add(this.gbPesquisa);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gvCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "frmClienteList";
            this.Text = "Pesquisar Clientes";
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCPF;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label lbRazaoSocial;
        private System.Windows.Forms.DataGridView gvCliente;
        private ToolMasked.TextMask TextMaskedit;
        private System.Windows.Forms.TextBox txtIE;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label lblIE;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblContato;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton rbJuridica;
        private System.Windows.Forms.RadioButton rbFisica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoCliente;
        private System.Windows.Forms.ToolStripButton btNovo;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btFechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_razao_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpf_cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_estadual_rg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;

    }
}