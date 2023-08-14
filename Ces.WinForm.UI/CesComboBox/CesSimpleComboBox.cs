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
    public partial class CesSimpleComboBox : Infrastructure.CesControlBase
    {
        public CesSimpleComboBox()
        {
            InitializeComponent();
            ChildContainer = pnlContainer;
        }


        // This Class Property
        private Ces.WinForm.UI.CesFormBase frm;

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


        private bool cesAlignToRight = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesAlignToRight
        {
            get { return cesAlignToRight; }
            set { cesAlignToRight = value; }
        }


        private Size cesPopupSize = new Size(400, 600);
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public Size CesPopupSize
        {
            get { return cesPopupSize; }
            set { cesPopupSize = value; }
        }


        private IList<Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem> cesSource;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public IList<Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem> CesSource
        {
            get { return cesSource; }
            set { cesSource = value; }
        }


        private Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem? cesSelectedItem = null;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem? CesSelectedItem
        {
            get { return cesSelectedItem; }
            set
            {
                cesSelectedItem = value;

                if (value != null)
                    this.txtSelectedItem.Text = value.Text;
                else
                    this.txtSelectedItem.Text = string.Empty;
            }
        }


        private void CesSimpleComboBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            frm.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            frm = new CesFormBase();
            frm.Deactivate += new EventHandler(frmDeactivated);
            frm.CesBorderColor = CesBorderColor;
            frm.CesBorderThickness = 1;
            frm.TopMost = true;
            frm.Size = CesPopupSize;

            // Check frm size to fit in location. if will be out ot screen,
            // another location shall be select automatically

            var screenSize = Screen.PrimaryScreen.WorkingArea;
            var popupRightLocation = 0;
            var popupLeftLocation = 0;
            var popupBottomLocation = this.Parent.PointToScreen(Point.Empty).Y + this.Top + frm.Height;

            // Top Location
            if (popupBottomLocation > screenSize.Height)
                frm.Top = this.Parent.PointToScreen(Point.Empty).Y + this.Top - frm.Height;
            else
                frm.Top = this.Parent.PointToScreen(Point.Empty).Y + this.Top + this.Height;

            // Left Location
            if (CesAlignToRight)
                popupLeftLocation = this.Parent.PointToScreen(Point.Empty).X + this.Left - (frm.Width - this.Width);
            else
                popupRightLocation = this.Parent.PointToScreen(Point.Empty).X + this.Left + frm.Width;

            if (CesAlignToRight)
            {
                if (popupLeftLocation < 0)
                    frm.Left = 0;
                else
                    frm.Left = this.Parent.PointToScreen(Point.Empty).X + this.Left - (frm.Width - this.Width);
            }
            else
            {
                if (popupRightLocation > screenSize.Width)
                    frm.Left = screenSize.Width - frm.Width;
                else
                    frm.Left = this.Parent.PointToScreen(Point.Empty).X + this.Left;
            }

            FlowLayoutPanel flp = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            if (cesSource is null || CesSource.Count == 0)
                return;

            foreach (Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem item in CesSource)
            {
                var newItem = new Ces.WinForm.UI.CesComboBox.CesComboBoxItem(item);

                newItem.lblItemText.Click += new EventHandler(CesItemClick);
                newItem.Margin = new Padding(0, CesItemMargin, 0, CesItemMargin);
                newItem.pbItemImage.Width = CesImageWidth;
                newItem.Height = CesItemHeight;

                flp.Controls.Add(newItem);
            }

            // Show
            frm.Controls.Add(flp);
            frm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CesSelectedItem = null;
        }

        private void CesItemClick(object sender, EventArgs e)
        {
            CesSelectedItem = ((Ces.WinForm.UI.CesComboBox.CesComboBoxItem)((Label)sender).Parent).CesItem;
            frm.Close();
        }
    }
}
