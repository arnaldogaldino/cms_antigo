using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Drawing;

namespace cms.Modulos.Util
{
    public partial class WindowBase : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public int tab_index = 0;
        public Color CorCampoInvalido = Color.Salmon;
        private GridCustom gridCustom;
        public bool? saved = null;

        public WindowBase()
        {
            this.KeyPreview = true;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.FormClosing += new FormClosingEventHandler(WindowBase_FormClosing);
        }

        public void WindowBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved == false && MessageBox.Show("Deseja gravar este registro?", "Opção de gravação do registro.", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //btGravar_Click(sender, e);
                saved = null;
            }
        }

        private bool formIsValid = true;
        public bool FormIsValid
        {
            get { return formIsValid; }
            set { formIsValid = value; }
        }

        private System.ComponentModel.IContainer components = null;
        
        protected override void OnLoad(EventArgs e)
        {
            FormatarControles(base.Controls);
            base.OnLoad(e);
            
            this.components = new System.ComponentModel.Container();

            this.gridCustom = new cms.Modulos.Util.GridCustom(this.components);

            AddCustomGrid(base.Controls);

            base.StartPosition = FormStartPosition.CenterScreen;

        }

        private void AddCustomGrid(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl.Controls != null)
                    AddCustomGrid(ctrl.Controls);
                
                if (ctrl.GetType() == typeof(DataGridView))
                    this.gridCustom.SetCustomGridView((DataGridView)ctrl, true);

                if (ctrl.GetType() == typeof(TextBox))
                    ((TextBox)ctrl).KeyDown += new KeyEventHandler(TextBox_KeyDown);
            }
        }

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                Calc c = new Calc();
                c.ShowDialog();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
            base.OnKeyPress(e);
        }

        private void FormatarControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is System.Windows.Forms.Button)
                {
                    ((System.Windows.Forms.Button)(ctrl)).ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }

                FormatarControles(ctrl.Controls);
            }
        }

        public void TravaFormControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)(ctrl)).ReadOnly = true;
                }  

                if (ctrl is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)(ctrl)).Enabled = false;
                }

                if (ctrl is System.Windows.Forms.CheckBox)
                {
                    ((System.Windows.Forms.CheckBox)(ctrl)).Enabled = false;
                }

                if (ctrl is System.Windows.Forms.RadioButton)
                {
                    ((System.Windows.Forms.RadioButton)(ctrl)).Enabled = false;
                }

                TravaFormControles(ctrl.Controls);
            }
        }

        public void DestravaFormControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)(ctrl)).ReadOnly = false;
                }

                if (ctrl is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)(ctrl)).Enabled = true;
                }

                if (ctrl is System.Windows.Forms.CheckBox)
                {
                    ((System.Windows.Forms.CheckBox)(ctrl)).Enabled = true;
                }
                DestravaFormControles(ctrl.Controls);
            }
        }
        
        public void LimparCampos(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)(ctrl)).Clear();
                    ((System.Windows.Forms.TextBox)(ctrl)).Tag = null;
                }

                if (ctrl is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)(ctrl)).ResetText();
                    ((System.Windows.Forms.ComboBox)(ctrl)).Refresh();
                }

                if (ctrl is System.Windows.Forms.CheckBox)
                {
                    ((System.Windows.Forms.CheckBox)(ctrl)).Checked = false;
                }

                if (ctrl is System.Windows.Forms.RadioButton)
                {
                    ((System.Windows.Forms.RadioButton)(ctrl)).Checked = false;
                }

                LimparCampos(ctrl.Controls);
            }
        }

        //public virtual void btEditar_Click(object sender, EventArgs e)
        //{
        //    saved = false;
        //}
        //public virtual void btNovo_Click(object sender, EventArgs e)
        //{
        //    saved = false;
        //}
        //public virtual void btExcluir_Click(object sender, EventArgs e)
        //{
        //    saved = null;
        //}
        //public virtual void btGravar_Click(object sender, EventArgs e)
        //{
        //    saved = null;
        //}
        //public virtual void btCancelar_Click(object sender, EventArgs e)
        //{}
        //public virtual void btFechar_Click(object sender, EventArgs e)
        //{}        

    }

}
