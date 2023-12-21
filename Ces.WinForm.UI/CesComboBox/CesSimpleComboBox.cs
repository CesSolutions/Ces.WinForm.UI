using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesComboBox
{
    [DefaultEvent(nameof(CesSelectedItemChanged))]
    [ToolboxItem(true)]
    public partial class CesSimpleComboBox : Infrastructure.CesControlBase
    {
        public CesSimpleComboBox()
        {
            InitializeComponent();
            ChildContainer = pnlContainer;
        }

        public delegate void CesSelectedItemChangedEventHandler(object sender, object? item);
        public event CesSelectedItemChangedEventHandler CesSelectedItemChanged;

        // This Class Property
        private Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxPopup frmPopup;

        private int cesItemMargin = 1;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public int CesItemMargin
        {
            get { return cesItemMargin; }
            set { cesItemMargin = value; }
        }

        private int cesItemHeight = 35;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public int CesItemHeight
        {
            get { return cesItemHeight; }
            set { cesItemHeight = value; }
        }


        private int cesImageWidth = 35;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public int CesImageWidth
        {
            get { return cesImageWidth; }
            set { cesImageWidth = value; }
        }

        private bool cesShowIndicator = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set { cesShowIndicator = value; }
        }


        private bool cesShowImage = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set { cesShowImage = value; }
        }


        private bool cesAlignToRight = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesAlignToRight
        {
            get { return cesAlignToRight; }
            set { cesAlignToRight = value; }
        }


        private Size cesPopupSize = new Size(350, 400);
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public Size CesPopupSize
        {
            get { return cesPopupSize; }
            set { cesPopupSize = value; }
        }


        //private IList<Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem> cesSource;
        //[System.ComponentModel.Category("Ces Simple ComboBox")]
        //[System.ComponentModel.Browsable(false)]
        //public IList<Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem> CesSource
        //{
        //    get { return cesSource; }
        //    set
        //    {
        //        cesSource = value;
        //        CesSelectedItem = null;
        //    }
        //}



        //private Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem? cesSelectedItem = null;
        //[System.ComponentModel.Category("Ces Simple ComboBox")]
        //[System.ComponentModel.Browsable(false)]
        //public Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem? CesSelectedItem
        //{
        //    get { return cesSelectedItem; }
        //    set
        //    {
        //        cesSelectedItem = value;

        //        if (value != null)
        //            this.txtSelectedItem.Text = value.Text;
        //        else
        //            this.txtSelectedItem.Text = string.Empty;
        //    }
        //}
        private object? cesSelectedItem = null;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        [System.ComponentModel.Browsable(false)]
        public object? CesSelectedItem
        {
            get { return cesSelectedItem; }
            set
            {
                cesSelectedItem = value;

                if (value != null)
                    this.txtSelectedItem.Text = ((Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem)value).Text;
                else
                    this.txtSelectedItem.Text = string.Empty;

                if (CesSelectedItemChanged != null)
                    CesSelectedItemChanged(this, value);
            }
        }


        private bool cesAdjustPopupToParentWidth = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesAdjustPopupToParentWidth
        {
            get { return cesAdjustPopupToParentWidth; }
            set { cesAdjustPopupToParentWidth = value; }
        }


        private bool cesShowClearButton = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowClearButton
        {
            get { return cesShowClearButton; }
            set
            {
                cesShowClearButton = value;
                this.btnClear.Visible = value;
            }
        }

        private string cesValueMember { get; set; }
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public string CesValueMember
        {
            get { return cesValueMember; }
            set
            {
                cesValueMember = value;
            }
        }

        private string cesDisplayMember { get; set; }
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public string CesDisplayMember
        {
            get { return cesDisplayMember; }
            set
            {
                cesDisplayMember = value;
            }
        }

        private IEnumerable<object> MainData = new List<object>();

        public void CesDataSource<T>(IList<T> dataSource) where T : class
        {
            //MainData = MainData.Cast<T>().ToList();
            //MainData = (List<T>)dataSource;

            frmPopup = new CesSimpleComboBoxPopup();
            frmPopup.MainData = MainData.Cast<T>().ToList();
            frmPopup.MainData = (List<T>)dataSource;
        }


        private void CesSimpleComboBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            frmPopup.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //if (cesSource is null || CesSource.Count == 0)
            //    return;

            if (frmPopup.MainData is null || frmPopup.MainData.Count() == 0)
                return;

            var comboOptions = new Ces.WinForm.UI.CesComboBox.CesComboBoxOptions
            {
                ShowIndicator = CesShowIndicator,
                ShowImage = cesShowImage,
                Margin = CesItemMargin,
                ImageWidth = CesImageWidth,
                ItemHeight = CesItemHeight,
                ValueMember = CesValueMember,
                DisplayMember = CesDisplayMember,
                //ItemWidth = frmPopup.flp.ClientRectangle.Width,
            };

            //frmPopup = new CesSimpleComboBoxPopup();

            frmPopup.Deactivate += new EventHandler(frmDeactivated);
            frmPopup.CesBorderColor = CesBorderColor;
            frmPopup.CesBorderThickness = 1;
            frmPopup.TopMost = true;
            frmPopup.Size = CesAdjustPopupToParentWidth ? new Size(this.Width, CesPopupSize.Height) : CesPopupSize;
            frmPopup.Options = comboOptions;
            

            // Check form size to fit in location. if locate out of screen,
            // another location shall be select automatically by application

            var screenSize = Screen.PrimaryScreen.WorkingArea;
            var popupRightLocation = 0;
            var popupLeftLocation = 0;
            var comboLocation = this.PointToScreen(Point.Empty);
            var popupBottomLocation = comboLocation.Y + frmPopup.Height;

            // Top Location
            if (popupBottomLocation > screenSize.Height)
                frmPopup.Top = comboLocation.Y - frmPopup.Height;
            else
                frmPopup.Top = comboLocation.Y + this.Height;

            // Left Location
            if (CesAlignToRight)
                popupLeftLocation = comboLocation.X - (frmPopup.Width - this.Width);
            else
                popupRightLocation = comboLocation.X + frmPopup.Width;

            if (CesAlignToRight)
            {
                if (popupLeftLocation < 0)
                    frmPopup.Left = 0;
                else
                    frmPopup.Left = comboLocation.X - (frmPopup.Width - this.Width);
            }
            else
            {
                if (popupRightLocation > screenSize.Width)
                    frmPopup.Left = screenSize.Width - frmPopup.Width;
                else
                    frmPopup.Left = comboLocation.X < 0 ? 0 : comboLocation.X;
            }

            //var comboOptions = new Ces.WinForm.UI.CesComboBox.CesComboBoxOptions
            //{
            //    ShowIndicator = CesShowIndicator,
            //    ShowImage = cesShowImage,
            //    Margin = CesItemMargin,
            //    ImageWidth = CesImageWidth,
            //    ItemHeight = CesItemHeight,
            //    //ItemWidth = frmPopup.flp.ClientRectangle.Width,
            //};

            //frmPopup.SuspendLayout();

            //int count = 0;

            //foreach (Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem item in MainData)
            //{
            //    var newItem = new Ces.WinForm.UI.CesComboBox.CesComboBoxItem(item, comboOptions);

            //    newItem.lblItemText.Click += new EventHandler(CesItemClick);
            //    newItem.Top = count * (comboOptions.ItemHeight + comboOptions.Margin);

            //    //frmPopup.pnlContainer.Controls.Add(newItem);
            //    count += 1;
            //}

            //frmPopup.ResumeLayout(true);

            // Show            
            frmPopup.ShowDialog(this);
            CesSelectedItem = frmPopup.SelectedItem;
            // اگر اسکرول بار عمود فعال شده باشد باید مجددا عرض آیتم ها را اصلاح
            // کرد و کوچکتر شوند تا اسکرول بار اففقط نمایان نشود
            //if (frmPopup.flp.VerticalScroll.Visible)
            //    foreach (Ces.WinForm.UI.CesComboBox.CesComboBoxItem item in frmPopup.flp.Controls)
            //    {
            //        item.Width = frmPopup.flp.ClientRectangle.Width;
            //    }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CesSelectedItem = null;
        }

        //private void CesItemClick(object sender, EventArgs e)
        //{
        //    CesSelectedItem = ((Ces.WinForm.UI.CesComboBox.CesComboBoxItem)((Label)sender).Parent).CesItem;
        //    frmPopup.Close();

        //    if (CesSelectedItemChanged != null)           
        //        CesSelectedItemChanged(this, CesSelectedItem);            
        //}
    }
}
