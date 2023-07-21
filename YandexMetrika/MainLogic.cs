
namespace YandexMetrika
{
    public class MainLogic
    {
        public static void Run()
        {
            var curentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var files = new DirectoryInfo(curentDirectory + @"\Results")
                .GetFiles("*.csv")
                .OrderBy(x => x.CreationTime)
                .ToDictionary(x => x.CreationTime, x => x.FullName);

            var lastFileInResult = files[files.Select(x => x.Key).Max()];

            var now = DateTime.Now.ToString("yyyy-MM-dd");
            var pathOut = @$"{curentDirectory}\Results\YandexMetrika_{now}.csv";
            var pathSaveData = @$"{curentDirectory}\Results\HistoricalData\YandexMetrika_{now}.csv";

            var dataAll = new List<ParseData>();
            var dataAllPrevious = new List<ParseData>();

            if (!File.Exists(pathOut))
            {
                if (!File.Exists(pathSaveData))
                {
                    var inDatas = ReadDataFromExcel.GetData();  // get data from 1C

                    dataAll = DataProcessing.Run(inDatas);  // base enrichment

                    WriteReadCsv.SaveToCsv(dataAll, pathSaveData, ','); // save to csv
                }
                else
                {
                    dataAll = WriteReadCsv.ReadFromCsv(pathSaveData, ',');  //read from csv  
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
                DataToDbSql.Save(dataAll, ApiYandexMetrika.SimplePost(pathOut, "UPDATE", "COMMA"));
            }

            if (files.Count() > 10) //  delete old files
            {
                foreach (var file in files)
                {
                    if (!file.Value.Equals(lastFileInResult))
                        File.Delete(file.Value);
                }
            }
        }
    }
}
