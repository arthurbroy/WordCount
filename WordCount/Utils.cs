using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
	public class Utils //基本功能和拓展功能
	{
		private int charCnt = 0;
		private int wordCnt = 0;
		private int lineCnt = 0;
		private int codeLineCnt = 0;
		private int commentaryLineCnt = 0;
		private int blankLineCnt = 0;
		private App app;
		#region CountChars
		/// <summary>
		/// 字符计数
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		public int CountChars(string file)
		{
			charCnt = 0;
			string text = File.ReadAllText(file);
			foreach (var ch in text)
			{
				if (ch != '\n' && ch != '\r' && ch != '\t')
					charCnt++;
			}
			Console.WriteLine("{0}的字符数：{1}", file, charCnt);
			return charCnt;
		}
		#endregion

		#region CountWords
		/// <summary>
		/// 单词计数
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		public int CountWords(string file)
		{
			wordCnt = 0;
			string text = File.ReadAllText(file);
			string[] wordList = text.Split(",.?\n\r".ToArray());
			foreach (var word in wordList)
			{
				if (wordList.Length > 0)
					wordCnt++;
			}
			Console.WriteLine("{0}的单词数： {1}", file, wordCnt);
			return wordCnt;
		}
		#endregion

		#region CountLines
		/// <summary>
		/// 行数计数
		/// </summary>
		/// <param name="file"></param>
		/// <return></return>
		public int CountLines(string file)
		{
			lineCnt = 0;
			commentaryLineCnt = 0;
			string text = File.ReadAllText(file);
			lineCnt = Regex.Matches(text, @"\r").Count + 1;
			//多行注释匹配
			MatchCollection matchCollection = Regex.Matches(text, @"\/\*([^\*]|\*+[^\/\*])*\*+\/");
			foreach (var mc in matchCollection)
			{
				commentaryLineCnt += mc.ToString().Split("\r".ToArray()).Count();
			}
			Console.WriteLine("{0}的行数： {1}", file, lineCnt);
			return lineCnt;
		}
		#endregion

		#region CountOthers
		/// <summary>
		/// 统计更复杂的数据（代码行/空行/注释行）
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		public string CountOthers(string file)
		{
			codeLineCnt = 0;
			blankLineCnt = 0;
			CountLines(file);
			FileStream fileStream = new FileStream(file, FileMode.Open);
			StreamReader streamReader = new StreamReader(fileStream);
			string line = streamReader.ReadLine();
			while (line != null) //若文件为空，三个值均为0
			{
				if (line.Trim() == "")
				{
					blankLineCnt++;
				}
				else if (line.Trim().IndexOf("//") == 1 || line.Trim().IndexOf("//") == 2)
				{
					//多行注释在CountLine中进行统计
					commentaryLineCnt++;
				}
				line = streamReader.ReadLine();
			}
			codeLineCnt = lineCnt - blankLineCnt - commentaryLineCnt;
			streamReader.Close();
			Console.WriteLine("{0}的空行：{1}, 代码行： {2}， 注释行：{3}", file, blankLineCnt, codeLineCnt, commentaryLineCnt);
			return blankLineCnt.ToString() + "/" + codeLineCnt.ToString() + "/" + commentaryLineCnt.ToString();
		}
		#endregion

		#region RunWindow
		///<summary>
		///调用窗体函数，同时设置最小化命令行窗口
		///</summary>
		void RunWindow()
		{
			var w = new ConsoleCtrl();
			w.SetWindow(ConsoleCtrl.WindowState.minimize);
			app.InitializeComponent();
			app.Run();
		}
		#endregion

		#region SelectFunction
		/// <summary>
		/// 根据输入的参数选择功能
		/// </summary>
		/// <param name="argv">控制台参数</param>
		public int SelectFunction(string[] argv)
		{
			if (argv.Contains("-x"))
			{
				app = new App();
				app.Dispatcher.Invoke(() => { RunWindow(); });
				return 0;
			}
			string path = argv.Last();
			int index = path.IndexOf(".");
			string ext = path.Substring(index, path.Length - index);
			if(argv.Contains("-s"))
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
				if (!argv.Contains("-s"))
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
						CountChars(fileName);
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
					else
					{
						Console.WriteLine("参数不合法");
						return -1;
					}
				}
			}
			return 0;
		}
		#endregion
	}
}
