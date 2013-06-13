using System;
using System.Drawing;
using System.Windows.Forms;
using ChromeSaver.Win32;

namespace ChromeSaver
{
	public partial class PreviewForm : Form
	{
		public PreviewForm()
		{
			InitializeComponent();
		}

		public PreviewForm(IntPtr parentHandle)
			: this()
		{
			User32.SetParent(Handle, parentHandle);

			Rectangle ParentRect;

			User32.GetClientRect(parentHandle, out ParentRect);

			Size = ParentRect.Size;
			Location = new Point(0, 0);
		}
	}
}
