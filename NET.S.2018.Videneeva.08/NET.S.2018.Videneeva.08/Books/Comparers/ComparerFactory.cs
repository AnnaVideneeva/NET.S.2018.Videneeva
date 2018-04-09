using System.Collections.Generic;

namespace Books.Comparers
{
    /// <summary>
    /// Provides a factory for creating a comparator.
    /// </summary>
    public static class ComparerFactory
    {
        /// <summary>
        /// Creates a comparator by tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>Comparator by tag.</returns>
        public static IComparer<Book> GetComparer(Tag tag)
        {
            switch(tag)
            {
                case Tag.Isbn:
                    {
                        return new ComparerByISBN();
                    }
                case Tag.Author:
                    {
                        return new ComparerByAuthor();
                    }
                case Tag.Name:
                    {
                        return new ComparerByName();
                    }
                case Tag.PublishingHouse:
                    {
                        return new ComparerByPublishingHouse();
                    }
                case Tag.YearOfPublishing:
                    {
                        return new ComparerByYearOfPublishing();
                    }
                case Tag.NumberOfPages:
                    {
                        return new ComparerByNumberOfPages();
                    }
                case Tag.Price:
                    {
                        return new ComparerByPrice();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
