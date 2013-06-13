using CefSharp;

namespace ChromeSaver.Cef
{
	public class NullMenuHandler : IMenuHandler
	{
		public bool OnBeforeMenu(IWebBrowser browser)
		{
			return true;
		}
	}
}