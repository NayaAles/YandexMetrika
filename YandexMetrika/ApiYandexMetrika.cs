using System.Net;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace YandexMetrika
{
    public class ApiYandexMetrika
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

        public static string SimplePost(string filePath, string mode, string delimiter)
        {
            string url = $"https://api-metrika.yandex.net/cdp/api/v1/counter/{SecureData.Get("CounterId")}" +
                $"/data/simple_orders?merge_mode={mode}&delimiter_type={delimiter}";

            var client = new MyWebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.Headers.Add("Authorization", SecureData.Get("Authorization"));
            client.Headers.Add("Content-Type", "text/csv");

            var response = Encoding.ASCII.GetString(client.UploadFile(url, "POST", filePath));
            Console.WriteLine(response);
            client.Dispose();

            return response;
        }
    }

    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
           var w = (HttpWebRequest)base.GetWebRequest(uri);
            w.Timeout = 1000 * 20 * 60 * 1000;

            return w;
        }
    }
}
