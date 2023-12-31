using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI
{
    [Designer(typeof(CesCollapsiblePanelDesigner))]
    public partial class CesCollapsiblePanel : UserControl
    {
        public CesCollapsiblePanel()
        {
            InitializeComponent();
            ExpandHeight = this.Height;
        }


        public delegate void CesCollapsiblePanelStateEventHandler(object sender, CesCollapsiblePanelStateEnum state);
        public event CesCollapsiblePanelStateEventHandler CesCollapsiblePanelStateChanged;

        private int ExpandHeight { get; set; }

        private CesCollapsiblePanelStateEnum cesState { get; set; } = CesCollapsiblePanelStateEnum.Expanded;
        public CesCollapsiblePanelStateEnum CesState
        {
            get { return cesState; }
            set
            {
                cesState = value;
                SetState();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public Panel ContainerPanel
        {
            get { return pnlContainer; }
        }


        private string cesTitle { get; set; } = "CesCollapsiblePanel";
        [Category("Ces CollapsiblePanel")]
        public string CesTitle
        {
            get { return cesTitle; }
            set
            {
                cesTitle = value;
                lblTitle.Text = value;
            }
        }

        private bool cesShowIcon { get; set; } = false;
        [Category("Ces CollapsiblePanel")]
        public bool CesShowIcon
        {
            get { return cesShowIcon; }
            set
            {
                cesShowIcon = value;
                pbIcon.Visible = value;
            }
        }

        private Image cesIcon { get; set; }
        [Category("Ces CollapsiblePanel")]
        public Image CesIcon
        {
            get { return cesIcon; }
            set
            {
                cesIcon = value;
                pbIcon.Image = value;
            }
        }

        private Color cesTitleBackColor { get; set; } = Color.Gainsboro;
        [Category("Ces CollapsiblePanel")]
        public Color CesTitleBackColor
        {
            get { return cesTitleBackColor; }
            set
            {
                cesTitleBackColor = value;
                pnlTitle.BackColor = value;
            }
        }

        private Color cesTitleTextColor { get; set; } = Color.Black;
        [Category("Ces CollapsiblePanel")]
        public Color CesTitleTextColor
        {
            get { return cesTitleTextColor; }
            set
            {
                cesTitleTextColor = value;
                lblTitle.ForeColor = value;
            }
        }

        private Color cesBackColor { get; set; } = Color.White;
        [Category("Ces CollapsiblePanel")]
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                pnlContainer.BackColor = value;
            }
        }

        private int cesTitleHeight { get; set; } = 40;
        [Category("Ces CollapsiblePanel")]
        public int CesTitleHeight
        {
            get { return cesTitleHeight; }
            set
            {
                cesTitleHeight = value;
                pnlTitle.Height = value;
                pbIcon.Width = value;
            }
        }


        private void pb_Click(object sender, EventArgs e)
        {
            if (CesState == CesCollapsiblePanelStateEnum.Expanded)
                CesState = CesCollapsiblePanelStateEnum.Collapsed;
            else
                CesState = CesCollapsiblePanelStateEnum.Expanded;
        }

        private void SetState()
        {
            if (CesState == CesCollapsiblePanelStateEnum.Collapsed)
            {
                ExpandHeight = this.Height;
                this.Height = CesTitleHeight + 2;
                pb.Image = Ces.WinForm.UI.Properties.Resources.CesCollapsiblePanelExpand;
            }
            else if (CesState == CesCollapsiblePanelStateEnum.Expanded)
            {
                this.Height = ExpandHeight;
                pb.Image = Ces.WinForm.UI.Properties.Resources.CesCollapsiblePanelCollapse;
            }

            CesCollapsiblePanelStateChanged?.Invoke(this, CesState);
        }

        private void CesCollapsiblePanel_ControlAdded(object sender, ControlEventArgs e)
        {
            this.Controls.Remove(e.Control);
        }
    }

    public class CesCollapsiblePanelDesigner : Microsoft.DotNet.DesignTools.Designers.ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (this.Control is CesCollapsiblePanel)
            {
                this.EnableDesignMode(
                   ((CesCollapsiblePanel)this.Control).ContainerPanel, "ContainerPanel");
            }
        }
    }

    public enum CesCollapsiblePanelStateEnum
    {
        Collapsed,
        Expanded,
    }
}
