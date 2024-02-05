using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModels
{
    public sealed class OrganizationDataMap : ClassMap<Organization>
    {
        public OrganizationDataMap()
        {
            Map(m => m.OrganizationId).Name("Organization Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Website).Name("Website");
            Map(m => m.Country).Name("Country");
            Map(m => m.Description).Name("Description");
            Map(m => m.Founded).Name("Founded");
            Map(m => m.Industry).Name("Industry");
            Map(m => m.NumberOfEmployees).Name("Number of employees");
        }
    }
}
