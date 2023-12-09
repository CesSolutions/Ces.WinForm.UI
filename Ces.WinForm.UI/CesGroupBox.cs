using System.ComponentModel;

namespace Ces.WinForm.UI
{
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
            this.Padding = CesPadding;
            this.GenerateBorder(this);
        }
    }
}
