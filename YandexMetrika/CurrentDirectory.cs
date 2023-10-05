
namespace YandexMetrika
{
    public static class CurrentDirectory
    {
        public static string Get()
        {
            var startDirectory = new DirectoryInfo(Directory.GetCurrentDirectory())
                .Parent;

            var i = 0;
            string currentDirectory = "";
            do
            {
                if (startDirectory != null)
                {
                    i++;
                    currentDirectory = startDirectory.FullName;
                    startDirectory = startDirectory.Parent;
                }
            }
            while (i < 3);

            return currentDirectory;
        }
    }
}
