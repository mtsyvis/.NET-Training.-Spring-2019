using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    using System.Linq;

    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            try
            {
                using (var fsWriter = new FileStream(destinationPath, FileMode.Create))
                {
                    foreach (var @byte in File.ReadAllBytes(sourcePath))
                    {
                        fsWriter.WriteByte(@byte);
                    }

                    return File.ReadAllBytes(sourcePath).Length;
                }
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException($"File with path {e.Source} does not exist", e);
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            using (TextReader reader = new StreamReader(sourcePath))
            using (TextWriter writer = new StreamWriter(destinationPath))
            {
                var encoding = Encoding.Default;
                var buffer = Encoding.Default.GetBytes(reader.ReadToEnd());

                var memoryStream = new MemoryStream(buffer);

                var newByteArray = new byte[buffer.Length];
                memoryStream.Read(newByteArray, 0, newByteArray.Length);

                var charArray = new char[encoding.GetCharCount(newByteArray, 0, newByteArray.Length)];
                encoding.GetChars(newByteArray, 0, newByteArray.Length, charArray, 0);

                writer.Write(charArray);

                return buffer.Length;
            }

            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            try
            {
                using (FileStream fsReader = File.OpenRead(sourcePath))
                using (var fsWriter = new FileStream(destinationPath, FileMode.Create))
                {
                    var buffer = File.ReadAllBytes(sourcePath);
                    fsReader.Read(buffer, 0, buffer.Length);
                    fsWriter.Write(buffer, 0, buffer.Length);
                    return checked((int)fsReader.Length);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException($"File with path {e.Source} does not exist", e);
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            using (FileStream fsReader = File.OpenRead(sourcePath))
            using (var fsWriter = new FileStream(destinationPath, FileMode.Create))
            {
                var memoryStream = new MemoryStream();
                fsReader.CopyTo(memoryStream);

                var buffer = new byte[memoryStream.Length];
                memoryStream.Write(buffer, 0, buffer.Length);

                fsWriter.Write(buffer, 0, buffer.Length);
                
                return buffer.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            using (FileStream fsReader = File.OpenRead(sourcePath))
            using (var fsWriter = new FileStream(destinationPath, FileMode.Create))
            using(var bufferedStream = new BufferedStream(fsReader))
            {
                var buffer = new byte[fsReader.Length];

                bufferedStream.Read(buffer, 0, buffer.Length);

                fsWriter.Write(buffer, 0, buffer.Length);

                return buffer.Length;
            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            var lines = File.ReadAllLines(sourcePath);

            File.WriteAllLines(destinationPath, lines);

            return lines.Length;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            return File.ReadAllBytes(sourcePath).SequenceEqual(File.ReadAllBytes(destinationPath));
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            
        }

        #endregion

        #endregion

    }
}
