using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfrastructure.Contracts
{
    public interface IReadCsvFileService
    {
        public Task<List<Organization>> ReadCsvFileAsync(string filePath);
    }
}
