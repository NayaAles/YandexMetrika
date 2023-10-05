using Microsoft.Win32.TaskScheduler;

namespace YandexMetrika
{
    public static class AutoTask
    {
        public static void SaveTask(string nameTask, int daysOffSet)
        {
            using (TaskService service = new TaskService())
            {
                TaskDefinition definition = service.NewTask();
                definition.RegistrationInfo.Description = "YandexMetrikaLoadData";

                var date = Convert.ToDateTime(DateTime.Now.AddDays(daysOffSet)
                    .ToString("yyyy-MM-dd") + "T10:00:00");
                definition.Triggers.Add(new TimeTrigger() { StartBoundary = date, Enabled = true });

                var exe = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .Parent + @"\YandexMetrika.exe";
                definition.Actions.Add(new ExecAction(exe, null, Path.GetDirectoryName(exe)));
                service.RootFolder.RegisterTaskDefinition(nameTask, definition);
            }
        }

        public static void DeleteOldTasks()
        {
            using (TaskService service = new TaskService())
            {
                var tasks = service.RootFolder.GetTasks()
                    .Select(x => x.Name);

                foreach (var task in tasks)
                {
                    if (task.Contains("YandexMetrika"))
                        service.RootFolder.DeleteTask(task);
                }
            }
        }
    }
}
