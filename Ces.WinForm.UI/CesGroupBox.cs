using System.ComponentModel;

namespace Ces.WinForm.UI
{
    [ToolboxItem(true)]
    [Designer(typeof(System.Windows.Forms.Design.ParentControlDesigner))]
    public partial class CesGroupBox : Infrastructure.CesControlBase
    {
        public CesGroupBox()
        {
            InitializeComponent();

            CesTitleText = "Group Name";
            CesTitlePosition = Infrastructure.CesTitlePositionEnum.Top;
            CesShowTitle = true;
        }

        private void CesGroupBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void CesGroupBox_Resize(object sender, EventArgs e)
        {
            SetPadding();
        }
    }
}
