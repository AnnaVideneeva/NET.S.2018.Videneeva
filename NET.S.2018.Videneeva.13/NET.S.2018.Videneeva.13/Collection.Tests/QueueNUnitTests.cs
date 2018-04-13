using NUnit.Framework;

namespace Collection.Tests
{
    [TestFixture]
    public class QueueNUnitTests
    {
        [TestCase(ExpectedResult = true)]
        public bool Enqueue_Int_SuccessfulExecution()
        {
            Queue<int> firstQueue = new Queue<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Queue<int> secondQueue = new Queue<int>();

            while (firstQueue.MoveNext())
            {
                secondQueue.Enqueue(firstQueue.Current);
            }

            return firstQueue.Equals(secondQueue);
        }

        [TestCase(ExpectedResult = true)]
        public bool Dequeue_String_SuccessfulExecution()
        {
            Queue<string> queue = new Queue<string>(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });

            while (queue.MoveNext())
            {
                queue.Dequeue();
            }

            return queue.IsEmpty();
        }

        [TestCase('1', ExpectedResult = true)]
        [TestCase('3', ExpectedResult = true)]
        [TestCase('5', ExpectedResult = true)]
        [TestCase('7', ExpectedResult = true)]
        [TestCase('q', ExpectedResult = false)]
        [TestCase('w', ExpectedResult = false)]
        [TestCase('e', ExpectedResult = false)]
        [TestCase('r', ExpectedResult = false)]
        public bool Contains_Char_SuccessfulExecution(char value)
        {
            Queue<char> queue = new Queue<char>(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            return queue.Contains(value);
        }

        [TestCase(ExpectedResult = "1")]
        public string Peek_String_SuccessfulExecution()
        {
            Queue<string> queue = new Queue<string>(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            return queue.Peek();
        }
    }
}