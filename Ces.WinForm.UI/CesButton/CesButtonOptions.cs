namespace Ces.WinForm.UI.CesButton
{
    public static class CesButtonOptions
    {
        static CesButtonOptions()
        {
            CesButtonColorTemplate = new Dictionary<ColorTemplateEnum, TemplateProperty>();

            CesButtonColorTemplate.Add(ColorTemplateEnum.Control, new TemplateProperty { TextColor = Color.Black, NormalColor = System.Drawing.SystemColors.Control, MouseOverColor = Color.Gainsboro, MouseDownColor = Color.WhiteSmoke, BorderColor = Color.LightGray });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Black, new TemplateProperty { TextColor = Color.White, NormalColor = Color.Black, MouseOverColor = Color.FromArgb(64, 64, 64), MouseDownColor = Color.Black, BorderColor = Color.Black });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Dark, new TemplateProperty { TextColor = Color.White, NormalColor = Color.FromArgb(64, 64, 64), MouseOverColor = Color.Gray, MouseDownColor = Color.FromArgb(64, 64, 64), BorderColor = Color.Black });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Gray, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gray, MouseOverColor = Color.DarkGray, MouseDownColor = Color.Gray, BorderColor = Color.FromArgb(64, 64, 64) });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Silver, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.LightGray, MouseOverColor = Color.Silver, MouseDownColor = Color.LightGray, BorderColor = Color.Gray });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Light, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.WhiteSmoke, MouseOverColor = Color.Gainsboro, MouseDownColor = Color.WhiteSmoke, BorderColor = Color.Silver });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Green, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.MediumSeaGreen, MouseOverColor = Color.DarkSeaGreen, MouseDownColor = Color.MediumSeaGreen, BorderColor = Color.DarkGreen });
            CesButtonColorTemplate.Add(ColorTemplateEnum.LightGreen, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.FromArgb(120, 209, 160), MouseOverColor = Color.MediumSeaGreen, MouseDownColor = Color.FromArgb(120, 209, 160), BorderColor = Color.MediumSeaGreen });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Blue, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.CornflowerBlue, MouseOverColor = Color.LightSteelBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.MediumBlue });
            CesButtonColorTemplate.Add(ColorTemplateEnum.LightSky, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.LightSkyBlue, MouseOverColor = Color.SkyBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.CornflowerBlue });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Red, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.OrangeRed, MouseOverColor = Color.Red, MouseDownColor = Color.OrangeRed, BorderColor = Color.Firebrick });
            CesButtonColorTemplate.Add(ColorTemplateEnum.LightRed, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.FromArgb(255, 113, 113), MouseOverColor = Color.FromArgb(255, 150, 150), MouseDownColor = Color.FromArgb(255, 113, 113), BorderColor = Color.Tomato });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Tomato, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Tomato, MouseOverColor = Color.Salmon, MouseDownColor = Color.Tomato, BorderColor = Color.Firebrick });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Orange, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Orange, MouseOverColor = Color.SandyBrown, MouseDownColor = Color.Orange, BorderColor = Color.Chocolate });
            CesButtonColorTemplate.Add(ColorTemplateEnum.LightOrange, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.FromArgb(255, 204, 111), MouseOverColor = Color.FromArgb(255, 220, 155), MouseDownColor = Color.FromArgb(255, 204, 111), BorderColor = Color.FromArgb(255, 204, 111) });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Yellow, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Khaki, MouseOverColor = Color.PaleGoldenrod, MouseDownColor = Color.Khaki, BorderColor = Color.DarkKhaki });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Gold, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gold, MouseOverColor = Color.Khaki, MouseDownColor = Color.Gold, BorderColor = Color.DarkKhaki });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Purple, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Plum, MouseOverColor = Color.Orchid, MouseDownColor = Color.Plum, BorderColor = Color.MediumOrchid });
            CesButtonColorTemplate.Add(ColorTemplateEnum.Olive, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.FromArgb(207, 219, 157), MouseOverColor = Color.DarkKhaki, MouseDownColor = Color.FromArgb(207, 219, 157), BorderColor = Color.FromArgb(192, 192, 0) });
        }

        public static IDictionary<ColorTemplateEnum, TemplateProperty> CesButtonColorTemplate;
    }

    public enum ColorTemplateEnum
    {
        None,
        Control,
        Black,
        Dark,
        Gray,
        Silver,
        Light,
        Green,
        LightGreen,
        Blue,
        LightSky,
        Red,
        LightRed,
        Tomato,
        Orange,
        LightOrange,
        Yellow,
        Gold,
        Purple,
        Olive,
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
