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
			string testSet = "F:\\Arthurbroy\\Code\\233.c";
			int expected = 121;
			int actual = utils.CountChars(testSet);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void wTest()
		{
			Utils utils = new Utils();
			string testSet = "F:\\Arthurbroy\\Code\\233.c";
			int expected = 27;
			int actual = utils.CountWords(testSet);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void lTest()
		{
			Utils utils = new Utils();
			string testSet = "F:\\Arthurbroy\\Code\\233.c";
			int expected = 13;
			int actual = utils.CountLines(testSet);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void aTest()
		{
			Utils utils = new Utils();
			string testSet = "F:\\Arthurbroy\\Code\\233.c";
			utils.CountOthers(testSet);
		}


		[TestMethod()]
		public void aANDsTest()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-s");
			testSet.Add("-a");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
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


		[TestMethod()]
		public void illegalTest1()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("-q");
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}

		[TestMethod()]
		public void illegalTest2()
		{
			Utils utils = new Utils();
			List<string> testSet = new List<string>();
			testSet.Add("F:\\Arthurbroy\\Code\\233.c");
			string[] testin = testSet.ToArray();
			utils.SelectFunction(testin);
		}
	}
}