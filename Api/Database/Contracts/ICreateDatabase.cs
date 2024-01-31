using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts
{
    public interface ICreateDatabase
    {
        public async Task CreateDatabaseAsync(string dbName) { }
    }
}
