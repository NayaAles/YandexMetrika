using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;

namespace YandexMetrika
{
    public static class ApiYandexMetrika
    {
        private const string CssButton = "#root > div > div.passp-page > div.passp-flex-wrapper > div > div" +
            " > div.passp-auth-content > div:nth-child(3) > div > form > button";
        private const string CssEmail = "#passp-field-login";
        private const string CssLogin = "#passp\\:sign-in";
        private const string CssPassword = "#passp-field-passwd";

        public static string GetToken()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            using (var driver = new ChromeDriver(options))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.Url = $"https://oauth.yandex.ru/authorize?response_type=token&client_id=" +
                    $"{SecureData.Get("ClientId")}";

                driver.FindElement(By.CssSelector(CssButton))
                    .Click();
                driver.FindElement(By.CssSelector(CssEmail))
                    .SendKeys(SecureData.Get("Email"));
                driver.FindElement(By.CssSelector(CssLogin))
                    .Click();
                driver.FindElement(By.CssSelector(CssPassword))
                    .SendKeys(SecureData.Get("PasswordYId"));
                driver.FindElement(By.CssSelector(CssLogin))
                    .Click();

                //  Enter the code sent to the phone number manually!
                System.Threading.Thread.Sleep(30000);

                return Regex.Match(driver.Url.ToString(), @"access_token=[^&]+")
                    .ToString();
            }
        }

        private static async Task<List<string>> SplitFile(string filePath, int numberOfLines)
        {
            var datas = WriteReadCsv.ReadFromCsv(filePath, ',')
                .Skip(1)
                .ToList();
            var files = new List<string>();

            if (datas.Count > numberOfLines)
            {
                var number = (int)Math.Ceiling(Convert.ToDouble(datas.Count) / Convert.ToDouble(numberOfLines));
                for (int i = 0; i < number; i++)
                {
                    var dataSplit = datas.Take(numberOfLines)
                        .ToList();
                    if (datas.Count > numberOfLines)
                        datas.RemoveRange(i, numberOfLines);
                    else
                        dataSplit = datas;

                    var path = Regex.Replace(filePath, @".csv+", $"_{i}.csv");
                    files.Add(path);
                    WriteReadCsv.SaveToCsv(dataSplit, path, ',');
                }
            }

            return files;
        }

        public static async Task<List<string>> UploadCsv(string filePath, string fileName, string mode, string delimiter)
        {
            var counter = SecureData.Get("CounterId");
            string url = $"https://api-metrika.yandex.net/cdp/api/v1/counter/{counter}" +
                $"/data/simple_orders?merge_mode={mode}&delimiter_type={delimiter}";

            var files = await SplitFile(filePath, 300000);
            var result = new List<string>();
            foreach (var file in files)
            {
                byte[] fileByteArray = File.ReadAllBytes(file);
                var content = new MultipartFormDataContent(new string('-', 10) + Guid.NewGuid());
                var byteArrayContent = new ByteArrayContent(fileByteArray);

                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
                content.Add(byteArrayContent, "\"file\"", $"\"{fileName}\"");

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(10);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("OAuth", SecureData.Get("Authorization"));

                    var response = await client.PostAsync(url, content);
                    result.Add(await response.Content.ReadAsStringAsync());
                }
            }

            return result;
        }
    }
}
