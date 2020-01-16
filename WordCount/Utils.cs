using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
	public class Utils //基本功能和拓展功能
	{
		private int letterCnt = 0;
		private int wordCnt = 0;
		private int lineCnt = 0;
		private int codeLine = 0;
		private int commentaryLine = 0;
		private int blankLine = 0;
		#region CountLetters
		/// <summary>
		/// 字符计数
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		public void CountLetters(string file)
		{
			string text = File.ReadAllText(file);
			foreach (var ch in text)
			{
				if (ch != '\n' && ch != '\r' && ch != '\t')
					letterCnt++;
			}
			Console.WriteLine("number of letters in {0}: {1}", file, letterCnt);
		}
		#endregion
		#region CountWords
		/// <summary>
		/// 单词计数
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		public void CountWords(string file)
		{
			string text = File.ReadAllText(file);
			string[] wordList = text.Split(",.?\n\r".ToArray());
			foreach (var word in wordList)
			{
				if (wordList.Length > 0)
					wordCnt++;
			}
			Console.WriteLine("number of words in {0}: {1}", file, wordCnt);
		}
		#endregion
		#region CountLines
		/// <summary>
		/// 行数计数
		/// </summary>
		/// <param name="file"></param>
		/// <return></return>
		public void CountLines(string file)
		{
			string text = File.ReadAllText(file);
			lineCnt = Regex.Matches(text, @"\r").Count + 1;
			Console.WriteLine("number of row in {0}: {1}", file, lineCnt);
		}
		#endregion
		#region CountOthers
		/// <summary>
		/// 统计更复杂的数据（代码行/空行/注释行）
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		void CountOthers(string file)
		{
			FileStream fileStream = new FileStream(file, FileMode.Open);
			StreamReader streamReader = new StreamReader(fileStream);
			string line = streamReader.ReadLine();
			while (line != null) //若文件为空，三个值均为0
			{
				if (line.Trim() == "")
				{
					blankLine++;
				}
				else if (line.Trim().IndexOf("//") == 1 || line.Trim().IndexOf("//") == 2)
				{
					commentaryLine++;
				}
				//TODO注释行判断有误，还可能是<!-->？
				else
				{
					codeLine++;
				}
				line = streamReader.ReadLine();
			}
			streamReader.Close();
			Console.WriteLine("空行：{0}, 代码行： {1}， 注释行：{2}", blankLine, codeLine, commentaryLine);
		}
		#endregion
		#region RunWindows
		///<summary>
		///调用窗体函数
		///</summary>
		void RunWindows()
		{
			MainWindow app = new MainWindow();
			app.InitializeComponent();
			//app.Run();
		}
		#endregion

		#region SelectFunction
		/// <summary>
		/// 根据输入的参数选择功能
		/// </summary>
		/// <param name="argv">控制台参数</param>
		public void SelectFunction(string[] argv)
		{
			//if(argv.Contains("-x"))
			//{
			//	RunWindows();
			//}
			string path = argv[argv.Length - 1];
			int index = path.IndexOf(".");
			string ext = path.Substring(index, path.Length - index);
			if(argv.Contains<string>("-s"))
			{
				if(!Directory.Exists(argv[argv.Length - 1]))
				{
					index = path.LastIndexOf("\\");
					path = path.Substring(0, index);
				}
			}
			List<FileInfo> fileInfos = FileSet.GetAllFiles(path, ext);
			string fileName = "";
			foreach (FileInfo file in fileInfos)
			{
				if (!argv.Contains<string>("-s"))
				{
					foreach (string item in argv)
					{
						if (item.EndsWith(ext) && item.ToString() == file.ToString())
							fileName = item;
					}
				}
				else
					fileName = file.FullName.ToString();
				for (int i = 0; i < argv.Length - 1; i++)
				{
					if (argv[i] == "-c")
					{
						CountLetters(fileName);
						break;
					}
					else if (argv[i] == "-w")
					{
						CountWords(fileName);
						break;
					}
					else if (argv[i] == "-l")
					{
						CountLines(fileName);
						break;
					}
					else if (argv[i] == "-a")
					{
						CountOthers(fileName);
						break;
					}
				}
			}
		}
		#endregion
	}
}
