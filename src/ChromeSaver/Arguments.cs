using System;
using System.Collections.Generic;

namespace ChromeSaver
{
	internal class Arguments
	{
		public Arguments(IList<string> args)
		{
			if (args == null || args.Count == 0) return;

			var firstArgument = args[0].ToLower().Trim();
			string secondArgument = null;

			if (firstArgument.Contains(":"))
			{
				secondArgument = firstArgument.Substring(3).Trim();
				firstArgument = firstArgument.Substring(0, 2);
			}
			else if (args.Count > 1)
			{
				secondArgument = args[1];
			}

			switch (firstArgument)
			{
				case "/p":
					Mode = Mode.Preview;
					long ptr;
					if (secondArgument != null && long.TryParse(secondArgument, out ptr))
					{
						ParentWindowHandle = new IntPtr(ptr);
					}
					break;
				case "/s":
					Mode = Mode.ScreenSaver;
					break;
				default: // case "/c":
					Mode = Mode.Configuation;
					break;
			}
		}

		public Mode Mode { get; private set; }

		public IntPtr ParentWindowHandle { get; private set; }
	}
}