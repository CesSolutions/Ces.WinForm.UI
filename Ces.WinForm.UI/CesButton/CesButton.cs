namespace Ces.WinForm.UI.CesButton
{
    public partial class CesButton : System.Windows.Forms.Button
    {

        public CesButton()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            SetProperty();
        }

        private ColorTemplateEnum cesColorTemplate { get; set; } 
            = ColorTemplateEnum.Silver;
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

            this.ForeColor = this.Enabled ? temp.Value.TextColor : Color.DarkGray;
            this.BackColor = this.Enabled ? temp.Value.NormalColor : Color.LightGray;
            this.FlatAppearance.MouseOverBackColor = temp.Value.MouseOverColor;
            this.FlatAppearance.MouseDownBackColor = temp.Value.MouseDownColor;
            this.FlatAppearance.BorderColor = temp.Value.BorderColor;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            SetProperty();
        }
    }
}
