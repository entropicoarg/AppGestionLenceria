using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Services.Configuration
{
    public class PrintTagConfiguration
    {
        // Font configurations
        public FontConfig TitleFont { get; set; }
        public FontConfig NormalFont { get; set; }
        public FontConfig PriceFont { get; set; }

        // Layout configurations
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int LineHeight { get; set; }
        public int TitleBottomMargin { get; set; }

        // Printer configuration
        public string PrinterNameContains { get; set; } = "Brother QL-800";

        public class FontConfig
        {
            public string FontFamily { get; set; }
            public float Size { get; set; }
            public FontStyle Style { get; set; }

            public Font CreateFont()
            {
                return new Font(FontFamily, Size, Style);
            }
        }
    }
}
