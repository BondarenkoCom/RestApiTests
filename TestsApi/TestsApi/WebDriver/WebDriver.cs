using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestsApi.Interfaces;
using TestsApi.Values;

namespace TestsApi.WebDriver
{
    public class ApiWebDriver : WebDriverInterface
    {
        public async Task<string> RunDriverClient(string url)
        {
           var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Headers =
                {
                    //Change place for Tokens
                    { "X-RapidAPI-Key", "-----something token" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    //Make my text parametr
                    { "q", "English is hard, but detectably so" },
                }),
           };
           using (var response = await client.SendAsync(request))
           {
               response.EnsureSuccessStatusCode();
               var body = await response.Content.ReadAsStringAsync();
               return body;
           }
           return null;
        }

        public void StatusTestCode()
        {
            throw new NotImplementedException();
        }
    }
}
