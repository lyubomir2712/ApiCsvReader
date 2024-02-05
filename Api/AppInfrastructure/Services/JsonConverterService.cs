using AppInfrastructure.Contracts;
using Database.EntityModels;
using Database.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfrastructure.Services
{
    public class JsonConverterService
    {
        public async Task<string> ConvertToJson(Task<List<Organization>> recordsTask)
        {
            List<Organization> records = await recordsTask;
            string newRecords = JsonConvert.SerializeObject(records);
            return newRecords;
        }
    }
}
