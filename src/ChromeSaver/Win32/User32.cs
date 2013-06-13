using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ChromeSaver.Win32
{
	internal static class User32
	{
		internal struct KBDLLHOOKSTRUCT
		{
			public int vkCode;
			public int scanCode;
			public int flags;
			public int time;
			public int dwExtraInfo;
		}

		public delegate IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam); 

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr SetWindowsHookEx(HookType idHook, HookProc lpfn, IntPtr hInstance, int threadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern bool UnhookWindowsHookEx(IntPtr hHook);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
	}
}