using System.Reflection;
using System.Text.RegularExpressions;

namespace YandexMetrika
{
    public class WriteReadCsv
    {
        public static List<ParseData> ReadFromCsv(string path, char separator)
        {
            var inDatas = new List<ParseData>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(line))
                        inDatas.Add(ConvertToData(line, separator));
                }
            }

            return inDatas;
        }

        private static ParseData ConvertToData(string line, char separator)
        {
            var data = new ParseData();

            var array = Regex.Matches(Regex.Replace(line, @$"{separator}{separator}", $"{separator} {separator}")
            .ToString(), $"\"([^\"]+).|[^{separator}]+")
            .Cast<Match>()
            .Select(x => Regex.Replace(x.ToString(), "\"", string.Empty))
            .ToArray();

            for (int i = 0; i < ParseData.FieldsCount(); i++)
                data.GetType().GetField(ParseData.Fields().ElementAt(i), BindingFlags.Instance | BindingFlags.NonPublic).SetValue(data, array[i].ToString().Trim());

            return data;
        }

        public static void SaveToCsv<T>(List<T> outDatas, string pathOut, char separator) //экранирование if class.field.Contains(separator)
        {
            int fieldsCount = (int)outDatas[0].GetType().GetMethod("FieldsCount").Invoke(null, null);
            List<string> fields = (List<string>)outDatas[0].GetType().GetMethod("Fields").Invoke(null, null);

            int k  = 0;
            using (StreamWriter writer = new StreamWriter(pathOut))
            {
                foreach (var data in outDatas)
                {
                    k++;
                    if (k == 1 && data.GetType().GetField(fields.ElementAt(0), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(data).ToString() != "id")
                    {
                        string titles = "id,emails_md5,phones_md5,order_status,create_date_time";
                        writer.WriteLine(titles);
                    }

                    string exit = "";

                    for (int i = 0; i < fieldsCount; i++)
                    {
                        string value = data.GetType().GetField(fields.ElementAt(i), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(data).ToString();

                        if (value == " ")
                            value = "";

                        if (i == fieldsCount - 1)
                            exit = String.Concat(exit, value.Contains(separator) ? $"\"{value}\"" : value);

                        else
                            exit = String.Concat(exit, value.Contains(separator) ? $"\"{value}\"" : value, separator);
                    }

                    writer.WriteLine(exit);
                }
            }
        }
    }
}
