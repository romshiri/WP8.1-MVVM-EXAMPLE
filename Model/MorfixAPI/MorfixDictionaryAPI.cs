using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Romfix.Model.MorfixAPI
{
    public class MorfixDictionaryAPI : IDictionaryAPI
    {
        private const string APIAddress = "http://services.britannicaenglish.com/Translationhebrew/TranslationService/GetTranslation/";
        IJsonParser _parser;

        public MorfixDictionaryAPI(IJsonParser parser)
        {
            _parser = parser;
        }

        public async Task<Translation> TranslateQueryAsync(string query)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string jsonQuery = JsonConvert.SerializeObject(new JsonPostQuery { Query = query });

                StringContent content = new StringContent(jsonQuery);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync(new Uri(APIAddress), content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Translation queryResult = _parser.ParseJsonResponse(jsonResponse);

                    return queryResult;
                }
                else
                {
                    return new Translation();
                }
            }
        }

        private class JsonPostQuery
        {
            public string Query { get; set; }
        }
    }


}
