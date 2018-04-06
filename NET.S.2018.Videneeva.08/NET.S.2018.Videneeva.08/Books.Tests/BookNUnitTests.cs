using NUnit.Framework;
using System;

namespace Books.Tests
{
    [TestFixture]
    public class BookNUnitTests
    {
        #region Equals tests

        [TestCase(ExpectedResult = true)]
        public bool Equals_BookAndBook_SuccessfulExecution()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            return firstBook.Equals(secondBook);
        }

        [TestCase(ExpectedResult = true)]
        public bool Equals_BookAndObject_SuccessfulExecution()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            object secondBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            return firstBook.Equals(secondBook);
        }

        [TestCase(ExpectedResult = false)]
        public bool Equals_BookAndBook_UnsuccessfulExecution()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-389-04564-5", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            return firstBook.Equals(secondBook);
        }

        #endregion Equals tests

        #region CompareTo tests

        [TestCase(ExpectedResult = -1)]
        public int CompareTo_SuccessfulExecution()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "	Эксмо", 2011, 160, 17);
            return firstBook.CompareTo(secondBook);
        }

        [TestCase(ExpectedResult = 1)]
        public int CompareTo_TagIsAuthor_SuccessfulExecution()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "	Эксмо", 2011, 160, 17);
            return firstBook.CompareTo(secondBook, Tag.Author);
        }

        [TestCase(ExpectedResult = -8)]
        public int CompareTo_TagIsPrice_SuccessfulExecution()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "	Эксмо", 2011, 160, 17);
            return firstBook.CompareTo(secondBook, Tag.Price);
        }

        [Test]
        public void CompareTo_ArgumentException()
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "	Эксмо", 2011, 160, 17);
            Assert.Throws<ArgumentException>(() => firstBook.CompareTo(secondBook, 0));
        }

        #endregion CompareTo tests

        #region ToString tests

        [TestCase("AN", null, ExpectedResult = "Author: Эрих Мария Ремарк;\nName: Три товарища.")]
        [TestCase("ANPY", null, ExpectedResult = "Author: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017.")]
        [TestCase("IANPYN", null, ExpectedResult = "ISBN: 978-5-17-103598-3;\nAuthor: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017;\nNumber of pages: 384.")]
        [TestCase("IANPYNP", null, ExpectedResult = "ISBN: 978-5-17-103598-3;\nAuthor: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017;\nNumber of pages: 384;\nPrice: 16.")]
        public string ToString_SuccessfulExecution(string format, IFormatProvider formatProvider)
        {
            var book = new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16);
            return book.ToString(format, formatProvider);
        }

        [TestCase("JKJHGP", null)]
        public void ToString_FormatException(string format, IFormatProvider formatProvider)
        {
            var book = new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16);

            Assert.Throws<FormatException>(() => book.ToString(format, formatProvider));
        }

        #endregion ToString tests
    }
}
