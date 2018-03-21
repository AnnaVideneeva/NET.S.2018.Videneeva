using System;
using NUnit.Framework;

namespace ExtensionDouble.Tests
{
    [TestFixture]
    public class ExtensionDoubleIEEE754NUnitTests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(double.NaN, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-312.3125, ExpectedResult = "1100000001110011100001010000000000000000000000000000000000000000")]
        public string ConvertDoubleToIEEE754_SuccessfulExecution(double number)
        {
            return ExtensionDoubleIEEE754.ConvertDoubleToIEEE754(number);
        }
    }
}
