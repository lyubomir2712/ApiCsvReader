using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Interface
{
    public interface IProcessCsvData
    {
        public Task ProcessCsvDataAsync(IEnumerable<Organization> csvData);
    }
}
