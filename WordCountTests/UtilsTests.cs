using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace WordCount.Tests
{
	[TestClass()]
	public class UtilsTests
	{
		
		[TestMethod()]
		public void cTest()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-c");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}

		[TestMethod()]
		public void wTest()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-w");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}

		[TestMethod()]
		public void lTest()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-l");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}

		[TestMethod()]
		public void aANDsTest()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			//testSet.Add("WordCount.exe");
			testSet.Add("-s");
			testSet.Add("-a");
			testSet.Add("F:\\Arthurbroy\\Code\\*.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}

		[TestMethod()]
		public void combTest1()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-l");
			testSet.Add("-a");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}

		[TestMethod()]
		public void combTest2()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-s");
			testSet.Add("-w");
			testSet.Add("-c");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}
	}
}