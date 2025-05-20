using System.ComponentModel;
using System.Reflection.PortableExecutable;

namespace Ces.WinForm.UI.CesGridView
{
    [ToolboxItem(false)]
    public partial class CesHeaderRow : UserControl
    {
        public CesHeaderRow()
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
