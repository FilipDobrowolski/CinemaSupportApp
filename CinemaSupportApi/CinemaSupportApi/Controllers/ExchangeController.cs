using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using CinemaSupportApi.ExternalCurrencyClient;
using Newtonsoft.Json;

namespace CinemaSupportApi.Controllers
{
    [RoutePrefix("exchange")]
    public class ExchangeController : ApiController
    {
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> GetAllCurrencies()
        {
            string responseBody = String.Empty;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://api.exchangeratesapi.io");
                var request = new HttpRequestMessage(HttpMethod.Get, "/2019-01-14?base=PLN");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                var response = await client.SendAsync(request);
                responseBody = response.Content.ReadAsStringAsync().Result;

            }

            return Ok(JsonConvert.DeserializeObject<object>(responseBody));
        }
    }
}
