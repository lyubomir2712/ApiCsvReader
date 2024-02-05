using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfrastructure.Contracts
{
    public interface IApiService
    {
        public Task<string> SendDataToApiAsync(string apiUrl, string json);
    }
}
