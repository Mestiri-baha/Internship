using DocumentFormat.OpenXml.Drawing;
using System.Drawing;

namespace HomeComponent.Shared.HomePage
{
    public static class colorConfig
    {
        public static string ChangeColorBrightness(this Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            Color c =  Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
            return  string.Format("{0:x}{1:x}{2:x}", c.R, c.G, c.B);

        }
        
    }
}
