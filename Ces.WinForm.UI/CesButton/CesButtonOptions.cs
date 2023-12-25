using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesButton
{
    public static class CesButtonOptions
    {
        static CesButtonOptions()
        {

            CesButtonColorTemplate = new Dictionary<ColorTemplateEnum, TemplateProperty>();

            CesButtonColorTemplate.Add(ColorTemplateEnum.Black, new TemplateProperty { TextColor = Color.White, NormalColor = Color.Black, MouseOverColor = Color.FromArgb(64, 64, 64), MouseDownColor = Color.Black, BorderColor = Color.Black });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Dark, new TemplateProperty { TextColor = Color.White, NormalColor = Color.FromArgb(64, 64, 64), MouseOverColor = Color.Gray, MouseDownColor = Color.FromArgb(64, 64, 64), BorderColor = Color.Black });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Gray, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gray, MouseOverColor = Color.DarkGray, MouseDownColor = Color.Gray, BorderColor = Color.FromArgb(64, 64, 64) });
            
            CesButtonColorTemplate.Add(ColorTemplateEnum.Silver, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.LightGray, MouseOverColor = Color.Silver, MouseDownColor = Color.LightGray, BorderColor = Color.Gray });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Light, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.WhiteSmoke, MouseOverColor = Color.Gainsboro, MouseDownColor = Color.WhiteSmoke, BorderColor = Color.Silver });

            CesButtonColorTemplate.Add(ColorTemplateEnum.Green, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.MediumSeaGreen, MouseOverColor = Color.DarkSeaGreen, MouseDownColor = Color.MediumSeaGreen, BorderColor = Color.DarkGreen });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Blue, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.CornflowerBlue, MouseOverColor = Color.LightSteelBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.MediumBlue });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Red, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Tomato, MouseOverColor = Color.Salmon, MouseDownColor = Color.Tomato, BorderColor = Color.Firebrick });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Orange, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Orange, MouseOverColor = Color.SandyBrown, MouseDownColor = Color.Orange, BorderColor = Color.Chocolate });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Yellow, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Khaki, MouseOverColor = Color.PaleGoldenrod, MouseDownColor = Color.Khaki, BorderColor = Color.DarkKhaki });
        }

        public static IDictionary<ColorTemplateEnum, TemplateProperty> CesButtonColorTemplate;
    }

    public enum ColorTemplateEnum
    {
        None,
        Black,
        Dark,
        Gray,
        Silver,
        Light,
        Green,
        Blue,
        Red,
        Orange,
        Yellow,
    }

    public class TemplateProperty
    {
        public Color TextColor { get; set; }
        public Color NormalColor { get; set; }
        public Color MouseOverColor { get; set; }
        public Color MouseDownColor { get; set; }
        public Color BorderColor { get; set; }
    }
}
