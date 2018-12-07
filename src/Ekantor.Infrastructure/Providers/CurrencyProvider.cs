using Exchange.Infrastructure.Dtos;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Exchange.Infrastructure.Providers
{
    public class CurrencyProvider : ICurrencyProvider
    {
        private readonly JavaScriptSerializer _serializer;

        public CurrencyProvider()
        {
            _serializer = new JavaScriptSerializer();
        }

        public async Task<CurrenciesDto> Download()
        {
            CurrenciesDto dto = null;
            using (var client = new HttpClient())
            {
                client.Timeout = new System.TimeSpan(0, 0, 3);
                var json = await client.GetStringAsync("http://webtask.future-processing.com:8068/currencies");
                dto = _serializer.Deserialize<CurrenciesDto>(json);
            }
            return dto;
        }
    }
}