using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesMessageBox
{
    public static class CesMessage
    {
        public static System.Windows.Forms.DialogResult Show(CesMessageBoxOptions? options = null)
        {
            var frm = new CesMessageBox(options);
            return frm.ShowDialog();
        }
    }

    public class CesMessageBoxOptions
    {
        public Size _small { get; set; } = new Size(430, 160);
        public Size _medium { get; set; } = new Size(640, 230);
        public Size _large { get; set; } = new Size(890, 480);

        public CesMessageBoxOptions()
        {
            Title = "Message Box";
            Message = "No Message";
            Icon = CesMessageBoxIconEnum.Information;
            Buttons = CesMessageBoxButtonsEnum.Ok;
            TopMost = true;
            Size = CesMessageBoxSizeEnum.Small;
        }

        public string? Title { get; set; }
        public string? Message { get; set; }
        public CesMessageBoxIconEnum Icon { get; set; }
        public CesMessageBoxButtonsEnum Buttons { get; set; }
        public bool TopMost { get; set; }
        public CesMessageBoxSizeEnum Size { get; set; }
    }

    public enum CesMessageBoxIconEnum
    {
        None,
        Asterik,
        Exclamation,
        HandStop,
        Information,
        Question,
        Stop,
        Success,
        Warning,
        Error,
    }

    public enum CesMessageBoxButtonsEnum
    {
        Ok,
        OkCancel,
        RetryCancel,
        YesNo,
        YesNoCancel,
        AbortRetryIgnore,
        //CancelTryContinue == RetryCancel
    }

    public enum CesMessageBoxSizeEnum
    {
        Small, //430 * 160
        Medium, //640 * 230
        Large, //890 * 480
    }
}
