namespace Ces.WinForm.UI
{
    public partial class CesButton : System.Windows.Forms.Button
    {
        public CesButton()
        {
            InitializeComponent();

            _template = new Dictionary<Infrastructure.ColorTemplateEnum, Infrastructure.TemplateProperty>();

            _template.Add(Infrastructure.ColorTemplateEnum.Black, new Infrastructure.TemplateProperty { TextColor = Color.White, NormalColor = Color.Black, MouseOverColor = Color.FromArgb(64, 64, 64), MouseDownColor = Color.Black, BorderColor = Color.Black });
            _template.Add(Infrastructure.ColorTemplateEnum.Dark, new Infrastructure.TemplateProperty { TextColor = Color.White, NormalColor = Color.FromArgb(64, 64, 64), MouseOverColor = Color.Gray, MouseDownColor = Color.FromArgb(64, 64, 64), BorderColor = Color.Black });
            _template.Add(Infrastructure.ColorTemplateEnum.Gray, new Infrastructure.TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gray, MouseOverColor = Color.DarkGray, MouseDownColor = Color.Gray, BorderColor = Color.FromArgb(64, 64, 64) });
            _template.Add(Infrastructure.ColorTemplateEnum.Green, new Infrastructure.TemplateProperty { TextColor = Color.Black, NormalColor = Color.MediumSeaGreen, MouseOverColor = Color.DarkSeaGreen, MouseDownColor = Color.MediumSeaGreen, BorderColor = Color.DarkGreen });
            _template.Add(Infrastructure.ColorTemplateEnum.Blue, new Infrastructure.TemplateProperty { TextColor = Color.Black, NormalColor = Color.CornflowerBlue, MouseOverColor = Color.LightSteelBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.MediumBlue });
            _template.Add(Infrastructure.ColorTemplateEnum.Red, new Infrastructure.TemplateProperty { TextColor = Color.Black, NormalColor = Color.Tomato, MouseOverColor = Color.Salmon, MouseDownColor = Color.Tomato, BorderColor = Color.Firebrick });
            _template.Add(Infrastructure.ColorTemplateEnum.Orange, new Infrastructure.TemplateProperty { TextColor = Color.Black, NormalColor = Color.Orange, MouseOverColor = Color.SandyBrown, MouseDownColor = Color.Orange, BorderColor = Color.Chocolate });
            _template.Add(Infrastructure.ColorTemplateEnum.Yellow, new Infrastructure.TemplateProperty { TextColor = Color.Black, NormalColor = Color.Khaki, MouseOverColor = Color.PaleGoldenrod, MouseDownColor = Color.Khaki, BorderColor = Color.DarkKhaki });
        }


        private IDictionary<Infrastructure.ColorTemplateEnum, Infrastructure.TemplateProperty> _template;


        private Infrastructure.ColorTemplateEnum cesColorTemplate { get; set; }
        public Infrastructure.ColorTemplateEnum CesColorTemplate
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

            if (cesColorTemplate == Infrastructure.ColorTemplateEnum.None)
                return;

            this.ForeColor = temp.Value.TextColor;
            this.BackColor = temp.Value.NormalColor;
            this.FlatAppearance.MouseOverBackColor = temp.Value.MouseOverColor;
            this.FlatAppearance.MouseDownBackColor = temp.Value.MouseDownColor;
            this.FlatAppearance.BorderColor = temp.Value.BorderColor;
        }
    }
}
