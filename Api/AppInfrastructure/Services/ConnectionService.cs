using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace AppInfrastructure.Services
{
    public class ConnectionService
    {
        public HttpClient _httpClient { get; set; }

        public ConnectionService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }
    }
}
