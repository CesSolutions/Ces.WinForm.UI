using System.Text;

namespace Ces.WinForm.UI
{
    public partial class CesTextList : System.Windows.Forms.Label
    {
        public CesTextList()
        {
            InitializeComponent();
        }

        private IList<string> cesItems { get; set; }
        public IList<string> CesItems
        {
            get
            {
                return cesItems;
            }
            set
            {
                cesItems = value;
                PopulateItems();
            }
        }


        private bool cesShowItemNumber { get; set; } = true;
        public bool CesShowItemNumber
        {
            get { return cesShowItemNumber; }
            set
            {
                cesShowItemNumber = value;
                PopulateItems();
            }
        }


        private string cesItemNumberSeparator { get; set; } = ".";
        public string CesItemNumberSeparator
        {
            get
            {
                return cesItemNumberSeparator;
            }
            set
            {
                cesItemNumberSeparator = value + " ";
                PopulateItems();
            }
        }


        private void PopulateItems()
        {
            this.Text = string.Empty;

            if (cesItems == null)
                return;

            var result = new StringBuilder();
            var counter = 0;

            foreach (var item in cesItems)
            {
                counter += 1;

                string currentItem =
                    (cesShowItemNumber ? counter.ToString() + cesItemNumberSeparator : string.Empty) +
                    item.ToString();

                result.Append(currentItem + Environment.NewLine);
            }

            this.Text = result.ToString();
        }
    }
}
