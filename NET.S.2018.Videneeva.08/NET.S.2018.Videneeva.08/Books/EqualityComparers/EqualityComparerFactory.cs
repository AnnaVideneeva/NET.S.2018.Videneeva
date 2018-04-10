using Books.EqualityComparers;
using System.Collections.Generic;

namespace Books.Comparers
{
    /// <summary>
    /// Provides a factory for creating a comparator.
    /// </summary>
    public static class EqualityComparerFactory
    {
        /// <summary>
        /// Creates a comparator by tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>Comparator by tag.</returns>
        public static IEqualityComparer GetEqualityComparer(Tag tag)
        {
            switch (tag)
            {
                case Tag.Isbn:
                    {
                        return new EqualityComparerByISBN();
                    }
                case Tag.Author:
                    {
                        return new EqualityComparerByAuthor();
                    }
                case Tag.Name:
                    {
                        return new EqualityComparerByName();
                    }
                case Tag.PublishingHouse:
                    {
                        return new EqualityComparerByPublishingHouse();
                    }
                case Tag.YearOfPublishing:
                    {
                        return new EqualityComparerByYearOfPublishing();
                    }
                case Tag.NumberOfPages:
                    {
                        return new EqualityComparerByNumberOfPages();
                    }
                case Tag.Price:
                    {
                        return new EqualityComparerByPrice();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}

