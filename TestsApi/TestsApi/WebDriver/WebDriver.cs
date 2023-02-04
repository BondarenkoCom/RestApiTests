using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestsApi.Interfaces;
using TestsApi.Values;
using System.Text.Json;
using TestsApi.Models;

namespace TestsApi.WebDriver
{
    public class ApiWebDriver : IWebDriver
    {
        public async Task<string> RunDriverClient(string url, string urlParamTypeApi, string ApiKey)
        {
            using (var client = new HttpClient())
            {
            client.BaseAddress = new Uri($"{url}");
                var response = await client.GetAsync($"{urlParamTypeApi}{ApiKey}");
                Console.WriteLine($"{urlParamTypeApi}{ApiKey}");


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    return "Request failed with status code: " + response.StatusCode;
                }
            }
        }

        public async Task<string> RunDriverClient(string url, string urlParamTypeApi)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{url}");
                var response = await client.GetAsync($"{urlParamTypeApi}");
                Console.WriteLine($"{urlParamTypeApi}");


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    return "Request failed with status code: " + response.StatusCode;
                }
            }
        }
        public void StatusTestCode()
        {
            throw new NotImplementedException();
        }
    }
}
