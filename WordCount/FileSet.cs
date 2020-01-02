using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
	class FileSet //实现对文件夹的递归操作
	{
		/// <summary>
		/// 用于存放获取的所有文件
		/// </summary>
		public static List<FileInfo> fileList = new List<FileInfo>();
		#region GetAllFilesInDir
		/// <summary>
		/// 获取所有文件
		/// </summary>
		/// <param name="path">文件夹路径</param>
		/// <param name="ext">要检索的文件扩展名</param>
		/// <returns></returns>
		public static List<FileInfo> GetAllFiles(string path, string ext)
		{
			TraverseDir(path, ext);
			return fileList;
		}
		/// <summary>
		/// 对文件夹进行递归遍历操作获取所有文件
		/// </summary>
		/// <param name="path">文件夹路径</param>
		/// <param name="ext">要检索的文件扩展名</param>
		public static void TraverseDir(string path, string ext)
		{
			string[] dirs = Directory.GetDirectories(path); //获取当前目录下的所有文件夹
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] fileInfo = directoryInfo.GetFiles();
			if (fileInfo != null) //获取当前目录下的文件
			{
				foreach (var file in fileInfo)
				{
					if (String.Equals(ext.ToLower(), file.Extension.ToLower()))
					{
						fileList.Add(file);
					}
				}
			}
			if (dirs.Length > 0) //递归操作文件夹
			{
				foreach (var dir in dirs)
				{
					TraverseDir(dir, ext);
				}
			}
		}
		#endregion
	}
}
