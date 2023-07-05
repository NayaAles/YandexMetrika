using YandexMetrika;
using Microsoft.Win32.TaskScheduler;

MainLogic.Run();

try
{
    using (TaskService service = new TaskService())
    {
        service.RootFolder.DeleteTask("YandexMetrika");
        service.RootFolder.DeleteTask("YandexMetrika1");
        service.RootFolder.DeleteTask("YandexMetrika2");
    }
}
catch (Exception) { }

AutoTask.SaveTask("YandexMetrika", 1);
AutoTask.SaveTask("YandexMetrika1", 2);
AutoTask.SaveTask("YandexMetrika2", 3);
