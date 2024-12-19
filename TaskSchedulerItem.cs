namespace ParallelFileReading
{
    public class TaskSchedulerItem
    {
        public int Count { get; private set; }
        public string FileName { get; private set; } = string.Empty;
        public Task Task { get; set; }
        public TaskSchedulerItem(string filename) => FileName = filename;
        public void FileHandler()
        {
            int blockSize = 1024;
            Count = BinaryFileReader.ReadFileInBlocks(FileName, blockSize);
        }
    }
}