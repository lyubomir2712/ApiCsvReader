using Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CreationDbContext
{
    public class CreateTables : ICreateTables
    {
        public CreateTables(string orgDbConnectionString) 
        {
            _orgDbConnectionString = orgDbConnectionString;
        }

        private string _orgDbConnectionString;
        public async Task CreateTablesAsync()
        {
            string createTableQuery =
            @"
                CREATE TABLE Countries (
                    CountryId INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(255) UNIQUE
                );

                CREATE TABLE Industries (
                    IndustryId INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(255) UNIQUE
                );

                CREATE TABLE Organizations (
                    OrganizationId VARCHAR(255) PRIMARY KEY,
                    Name NVARCHAR(255),
                    Website NVARCHAR(255),
                    Description TEXT,
                    Founded INT,
                    NumberOfEmployees INT,
                    CountryId INT FOREIGN KEY REFERENCES Countries(CountryId),
                    IndustryId INT FOREIGN KEY REFERENCES Industries(IndustryId)
                );
            ";

            using (SqlConnection connection = new SqlConnection(_orgDbConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
