using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms.Modulos.Util
{

    public partial class Lockup : UserControl
    {
        public event LockupHandler OnLockup;
        public delegate void LockupHandler(object sender, LockupEventArgs e);

        private object _value = null;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
        public string Id
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public string Text
        {
            get { return txtDescricao.Text; }
            set { txtDescricao.Text = value; }
        }

        public bool Enabled
        {
            get 
            {
                return btLockup.Enabled;
            }
            set
            {
                btLockup.Enabled = value;
                txtID.ReadOnly = (!value);
            }
        }
                
        public Lockup()
        {
            InitializeComponent();

            btLockup.Click += new EventHandler(btLockup_Click);
            txtID.KeyDown += new KeyEventHandler(txtID_KeyDown);            
            txtID.Leave += new EventHandler(txtID_Leave);
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                Clear();
                return;
            }

            LockupEventArgs eventArgs = new LockupEventArgs();
            eventArgs.LockupEx = LockupEx.KeysEnter;

            OnLockup.Invoke(sender, eventArgs); 
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LockupEventArgs eventArgs = new LockupEventArgs();
                eventArgs.LockupEx = LockupEx.KeysF1;

                OnLockup.Invoke(sender, eventArgs);   
            }
            else if (e.KeyCode == Keys.Enter)
            {
                LockupEventArgs eventArgs = new LockupEventArgs();
                eventArgs.LockupEx = LockupEx.KeysEnter;

                OnLockup.Invoke(sender, eventArgs);   
            }
        }

        public void Set(object value, string id, string text)
        {
            _value = value;
            txtID.Text = id;
            txtDescricao.Text = text;
        }

        public void Clear()
        {
            _value = null;
            txtID.Text = string.Empty;
            txtDescricao.Text = string.Empty;
        }
        
        public void btLockup_Click(object sender, EventArgs e)
        {
            LockupEventArgs eventArgs = new LockupEventArgs();
            eventArgs.LockupEx = LockupEx.MouseClick;

            OnLockup.Invoke(sender, eventArgs);    
        }
    }

    public enum LockupEx
    {
        Null = -1,
        KeysF1 = 0,
        KeysEnter = 1,
        MouseClick = 3
    }

    public class LockupEventArgs
    {
        private LockupEx _LockupEx = LockupEx.Null;
        public LockupEx LockupEx
        {
            get { return _LockupEx; }
            set { _LockupEx = value; }
        }

        public LockupEventArgs()
        { }
    }
}
