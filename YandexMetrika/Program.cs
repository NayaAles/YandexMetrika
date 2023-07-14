using YandexMetrika;
using Microsoft.Win32.TaskScheduler;

MainLogic.Run();

using (TaskService service = new TaskService())
{
    var tasks = service.RootFolder.GetTasks().Select(x => x.Name);

    foreach (var task in tasks)
    {
        if (task.Contains("YandexMetrika"))
            service.RootFolder.DeleteTask(task);
    }
}

AutoTask.SaveTask("YandexMetrika", 1);
AutoTask.SaveTask("YandexMetrika1", 2);
AutoTask.SaveTask("YandexMetrika2", 3);
