using AppInfrastructure.Services;
using Database.Insert;
using Database.ViewModels;
using ExcelDataReader;
using Newtonsoft.Json.Linq;
using System.Data;

ReadCsvFileService reader = new ReadCsvFileService();

InsertData data = new InsertData("OrganizationsDb");
data.ProcessCsvDataAsync(await reader.ReadCsvFileAsync("D:\\Games\\ApiCsvReader\\organizations-100.csv"));


//JsonConverterService converter = new JsonConverterService();
//Task<string> jsonData = converter.ConvertToJson(reader.ReadCsvFileAsync("D:\\Games\\ApiCsvReader\\organizations-100.csv"));
//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("https://localhost:7088/");
//ApiService sendData = new ApiService(client);
//await sendData.SendDataToApiAsync($"https://localhost:7088/api/DataReciever/receiveData", jsonData.ToString());