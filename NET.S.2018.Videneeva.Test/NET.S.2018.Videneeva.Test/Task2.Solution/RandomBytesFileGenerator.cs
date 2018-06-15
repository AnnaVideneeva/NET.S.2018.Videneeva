using System;

namespace Task2.Solution
{
    public class RandomBytesFileGenerator : RandomFileGenerator
    {
        public const string workingDirectory = "Files with random bytes";

        public const string fileExtension = ".bytes";

        public RandomBytesFileGenerator() : base(workingDirectory, fileExtension)
        {
        }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}
