using System.Text.RegularExpressions;

namespace YandexMetrika
{
    public class DataProcessing
    {
        public static List<ParseData> Run(Dictionary<string, DateTime> preparedData)
        {
            using (ByProductTypeContext context = new ByProductTypeContext())
            {
                var domainDateDict = new Dictionary<string, DateTime>();

                var domainDateQuery = context.InnDomains.ToList();

                var domainDate = domainDateQuery
                    .Where(x => preparedData.ContainsKey(x.Inn))
                    .Select(y => new KeyValuePair<string, DateTime>(y.DomainCorp, preparedData[y.Inn]));

                foreach (var domain in domainDate)
                {
                    if (!domainDateDict.ContainsKey(domain.Key))
                    {
                        domainDateDict.Add(domain.Key, domain.Value);
                    }
                }

                var emailsQuery = context.MainEmails.ToList();

                var emails = emailsQuery
                    .Where(x => domainDateDict.ContainsKey(x.DomainCorp))
                    .Where(z => Regex.Replace(z.Email, @"[^@]", string.Empty).Length < 2)
                    .Select(y => new ParseData
                    {
                        Id = CreateMD5(y.Email.ToLower()),
                        EmailsMd5 = CreateMD5(y.Email.ToLower()),
                        PhonesMd5 = "",
                        OrderStatus = "IN_PROGRESS",
                        CreateDateTime = domainDateDict[y.DomainCorp].ToString("dd.MM.yyyy HH:mm")
                    }).ToList();

                domainDateDict.Clear();

                // get phones
                var phonesQuery = context.PhonesInns.ToList();

                var phones = phonesQuery
                    .Where(x => preparedData.ContainsKey(x.Inn))
                    .Select(y => new { Phone = y.Phone, Date = preparedData[y.Inn] })
                    .GroupBy(z => z.Phone)
                    .Select(e => e.FirstOrDefault())
                    .Select(f => new ParseData
                    {
                        Id = CreateMD5(f.Phone),
                        EmailsMd5 = "",
                        PhonesMd5 = CreateMD5(f.Phone),
                        OrderStatus = "IN_PROGRESS",
                        CreateDateTime = f.Date.ToString("dd.MM.yyyy HH:mm")
                    }).ToList();

                emails.AddRange(phones);
                phones.Clear();

                return emails;
            }
        }

        private static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
