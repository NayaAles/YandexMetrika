using System.Reflection;

namespace YandexMetrika.EntitiesYandexMetrika
{
    public class Data1C
    {
        public string? Link { get; set; }
        public string? Number { get; set; }
        public string? Date { get; set; }
        public string? VerifiedByManager { get; set; }
        public string? Counterparty { get; set; }
        public string? Inn { get; set; }
        public string? Code { get; set; }

        public static List<string> Fields()
        {
            List<string> fields = typeof(Data1C).GetRuntimeFields().Select(x => x.Name).ToList();

            return fields;
        }

        public static int FieldsCount()
        {
            List<string> fields = typeof(Data1C).GetRuntimeFields().Select(x => x.Name).ToList();
            int fieldsCount = fields.Count();

            return fieldsCount;
        }
    }
}
