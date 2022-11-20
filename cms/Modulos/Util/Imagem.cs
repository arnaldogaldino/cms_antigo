using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using cms.Modulos.Util;
using System.IO;

namespace cms.Modulos.Util
{
    public class Imagem
    {
        public static Image redimensionarImagem(byte[] imagem, Size tamanho)
        {
            MemoryStream ms = new MemoryStream(imagem);

            Image img = Image.FromStream(ms);
            return redimensionarImagem(img, tamanho);
        }

        public static Image redimensionarImagem(Image imagem, Size tamanho)
        {
            int larguraOrigem = imagem.Width;
            int alturaOrigem = imagem.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)tamanho.Width / (float)larguraOrigem);
            nPercentH = ((float)tamanho.Height / (float)alturaOrigem);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int larguraDestino = (int)(larguraOrigem * nPercent);
            int alturaDestino = (int)(alturaOrigem * nPercent);

            Bitmap b = new Bitmap(larguraDestino, alturaDestino);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imagem, 0, 0, larguraDestino, alturaDestino);
            g.Dispose();

            return (Image)b;
        }

    }
}
