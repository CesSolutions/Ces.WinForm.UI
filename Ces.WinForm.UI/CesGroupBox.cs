using System.ComponentModel;

namespace Ces.WinForm.UI
{
    [ToolboxItem(true)]
    [Designer(typeof(Microsoft.DotNet.DesignTools.Designers.ParentControlDesigner))]
    public partial class CesGroupBox : Infrastructure.CesControlBase
    {
        public CesGroupBox()
        {
            InitializeComponent();

            CesTitleText = "Group Name";
            CesTitlePosition = Infrastructure.CesTitlePositionEnum.Top;
            CesShowTitle = true;
        }

        private Color currentBorderColor;

        private void CesGroupBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void CesGroupBox_Resize(object sender, EventArgs e)
        {
            SetPadding();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
                CesBorderColor = currentBorderColor;
            else
            {
                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }
    }
}
