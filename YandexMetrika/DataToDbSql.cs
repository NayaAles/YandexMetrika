using System;
using System.Text.RegularExpressions;
using YandexMetrika.EntitiesYandexMetrika;

namespace YandexMetrika
{
    public static class DataToDbSql
    {
        public static void SaveData(List<ParseData> dataAll)
        {
            var progress = new List<InProgress>();
            dataAll.RemoveAt(0);
            foreach (var item in dataAll)
            {
                progress.Add(new InProgress
                {
                    EmailsMd5 = item.EmailsMd5,
                    PhonesMd5 = item.PhonesMd5,
                    OrderStatus = item.OrderStatus,
                    CreateDateTime = DateTime.Parse(item.CreateDateTime)
                });
            }

            using (var context = new YandexMetrikaContext())
            {
                context.InProgresses.RemoveRange(context.InProgresses); //  Delete all!
                context.InProgresses.AddRange(progress);

                context.SaveChanges();
            }
        }

        public static void SaveLog(string response)
        {
            if (!String.IsNullOrEmpty(response) && response.Contains("{\"uploading\":"))
            {
                using (var context = new YandexMetrikaContext())
                {
                    var dateCreated = DateTime.Parse(Regex.Match(response, @"datetime.:.(.{19})").Groups[1].ToString());
                    context.AddLogs.Add(new AddLog { DateCreated = dateCreated, Log = response });
                    context.SaveChanges();
                }
            }
            else
            {
                using (var context = new YandexMetrikaContext())
                {
                    context.AddLogs.Add(new AddLog { DateCreated = DateTime.Now, Log = response });
                    context.SaveChanges();
                }
            }
        }

        public static bool CheckLogs()
        {
            bool flag = true;
            var today = DateOnly.FromDateTime(DateTime.Today);
            using (var context = new YandexMetrikaContext())
            {
                var lastLog = context.AddLogs
                    .OrderBy(x => x.DateCreated)
                    .Last();

                var dateInLog = DateOnly.FromDateTime(lastLog.DateCreated);
                if (today.Equals(dateInLog) && lastLog.Log.Contains("{\"uploading\":"))
                    flag = false;
            }

            return flag;
        }
    }
}
