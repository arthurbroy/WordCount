using Microsoft.Win32;
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
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ShowDialog();
			txtFile.Text = ofd.FileName;
			Utils utils = new Utils();
			txtChar.Text = utils.CountChars(ofd.FileName).ToString();
			txtWord.Text = utils.CountWords(ofd.FileName).ToString();
			txtLine.Text = utils.CountLines(ofd.FileName).ToString();
			string[] others = utils.CountOthers(ofd.FileName).Split('/');
			txtBlank.Text = others[0];
			txtCode.Text = others[1];
			txtCommentary.Text = others[2];
		}
	}
}
