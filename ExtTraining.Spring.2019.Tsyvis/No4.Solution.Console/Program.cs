namespace No4.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomFileGenerator generator = new RandomBytesFileGenerator();
            generator.GenerateFiles(1, 100);

            generator = new RandomCharsFileGenerator();
            generator.GenerateFiles(1, 2000);
        }
    }
}
