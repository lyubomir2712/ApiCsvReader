using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts
{
    public interface IProcessCsvData
    {
        public async Task ProcessCsvDataAsync(IEnumerable<Organization> csvData) { }
    }
}
