namespace Ces.WinForm.UI.CesButton
{
    public partial class CesButton : System.Windows.Forms.Button
    {

        public CesButton()
        {
            InitializeComponent();

            //_colorTemplate = new Dictionary<ColorTemplateEnum, TemplateProperty>();

            //// تخصیص مقادیر پیش فرض جهت انتخاب رنگ
            //_colorTemplate.Add(ColorTemplateEnum.Black, new TemplateProperty { TextColor = Color.White, NormalColor = Color.Black, MouseOverColor = Color.FromArgb(64, 64, 64), MouseDownColor = Color.Black, BorderColor = Color.Black });
            //_colorTemplate.Add(ColorTemplateEnum.Dark, new TemplateProperty { TextColor = Color.White, NormalColor = Color.FromArgb(64, 64, 64), MouseOverColor = Color.Gray, MouseDownColor = Color.FromArgb(64, 64, 64), BorderColor = Color.Black });
            //_colorTemplate.Add(ColorTemplateEnum.Gray, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gray, MouseOverColor = Color.DarkGray, MouseDownColor = Color.Gray, BorderColor = Color.FromArgb(64, 64, 64) });
            //_colorTemplate.Add(ColorTemplateEnum.Green, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.MediumSeaGreen, MouseOverColor = Color.DarkSeaGreen, MouseDownColor = Color.MediumSeaGreen, BorderColor = Color.DarkGreen });
            //_colorTemplate.Add(ColorTemplateEnum.Blue, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.CornflowerBlue, MouseOverColor = Color.LightSteelBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.MediumBlue });
            //_colorTemplate.Add(ColorTemplateEnum.Red, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Tomato, MouseOverColor = Color.Salmon, MouseDownColor = Color.Tomato, BorderColor = Color.Firebrick });
            //_colorTemplate.Add(ColorTemplateEnum.Orange, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Orange, MouseOverColor = Color.SandyBrown, MouseDownColor = Color.Orange, BorderColor = Color.Chocolate });
            //_colorTemplate.Add(ColorTemplateEnum.Yellow, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Khaki, MouseOverColor = Color.PaleGoldenrod, MouseDownColor = Color.Khaki, BorderColor = Color.DarkKhaki });
        }


        // private IDictionary<ColorTemplateEnum, TemplateProperty> _colorTemplate;


        private ColorTemplateEnum cesColorTemplate { get; set; }
        [System.ComponentModel.Category("Ces Button")]
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
        [System.ComponentModel.Category("Ces Button")]
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
        [System.ComponentModel.Category("Ces Button")]
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

        // ToolTip

        private bool cesEnableToolTip { get; set; } = false;
        [System.ComponentModel.Category("Ces Button")]
        public bool CesEnableToolTip
        {
            get { return cesEnableToolTip; }
            set
            {
                cesEnableToolTip = value;
                CesToolTip.CesAddToolTipHandler(this);
            }
        }

        private string cesToolTipText { get; set; }
        [System.ComponentModel.Category("Ces Button")]
        public string CesToolTipText
        {
            get { return cesToolTipText; }
            set
            {
                cesToolTipText = value;
                CesToolTip.CesAddToolTipHandler(this);
            }
        }


        // Methods


        private void SetProperty()
        {
            var temp = Ces.WinForm.UI.CesButton.CesButtonOptions.CesButtonColorTemplate.FirstOrDefault(x => x.Key == cesColorTemplate);

            if (temp.Value == null || cesColorTemplate == ColorTemplateEnum.None)
                return;

            this.ForeColor = temp.Value.TextColor;
            this.BackColor = temp.Value.NormalColor;
            this.FlatAppearance.MouseOverBackColor = temp.Value.MouseOverColor;
            this.FlatAppearance.MouseDownBackColor = temp.Value.MouseDownColor;
            this.FlatAppearance.BorderColor = temp.Value.BorderColor;
        }
    }
}
