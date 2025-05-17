using Ces.WinForm.UI.CesGridView.Events;
using System.ComponentModel;

namespace Ces.WinForm.UI.CesGridView
{
    //[ToolboxItem(false)]
    public partial class CesColumnHeader : UserControl
    {
        public CesColumnHeader()
        {
            InitializeComponent();
        }

        public event EventHandler<FilterTextChangedEvent> FilterTextChanged;

        private string _Title { get; set; }
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                btn.Text = value;
            }
        }

        private ContentAlignment _TitleAlignment { get; set; } = ContentAlignment.MiddleCenter;
        public ContentAlignment TitleAlignment
        {
            get { return _TitleAlignment; }
            set
            {
                _TitleAlignment = value;
                btn.TextAlign = value;
            }
        }

        private void txt_Load(object sender, EventArgs e)
        {

        }

        private void txt_CesTextChanged(object sender, EventArgs e)
        {
            if (FilterTextChanged != null)
                FilterTextChanged.Invoke(this, new FilterTextChangedEvent { Filter = txt.CesText });
        }
    }
}
