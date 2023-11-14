using YandexMetrika;

await MainLogic.Run();

AutoTask.DeleteOldTasks();
AutoTask.SaveTasks("YandexMetrika", 3);
