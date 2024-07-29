namespace Ces.WinForm.UI.Infrastructure
{
    public static class Win32Helpers
    {
        public const int WM_NCPAINT = 0x85;
        public const int RDW_INVALIDATE = 0x0001,
            RDW_ERASE = 0x0004,
            RDW_ALLCHILDREN = 0x0080,
            RDW_ERASENOW = 0x0200,
            RDW_UPDATENOW = 0x0100,
            RDW_FRAME = 0x0400;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int SWP_FRAMECHANGED = 0x0020,
            SWP_NOMOVE = 0x0002,
            SWP_NOSIZE = 0x0001,
            SWP_NOZOORDER = 0x0004;


        public const int WM_NCHITTEST = 0x0084;
        public const int HTBORDER = 18;
        public const int HTHSCROLL = 6;
        public const int HTVSCROLL = 7;
        public const int HTCLIENT = 1;

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 3)]
            public RECT[] rgrc;
            public WINDOWPOS lppos;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }
        public const int NM_FIRST = 0;
        public const int NM_CLICK = NM_FIRST - 2;
        public const int WM_REFLECT = 0x2000;
        public const int WM_NOFITY = 0x004e;
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, RECT lpRect, bool bErase);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, int flags);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    }
}
