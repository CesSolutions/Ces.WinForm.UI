using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesMessageBox
{
    public static class CesMessage
    {
        public static System.Windows.Forms.DialogResult Show(string message, CesMessageBoxOptions? options = null)
        {
            var frm = new CesMessageBox(message, options);
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
            Icon = CesMessageBoxIconEnum.MessageInformation;
            Buttons = CesMessageBoxButtonsEnum.Ok;
            TopMost = true;
            Size = CesMessageBoxSizeEnum.Small;
            ButtonImage = CesMessageBoxButtonImageEnum.TextAndImage;
            TextImageRelation = TextImageRelation.ImageAboveText;
            ButtonCaption = new CesMessageBoxButtonCaption();
        }

        public string? Title { get; set; }
        public CesMessageBoxIconEnum Icon { get; set; }
        public CesMessageBoxButtonsEnum Buttons { get; set; }
        public bool TopMost { get; set; }
        public CesMessageBoxSizeEnum Size { get; set; }
        //private CesMessageBoxButtonImageEnum buttonImage { get; set; }
        public CesMessageBoxButtonImageEnum ButtonImage { get; set; }
        //{
        //    get { return buttonImage; }
        //    set
        //    {
        //        buttonImage = value;

        //        if(value == CesMessageBoxButtonImageEnum.TextOnly)
        //        {
        //            ButtonImageAlignment = ContentAlignment.MiddleCenter;
        //            ButtonTextAlignment = ContentAlignment.MiddleCenter;
        //        }
        //        if (value == CesMessageBoxButtonImageEnum.ImageOnly)
        //        {
        //            ButtonImageAlignment = ContentAlignment.MiddleCenter;
        //            ButtonTextAlignment = ContentAlignment.MiddleCenter;
        //        }
        //        if (value == CesMessageBoxButtonImageEnum.TextAndImage)
        //        {
        //            ButtonImageAlignment = ContentAlignment.MiddleRight;
        //            ButtonTextAlignment = ContentAlignment.MiddleLeft;
        //        }
        //    }
        //}
        //public System.Drawing.ContentAlignment   ButtonImageAlignment { get; set; }
        //public System.Drawing.ContentAlignment   ButtonTextAlignment { get; set; }
        public System.Windows.Forms.TextImageRelation TextImageRelation { get; set; }
        public CesMessageBoxButtonCaption ButtonCaption { get; set; }
    }

    public class CesMessageBoxButtonCaption
    {
        public string CesMessageBoxOk { get; set; } = "Ok";
        public string CesMessageBoxYes { get; set; } = "Yes";
        public string CesMessageBoxNo { get; set; } = "No";
        public string CesMessageBoxCancel { get; set; } = "Cancel";
        public string CesMessageBoxRetry { get; set; } = "Retry";
        public string CesMessageBoxAbort { get; set; } = "Abort";
        public string CesMessageBoxIgnore { get; set; } = "Ignore";
        public string CesMessageBoxCopy { get; set; } = "Copy";
    }

    public enum CesMessageBoxIconEnum
    {
        None,
        MessageAsterisk,
        MessageExclamation,
        MessageHandStop,
        MessageInformation,
        MessageQuestion,
        MessageStop,
        MessageSuccess,
        MessageWarning,
        MessageError,
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

    public enum CesMessageBoxButtonImageEnum
    {
        TextOnly,
        ImageOnly,
        TextAndImage
    }

    public enum CesMessageBoxButtonImageLocationEnum
    {
        Left,
        Right,
        TextAndImage
    }

    public enum CesMessageBoxSizeEnum
    {
        Small, //430 * 160
        Medium, //640 * 230
        Large, //890 * 480
    }
}
