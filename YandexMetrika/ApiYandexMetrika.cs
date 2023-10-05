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

        public static async Task<string> UploadCsv(string filePath, string fileName, string mode, string delimiter)
        {
            string url = $"https://api-metrika.yandex.net/cdp/api/v1/counter/{SecureData.Get("CounterId")}" +
                   $"/data/simple_orders?merge_mode={mode}&delimiter_type={delimiter}";

            byte[] fileByteArray = File.ReadAllBytes(filePath);
            var content = new MultipartFormDataContent(new string('-', 10) + Guid.NewGuid());
            var byteArrayContent = new ByteArrayContent(fileByteArray);

            byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
            content.Add(byteArrayContent, "\"file\"", $"\"{fileName}\"");

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(5);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("OAuth", SecureData.Get("Authorization"));

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
