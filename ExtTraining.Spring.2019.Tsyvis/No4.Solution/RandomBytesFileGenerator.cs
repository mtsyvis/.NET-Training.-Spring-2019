namespace No4.Solution
{
    using System;

    public class RandomBytesFileGenerator : RandomFileGenerator
    {
        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}