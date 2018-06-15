using System;
using System.IO;

namespace Task2.Solution
{
    public abstract class RandomFileGenerator
    {
        public string WorkingDirectory { get; private set; }

        public string FileExtension { get; private set; }

        public RandomFileGenerator(string workingDirectory, string fileExtension)
        {
            this.WorkingDirectory = workingDirectory;
            this.FileExtension = fileExtension;
        }

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        protected abstract byte[] GenerateFileContent(int contentLength);

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
