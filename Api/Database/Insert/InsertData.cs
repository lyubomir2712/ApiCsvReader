using Database.EntityModels;
using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Insert
{
    public class InsertData
    {
        public string _orgDbConnectionString; 
        public InsertData(string orgDbConnectionString) 
        {
            _orgDbConnectionString = orgDbConnectionString;
        }
        public async Task InsertOrganizationAsync(OrganizationEntity organization)
        {
            using (SqlConnection connection = new SqlConnection($"Server=(Local)\\SQLEXPRESS01;Database={_orgDbConnectionString};Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string upsertSql = @"
                    IF EXISTS (SELECT 1 FROM Organizations WHERE OrganizationId = @OrganizationId)
                    BEGIN
                        UPDATE Organizations 
                        SET 
                            Name = @Name, 
                            Website = @Website, 
                            Description = @Description, 
                            Founded = @Founded, 
                            Industry = @Industry, 
                            NumberOfEmployees = @NumberOfEmployees, 
                            CountryId = @CountryId
                        WHERE OrganizationId = @OrganizationId
                    END
                    ELSE
                    BEGIN
                        INSERT INTO Organizations 
                        (OrganizationId, Name, Website, Description, Founded, Industry, NumberOfEmployees, CountryId)
                        VALUES 
                        (@OrganizationId, @Name, @Website, @Description, @Founded, @Industry, @NumberOfEmployees, @CountryId)
                    END";

                        using (SqlCommand command = new SqlCommand(upsertSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrganizationId", organization.OrganizationId);
                            command.Parameters.AddWithValue("@Name", organization.Name);
                            command.Parameters.AddWithValue("@Website", organization.Website);
                            command.Parameters.AddWithValue("@Description", organization.Description);
                            command.Parameters.AddWithValue("@Founded", organization.Founded.HasValue ? (object)organization.Founded : DBNull.Value);
                            command.Parameters.AddWithValue("@Industry", organization.Industry);
                            command.Parameters.AddWithValue("@NumberOfEmployees", organization.NumberOfEmployees.HasValue ? (object)organization.NumberOfEmployees : DBNull.Value);
                            command.Parameters.AddWithValue("@CountryId", organization.CountryId);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error in InsertOrganizationAsync: {ex.Message}", ex);
                    }
                }
            }
        }

        public async Task<int> GetOrInsertCountryAsync(string countryName)
        {
            using (var connection = new SqlConnection($"Server=(Local)\\SQLEXPRESS01;Database={_orgDbConnectionString};Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"))
            {
                
                connection.Open();
                


                string checkSql = "SELECT CountryId FROM Countries WHERE Name = @Name";
                using (var checkCommand = new SqlCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Name", countryName);
                    var result = checkCommand.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                string insertSql = "INSERT INTO Countries (Name) OUTPUT INSERTED.CountryId VALUES (@Name)";
                using (var insertCommand = new SqlCommand(insertSql, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Name", countryName);
                    return (int) insertCommand.ExecuteScalar();
                }
            }
        }

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
