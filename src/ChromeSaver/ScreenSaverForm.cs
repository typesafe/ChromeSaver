using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ChromeSaver.Cef;

namespace ChromeSaver
{	
	public partial class ScreenSaverForm : Form
	{
		private readonly WebView webView;

		public ScreenSaverForm()
		{
			InitializeComponent();
		}

		public ScreenSaverForm(Rectangle bounds, string address) : this()
		{	
			Bounds = bounds;
			Address = address;

			var browserSettings = new BrowserSettings
			{
				PageCacheDisabled = true,
				FileAccessFromFileUrlsAllowed = true
			};

			webView = new WebView(Address, browserSettings) { Dock = DockStyle.Fill };
			webView.MenuHandler = new NullMenuHandler();

			Controls.Add(webView);
		}

		protected string Address { get; set; }

		public void ShowDevTools()
		{
			webView.ShowDevTools();
		}
	}
}
