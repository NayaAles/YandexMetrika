using Aspose.Cells;
using System.Reflection;
using YandexMetrika.EntitiesYandexMetrika;

namespace YandexMetrika
{
    public class ReadDataFromExcel
    {
        public static List<Data1C> GetData()
        {
            const string PathDataFrom1C = @"\\192.168.0.12\выгрузка\ВсеСчета.xlsx";
            Workbook workbook = new Workbook();

            LoadOptions xlsxLoadOptions = new LoadOptions(LoadFormat.Xlsx);
            xlsxLoadOptions.Password = SecureData.GetSecureData("PasswordExcel");

            try
            {
                workbook = new Workbook(PathDataFrom1C, xlsxLoadOptions);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            WorksheetCollection worksheets = workbook.Worksheets;
            // get data from first worksheet
            Worksheet worksheet = worksheets[0];

            int rows = worksheet.Cells.MaxDataRow + 1;
            int cols = worksheet.Cells.MaxDataColumn + 1;

            List<Data1C> inDatas = new List<Data1C>();

            for (int i = 1; i < rows; i++)
            {
                Data1C tempInData = new Data1C();

                for (int j = 0; j < cols; j++)
                {
                    if (worksheet.Cells[i, j].Value != null)
                    {
                        string data = worksheet.Cells[i, j].Value.ToString().Trim();

                        tempInData.GetType().GetField(Data1C.Fields().ElementAt(j), BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tempInData, data);
                    }
                }

                inDatas.Add(tempInData);
            }

            return inDatas;
        }
    }
}
