namespace ParallelFileReading
{
    public class HomeWork
    {
        public void Task01()
        {
            var scheduler = new TasksScheduler();
            string[] file_list = ["data1.txt", "data2.txt", "data3.txt"];
            Parallel.For(0, file_list.Length, i =>
            {
                try
                {
                    if (!File.Exists(file_list[i]))
                    {
                        long fileSizeInBytes = 1024 * 1024; // Например, 1 МБ
                        RandomFileGenerator.GenerateRandomFile(file_list[i], fileSizeInBytes);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File {file_list[i]} creation failed: {ex.Message}");
                }

            });

            scheduler.ProcessQueue(file_list);
        }
        public void Task02(string search_dir)
        {
            var scheduler = new TasksScheduler();
            var dir_reader = new ReadDirectory();
            var fileList = new List<string>();
            dir_reader.FileFound += (sender, e) =>
            {
                fileList.Add(e.FileName);
            };
            Console.WriteLine($"Walking through directory [{search_dir}]...");
            dir_reader.ReadDir(search_dir);
            Console.WriteLine($"Found {fileList.Count} files");
            scheduler.ProcessQueue(fileList.ToArray());
        }
    }
}
