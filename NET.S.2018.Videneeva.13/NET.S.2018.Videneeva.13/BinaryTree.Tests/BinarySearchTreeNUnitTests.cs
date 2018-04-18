using System.Linq;
using BinaryTree.Tests.Comparers;
using NUnit.Framework;

namespace BinaryTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeNUnitTests
    {
        #region Fields

        private static Book[] primaryListBooks = new Book[]
        {
            new Book("Оскар Уайльд", "Портрет Дориана Грея"),
            new Book("Антуан де Сент-Экзюпери", "Маленький принц"),
            new Book("Эрих Мария Ремарк", "Три товарища"),
            new Book("Джордж Оруэлл", "1984")
        };

        private static Book[] preOrderListBooks = new Book[]
        {
            new Book("Оскар Уайльд", "Портрет Дориана Грея"),
            new Book("Антуан де Сент-Экзюпери", "Маленький принц"),
            new Book("Джордж Оруэлл", "1984"),
            new Book("Эрих Мария Ремарк", "Три товарища")
        };

        private static Book[] inOrderListBooks = new Book[]
        {           
            new Book("Антуан де Сент-Экзюпери", "Маленький принц"),
            new Book("Джордж Оруэлл", "1984"),
            new Book("Оскар Уайльд", "Портрет Дориана Грея"),
            new Book("Эрих Мария Ремарк", "Три товарища")
        };

        private static Book[] postOrderListBooks = new Book[]
        {
            new Book("Джордж Оруэлл", "1984"),
            new Book("Антуан де Сент-Экзюпери", "Маленький принц"),
            new Book("Эрих Мария Ремарк", "Три товарища"),
            new Book("Оскар Уайльд", "Портрет Дориана Грея")
        };

        private static Point[] primaryListPoints = new Point[]
        {
            new Point(2, 2),
            new Point(7, 7),
            new Point(1, 1),
            new Point(4, 4),
            new Point(3, 3),
            new Point(5, 5),
            new Point(6, 6)
        };

        private static Point[] preOrderListPoints = new Point[]
        {
            new Point(2, 2),
            new Point(1, 1),
            new Point(7, 7),    
            new Point(4, 4),
            new Point(3, 3),
            new Point(5, 5),
            new Point(6, 6)
        };

        private static Point[] inOrderListPoints = new Point[]
        {
            new Point(1, 1),
            new Point(2, 2),
            new Point(3, 3),
            new Point(4, 4),
            new Point(5, 5),
            new Point(6, 6),
            new Point(7, 7)
        };

        private static Point[] postOrderListPoints = new Point[]
        {
            new Point(1, 1),
            new Point(3, 3),
            new Point(6, 6),
            new Point(5, 5),
            new Point(4, 4),
            new Point(7, 7),
            new Point(2, 2)
        };

        #endregion Fields

        #region Tests for Int32

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31 }, 35, ExpectedResult = true)]
        public bool AddNode_Int32_DefaultComparator(int[] collection, int node)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection);

            binarySearchTree.AddNode(node);

            return binarySearchTree.Contains(node);
        }

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31 }, 35, ExpectedResult = true)]
        public bool AddNode_Int32_ConnectableComparator(int[] collection, int node)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection, new ComparerInt());

            binarySearchTree.AddNode(node);

            return binarySearchTree.Contains(node);
        }

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31, 35 }, 35, ExpectedResult = true)]
        public bool RemoveNode_Int32_DefaultComparator(int[] collection, int node)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection);

            return binarySearchTree.RemoveNode(node);
        }

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31, 35 }, 19, ExpectedResult = true)]
        public bool RemoveNode_Int32_ConnectableComparator(int[] collection, int node)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection, new ComparerInt());

            return binarySearchTree.RemoveNode(node);
        }

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31, 35 }, ExpectedResult = new int[] { 19, 13, 3, 17, 15, 18, 33, 31, 35 })]
        public int[] PreOrder_Int32_DefaultComparator(int[] collection)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection);

            return binarySearchTree.PreOrder().ToArray();
        }

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31, 35 }, ExpectedResult = new int[] { 3, 13, 15, 17, 18, 19, 31, 33, 35 })]
        public int[] InOrder_Int32_DefaultComparator(int[] collection)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection);

            return binarySearchTree.InOrder().ToArray();
        }

        [TestCase(new int[] { 19, 13, 3, 17, 15, 18, 33, 31, 35 }, ExpectedResult = new int[] { 3, 15, 18, 17, 13, 31, 35, 33, 19 })]
        public int[] PostOrder_Int32_DefaultComparator(int[] collection)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(collection);

            return binarySearchTree.PostOrder().ToArray();
        }

        #endregion Tests for Int32

        #region Tests for String

        [TestCase(new string[] { "19", "13", "3", "17", "15", "18", "33", "31" }, "35", ExpectedResult = true)]
        public bool AddNode_String_DefaultComparator(string[] collection, string node)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection);

            binarySearchTree.AddNode(node);

            return binarySearchTree.Contains(node);
        }

        [TestCase(new string[] { "19", "13", "3", "17", "15", "18", "33", "31" }, "35", ExpectedResult = true)]
        public bool AddNode_String_ConnectableComparator(string[] collection, string node)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection, new ComparerString());

            binarySearchTree.AddNode(node);

            return binarySearchTree.Contains(node);
        }

        [TestCase(new string[] { "19", "13", "3", "17", "15", "18", "33", "31", "35" }, "35", ExpectedResult = true)]
        public bool RemoveNode_String_DefaultComparator(string[] collection, string node)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection);

            return binarySearchTree.RemoveNode(node);
        }

        [TestCase(new string[] { "19", "13", "3", "17", "15", "18", "33", "31", "35" }, "19", ExpectedResult = true)]
        public bool RemoveNode_String_ConnectableComparator(string[] collection, string node)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection, new ComparerString());

            return binarySearchTree.RemoveNode(node);
        }

        [TestCase(new string[] { "B", "A", "D", "E", "F", "G", "C", "H", "I" }, new string[] { "B", "A", "D", "C", "E", "F", "G", "H", "I" })]
        public void PreOrder_String_DefaultComparator(string[] collection, string[] result)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection);

            CollectionAssert.AreEqual(binarySearchTree.PreOrder().ToArray(), result);
        }

        [TestCase(new string[] { "B", "A", "D", "E", "F", "G", "C", "H", "I" }, new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" })]
        public void InOrder_String_DefaultComparator(string[] collection, string[] result)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection);

            CollectionAssert.AreEqual(binarySearchTree.InOrder().ToArray(), result);
        }

        [TestCase(new string[] { "B", "A", "D", "E", "F", "G", "C", "H", "I" }, new string[] { "A", "C", "I", "H", "G", "F", "E", "D", "B" })]
        public void PostOrder_String_DefaultComparator(string[] collection, string[] result)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>(collection);

            CollectionAssert.AreEqual(binarySearchTree.PostOrder().ToArray(), result);
        }

        #endregion Tests for String

        #region Tests for Book class

        [TestCase(ExpectedResult = true)]
        public bool AddNode_Book_DefaultComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks);
            Book book = new Book("Лев Толстой", "Война и мир");

            binarySearchTree.AddNode(book);

            return binarySearchTree.Contains(book);
        }

        [TestCase(ExpectedResult = true)]
        public bool AddNode_Book_ConnectableComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks, new ComparerBook());
            Book book = new Book("Лев Толстой", "Война и мир");

            binarySearchTree.AddNode(book);

            return binarySearchTree.Contains(book);
        }

        [TestCase(ExpectedResult = true)]
        public bool RemoveNode_Book_DefaultComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks);
            Book book = new Book("Эрих Мария Ремарк", "Три товарища");

            return binarySearchTree.RemoveNode(book);
        }

        [TestCase(ExpectedResult = true)]
        public bool RemoveNode_Book_ConnectableComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks, new ComparerBook());
            Book book = new Book("Эрих Мария Ремарк", "Три товарища");

            return binarySearchTree.RemoveNode(book);
        }

        [Test]
        public void PreOrder_Book_DefaultComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks);

            CollectionAssert.AreEqual(binarySearchTree.PreOrder().ToArray(), preOrderListBooks);
        }

        [Test]
        public void InOrder_Book_DefaultComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks);

            CollectionAssert.AreEqual(binarySearchTree.InOrder().ToArray(), inOrderListBooks);
        }

        [Test]
        public void PostOrder_Book_DefaultComparator()
        {
            BinarySearchTree<Book> binarySearchTree = new BinarySearchTree<Book>(primaryListBooks);

            CollectionAssert.AreEqual(binarySearchTree.PostOrder().ToArray(), postOrderListBooks);
        }

        #endregion Tests for Book class

        #region Tests for Point struct
  
        [TestCase(ExpectedResult = true)]
        public bool AddNode_Point_ConnectableComparator()
        {
            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(primaryListPoints, new ComparerPoint());
            Point point = new Point(8, 8);

            binarySearchTree.AddNode(point);

            return binarySearchTree.Contains(point);
        }

        [TestCase(ExpectedResult = true)]
        public bool RemoveNode_Point_ConnectableComparator()
        {
            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(primaryListPoints, new ComparerPoint());
            Point point = new Point(7, 7);

            return binarySearchTree.RemoveNode(point);
        }

        [Test]
        public void PreOrder_Point_ConnectableComparator()
        {
            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(primaryListPoints, new ComparerPoint());

            CollectionAssert.AreEqual(binarySearchTree.PreOrder().ToArray(), preOrderListPoints);
        }

        [Test]
        public void InOrder_Point_ConnectableComparator()
        {
            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(primaryListPoints, new ComparerPoint());

            CollectionAssert.AreEqual(binarySearchTree.InOrder().ToArray(), inOrderListPoints);
        }

        [Test]
        public void PostOrder_Point_ConnectableComparator()
        {
            BinarySearchTree<Point> binarySearchTree = new BinarySearchTree<Point>(primaryListPoints, new ComparerPoint());

            CollectionAssert.AreEqual(binarySearchTree.PostOrder().ToArray(), postOrderListPoints);
        }

        #endregion Tests for Point struct
    }
}
