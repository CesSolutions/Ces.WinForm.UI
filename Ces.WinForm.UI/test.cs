using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ces.WinForm.UI.Infrastructure;

namespace Ces.WinForm.UI
{
    public partial class test : UserControl
    {
        public test()
        {
            BorderOptions = new BorderOptions(this);
            TitleOptions = new TitleOptions(this, this.Font);

            InitializeComponent();
        }


        public Ces.WinForm.UI.Infrastructure.BorderOptions BorderOptions { get; set; }
        public Ces.WinForm.UI.Infrastructure.TitleOptions TitleOptions { get; set; }


        private void test_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.GenerateBorder(BorderOptions, TitleOptions);            
        }

       
        public void Arraneg()
        {
            this.ArrangeControls(BorderOptions, TitleOptions);
        }
    }
}
