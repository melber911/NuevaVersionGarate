using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace GMT_Sfe
{
    public class BarCode
    {
        private static int ErrorLevelSunat = 5;

        public static Bitmap PDF417(string _param0, int _param1 = 1)
        {
            if (string.IsNullOrEmpty(_param0.Trim()))
                return (Bitmap)null;

            BarcodePDF417 barcodePdF417 = new BarcodePDF417();
            barcodePdF417.ErrorLevel = BarCode.ErrorLevelSunat;
            barcodePdF417.CodeRows = 5;
            barcodePdF417.CodeColumns = 18;
            barcodePdF417.LenCodewords = 999;
            barcodePdF417.Options = 32;
            byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(_param0);
            barcodePdF417.Text = bytes;
            try
            {
                Bitmap bitmap1 = new Bitmap(barcodePdF417.CreateDrawingImage(Color.Black, Color.White));
                if (_param1 == 1)
                    return bitmap1;
                Bitmap bitmap2 = new Bitmap(Convert.ToInt32(bitmap1.Width * _param1), Convert.ToInt32(bitmap1.Height * _param1));
                Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap2);
                graphics.ScaleTransform((float)_param1, (float)_param1);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage((System.Drawing.Image)bitmap1, new Point(0, 0));
                return bitmap2;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating PDF417 barcode. Desc:" + ex.Message);
            }
        }

        public static iTextSharp.text.Image MakeBarcodePDF417(string _param0, int _param1 = 1)
        {
            BarcodePDF417 barcodePdF417 = new BarcodePDF417();
            barcodePdF417.ErrorLevel = BarCode.ErrorLevelSunat;
            barcodePdF417.CodeRows = 5;
            barcodePdF417.CodeColumns = 18;
            barcodePdF417.LenCodewords = 999;
            barcodePdF417.Options = 32;
            byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(_param0);
            barcodePdF417.Text = bytes;
            iTextSharp.text.Image image = barcodePdF417.GetImage();
            image.ScalePercent((float)(100 * _param1));
            return image;
        }
    }
}
