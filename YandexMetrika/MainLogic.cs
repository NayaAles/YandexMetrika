
namespace YandexMetrika
{
    public class MainLogic
    {
        public static void Run()
        {
            var curentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var files = new DirectoryInfo(curentDirectory + "\\Results").GetFiles("*.csv")
                .ToDictionary(x => x.CreationTime, x => x.FullName);

            var lastFileInResult = files[files.Select(x => x.Key).Max()];

            var now = DateTime.Now.ToString("yyyy-MM-dd");
            var pathOut = @$"{curentDirectory}\Results\YandexMetrika_{now}.csv";
            var pathSaveData = @$"{curentDirectory}\Results\HistoricalData\YandexMetrika_{now}.csv";

            if (!File.Exists(pathOut))
            {
                var dataAll = new List<ParseData>();
                var dataAllPrevious = new List<ParseData>();

                if (!File.Exists(pathSaveData))
                {
                    var inDatas = ReadFromExcel.GetData(); // get data from 1C

                    var preparedData = PreparedData.GetData(inDatas); // parse data

                    dataAll = DataProcessing.Run(preparedData); // base enrichment

                    WriteReadCsv.SaveToCsv(dataAll, pathSaveData, ','); // save to csv
                }
                else
                {
                    dataAll = WriteReadCsv.ReadFromCsv(pathSaveData, ','); //read from csv  
                }

                if (File.Exists(lastFileInResult))
                {
                    dataAllPrevious = WriteReadCsv.ReadFromCsv(lastFileInResult, ',');

                    if (dataAllPrevious.Count > 0)
                    {
                        var tempPaid = new List<ParseData>();
                        var dict = new Dictionary<string, ParseData>();

                        foreach (var item in dataAll)
                            dict[item.Id] = item;

                        foreach (var item in dataAllPrevious)
                        {
                            if (!dict.ContainsKey(item.Id) && !item.Id.Equals("id"))
                            {
                                tempPaid.Add(new ParseData
                                {
                                    Id = item.Id,
                                    EmailsMd5 = item.EmailsMd5,
                                    PhonesMd5 = item.PhonesMd5,
                                    OrderStatus = "PAID",
                                    CreateDateTime = item.CreateDateTime
                                });
                            }
                        }

                        dataAll.AddRange(tempPaid);
                    }
                }

                WriteReadCsv.SaveToCsv(dataAll, pathOut, ',');
            }

            ApiYandexMetrika.SimplePost(pathOut, "UPDATE", "COMMA");
            Console.WriteLine(new string('_', 57));
            Console.WriteLine("Данные загружены в метрику");

            ///////////////////////////////////////////////////////////////////////////////
            //foreach (var item in dataAll)
            //{
            //    progress.Add(new InProgress
            //    {
            //        Id = item.Id,
            //        ContactData = item.Data,
            //        DataType = item.Type,
            //        CreateDateTime = DateTime.Parse(item.DateCreate)
            //    });
            //}

            //using (YandexMetrikaContext context = new YandexMetrikaContext()) // save to sql
            //{
            //    context.InProgresses.RemoveRange(context.InProgresses); // DELETE ALL!!!

            //    context.InProgresses.AddRange(progress);
            //    context.SaveChanges();
            //}
        }
    }
}
