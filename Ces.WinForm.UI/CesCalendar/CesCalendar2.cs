
using System.ComponentModel;

namespace Ces.WinForm.UI.CesCalendar
{
    [ToolboxItem(true)]
    public partial class CesCalendar2 : Infrastructure.CesControlBase
    {
        private Color currentBorderColor;

        public CesCalendar2()
        {
            InitializeComponent();
            ChildContainer = this.pnlContainer;
            cesMonthCalendar = this.MonthCalendar;
        }

        private MonthCalendar cesMonthCalendar;
        public MonthCalendar CesMonthCalendar
        {
            get { return cesMonthCalendar; }
            set {  cesMonthCalendar = value; }
        }

        #region Override Methods

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                CesBorderColor = currentBorderColor;
            }
            else
            {
                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }

        #endregion Override Methods

        private void CesCalendar2_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }
    }
}
