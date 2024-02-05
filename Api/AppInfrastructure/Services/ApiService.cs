using AppInfrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppInfrastructure.Services
{
    public class ApiService : IApiService
    {
        
            private readonly HttpClient _client;

            public ApiService(HttpClient client)
            {
                _client = client;
            }

            public async Task<string> SendDataToApiAsync(string apiUrl, string content)
            {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            Dictionary<string, string> parameter = new Dictionary<string, string>() { { "organizationsJson", content } };
            HttpContent httpParameter = new FormUrlEncodedContent(parameter);
            var response = await _client.PostAsync(apiUrl, httpParameter);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Status code: {response.StatusCode}, Error: {await response.Content.ReadAsStringAsync()}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
}
