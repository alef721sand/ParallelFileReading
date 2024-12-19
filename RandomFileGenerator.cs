using System.Text;

namespace ParallelFileReading

{
    public class RandomFileGenerator
    {
        private static readonly char[] Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ".ToCharArray();

        public static void GenerateRandomFile(string filePath, long fileSizeInBytes)
        {
            Random random = new Random();

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                long bytesWritten = 0;
                while (bytesWritten < fileSizeInBytes)
                {
                    char randomChar = Characters[random.Next(Characters.Length)];
                    writer.Write(randomChar);
                    bytesWritten++;

                    if (bytesWritten % 1024 == 0)
                    {
                        writer.Flush();
                    }
                }
            }

            Console.WriteLine($"File '{filePath}' of size {fileSizeInBytes} bytes has been created.");
        }
    }
}