﻿using YandexMetrika.Contexts;
using YandexMetrika.EntitiesYandexMetrika;

namespace YandexMetrika
{
    public static class DataToDbSql
    {
        public static void Save(List<ParseData> dataAll, string response)
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
                context.InProgresses.RemoveRange(context.InProgresses); // DELETE ALL!
                context.SaveChanges();

                context.InProgresses.AddRange(progress);
                context.SaveChanges();

                if (!String.IsNullOrEmpty(response))
                    context.AddLogs.Add(new AddLog { Log = response });
                else
                    context.AddLogs.Add(new AddLog { Log = "error: not response" });

                context.SaveChanges();
            }
        }
    }
}