namespace Ces.WinForm.UI.CesButton
{
    public partial class CesButton : System.Windows.Forms.Button
    {
        public CesButton()
        {
            InitializeComponent();

            _template = new Dictionary<ColorTemplateEnum, TemplateProperty>();

            _template.Add(ColorTemplateEnum.Black, new TemplateProperty { TextColor = Color.White, NormalColor = Color.Black, MouseOverColor = Color.FromArgb(64, 64, 64), MouseDownColor = Color.Black, BorderColor = Color.Black });
            _template.Add(ColorTemplateEnum.Dark, new TemplateProperty { TextColor = Color.White, NormalColor = Color.FromArgb(64, 64, 64), MouseOverColor = Color.Gray, MouseDownColor = Color.FromArgb(64, 64, 64), BorderColor = Color.Black });
            _template.Add(ColorTemplateEnum.Gray, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gray, MouseOverColor = Color.DarkGray, MouseDownColor = Color.Gray, BorderColor = Color.FromArgb(64, 64, 64) });
            _template.Add(ColorTemplateEnum.Green, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.MediumSeaGreen, MouseOverColor = Color.DarkSeaGreen, MouseDownColor = Color.MediumSeaGreen, BorderColor = Color.DarkGreen });
            _template.Add(ColorTemplateEnum.Blue, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.CornflowerBlue, MouseOverColor = Color.LightSteelBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.MediumBlue });
            _template.Add(ColorTemplateEnum.Red, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Tomato, MouseOverColor = Color.Salmon, MouseDownColor = Color.Tomato, BorderColor = Color.Firebrick });
            _template.Add(ColorTemplateEnum.Orange, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Orange, MouseOverColor = Color.SandyBrown, MouseDownColor = Color.Orange, BorderColor = Color.Chocolate });
            _template.Add(ColorTemplateEnum.Yellow, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Khaki, MouseOverColor = Color.PaleGoldenrod, MouseDownColor = Color.Khaki, BorderColor = Color.DarkKhaki });
        }


        private IDictionary<ColorTemplateEnum, TemplateProperty> _template;


        private ColorTemplateEnum cesColorTemplate { get; set; }
        public ColorTemplateEnum CesColorTemplate
        {
            get { return cesColorTemplate; }
            set
            {
                cesColorTemplate = value;
                SetProperty();
            }
        }


        private int cesBorderThickness { get; set; } = 1;
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                this.FlatAppearance.BorderSize = value;
            }
        }


        private bool cesBorderVisible { get; set; }
        public bool CesBorderVisible
        {
            get { return cesBorderVisible; }
            set
            {
                cesBorderVisible = value;

                if (value == true)
                {
                    this.FlatAppearance.BorderSize = cesBorderThickness;
                }
                else
                {
                    this.FlatAppearance.BorderSize = 0;
                }
            }
        }


        private void SetProperty()
        {
            var temp = _template.FirstOrDefault(x => x.Key == cesColorTemplate);

            if (temp.Value == null)
                return;

            if (cesColorTemplate == ColorTemplateEnum.None)
                return;

            this.ForeColor = temp.Value.TextColor;
            this.BackColor = temp.Value.NormalColor;
            this.FlatAppearance.MouseOverBackColor = temp.Value.MouseOverColor;
            this.FlatAppearance.MouseDownBackColor = temp.Value.MouseDownColor;
            this.FlatAppearance.BorderColor = temp.Value.BorderColor;
        }
    }
}
