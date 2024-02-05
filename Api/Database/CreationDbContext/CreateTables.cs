using Database.Contracts;
using Database.EntityModels;

using Database.ViewModels;
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

        public string _orgDbConnectionString;
        public async Task CreateTablesAsync()
        {
            string createTableQuery =
            @"
                CREATE TABLE Countries (
                    CountryId INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(255) UNIQUE
                );

                

                CREATE TABLE Organizations (
                    OrganizationId VARCHAR(255) PRIMARY KEY,
                    Name NVARCHAR(255),
                    Website NVARCHAR(255),
                    Description TEXT,
                    Founded INT,
                    Industry Text,
                    NumberOfEmployees INT,
                    CountryId INT FOREIGN KEY REFERENCES Countries(CountryId),
                    
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
