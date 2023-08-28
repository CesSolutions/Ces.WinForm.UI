using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// this codes get from https://www.reza-aghaei.com/enable-designer-of-child-panel-in-a-usercontrol/
/// </summary>

namespace Ces.WinForm.UI
{
   // [System.ComponentModel.Designer(typeof(CesGroupBoxDesigner))]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class CesGroupBox : Infrastructure.CesControlBase
    {
        public CesGroupBox()
        {
            InitializeComponent();
            CesTitleText = "Group Name";
            CesTitlePosition = Infrastructure.CesTitlePositionEnum.Top;
            CesShowTitle = true;


            //System.ComponentModel.TypeDescriptor.AddAttributes(this.pnlContainer,
            //    new System.ComponentModel.DesignerAttribute(typeof(ContainerPanelDesigner)));
        }

        private void CesGroupBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }


        //[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[System.ComponentModel.Category("Ces Container Panel")]
        //public Panel ContainerPanel
        //{
        //    get { return pnlContainer; }
        //}
    }

    //public class CesGroupBoxDesigner : System.Windows.Forms.Design.ParentControlDesigner
    //{
    //    public override void Initialize(IComponent component)
    //    {
    //        base.Initialize(component);
    //        //var contentsPanel = ((CesGroupBox)this.Control).ContainerPanel;
    //        //this.EnableDesignMode(contentsPanel, "Ces Container Panel");

    //        //if (this.Control is CesGroupBox)
    //        //    this.EnableDesignMode(
    //        //        ((CesGroupBox)this.Control).ContainerPanel, 
    //        //        "Ces Container Panel");
    //    }
    //    //public override bool CanParent(Control control)
    //    //{
    //    //    return false;
    //    //}
    //    //protected override void OnDragOver(DragEventArgs de)
    //    //{
    //    //    de.Effect = DragDropEffects.None;
    //    //}
    //    //protected override IComponent[] CreateToolCore(System.Drawing.Design.ToolboxItem tool,
    //    //    int x, int y, int width, int height, bool hasLocation, bool hasSize)
    //    //{
    //    //    return null;
    //    //}
    //}

    //public class ContainerPanelDesigner : System.Windows.Forms.Design.ParentControlDesigner
    //{
    //    public override System.Windows.Forms.Design.SelectionRules SelectionRules
    //    {
    //        get
    //        {
    //            System.Windows.Forms.Design.SelectionRules selectionRules = base.SelectionRules;
    //            selectionRules &= ~System.Windows.Forms.Design.SelectionRules.AllSizeable;
    //            return selectionRules;
    //        }
    //    }
    //    protected override void PostFilterAttributes(System.Collections.IDictionary attributes)
    //    {
    //        base.PostFilterAttributes(attributes);
    //        attributes[typeof(DockingAttribute)] = new DockingAttribute(DockingBehavior.Never);
    //    }
    //    protected override void PostFilterProperties(System.Collections.IDictionary properties)
    //    {
    //        base.PostFilterProperties(properties);
    //        var propertiesToRemove = new string[] {
    //        "Dock", "Anchor",
    //        "Size", "Location", "Width", "Height",
    //        "MinimumSize", "MaximumSize",
    //        "AutoSize", "AutoSizeMode",
    //        "Visible", "Enabled",
    //    };
    //        foreach (var item in propertiesToRemove)
    //        {
    //            if (properties.Contains(item))
    //                properties[item] = TypeDescriptor.CreateProperty(
    //                    this.Component.GetType(),
    //                    (PropertyDescriptor)properties[item],
    //                    new BrowsableAttribute(false));
    //        }
    //    }
    //}
}
