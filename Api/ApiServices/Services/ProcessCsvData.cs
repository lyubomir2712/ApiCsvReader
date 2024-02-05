using ApiInfrastructure.Interface;
using Database.EntityModels;
using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Services
{
    public class ProcessCsvData : IProcessCsvData 
    {

        public async Task ProcessCsvDataAsync(IEnumerable<Organization> csvData)
        {
            foreach (var csvRecord in csvData)
            {
                int countryId = await GetOrInsertCountryAsync(csvRecord.Country);

                var organization = new OrganizationEntity
                {
                    OrganizationId = csvRecord.OrganizationId,
                    Name = csvRecord.Name,
                    Website = csvRecord.Website,
                    Description = csvRecord.Description,
                    Founded = csvRecord.Founded,
                    Industry = csvRecord.Industry,
                    NumberOfEmployees = csvRecord.NumberOfEmployees,
                    CountryId = countryId,
                };

                await InsertOrganizationAsync(organization);
            }
        }
    }
}
