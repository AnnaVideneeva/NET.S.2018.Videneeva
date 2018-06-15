using Task2.Solution;

namespace Task2.Tests
{
    public static class Program
    {
        public static void Main()
        {
            RandomFileGenerator fileGenerator = new RandomBytesFileGenerator();
            fileGenerator.GenerateFiles(20, 20);

            fileGenerator = new RandomCharsFileGenerator();
            fileGenerator.GenerateFiles(20, 20);
        }
    }
}
