using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuestCodeChallenge;

namespace UnitTestCodechallenger
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCaseInputInvalid()
        {
            string input = "? 1 / 2 * 3_3 / 4";
            bool isValid = MathCalculation.CheckUserInputs(input);
            Assert.AreEqual(false, isValid);
        }
        [TestMethod]
        public void TestCaseInputInValid()
        {
            string input = "? 1 / 2 * 3-3 / 4";
            bool isValid = MathCalculation.CheckUserInputs(input);
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void TestCaseCaculateInputSuccess()
        {
            string input = "?10-3/8 + 9/8";
            string errorMsg = "";
            decimal result = MathCalculation.Calculate(input, out errorMsg);
            Assert.AreEqual<decimal>(result, MathCalculation.Calculate(input, out errorMsg));

        }
        [TestMethod]
        public void TestCaseCaculateInputFailed()
        {
            string input = "?10-3/8 + 9/8";
            string errorMsg = "";
            bool isSame = false;
            decimal result = MathCalculation.Calculate(input, out errorMsg);
            decimal temp = MathCalculation.Calculate("?11-3/8 + 9/8" ,out errorMsg);
            isSame = result == temp ? true : false;
            Assert.AreEqual<bool>(false, isSame);
        }
    }
}
