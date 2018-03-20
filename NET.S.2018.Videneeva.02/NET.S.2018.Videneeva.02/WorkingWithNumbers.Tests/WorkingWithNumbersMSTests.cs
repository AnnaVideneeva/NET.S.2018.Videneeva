using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkingWithNumbers.Tests
{
    [TestClass]
    public class WorkingWithNumbersMSTests
    {
        [TestMethod]
        public void InsertNumber8To15_FromPosition3To8_120Returned()
        {
            int firstNumber = 8;
            int secondNumber = 15;
            int i = 3;
            int j = 8;
            int correctResult = 120;

            int result = WorkingWithNumbers.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(result, correctResult);
        }

        [TestMethod]
        public void InsertNumber8To15_FromPosition0To0_9Returned()
        {
            int firstNumber = 8;
            int secondNumber = 15;
            int i = 0;
            int j = 0;
            int correctResult = 9;

            int result = WorkingWithNumbers.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(result, correctResult);
        }

        [TestMethod]
        public void InsertNumber15To15_FromPosition0To0_15Returned()
        {
            int firstNumber = 15;
            int secondNumber = 15;
            int i = 0;
            int j = 0;
            int correctResult = 15;

            int result = WorkingWithNumbers.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(result, correctResult);
        }
    }
}
