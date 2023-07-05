
namespace YandexMetrika
{
    public class PreparedData
    {
        public static Dictionary<string, DateTime> GetData(List<Data1C> inDatas)
        {
            var preparedData = new Dictionary<string, DateTime>();
            var mnGroup = inDatas.GroupBy(x => x.Code);

            foreach (var mn in mnGroup)
            {
                DateTime today = DateTime.Now;
                var dateLast = new DateTime();

                bool statusCheck = false;
                var statusGroup = mn.GroupBy(x => x.VerifiedByManager);

                foreach (var lable in statusGroup)
                {
                    if (lable.Key.Equals("Нет"))
                    {
                        dateLast = lable.Select(x => DateTime.Parse(x.Date))
                            .ToList()
                            .Max();

                        var diffDays = (today - dateLast).TotalDays;
                        if (diffDays < 61)
                        {
                            statusCheck = true;
                        }
                    }
                }

                if (statusCheck)
                {
                    var inns = mn.GroupBy(x => x.Inn).Select(y => y.Key).ToList();

                    foreach (var inn in inns)
                    {
                        if (!String.IsNullOrEmpty(inn) && !preparedData.ContainsKey(inn))
                        {
                            preparedData.Add(inn, dateLast);
                        }
                    }
                }
            }

            return preparedData;
        }
    }
}
