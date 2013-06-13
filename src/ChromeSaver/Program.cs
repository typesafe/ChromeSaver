using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ChromeSaver.Win32;

namespace ChromeSaver
{
	static class Program
	{
		[STAThread]
		static int Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var arguments = new Arguments(args);

			if (arguments.Mode == Mode.Preview)
			{
				return ShowPreview(arguments.ParentWindowHandle);
			}

			using (CreateKeyboardHook())
			using (CreateMouseHook())
			{
				if (arguments.Mode == Mode.Configuation)
				{
					Application.Run(new SettingsForm());
					return 0;
				}

				var address = Path.Combine(Assembly.GetExecutingAssembly().Location, "..\\web\\index.html");

				var mainForm = new ScreenSaverForm(Screen.PrimaryScreen.Bounds, address) { TopMost = true };
				mainForm.Show();

				foreach (var s in Screen.AllScreens)
				{
					if (ReferenceEquals(s, Screen.PrimaryScreen)) continue;
					
					var form = new Form
					{
						BackColor = Color.Black,
						FormBorderStyle = FormBorderStyle.None,
						TopMost = true,
						Bounds = s.Bounds
					};

					form.Show();
				}

				Application.Run();
			}
			return 0;
		}

		private static int ShowPreview(IntPtr parentWindowHandle)
		{
			if (parentWindowHandle == IntPtr.Zero)
			{
				MessageBox.Show(
					"Previewing a screen saver requires the parent window handle, which was not supplied. Use '/p:handle' or '/p handle'",
					"ChromeSaver");
				return 1;
			}

			Application.Run(new PreviewForm(parentWindowHandle));
			return 0;
		}

		private static WindowsHook CreateKeyboardHook()
		{
			return new WindowsHook(HookType.KeyBoardGlobal, (c, w, l) =>
			{
				var kb = (User32.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(new IntPtr(l), typeof(User32.KBDLLHOOKSTRUCT));
				//var key = (Keys) kb.vkCode;
				//if (key == Keys.F12)
				//{
				//    screenSaverForms[0].ShowDevTools();
				//    return false;
				//}
				Application.Exit();
				return false;
			});
		}

		private static WindowsHook CreateMouseHook()
		{
			return new WindowsHook(HookType.MouseGlobal, (c, w, l) =>
			{
				Application.Exit();
				return false;
			});
		}
	}
}
