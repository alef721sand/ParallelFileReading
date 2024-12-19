using System.Diagnostics;

namespace ParallelFileReading
{
    public class TasksScheduler
    {
        private readonly List<TaskSchedulerItem> _queueHandlerTasks = new List<TaskSchedulerItem>();

        public void ProcessQueue(string[] file_list)
        {
            var stopWatch = new Stopwatch();

            Console.WriteLine("Handling queue...");
            stopWatch.Start();

            foreach (var file in file_list)
            {
                var task = new TaskSchedulerItem(file);
                _queueHandlerTasks.Add(task);
            }
            _queueHandlerTasks.ForEach(StartHandlerTask);
            WaitAllTasksWithRetry();
            stopWatch.Stop();
            foreach (var task in _queueHandlerTasks)
            { 
                Console.WriteLine($"{task.FileName}: {task.Count} spaces"); 
            }
            Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
        }

        private void WaitAllTasksWithRetry()
        {
            try
            {
                var tasksForWait = GetTasksForWait();
                Task.WaitAll(tasksForWait);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Task[] GetTasksForWait()
        {
            return _queueHandlerTasks
                .Select(x => x.Task)
                .ToArray();
        }

        private void StartHandlerTask(TaskSchedulerItem item)
        {
            item.Task = Task.Run(() => item.FileHandler());
        }

    }
}
