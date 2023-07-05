using System.Reflection;

namespace YandexMetrika
{
    public class ParseData
    {
        public string? Id { get; set; }
        public string? EmailsMd5 { get; set; }
        public string? PhonesMd5 { get; set; }
        public string? OrderStatus { get; set; }
        public string? CreateDateTime { get; set; }

        public static List<string> Fields()
        {
            List<string> fields = typeof(ParseData).GetRuntimeFields().Select(x => x.Name).ToList();

            return fields;
        }

        public static int FieldsCount()
        {
            List<string> fields = typeof(ParseData).GetRuntimeFields().Select(x => x.Name).ToList();
            int fieldsCount = fields.Count();

            return fieldsCount;
        }
    }
}
