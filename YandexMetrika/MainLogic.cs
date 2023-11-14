
namespace YandexMetrika
{
    public class MainLogic
    {
        public static async Task<string> Run()
        {
            var curentDirectory = CurrentDirectory.Get();

            var files = new DirectoryInfo(curentDirectory + @"\Results")
                .GetFiles("*.csv")
                .OrderBy(x => x.CreationTime)
                .ToDictionary(x => x.CreationTime, x => x.FullName);

            var lastFileInResult = files[files.Select(x => x.Key).Max()];

            var fileName = $"YandexMetrika_{DateTime.Now.ToString("yyyy-MM-dd")}";
            var pathOut = @$"{curentDirectory}\Results\{fileName}.csv";
            var pathSaveData = @$"{curentDirectory}\Results\HistoricalData\{fileName}.csv";

            var response = $"Error: not response. File {fileName} not uploaded";

            var dataAll = new List<ParseData>();
            var dataAllPrevious = new List<ParseData>();

            if (!File.Exists(pathOut))
            {
                if (!File.Exists(pathSaveData))
                {
                    //  Get data from 1C
                    var inDatas = ReadDataFromExcel.GetData();

                    //  Base enrichment
                    dataAll = DataProcessing.Run(inDatas);
                    WriteReadCsv.SaveToCsv(dataAll, pathSaveData, ',');
                }
                else
                    dataAll = WriteReadCsv.ReadFromCsv(pathSaveData, ',');

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
            else
            {
                dataAll = WriteReadCsv.ReadFromCsv(pathOut, ',');
            }

            if (DataToDbSql.CheckLogs())
            {
                var results = await ApiYandexMetrika.UploadCsv(pathOut, fileName, "UPDATE", "COMMA");
                var check = results.Select(x => x.Contains("{\"uploading\":"))
                    .Where(y => y == true)
                    .Count();

                if (check == results.Count)
                {
                    DataToDbSql.SaveData(dataAll);
                    foreach (var result in results)
                        DataToDbSql.SaveLog(result);
                }
                else
                {
                    //  If token expired
                    //var token = ApiYandexMetrika.GetToken();
                    //SecureData.WriteToken(token);

                    foreach (var result in results)
                        DataToDbSql.SaveLog(result);
                }       
            }

            files = new DirectoryInfo(curentDirectory + @"\Results")
                .GetFiles("*.csv")
                .OrderBy(x => x.CreationTime)
                .ToDictionary(x => x.CreationTime, x => x.FullName);

            var filesToDelete = files.Where(x => x.Value.Contains("DELETE"))
                .Select(x => x.Value)
                .ToList();

            //  Delete old files and split files
            if (files.Count() > 10)
            {
                foreach (var file in files)
                {
                    if (!file.Value.Equals(lastFileInResult) && !file.Value.Equals(pathOut))
                        File.Delete(file.Value);
                }
            }
            else if (filesToDelete.Count > 0)
            {
                foreach (var file in filesToDelete)
                     File.Delete(file);
            }

            return response;
        }
    }
}
