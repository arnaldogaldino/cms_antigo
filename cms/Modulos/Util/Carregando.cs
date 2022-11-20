using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms.Modulos.Util
{
    public class Carregando
    {
        public Button btCancelar = new Button();
        public Label lblCarregando = new Label();
        Panel pnlLoad = new Panel();
        PictureBox img = new PictureBox();

        public void LoadShow(Control ctrl)
        {
            if (ctrl.Controls["pnlLoad"] == null)
            {
                img.Image = global::cms.Properties.Resources.carregando;
                img.Location = new System.Drawing.Point(10, 10);
                img.Name = "imgCarregando";
                img.Size = new System.Drawing.Size(36, 36);
                img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

                pnlLoad.Controls.Add(img);
                pnlLoad.Name = "pnlLoad";
                pnlLoad.BorderStyle = BorderStyle.FixedSingle;
                pnlLoad.Size = new System.Drawing.Size(200, 56);
                pnlLoad.Location = new System.Drawing.Point(
                                                            (ctrl.Size.Width / 2) - 125,
                                                            (ctrl.Size.Height / 2) - 28
                                                           );

                ctrl.Resize += new EventHandler(ctrl_Resize);

                btCancelar.Name = "btCancelar";
                btCancelar.Text = "Cancelar";

                btCancelar.Location = new System.Drawing.Point(
                                                            (pnlLoad.Size.Width) - 125,
                                                            (pnlLoad.Size.Height / 2) - 5
                                                           );

                pnlLoad.Controls.Add(btCancelar);

                lblCarregando.Text = "Carregando...";
                lblCarregando.Name = "lblCarregando";

                lblCarregando.Location = new System.Drawing.Point(
                                                            (pnlLoad.Size.Width) - lblCarregando.Size.Width - 20,
                                                            (pnlLoad.Size.Height / 2) - lblCarregando.Size.Height
                                                           );
                pnlLoad.Controls.Add(lblCarregando);

                ctrl.Controls.Add(pnlLoad);

                pnlLoad.BringToFront();
            }
        }

        public void Processar(Control ctrl) 
        {
            if (ctrl.Controls["pnlLoad"] == null)
            {
                img.Image = global::cms.Properties.Resources.carregando;
                img.Location = new System.Drawing.Point(10, 10);
                img.Name = "imgCarregando";
                img.Size = new System.Drawing.Size(36, 36);
                img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

                pnlLoad.Controls.Add(img);
                pnlLoad.Name = "pnlLoad";
                pnlLoad.BorderStyle = BorderStyle.FixedSingle;
                pnlLoad.Size = new System.Drawing.Size(200, 56);
                pnlLoad.Location = new System.Drawing.Point(
                                                            (ctrl.Size.Width / 2) - 125,
                                                            (ctrl.Size.Height / 2) - 28
                                                           );

                ctrl.Resize += new EventHandler(ctrl_Resize);

                btCancelar.Name = "btCancelar";
                btCancelar.Text = "Cancelar";

                btCancelar.Location = new System.Drawing.Point(
                                                            (pnlLoad.Size.Width) - 125,
                                                            (pnlLoad.Size.Height / 2) - 5
                                                           );

                pnlLoad.Controls.Add(btCancelar);

                lblCarregando.Text = "Carregando...";
                lblCarregando.Name = "lblCarregando";

                lblCarregando.Location = new System.Drawing.Point(
                                                            (pnlLoad.Size.Width) - lblCarregando.Size.Width - 20,
                                                            (pnlLoad.Size.Height / 2) - lblCarregando.Size.Height
                                                           );
                pnlLoad.Controls.Add(lblCarregando);

                ctrl.Controls.Add(pnlLoad);

                pnlLoad.BringToFront();
            }
        }

        public void LoadHide(Control ctrl)
        {
            if (ctrl.Controls["pnlLoad"] != null)
                ctrl.Controls.Remove(ctrl.Controls["pnlLoad"]);
        }

        public bool InvokeRequired(Control ctrl)
        {
            return ctrl.Controls["pnlLoad"].InvokeRequired;
        }
        
        public void ctrl_Resize(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;

            pnlLoad.Location = new System.Drawing.Point(
                                            (ctrl.Size.Width / 2) - 125,
                                            (ctrl.Size.Height / 2) - 28
                                            );
        }

    }
}
