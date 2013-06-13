using System;
using System.Diagnostics;
using ChromeSaver.Win32;

namespace ChromeSaver
{
	internal class WindowsHook : IDisposable
	{
		private static readonly IntPtr ModuleHandle = Kernel32.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
		
		internal delegate bool ProcHandler(int code, int wparam, int lparam);
		
		private readonly IntPtr hook;
		private bool disabled;

		public WindowsHook(HookType type, ProcHandler proc)
		{
			hook = User32.SetWindowsHookEx(type, (code, wParam, lParam) =>
				{
					if (disabled) return User32.CallNextHookEx(hook, code, wParam, lParam);

					return !proc(code, wParam.ToInt32(), lParam.ToInt32())
						? User32.CallNextHookEx(hook, code, wParam, lParam)
						: IntPtr.Zero;
				},
				ModuleHandle,
				0);

			if (hook == IntPtr.Zero) throw new Exception("could not start monitoring mouse events");
		}

		public void Dispose()
		{
			User32.UnhookWindowsHookEx(hook);
		}

		public void Disable()
		{
			disabled = true;
		}

		public void Enable()
		{
			disabled = false;
		}
	}
}
