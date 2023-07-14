using Microsoft.Extensions.Configuration;

namespace YandexMetrika
{
    public static class SecureData
    {
        public static string GetSecureData(string keyWord)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appConfig.json");
            var config = builder.Build();
            return config.GetConnectionString(keyWord);
        }
    }
}
