using System.Collections.Generic;
using NUnit.Framework;

namespace Books.Tests
{
    [TestFixture]
    public class BookListServiceNUnitTests
    {
        #region Fields

        private static BookListService bookListService = new BookListService(
            new List<Book>
            {
                new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9),
                new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17),
                new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16),
                new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10)
            });

        private static BookListService bookListServiceSortedByIsbn = new BookListService(
           new List<Book>
           {
                new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10),
                new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16),
                new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9),
                new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17)
           });

        private static BookListService bookListServiceSortedByAuthor = new BookListService(
           new List<Book>
           {
                new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17),
                new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10),
                new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9),
                new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16)
           });

        private static BookListService bookListServiceSortedByName = new BookListService(
            new List<Book>
            {
                new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10),
                new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17),
                new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9),
                new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16)
            });

        private static BookListService bookListServiceSortedByYearOfPublishing = new BookListService(
            new List<Book>
            {
                new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17),
                new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9),
                new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10),
                new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16)
            });

        private static BookListService bookListServiceSortedByPrice = new BookListService(
            new List<Book>
            {
                new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9),
                new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10),
                new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16),
                new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17)
            });

        #endregion Fields

        #region FindBookByTag tests

        [TestCase(ExpectedResult = "ISBN: 978-5-17-080115-2;\nAuthor: Джордж Оруэлл;\nName: 1984;\nPublishing House: АСТ;\nYear: 2015;\nNumber of pages: 320;\nPrice: 10.")]
        public string FindBookByTag_TagIsName_SuccessfulExecution()
        {
            return bookListService.FindBookByTag(Tag.Name, "1984");
        }

        [TestCase(ExpectedResult = "ISBN: 978-5-17-103598-3;\nAuthor: Эрих Мария Ремарк;\nName: Три товарища;\nPublishing House: АСТ;\nYear: 2017;\nNumber of pages: 384;\nPrice: 16.")]
        public string FindBookByTag_TagIsNumberOfPages_SuccessfulExecution()
        {
            return bookListService.FindBookByTag(Tag.NumberOfPages, "384");
        }

        [TestCase(ExpectedResult = "There is no such book!")]
        public string FindBookByTag_TagIsPrice_SuccessfulExecution()
        {
            return bookListService.FindBookByTag(Tag.Price, "11");
        }

        #endregion FindBookByTag tests

        #region SortBooksByTag tests

        [Test]
        public void SortBooksByTag_TagIsIsbn_SuccessfulExecution()
        {
            bookListService.SortBooksByTag(Tag.Isbn);
            Assert.AreEqual(bookListService.ListBook, bookListServiceSortedByIsbn.ListBook);
        }

        [Test]
        public void SortBooksByTag_TagIsAuthor_SuccessfulExecution()
        {
            bookListService.SortBooksByTag(Tag.Author);
            Assert.AreEqual(bookListService.ListBook, bookListServiceSortedByAuthor.ListBook);
        }

        [Test]
        public void SortBooksByTag_TagIsName_SuccessfulExecution()
        {
            bookListService.SortBooksByTag(Tag.Name);
            Assert.AreEqual(bookListService.ListBook, bookListServiceSortedByName.ListBook);
        }

        [Test]
        public void SortBooksByTag_TagIsYearOfPublishing_SuccessfulExecution()
        {
            bookListService.SortBooksByTag(Tag.YearOfPublishing);
            Assert.AreEqual(bookListService.ListBook, bookListServiceSortedByYearOfPublishing.ListBook);
        }

        [Test]
        public void SortBooksByTag_TagIsPrice_SuccessfulExecution()
        {
            bookListService.SortBooksByTag(Tag.Price);
            Assert.AreEqual(bookListService.ListBook, bookListServiceSortedByPrice.ListBook);
        }

        #endregion SortBooksByTag tests
    }
}