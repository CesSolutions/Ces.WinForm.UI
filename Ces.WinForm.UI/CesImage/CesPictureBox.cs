using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesImage
{
    public partial class CesPictureBox : Infrastructure.CesControlBase
    {
        public CesPictureBox()
        {
            InitializeComponent();
            ChildContainer = this.panel1;
        }

        private Image cesImage { get; set; }
        public Image CesImage
        {
            get { return cesImage; }
            set
            {
                cesImage = value;
                this.pb.Image = value;
            }
        }

        private System.Windows.Forms.PictureBoxSizeMode cesSizeMode { get; set; } 
            = PictureBoxSizeMode.StretchImage;
        public System.Windows.Forms.PictureBoxSizeMode  CesSizeMode
        {
            get { return cesSizeMode; }
            set
            {
                cesSizeMode = value;
                this.pb.SizeMode = value;
            }
        }

        private void CesPictureBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }
    }
}
