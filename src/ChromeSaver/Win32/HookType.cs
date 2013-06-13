namespace ChromeSaver.Win32
{
	internal enum HookType
	{
		JournalRecord = 0,			//WH_JOURNALRECORD
		JournalPlayback = 1,		//WH_JOURNALPLAYBACK
		KeyBoard = 2,				//WH_KEYBOARD
		MessageQueue = 3,			//WH_GETMESSAGE
		BeforeWindow = 4,			//WH_CALLWNDPROC
		ComputerBasedTraining = 5,	//WH_CBT
		SystemMessages = 6,			//WH_SYSMSGFILTER
		Mouse = 7,					//WH_MOUSE
		Hardware = 8,				//WH_HARDWARE
		Debug = 9,					//WH_DEBUG 
		Shell = 10,					//WH_SHELL
		ForeGroundIdle = 11,		//WH_FOREGROUNDIDLE
		AfterWindow = 12,			//WH_CALLWNDPROCRET
		KeyBoardGlobal = 13,		//WH_KEYBOARD_LL
		MouseGlobal = 14			//WH_MOUSE_LL
	}
}