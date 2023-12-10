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

        public bool cesUseIndeterminateState { get; set; } = false;
        [Category("Ces CheckBox")]
        public bool CesUseIndeterminateState
        {
            get { return cesUseIndeterminateState; }
            set { cesUseIndeterminateState = value; }
        }

        private System.Windows.Forms.CheckState cesCheckState { get; set; }
        [Category("Ces CheckBox")]
        public System.Windows.Forms.CheckState CesCheckState
        {
            get { return cesCheckState; }
            set
            {
                cesCheckState = value;
                SetCheckBox();
            }
        }

        private string cesText { get; set; }
        public string CesText
        {
            get { return cesText; }
            set
            {
                cesText = value;
                lbl.Text = value;
            }
        }

        private void SetCheckBox()
        {
            if (CesCheckState == CheckState.Indeterminate)
                SetCheckBoxIndeterminate();

            if (CesCheckState == CheckState.Unchecked)
                SetCheckBoxUnchecked();

            if (CesCheckState == CheckState.Checked)
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

            if (CesType == CesCheckBoxTypeEnum.TypeF)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_32_Check;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeG)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_16_Check;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_24_Check;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_32_Check;

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

            if (CesType == CesCheckBoxTypeEnum.TypeF)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_32_Uncheck;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeG)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_16_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_24_Uncheck;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_32_Uncheck;

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

            if (CesType == CesCheckBoxTypeEnum.TypeF)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeF_32_None;

                return;
            }

            if (CesType == CesCheckBoxTypeEnum.TypeG)
            {
                if (CesSize == CesCheckBoxSizeEnum.Small)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_16_None;

                if (CesSize == CesCheckBoxSizeEnum.Medium)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_24_None;

                if (CesSize == CesCheckBoxSizeEnum.Large)
                    pb.Image = Ces.WinForm.UI.Properties.Resources.CheckBoxTypeG_32_None;

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
            if (CesUseIndeterminateState)
            {
                if (CesCheckState == CheckState.Indeterminate)
                    CesCheckState = CheckState.Unchecked;
                else if (CesCheckState == CheckState.Unchecked)
                    CesCheckState = CheckState.Checked;
                else
                    CesCheckState = CheckState.Indeterminate;
            }
            else
            {
                if (CesCheckState == CheckState.Unchecked || CesCheckState == CheckState.Indeterminate)
                    CesCheckState = CheckState.Checked;
                else
                    CesCheckState = CheckState.Unchecked;
            }

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

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                lbl.Font = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.BackColor = value;
                lbl.BackColor = value;
                pb.BackColor = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lbl.ForeColor = value;
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
        TypeF,
        TypeG,
    }
}
