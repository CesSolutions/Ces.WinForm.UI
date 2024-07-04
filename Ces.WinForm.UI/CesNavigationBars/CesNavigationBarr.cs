using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesNavigationBars
{
    public partial class CesNavigationBarr : System.Windows.Forms.ToolStrip
    {
        private const int _buttonMargine = 2;

        public CesNavigationBarr()
        {
            InitializeComponent();
            CreateStandardItems();
        }

        private void CreateStandardItems()
        {
            CreateHelpSection();
            CreateNavigationSection();
        }

        private void CreateHelpSection()
        {
            var btnHelp = new ToolStripButton();
            btnHelp.Name = nameof(btnHelp);
            btnHelp.Text = "Help";
            btnHelp.ToolTipText = btnHelp.Text;
            btnHelp.Margin = new Padding(all: _buttonMargine);
            btnHelp.ImageScaling = ToolStripItemImageScaling.None;
            btnHelp.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarHelp;
            btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnHelp.Visible = true;

            var helpSectionSeparator = new System.Windows.Forms.ToolStripSeparator();
            helpSectionSeparator.Name = nameof(helpSectionSeparator);
            helpSectionSeparator.Visible = true;

            this.Items.Add(btnHelp);
            this.Items.Add(helpSectionSeparator);
        }

        private void CreateNavigationSection()
        {
            var btnFirst = new ToolStripButton();
            btnFirst.Name = nameof(btnFirst);
            btnFirst.Text = "First";
            btnFirst.ToolTipText = btnFirst.Text;
            btnFirst.Margin = new Padding(all: _buttonMargine);
            btnFirst.ImageScaling = ToolStripItemImageScaling.None;
            btnFirst.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarFirst;
            btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFirst.Visible = true;

            var btnPrevious = new ToolStripButton();
            btnPrevious.Name = nameof(btnPrevious);
            btnPrevious.Text = "Previous";
            btnPrevious.ToolTipText = btnPrevious.Text;
            btnPrevious.Margin = new Padding(all: _buttonMargine);
            btnPrevious.ImageScaling = ToolStripItemImageScaling.None;
            btnPrevious.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarPrevious;
            btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnPrevious.Visible = true;

            var txtNavigationInfo = new ToolStripTextBox();
            txtNavigationInfo.Name = nameof(txtNavigationInfo);
            txtNavigationInfo.Size = new System.Drawing.Size(100, 35);
            txtNavigationInfo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtNavigationInfo.Text = "0 of 0";
            txtNavigationInfo.ToolTipText = txtNavigationInfo.Text;
            txtNavigationInfo.Margin = new Padding(all: _buttonMargine);
            btnPrevious.Visible = true;

            var btnNext = new ToolStripButton();
            btnNext.Name = nameof(btnNext);
            btnNext.Text = "Next";
            btnNext.ToolTipText = btnNext.Text;
            btnNext.Margin = new Padding(all: _buttonMargine);
            btnNext.ImageScaling = ToolStripItemImageScaling.None;
            btnNext.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarNext;
            btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnNext.Visible = true;

            var btnLast = new ToolStripButton();
            btnLast.Name = nameof(btnLast);
            btnLast.Text = "Last";
            btnLast.ToolTipText = btnLast.Text;
            btnLast.Margin = new Padding(all: _buttonMargine);
            btnLast.ImageScaling = ToolStripItemImageScaling.None;
            btnLast.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarLast;
            btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnLast.Visible = true;

            var navigationSectionSeparator = new System.Windows.Forms.ToolStripSeparator();
            navigationSectionSeparator.Name = nameof(navigationSectionSeparator);
            navigationSectionSeparator.Visible = true;

            this.Items.Add(btnFirst);
            this.Items.Add(btnPrevious);
            this.Items.Add(txtNavigationInfo);
            this.Items.Add(btnNext);
            this.Items.Add(btnLast);
            this.Items.Add(navigationSectionSeparator);
        }

        private void CreateOperationSection()
        {
            var btnSelectAll = new ToolStripButton();
            btnSelectAll.Name = nameof(btnSelectAll);
            btnSelectAll.Text = "Select All";
            btnSelectAll.ToolTipText = btnSelectAll.Text;
            btnSelectAll.Margin = new Padding(all: _buttonMargine);
            btnSelectAll.ImageScaling = ToolStripItemImageScaling.None;
            btnSelectAll.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarSelectAll;
            btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSelectAll.Visible = true;

            var btnClearSelection = new ToolStripButton();
            btnClearSelection.Name = nameof(btnClearSelection);
            btnClearSelection.Text = "Clear Selection";
            btnClearSelection.ToolTipText = btnClearSelection.Text;
            btnClearSelection.Margin = new Padding(all: _buttonMargine);
            btnClearSelection.ImageScaling = ToolStripItemImageScaling.None;
            btnClearSelection.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarClearSelection;
            btnClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnClearSelection.Visible = true;

            var btnFilter = new ToolStripButton();
            btnFilter.Name = nameof(btnFilter);
            btnFilter.Text = "Filter";
            btnFilter.ToolTipText = btnFilter.Text;
            btnFilter.Margin = new Padding(all: _buttonMargine);
            btnFilter.ImageScaling = ToolStripItemImageScaling.None;
            btnFilter.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarFilter;
            btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFilter.Visible = true;

            var btnSort = new ToolStripButton();
            btnSort.Name = nameof(btnSort);
            btnSort.Text = "Sort";
            btnSort.ToolTipText = btnSort.Text;
            btnSort.Margin = new Padding(all: _buttonMargine);
            btnSort.ImageScaling = ToolStripItemImageScaling.None;
            btnSort.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarSort;
            btnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSort.Visible = true;

            var helpSectionSeparator = new System.Windows.Forms.ToolStripSeparator();
            helpSectionSeparator.Name = nameof(helpSectionSeparator);
            helpSectionSeparator.Visible = true;

            this.Items.Add(btnSelectAll);
            this.Items.Add(btnClearSelection);
            this.Items.Add(btnFilter);
            this.Items.Add(btnSort);
            this.Items.Add(helpSectionSeparator);
        }
    }
}
