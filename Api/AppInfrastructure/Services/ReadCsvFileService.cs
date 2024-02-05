using AppInfrastructure.Contracts;
using CsvHelper;
using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfrastructure.Services
{
    public class ReadCsvFileService : IReadCsvFileService
    {
        public async Task<List<Organization>> ReadCsvFileAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<OrganizationDataMap>();
                var records = new List<Organization>();

                await csv.ReadAsync();
                csv.ReadHeader();
                while (await csv.ReadAsync())
                {
                    var record = csv.GetRecord<Organization>();
                    records.Add(record);
                }

                return records;
            }
        }
    }
}

