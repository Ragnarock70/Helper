using System;
using System.Runtime.InteropServices;

namespace Helper.WinAPI
{
    [Flags]
    internal enum KBDLLHOOKSTRUCTFlags : uint
    {
        /// <summary>
        /// KEYEVENTF_EXTENDEDKEY = 0x0001 (If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).)
        /// </summary>
        ExtendedKey = 0x0001,

        /// <summary>
        /// KEYEVENTF_KEYUP = 0x0002 (If specified, the key is being released. If not specified, the key is being pressed.)
        /// </summary>
        KeyUp = 0x0002,

        /// <summary>
        /// KEYEVENTF_UNICODE = 0x0004 (If specified, wScan identifies the key and wVk is ignored.)
        /// </summary>
        Unicode = 0x0004,

        /// <summary>
        /// KEYEVENTF_SCANCODE = 0x0008 (Windows 2000/XP: If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined with the KEYEVENTF_KEYUP flag.)
        /// </summary>
        ScanCode = 0x0008,

        /// <summary>
        /// LLKHF_INJECTED = 0x0010 (Information, specifies a key injected by the sendinput method)
        /// </summary>
        LLKHF_INJECTED = 0x0010,

        /// <summary>
        /// LLKHF_ALTDOWN = 0x0020 (Information, alt key is being pressed)
        /// </summary>
        LLKHF_ALTDOWN = 0x0020,

        /// <summary>
        ///LLKHF_UP = 0x0080 (Information, the key is being released. If not specified, the key is being pressed.)
        /// </summary>
        LLKHF_UP = 0x0080,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KBDLLHOOKSTRUCT
    {
        //A virtual-key code. The code must be a value in the range 1 to 254.           
        internal uint vkCode;

        //A hardware scan code for the key. 
        internal uint scanCode;

        //The extended-key flag, event-injected flag, context code, and transition-state flag.
        internal KBDLLHOOKSTRUCTFlags flags;

        //The time stamp for this message.
        internal uint time;

        //Additional information associated with the message. 
        internal IntPtr dwExtraInfo;

        internal KBDLLHOOKSTRUCT(uint vkCode, uint scanCode, KBDLLHOOKSTRUCTFlags flags, uint time, IntPtr dwExtraInfo)
        {
            this.vkCode = vkCode;
            this.scanCode = scanCode;
            this.flags = flags;
            this.time = time;
            this.dwExtraInfo = dwExtraInfo;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    internal enum HookType
    {
        WH_KEYBOARD_LL = 0xD,
        WH_MOUSE_LL = 0xE
    }

    public enum WindowMessages
    {
        WM_NULL = 0x0000,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MOUSEWHEEL = 0x020A,
        WM_XBUTTONDOWN = 0x020B,
        WM_XBUTTONUP = 0x020C,
        WM_MOUSEHWHEEL = 0x020E
    }

    internal enum MapVirtualKeyMapTypes : uint
    {
        /// <summary>
        /// uCode is a virtual-key code and is translated into a scan code.
        /// If it is a virtual-key code that does not distinguish between left- and
        /// right-hand keys, the left-hand scan code is returned.
        /// If there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VK_TO_VSC = 0x00,

        /// <summary>
        /// uCode is a scan code and is translated into a virtual-key code that
        /// does not distinguish between left- and right-hand keys. If there is no
        /// translation, the function returns 0.
        /// </summary>
        MAPVK_VSC_TO_VK = 0x01,

        /// <summary>
        /// uCode is a virtual-key code and is translated into an unshifted
        /// character value in the low-order word of the return value. Dead keys (diacritics)
        /// are indicated by setting the top bit of the return value. If there is no
        /// translation, the function returns 0.
        /// </summary>
        MAPVK_VK_TO_CHAR = 0x02,

        /// <summary>
        /// Windows NT/2000/XP: uCode is a scan code and is translated into a
        /// virtual-key code that distinguishes between left- and right-hand keys. If
        /// there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VSC_TO_VK_EX = 0x03,

        /// <summary>
        /// Not currently documented
        /// </summary>
        MAPVK_VK_TO_VSC_EX = 0x04
    }
}
