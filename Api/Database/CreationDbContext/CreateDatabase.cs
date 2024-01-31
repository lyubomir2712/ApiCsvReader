using Database.Contracts;
using System;
using System.Data.SqlClient;

public class CreateDatabase : ICreateDatabase
{
    private string _masterConnectionString;


    public CreateDatabase(string masterConnectionString, string orgDbConnectionString)
    {
        _masterConnectionString = masterConnectionString;

    }
    public async Task CreateDatabaseAsync(string dbName)
    {
        string createDatabaseQuery = $"CREATE DATABASE {dbName}";

        using (SqlConnection connection = new SqlConnection(_masterConnectionString))
        {
            await connection.OpenAsync();
            using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
            {
                await command.ExecuteNonQueryAsync();
            }
        }
    }


    


    
}

