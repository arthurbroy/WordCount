using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace WordCount.Tests
{
	[TestClass()]
	public class UtilsTests
	{
		
		[TestMethod()]
		public void SelectFunctionTest()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();

			//测试-c
			testSet.Add("-c");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);

			//测试-w
			testSet.Clear();
			testSet.Add("-w");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			utils.SelectFunction(testin);


			//测试-l
			testSet.Clear();
			testSet.Add("-l");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			utils.SelectFunction(testin);


			//测试-a -s
			testSet.Clear();
			testSet.Add("-s");
			testSet.Add("-a");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			utils.SelectFunction(testin);

		}
	}
}