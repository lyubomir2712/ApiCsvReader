using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts
{
    public interface IInsertOrganization
    {
        public async Task InsertOrganizationAsync(Organization organization) { }
    }
}
