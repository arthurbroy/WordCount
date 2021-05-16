using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WordCount
{
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	public partial class App : Application
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.Title = "WordCount";
			if (args.Length > 0)
			{
				Utils utils = new Utils();
				if (utils.SelectFunction(args) == 0)
				{
					Console.WriteLine("执行成功");
				}
			}
			else
			{
				Console.WriteLine("参数数量不合法");
			}

			return;
		}
	}
}
