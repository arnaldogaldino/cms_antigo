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
using System.Data;
using System.Threading;

namespace cms.Modulos.Util
{
    [ProvideProperty("CustomGridView", typeof(DataGridView))]
    public class GridCustom : System.ComponentModel.Component, 
        System.ComponentModel.IExtenderProvider
    {
        DataTable dtItens = new DataTable();
        private Control ctrl;

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
            public bool Custom;
            public Properties()
            {
                Custom = true;
            }
        }
        #endregion

        #region Events
        public bool GetCustomGridView(DataGridView t)
        {
            return EnsurePropertiesExists(t).Custom;
        }

        ContextMenuStrip cMenu = new ContextMenuStrip();

        [DefaultValue(true)]
        public void SetCustomGridView(Control control, bool value)
        {
            DataGridView grid = control as DataGridView;
            ctrl = control;
            GridDesigner(grid);

            ContextMenuStrip mnu = new ContextMenuStrip();
            mnu.ShowCheckMargin = true;
            mnu.AutoClose = true;
            grid.AutoGenerateColumns = false;

            grid.RowHeightChanged += new DataGridViewRowEventHandler(grid_RowHeightChanged);

            grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(grid_ColumnWidthChanged);
            grid.ColumnDisplayIndexChanged += new DataGridViewColumnEventHandler(grid_ColumnDisplayIndexChanged);

                
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                ToolStripMenuItem ts = new ToolStripMenuItem();
                string name = grid.Columns[i].Name;
                string header = grid.Columns[i].HeaderText;

                ts.Name = "mnu_" + name;
                ts.Text = header;
                ts.CheckOnClick = true;
                ts.Tag = name;

                ts.Checked = IsCheckd(AuthEntity.UsuarioOnLine.id_usuario + "_" + grid.Parent.Name + "_" + grid.Name + "_" + grid.Columns[i].Name);
                ts.Tag = AuthEntity.UsuarioOnLine.id_usuario + "_" + grid.Parent.Name + "_" + grid.Name + "_" + grid.Columns[i].Name;

                if(grid.Columns[i].Visible == true)
                    grid.Columns[i].Visible = ts.Checked;

                int width = getWidth(AuthEntity.UsuarioOnLine.id_usuario + "_" + grid.Parent.Name + "_" + grid.Name + "_" + grid.Columns[i].Name);
                int? order = getOrder(AuthEntity.UsuarioOnLine.id_usuario + "_" + grid.Parent.Name + "_" + grid.Name + "_" + grid.Columns[i].Name);

                if (width > 0)
                    grid.Columns[i].Width = width;

                if (order != null)
                    grid.Columns[i].DisplayIndex = order.Value;

                if (grid.Columns[i].CellType == typeof(DataGridViewImageCell))
                {
                    grid.Columns[i].DefaultCellStyle.NullValue = global::cms.Properties.Resources.preview;
                }

                ts.Click += new EventHandler(ts_Click);

                grid.Columns[i].Resizable = DataGridViewTriState.True;


                if (grid.Columns[i].Visible == true)
                {
                    mnu.Items.Add(ts);
                    AddRows(AuthEntity.UsuarioOnLine.id_usuario + "_" + grid.Parent.Name + "_" + grid.Name + "_" + grid.Columns[i].Name, grid.Parent.Name, grid.Name, grid.Columns[i].Name, grid.Columns[i].Width, grid.Columns[i].DisplayIndex, true);
                }
            }

            grid.ContextMenuStrip = mnu;
            DataSave();
        }

        void grid_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView grid = ctrl as DataGridView;
            grid.Invoke(new MethodInvoker(delegate { ResizeRows(e.Row.Height); }));
        }

        private void ResizeRows(int RowsHeight)
        {
            DataGridView grid = ctrl as DataGridView;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Invoke(new MethodInvoker(delegate { grid.Rows[i].Height = RowsHeight; }));
            }   
        }

        void grid_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView grid = ctrl as DataGridView;
            EditRows(AuthEntity.UsuarioOnLine.id_usuario + "_" + e.Column.DataGridView.Parent.Name + "_" + e.Column.DataGridView.Name + "_" + e.Column.Name, e.Column.Width, e.Column.DisplayIndex, e.Column.Visible);
            DataSave();
        }

        void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView grid = ctrl as DataGridView;
            EditRows(AuthEntity.UsuarioOnLine.id_usuario + "_" + e.Column.DataGridView.Parent.Name + "_" + e.Column.DataGridView.Name + "_" + e.Column.Name, e.Column.Width, e.Column.DisplayIndex, e.Column.Visible);
            DataSave();
        }

        public void GridDesigner(DataGridView gd)
        {
            Color cor_titulo = Color.FromArgb(155, 187, 89);
            Color cor_linha = Color.FromArgb(215, 228, 188);
            Color cor_linha_alternate = Color.FromArgb(234, 241, 221);
            Color cor_linha_select = Color.FromArgb(117, 146, 60);
            Color cor_border = Color.FromArgb(194, 241, 154);
            Color cor_texto_linha = Color.FromArgb(0, 0, 0);
            Color cor_texto_titulo = Color.FromArgb(255, 255, 255);
            Color cor_fundo = Color.FromArgb(255, 255, 255);

            Font font_titulo = new Font("Verdana", 7, FontStyle.Bold, GraphicsUnit.Point);
            Font font_linha = new Font("Verdana", 7, FontStyle.Regular, GraphicsUnit.Point);

            gd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gd.BorderStyle = BorderStyle.FixedSingle;
            gd.BackgroundColor = cor_fundo;

            gd.EnableHeadersVisualStyles = false;
            
            gd.ColumnHeadersDefaultCellStyle.BackColor = cor_titulo;
            gd.ColumnHeadersDefaultCellStyle.Font = font_titulo;
            gd.ColumnHeadersDefaultCellStyle.ForeColor = cor_texto_titulo;

            gd.RowHeadersDefaultCellStyle.BackColor = cor_titulo;
            gd.RowHeadersDefaultCellStyle.ForeColor = cor_texto_titulo;
            gd.RowHeadersDefaultCellStyle.Font = font_titulo;

            if(gd.ImeMode != ImeMode.On)
                gd.RowHeadersVisible = false;

            gd.AllowUserToOrderColumns = true;

            gd.AlternatingRowsDefaultCellStyle.BackColor = cor_linha;
            gd.AlternatingRowsDefaultCellStyle.ForeColor = cor_texto_linha;
            gd.AlternatingRowsDefaultCellStyle.Font = font_linha;

            gd.RowsDefaultCellStyle.BackColor = cor_linha_alternate;
            gd.RowsDefaultCellStyle.ForeColor = cor_texto_linha;
            gd.RowsDefaultCellStyle.Font = font_linha;
        }

        void ts_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = (ToolStripMenuItem)sender;
            DataGridView grid = ctrl as DataGridView;

            EditRows(ts.Tag.ToString(), grid.Columns[ts.Name.Replace("mnu_", "")].Width, grid.Columns[ts.Name.Replace("mnu_", "")].Index, ts.Checked);

            grid.Columns[ts.Name.Replace("mnu_", "")].Visible = ts.Checked;

            DataSave();
        }

        #endregion
        private bool IsCheckd(string id)
        {
            bool exist = true;
            foreach (DataRow dr in dtItens.Rows)
                if (dr["id"].ToString() == id)
                    if (dr["chk"].ToString() == "True")
                        exist = true;
                    else
                        exist = false;

            return exist;
        }
        private int getWidth(string id)
        {
            int width = 0;

            foreach (DataRow dr in dtItens.Rows)
                if (dr["id"].ToString() == id)
                    try
                    {
                        width = int.Parse(dr["width_column"].ToString());
                    }
                    catch { }

            return width;
        }
        private int? getOrder(string id)
        {
            int? order = null;

            foreach (DataRow dr in dtItens.Rows)
                if (dr["id"].ToString() == id)
                    try
                    {
                        order = int.Parse(dr["order_column"].ToString());
                    }
                    catch { return null; }

            return order;
        }
        private void DataSave()
        {
            dtItens.WriteXml("GridVews.theme");
        }

        private void EditRows(string id, int width_column, int order_column, bool value)
        {
            foreach (DataRow dr in dtItens.Rows)
            {
                if (dr["id"].ToString() == id)
                {
                    dr["order_column"] = order_column;
                    dr["width_column"] = width_column;
                    dr["chk"] = value;
                }
            }
        }

        private void AddRows(string id, string name_parent, string name_grid, string name_column, int width_column, int order_column, bool value)
        {
            bool exist = false;
            foreach (DataRow dr in dtItens.Rows)
                if (dr["id"].ToString() == id)
                    exist = true;

            if (!exist)
                dtItens.Rows.Add(id, name_parent, name_grid, name_column, width_column, order_column, value);
        }

        #region Contrutores
        public GridCustom()
        {
            properties = new Hashtable();
            InitializeComponent();
        }

        public GridCustom(System.ComponentModel.IContainer container)
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
            dtItens.Columns.Add("id", Type.GetType("System.String"));
            dtItens.Columns.Add("name_parent", Type.GetType("System.String"));
            dtItens.Columns.Add("name_grid", Type.GetType("System.String"));
            dtItens.Columns.Add("name_column", Type.GetType("System.String"));
            dtItens.Columns.Add("width_column", Type.GetType("System.String"));
            dtItens.Columns.Add("order_column", Type.GetType("System.String"));
            dtItens.Columns.Add("chk", Type.GetType("System.Boolean"));
            dtItens.TableName = "grids";

            System.IO.FileInfo fi = new System.IO.FileInfo("GridVews.theme");
            
            if(fi.Exists)
                dtItens.ReadXml("GridVews.theme");
            else
                dtItens.WriteXml("GridVews.theme");
        }
        #endregion

        #region IExtenderProvider.CanExtend
        bool IExtenderProvider.CanExtend(object ctrl)
        {
            return (ctrl is DataGridView);
        }
        #endregion

    }

}
