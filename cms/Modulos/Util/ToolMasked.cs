using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;

namespace ToolMasked
{

    [ProvideProperty("TextMasked", typeof(Control))]
    public class TextMask : System.ComponentModel.Component, System.ComponentModel.IExtenderProvider
    {
        private Hashtable properties;
        private System.ComponentModel.Container components = null;

        #region Propriedade
        private Properties EnsurePropertiesExists(object key)
        {
            Properties p = (Properties)properties[key];

            if (p == null)
            {
                p = new Properties();

                properties[key] = p;
            }

            return p;
        }

        private class Properties
        {
            public Formats Mask;

            public Properties()
            {
                Mask = Formats.None;
            }
        }

        public enum Formats : int
        {
            None = 0,
            Dinheiro = 1,
            Numero = 2,
            Telefone = 3,
            Cep = 4,
            Cpf = 5,
            Cnpj = 6,
            Rg = 7,
            Ie = 8,
            Ncm = 9,
            PlanoContas = 10
        }

        #endregion

        #region Masked
        public Formats GetTextMasked(Control t)
        {
            return EnsurePropertiesExists(t).Mask;
        }

        [DefaultValue(Formats.None)]
        public void SetTextMasked(Control t, Formats value)
        {
            EnsurePropertiesExists(t).Mask = value;
            ((TextBox)t).Leave += new EventHandler(OnLeave);
            ((TextBox)t).KeyPress += new KeyPressEventHandler(OnKeyPress);
            ((TextBox)t).KeyDown += new KeyEventHandler(OnKeyDown);
            ((TextBox)t).TextChanged += new EventHandler(OnTextChanged);
            t.Invalidate();
        }

        public string Text
        {
            get;
            set;
        }

        #endregion

        #region Events
        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).ReadOnly == true)
                return;

            switch (EnsurePropertiesExists(sender).Mask)
            {
                case Formats.None:
                    break;

                case Formats.Dinheiro:
                    MaskDinheiro(sender, e);
                    break;

                case Formats.Numero:
                    MaskNumero(sender, e);
                    break;

                case Formats.Telefone:
                    MaskTelefone(sender, e);
                    break;

                case Formats.Cep:
                    MaskCep(sender, e);
                    break;

                case Formats.Cpf:
                    MaskCpf(sender, e);
                    break;

                case Formats.Cnpj:
                    MaskCnpj(sender, e);
                    break;

                case Formats.Rg:
                    MaskRg(sender, e);
                    break;

                case Formats.Ie:
                    MaskIe(sender, e);
                    break;

                case Formats.PlanoContas:
                    MaskPlanoContas(sender, e);
                    break;

                case Formats.Ncm:
                    MaskNcm(sender, e);
                    break;

                default:
                    break;
            }
        }
        
        public void OnTextChanged(object sender, EventArgs e)
        {
            switch (EnsurePropertiesExists(sender).Mask)
            {
                case Formats.None:
                    break;
                    
                case Formats.Dinheiro:
                    ((TextBox)sender).Text = string.Format("{0:n}", ((TextBox)sender).Text);
                    break;

                case Formats.Numero:
                    break;

                case Formats.Telefone:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{2})(\d{4})(\d{4})", "($1) $2-$3");
                    break;

                case Formats.Cep:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{5})(\d{3})", "$1-$2");
                    break;

                case Formats.Cpf:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");//string.Format("{0:###.###.###-##}", ((TextBox)sender).Text);
                    break;

                case Formats.Cnpj:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5"); //string.Format("{0:##.###.###/####-##}", ((TextBox)sender).Text);
                    break;

                case Formats.Rg:
                    ((TextBox)sender).Text =  Regex.Replace(((TextBox)sender).Text, @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4"); //string.Format("{0:##.###.###-#}", ((TextBox)sender).Text);
                    break;

                case Formats.Ie:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{3})(\d{3})(\d{3})(\d{3})", "$1.$2.$3.$4"); //string.Format("{0:###.###.###.###}", ((TextBox)sender).Text);
                    break;

                case Formats.PlanoContas:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{2})(\d{3})(\d{1})", "$1.$2.$3"); //= string.Format("{0:##.###.#}", ((TextBox)sender).Text);
                    break;

                case Formats.Ncm:
                    ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, @"(\d{2})(\d{3})(\d{2})", "$1.$2.$3"); // string.Format("{0:##.###.##}", ((TextBox)sender).Text);
                    break;

                default:
                    break;
            }
        }

        public void OnLeave(object sender, EventArgs e)
        {

            switch (EnsurePropertiesExists(sender).Mask)
            {
                case Formats.None:
                    break;

                case Formats.Dinheiro:
                    break;

                case Formats.Numero:
                    break;

                case Formats.Telefone:
                    break;

                case Formats.Cep:
                    break;

                case Formats.Cpf:
                    break;

                case Formats.Cnpj:
                    break;

                case Formats.Rg:
                    break;

                case Formats.Ie:
                    break;

                default:
                    break;
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (EnsurePropertiesExists(sender).Mask)
            {
                case Formats.None:
                    break;

                case Formats.Dinheiro:
                    break;

                case Formats.Numero:
                    break;

                case Formats.Telefone:
                    break;

                case Formats.Cep:
                    break;

                case Formats.Cpf:
                    break;

                case Formats.Cnpj:
                    break;

                case Formats.Rg:
                    break;

                case Formats.Ie:
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Contrutores
        public TextMask()
        {
            properties = new Hashtable();
            InitializeComponent();
            try
            {
                ((TextBox)components.Components[0]).Text = "0";
            }
            catch { }
        }

        public TextMask(System.ComponentModel.IContainer container)
            : this()
        {
            container.Add(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Initialize
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region IExtenderProvider.CanExtend
        public bool CanExtend(object extendee)
        {
            if (extendee is TextBox && !(extendee is TextMask) && !(extendee is Form))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Mascaras

        /// <summary>
        /// 0000000000000
        /// </summary>
        /// <param name="e"></param>
        private void MaskNumero(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// 0.000.000,00
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskDinheiro(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            try
            {
                ((TextBox)sender).Text = int.Parse(((TextBox)sender).Text.Replace(".", "").Replace(",", "")).ToString();
            }
            catch
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(".", "").Replace(",", "");
            }

            if (( ((TextBox)sender).Text.Length > 1) && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 1, ",");
                
                if(((TextBox)sender).Text.Length >= 6)
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 5, ".");

                if (((TextBox)sender).Text.Length >= 10)
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 9, ".");

                if (((TextBox)sender).Text.Length >= 14)
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 13, ".");

                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if ((((TextBox)sender).Text.Length < 2) && e.KeyChar != 8)
            {
                if (((TextBox)sender).Text.Length - 1 == -1)
                    ((TextBox)sender).Text = "0,0" + ((TextBox)sender).Text;
                if (((TextBox)sender).Text.Length - 1 == 0 && e.Handled)
                    ((TextBox)sender).Text = "0,00";
                if (((TextBox)sender).Text.Length - 1 == 0)
                    ((TextBox)sender).Text = "0," + ((TextBox)sender).Text;
            }
            else if (e.KeyChar == 8)
            {

                if (((TextBox)sender).Text.Length == 1 || ((TextBox)sender).Text.Length > 1)
                {
                    try
                    {
                        if (((TextBox)sender).Text.Length - 1 > 2)
                        {
                            ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 3, ",");

                            if (((TextBox)sender).Text.Length >= 6)
                                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 7, ".");

                            if (((TextBox)sender).Text.Length >= 10)
                                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 11, ".");

                            if (((TextBox)sender).Text.Length >= 14)
                                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).Text.Length - 15, ".");
                        }
                        if (((TextBox)sender).Text.Length - 1 == 2)
                            ((TextBox)sender).Text = "0," + ((TextBox)sender).Text;
                        if (((TextBox)sender).Text.Length - 1 == 1)
                            ((TextBox)sender).Text = "0,0" + ((TextBox)sender).Text;
                        if (((TextBox)sender).Text.Length - 1 == 0)
                            ((TextBox)sender).Text = "0,00" + ((TextBox)sender).Text;
                    }
                    catch { }
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
                }
            }

            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }

        /// <summary>
        /// 00000-000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskCep(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if (((TextBox)sender).Text.Length == 5 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "-";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 8 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// (00) 0000-0000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskTelefone(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if (((TextBox)sender).Text.Length == 0 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "(";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length == 3 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ") ";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 2;
            }
            else if (((TextBox)sender).Text.Length == 9 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "-";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 13 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// 000.000.000-00
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskCpf(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if (((TextBox)sender).Text.Length == 3 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length == 7 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length == 11 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "-";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 13 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// 00.000.000/0000-00
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskCnpj(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if ((((TextBox)sender).Text.Length == 2 || ((TextBox)sender).Text.Length == 6) && (e.KeyChar != 8))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length == 10 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "/";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length == 15 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "-";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 17 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 00.000.000-0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskRg(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if ((((TextBox)sender).Text.Length == 2 || ((TextBox)sender).Text.Length == 6) && (e.KeyChar != 8))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length == 10 && e.KeyChar != 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "-";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 11 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 000.000.000.000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskIe(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if ((((TextBox)sender).Text.Length == 3 || ((TextBox)sender).Text.Length == 7 || ((TextBox)sender).Text.Length == 11) && (e.KeyChar != 8))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 14 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// 0.0.00.00.000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskPlanoContas(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if ((((TextBox)sender).Text.Length == 1 || ((TextBox)sender).Text.Length == 3 || ((TextBox)sender).Text.Length == 6  || ((TextBox)sender).Text.Length == 9) && (e.KeyChar != 8))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 12 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// 0000.00.00
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskNcm(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24 || e.KeyChar == (char)26)
                e.Handled = false;
            else
                e.Handled = true;

            if ((((TextBox)sender).Text.Length == 4 || ((TextBox)sender).Text.Length == 7) && (e.KeyChar != 8))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            else if (((TextBox)sender).Text.Length > 9 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
                
        #endregion

    }

}
