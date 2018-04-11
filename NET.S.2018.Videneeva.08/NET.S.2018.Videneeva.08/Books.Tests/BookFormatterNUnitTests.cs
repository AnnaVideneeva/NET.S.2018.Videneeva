using System;
using NUnit.Framework;

namespace Books.Tests
{
    [TestFixture]
    public class BookFormatterNUnitTests
    {
        [TestCase("{0:AN}", ExpectedResult = "Author: Эрих Мария Ремарк;\nName: Три товарища.")]
        [TestCase("{0:ANPY}", ExpectedResult = "Author: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017.")]
        [TestCase("{0:IANPYN}", ExpectedResult = "ISBN: 978-5-17-103598-3;\nAuthor: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017;\nNumber of pages: 384.")]
        [TestCase("{0:IANPYNP}", ExpectedResult = "ISBN: 978-5-17-103598-3;\nAuthor: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017;\nNumber of pages: 384;\nPrice: 16.")]
        public string ToString_SuccessfulExecution(string format)
        {
            var book = new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16);
            return string.Format(new BookFormatter(), format, book);
        }

        [TestCase("{0:JKJHGP}")]
        public void ToString_FormatException(string format)
        {
            var book = new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16);

            Assert.Throws<FormatException>(() => string.Format(new BookFormatter(), format, book));
        }
    }
}
