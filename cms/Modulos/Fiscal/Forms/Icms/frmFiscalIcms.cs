using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Fiscal.Cn;

namespace cms.Modulos.Fiscal.Forms.Icms
{

    public partial class frmFiscalIcms : cms.Modulos.Util.WindowBase
    {
        decimal Aliquota = 0;

        public frmFiscalIcms()
        {
            InitializeComponent();
            
            Fiscal.Cn.cnFiscalIcms cFIscalIcms = new cnFiscalIcms();
            DataTable dt =  cFIscalIcms.GetIcms();
            gvIcms.DataSource = dt;
            gvIcms.Refresh();
            gvIcms.AllowUserToOrderColumns = false;

            gvIcms.RowHeadersVisible = true;
            for (int i = 0; i < gvIcms.Rows.Count; i++)
            {
                gvIcms.Rows[i].HeaderCell.Value = i.ToString();
            }
        }

        private void frmFiscalIcms_Load(object sender, EventArgs e)
        {

        }

        private void gvIcms_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = string.Empty;

            try
            {
                gvIcms.Invoke(new MethodInvoker(delegate
                {
                    strRowNumber = gvIcms.Columns[e.RowIndex].HeaderText;
                }));
            }
            catch { }

            //while (strRowNumber.Length < dataGridView1.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            SizeF size =  e.Graphics.MeasureString(strRowNumber, gvIcms.ColumnHeadersDefaultCellStyle.Font); 

            if (gvIcms.RowHeadersWidth < (int)(size.Width + 20)) gvIcms.RowHeadersWidth = (int)(size.Width + 20);

            Brush b = new SolidBrush(gvIcms.ColumnHeadersDefaultCellStyle.ForeColor); 
                       
            e.Graphics.DrawString(strRowNumber, gvIcms.ColumnHeadersDefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            gvIcms.Invoke(new MethodInvoker(delegate { gvIcms.Rows[e.RowIndex].Tag = strRowNumber; }));
                      
        }
        
        private void gvIcms_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Aliquota = 0;

            if (decimal.TryParse(gvIcms.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out Aliquota))
            {
                string uf_origem = string.Empty;
                string uf_destino = gvIcms.Columns[e.ColumnIndex].HeaderText;

                if (gvIcms.Rows[e.RowIndex].Tag != null)
                    uf_origem = gvIcms.Rows[e.RowIndex].Tag.ToString();

                if (gvIcms.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() != gvIcms.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString())
                {
                    cnFiscalIcms cFIscalIcms = new cnFiscalIcms();
                    cFIscalIcms.AtualizarICMS(uf_origem, uf_destino, Aliquota);
                }
            }
            else
            {
                decimal.TryParse(gvIcms.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString(), out Aliquota);
                MessageBox.Show(null, "Valor inválido!", "Erro ao cadastrar icms.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvIcms_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            gvIcms[e.ColumnIndex, e.RowIndex].Value = string.Format("{0:n}", Aliquota);
        }

        private void gvIcms_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            gvIcms[e.ColumnIndex, e.RowIndex].Value = string.Format("{0:n}", Aliquota);
        }

    }
}
