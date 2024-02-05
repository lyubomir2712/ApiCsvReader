using Database.Contracts;
using Database.CreationDbContext;
using Database.Insert;
using Database.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataRecieverController : ControllerBase
    {

        public InsertData _insertDataService;
        public DataRecieverController(InsertData insertDataService) 
        {
            _insertDataService = insertDataService;
        }


        [HttpPost("receiveData")]
        public async Task<IActionResult> ReceiveData(string organizationsJson)
        {
            List<Organization> organizations = JsonConvert.DeserializeObject<List<Organization>>(organizationsJson);
            try
            {
                await _insertDataService.ProcessCsvDataAsync(organizations);
                return Ok("Data processed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while processing the data: " + ex.Message);
            }
        }
    }
}
