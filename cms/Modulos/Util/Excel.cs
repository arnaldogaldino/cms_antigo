using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace cms.Modulos.Util
{
    public class Excel_
    {
        private System.Data.DataTable dt = new System.Data.DataTable();

        public Excel_()
        {

        }

        public MemoryStream GerarExcel(System.Data.DataTable table)
        {
            MemoryStream ms = new MemoryStream();

            Microsoft.Office.Interop.Excel.Application app = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            Microsoft.Office.Interop.Excel.Range workSheet_range = null;
            
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            workbook = app.Workbooks.Add(1);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            for (int c = 0; c < table.Columns.Count; c++)
            {
                worksheet.Cells[1, c+1] = table.Columns[c].ColumnName;
            }
            
            for (int l = 0; l < table.Rows.Count; l++)
            {
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    worksheet.Cells[(l + 2), (c + 1)] = table.Rows[l][c].ToString();
                    //SizeF size = TextRenderer.MeasureText(table.Rows[l][c].ToString(), new System.Drawing.Font("Verdana", 10));
                    //worksheet.Columns[c].ColumnWidth = int.Parse(size.Height.ToString());
                }
            }
            
            return ms;
        }

    }
}
