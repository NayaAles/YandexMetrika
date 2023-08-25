using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace YandexMetrika
{
    public static class SecureData
    {
        public static string Get(string keyWord)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appConfig.json");
            var config = builder.Build();

            return config.GetConnectionString(keyWord);
        }

        public static void WriteToken(string token)
        {
            using (var reader = new StreamReader($@"{Directory.GetCurrentDirectory()}/appConfig.json"))
            {
                var json = reader.ReadToEnd();
                var allData = JsonConvert.DeserializeObject<DataJson>(json);
                allData.ConnectionStrings.Authorization = token;

                var stringToSave = JsonConvert.SerializeObject(allData);

                File.WriteAllText($@"{Directory.GetCurrentDirectory()}/appConfig.json", stringToSave);
            }
        }

        private class ConnectionStrings
        {
            public string ConnectionYandexMetrika { get; set; }
            public string ConnectionByProductType { get; set; }
            public string Authorization { get; set; }
            public string ClientId { get; set; }
            public string Email { get; set; }
            public string CounterId { get; set; }
            public string PasswordYId { get; set; }
            public string PasswordExcel { get; set; }
        }

        private class DataJson
        {
            public ConnectionStrings ConnectionStrings { get; set; }
        }
    }
}
