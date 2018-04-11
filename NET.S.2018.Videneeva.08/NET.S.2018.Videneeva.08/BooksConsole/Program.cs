using System;
using System.Linq;
using Books;

namespace BooksConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Book firstBook = new Book("978-5-389-04564-4", "Оскар Уайльд", "Портрет Дориана Грея", "Азбука", 2012, 416, 9);
            Book secondBook = new Book("978-5-699-50605-7", "Антуан де Сент-Экзюпери", "Маленький принц", "Эксмо", 2011, 160, 17);
            Book thirdBook = new Book("978-5-17-103598-3", "Эрих Мария Ремарк", "Три товарища", "АСТ", 2017, 384, 16);
            Book fourthBook = new Book("978-5-17-080115-2", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 10);

            BookListService firstBookListService = new BookListService();

            firstBookListService.AddBook(firstBook);
            firstBookListService.AddBook(secondBook);

            firstBookListService.RemoveBook(secondBook);

            firstBookListService.AddBook(secondBook);
            firstBookListService.AddBook(thirdBook);

            firstBookListService.RemoveBook(thirdBook);

            firstBookListService.AddBook(thirdBook);
            firstBookListService.AddBook(fourthBook);

            ConsoleWrite(firstBookListService);

            firstBookListService.WriteDataToFile();

            BookListService secondBookListService = new BookListService();
            secondBookListService.ReadDataFromFile();

            ConsoleWrite(secondBookListService);

            Console.WriteLine(secondBookListService.FindBookByTag(Tag.YearOfPublishing, "2017"));

            try
            {
                Book fifthBook = null;
                secondBookListService.RemoveBook(fifthBook);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            secondBookListService.SortBooksByTag(Tag.YearOfPublishing);

            ConsoleWrite(secondBookListService);
        }

        public static void ConsoleWrite(BookListService bookListService)
        {
            for (int i = 0; i < bookListService.Count; i++)
            {
                Console.WriteLine(bookListService.ListBook.ElementAt(i).ToString());
                Console.WriteLine();
            }
        }
    }
}