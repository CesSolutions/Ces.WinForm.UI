using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.NavigationBars.Events
{
    public class CesNavigationEvent : EventArgs
    {
        public int TotalRows { get; set; }
        public int CurrentRowNumber { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }
    }
}
