using Ces.WinForm.UI.CesGridView.Events;
using System.ComponentModel;

namespace Ces.WinForm.UI.CesGridView
{
    [ToolboxItem(false)]
    public partial class CesColumnHeader : UserControl
    {
        public CesColumnHeader()
        {
            InitializeComponent();
        }

        public event EventHandler<FilterTextChangedEvent> FilterTextChanged;
        private int _initialMouseX;
        private int _initialWidth;

        private int _Index { get; set; }
        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
            }
        }

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

        private void txt_CesTextChanged(object sender, EventArgs e)
        {
            if (FilterTextChanged != null)
                FilterTextChanged.Invoke(this, new FilterTextChangedEvent { Filter = txt.CesText });
        }

        private void splitter_MouseDown(object sender, MouseEventArgs e)
        {
            _initialMouseX = Cursor.Position.X;
            _initialWidth = this.Width;
        }

        private void splitter_MouseUp(object sender, MouseEventArgs e)
        {
            var headerX = this.PointToScreen(Point.Empty).X;
            var currentMouseX = Cursor.Position.X;
            this.Width = _initialWidth + (currentMouseX - _initialMouseX);
        }
    }
}
