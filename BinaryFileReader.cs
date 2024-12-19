using System;
using System.IO;

namespace ParallelFileReading
{
    public class BinaryFileReader
    {
        public static int ReadFileInBlocks(string filePath, int blockSize)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return 0;
            }

            try
            {
                int rc = 0;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[blockSize];
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, blockSize)) > 0)
                    {
                        rc += buffer.Where(p => p == 32).Count();
                    }
                    return rc;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return 0;
            }
        }

        //static void Main(string[] args)
        //{
        //    string filePath = "example.bin";
        //    int blockSize = 1024; // Размер блока в байтах (например, 1 КБ)

        //    ReadFileInBlocks(filePath, blockSize);
        //}
    }
}
