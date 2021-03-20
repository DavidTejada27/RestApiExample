using Newtonsoft.Json;
using RestApiExample.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExample.Services
{
    public class InstanceApiService : IInstanceApiService
    {
        public async Task<Synonim> GetInstanceAsync(string word)
        {
            Synonim result = new Synonim();
            HttpClient client = new HttpClient();

            string urlString = $"https://wordsapiv1.p.rapidapi.com/words/{word}/synonyms";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(urlString),
                Headers = {
                    { "x-rapidapi-key", "704ca8d251mshe6218a98dd2f799p114d43jsn0dae0dca77d3" },
                    { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonPayload = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    result = await Task.Run(() =>
                           JsonConvert.DeserializeObject<Synonim>(jsonPayload)
                        ).ConfigureAwait(false);
                }

                return result;
            }
        }
    }
}
