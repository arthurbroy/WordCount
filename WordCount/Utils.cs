﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
	class Utils //完成基本功能和拓展功能（-a)
	{
		#region SelectFunction
		/// <summary>
		/// 根据输入的参数选择功能
		/// </summary>
		/// <param name="argv">控制台参数</param>
		public void SelectFunction(string[] argv)
		{
			for (int i = 0; i < argv.Length - 1; i++)
			{
				if (argv[i] == "-c")
				{
					CountLetter(argv[i + 1]);
					break;
				}
				else if (argv[i] == "-w")
				{
					CountWords(argv[i + 1]);
					break;
				}
				else if (argv[i] == "-l")
				{
					CountRows(argv[i + 1]);
					break;
				}
			}
		}
		#endregion
		#region CountLetters
		/// <summary>
		/// 字符计数
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <return></return>
		public void CountLetter(string file)
		{
			string text = File.ReadAllText(file);
			int letterCnt = 0;
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
			int wordCnt = 0;
			string[] wordList = text.Split(",.?\n\r".ToArray());
			foreach (var word in wordList)
			{
				if (wordList.Length > 0)
					wordCnt++;
			}
			Console.WriteLine("number of words in {0}: {1}", file, wordCnt);
		}
		#endregion
		#region CountRows
		/// <summary>
		/// 行数计数
		/// </summary>
		/// <param name="file"></param>
		/// <return></return>
		public void CountRows(string file)
		{
			string text = File.ReadAllText(file);
			int rowCnt = 0;
			rowCnt = Regex.Matches(text, @"\r").Count + 1;
			Console.WriteLine("number of row in {0}: {1}", text, rowCnt);
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
			int codeLine = 0, commentaryLine = 0, blankLine = 0;
			FileStream fileStream = new FileStream(file, FileMode.Open);
			StreamReader streamReader = new StreamReader(fileStream);
			string line = streamReader.ReadLine();
			while (line != null) //若文件为空，三个值均为0
			{
				if (line.Trim() == "")
					blankLine++;
				else if (line.Trim().IndexOf("//") == 1 || line.Trim().IndexOf("//") == 2)
					commentaryLine++;
				//TODO注释行判断有误，还可能是<!-->？
				else
					codeLine++;
			}
			Console.WriteLine("");
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
	}
}