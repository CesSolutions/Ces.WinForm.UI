using System.Reflection.PortableExecutable;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CeeHeaderRow : UserControl
    {
        public CeeHeaderRow()
        {
            InitializeComponent();
        }

        private List<CesColumnHeader> _Columns { get; set; }
        public List<CesColumnHeader> Columns
        {
            get { return _Columns; }
        }

        public void AddColumn(CesColumnHeader column)
        {
            _Columns.Add(column);

          
        }
    }
}
