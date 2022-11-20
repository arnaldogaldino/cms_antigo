using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Usuario.Cn;
using cms.Modulos.Empresa.Cn;
using System.Diagnostics;

namespace cms.Modulos.Util
{
    public partial class ctrlFilial : UserControl
    {
        private bool labelSelecione = false;
        public bool LabelSelecione
        {
            get { return labelSelecione; }
            set { labelSelecione = value; }
        }

        public void SetSelectedValue(string value)
        {
            cbFilial.SelectedValue = value;
        }

        public string GetSelectedValue()
        {
            string result = string.Empty;
            cbFilial.Invoke(new MethodInvoker(delegate { result = cbFilial.SelectedValue.ToString(); }));

            return result;
        }

        private bool selectedDefault = false;
        public bool SelectedDefault
        {
            get { return selectedDefault; }
            set { selectedDefault = value; }
        }

        public ctrlFilial()
        {
            InitializeComponent();
        }

        private void ctrlFilial_Load(object sender, EventArgs e)
        {
            #if (DEBUG)
                Atualizar();
            #endif
        }

        [Conditional("DEBUG")]
        public void Atualizar()
        {
            List<cms.Modulos.Util.Combos.ComboPropriedades> dResult = new List<cms.Modulos.Util.Combos.ComboPropriedades>();

            if (cms.Modulos.Util.AuthEntity.UsuarioOnLine != null)
            {
                var empresas = cms.Modulos.Util.AuthEntity.UsuarioOnLine.empresa;

                if (labelSelecione && empresas.Count > 1)
                    dResult.Add(new cms.Modulos.Util.Combos.ComboPropriedades("", "Selecione"));

                foreach (var emp in empresas)
                    dResult.Add(new cms.Modulos.Util.Combos.ComboPropriedades(emp.id_empresa.ToString(), emp.apelido));

                if (empresas.Count == 1 || empresas.Count == 0)
                {
                    this.Visible = false;
                }
            }
            else
            {
                this.Visible = false;
            }

            cbFilial.DataSource = dResult;
            cbFilial.Refresh();

            if (cbFilial.Items.Count > 0)
                cbFilial.SelectedIndex = 0;

            if (cms.Modulos.Util.AuthEntity.EmpresaPadrao != null)
                cbFilial.SelectedValue = cms.Modulos.Util.AuthEntity.EmpresaPadrao.id_empresa.ToString();
        }

        public empresa GetEmpresa()
        {
            if (cbFilial.SelectedValue == null || string.IsNullOrEmpty(cbFilial.SelectedValue.ToString()))
                return null;

            cnEmpresa emp = new cnEmpresa();
            return emp.GetEmpresaByID(long.Parse(cbFilial.SelectedValue.ToString()));
        }

        public int ItemsCount()
        {
            return cbFilial.Items.Count;
        }

        private void cbFilial_SelectedValueChanged(object sender, EventArgs e)
        {
        }

    }
}
