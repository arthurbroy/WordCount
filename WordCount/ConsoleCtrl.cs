using System;
using System.Runtime.InteropServices;

namespace WordCount
{
    class ConsoleCtrl
	{
		[DllImport("User32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Unicode)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Unicode)]   //找子窗体   
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
		[DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]   //用于发送信息给窗体   
		private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
		[DllImport("User32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Unicode)]   //
		private static extern bool ShowWindow(IntPtr hWnd, int type);

		private readonly IntPtr ParenthWnd;
		public ConsoleCtrl()
		{
			ParenthWnd = FindWindow(null, Console.Title);
		}
		public enum WindowState // 0: 后台执行；1:正常启动；2:最小化到任务栏；3:最大化
		{
			background, normal, minimize, maximize
		}
		/// <summary>
		/// 设置窗体显示状态，0: 后台执行；1:正常启动；2:最小化到任务栏；3:最大化
		/// </summary>
		/// <param name="n"></param>
		public void SetWindow(WindowState n)
		{
			ShowWindow(ParenthWnd, (int)n);
		}
	}
}
