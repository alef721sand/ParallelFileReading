namespace ParallelFileReading
{
    public class FileFoundEvenArgs : EventArgs
    {
        public string FileName { get; }

        public FileFoundEvenArgs(string fileName)
        {
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }
    }
}
