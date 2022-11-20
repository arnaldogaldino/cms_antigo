using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDI.NFe2.Business;

namespace RDI.NFe.Visual
{
    public partial class FrmVisualizaXML : Form
    {
        System.Xml.XmlDocument xmlDoc;
        String xml;
        public FrmVisualizaXML(String XML)
        {
            InitializeComponent();
            xml = XML;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmVisualizaXML_Load(object sender, EventArgs e)
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xml);
            NFeUtils.PopulaTreeView(xmlDoc, tvXmlNota);
        }

    }
}