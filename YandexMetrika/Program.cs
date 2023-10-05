using YandexMetrika;

await MainLogic.Run();

AutoTask.DeleteOldTasks();

AutoTask.SaveTask("YandexMetrika", 1);
AutoTask.SaveTask("YandexMetrika1", 2);
AutoTask.SaveTask("YandexMetrika2", 3);