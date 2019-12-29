using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordCount
{
	class Program
	{
		static void Main(string[] args) 
		{
			Console.WriteLine("test");
			if(args.Length > 0)
			{
				Utils utils = new Utils();
				utils.SelectFunction(args);
				Console.WriteLine("test success");
			}
			Console.Read();
            //Application.Run(new MainWindow());
		}
	}
}
