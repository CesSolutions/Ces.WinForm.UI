using System;
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
    public partial class CesCheckBox : UserControl
    {
        public CesCheckBox()
        {
            InitializeComponent();
        }

        private CesCheckBoxSizeEnum cesSize { get; set; } = CesCheckBoxSizeEnum.Medium;
        [Category("Ces CheckBox")]
        public CesCheckBoxSizeEnum CesSize
        {
            get { return cesSize; }
            set
            {
                cesSize = value;

                this.Height = 
                    value == CesCheckBoxSizeEnum.Small ? 16 :
                    value == CesCheckBoxSizeEnum.Medium ? 24 : 32;

                this.pb.Width =
                    value == CesCheckBoxSizeEnum.Small ? 16 :
                    value == CesCheckBoxSizeEnum.Medium ? 24 : 32;

                SetCheckBox();
            }
        }

        private CesCheckBoxTypeEnum cesType { get; set; } = CesCheckBoxTypeEnum.TypeB;
        [Category("Ces CheckBox")]
        public CesCheckBoxTypeEnum CesType
        {
            get { return cesType; }
            set
            {
                cesType = value;
                SetCheckBox();
            }
        }

        private System.Windows.Forms.CheckState cesCheck { get; set; }
        [Category("Ces CheckBox")]
        public System.Windows.Forms.CheckState CesCheck
        {
            get { return cesCheck; }
            set
            {
                cesCheck = value;
                SetCheckBox();
            }
        }

        private void SetCheckBox()
        {
            if (CesCheck == CheckState.Indeterminate)
                SetCheckBoxIndeterminate();

            if (CesCheck == CheckState.Unchecked)
                SetCheckBoxUnchecked();

            if (CesCheck == CheckState.Checked)
                SetCheckBoxChecked();
        }

        private void SetCheckBoxChecked()
        {
            if (CesType == CesCheckBoxTypeEnum.TypeA)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_32_Check;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeB)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_32_Check;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeC)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_32_Check;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeD)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_32_Check;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeE)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_32_Check;

                return;
            }
        }

        private void SetCheckBoxUnchecked()
        {
            if (CesType == CesCheckBoxTypeEnum.TypeA)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_32_Uncheck;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeB)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_32_Uncheck;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeC)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_32_Uncheck;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeD)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_32_Uncheck;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeE)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_32_Uncheck;

                return;
            }
        }

        private void SetCheckBoxIndeterminate()
        {
            if (CesType == CesCheckBoxTypeEnum.TypeA)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeA_32_None;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeB)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_32_None;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeC)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeC_32_None;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeD)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeD_32_None;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeE)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeE_32_None;

                return;
            }
        }

        private void pb_Click(object sender, EventArgs e)
        {
            SetCheckBoxState();
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            SetCheckBoxState();
        }

        private void SetCheckBoxState()
        {
            // تعیین وضعیت چک باکس باهر بار کلیک
            if (CesCheck == CheckState.Indeterminate)
                CesCheck = CheckState.Unchecked;
            else if (CesCheck == CheckState.Unchecked)
                CesCheck = CheckState.Checked;
            else
                CesCheck = CheckState.Indeterminate;

            SetCheckBox();
        }

        public override Cursor Cursor 
        {
            get { return base.Cursor; }
            set 
            { 
                base.Cursor = value;
                pb.Cursor = value;
                lbl.Cursor = value;
            }
        }
    }



    public enum CesCheckBoxSizeEnum
    {
        Small,
        Medium,
        Large,
    }

    public enum CesCheckBoxTypeEnum
    {
        TypeA,
        TypeB,
        TypeC,
        TypeD,
        TypeE,
    }
}
