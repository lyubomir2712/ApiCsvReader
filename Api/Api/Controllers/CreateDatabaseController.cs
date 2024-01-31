using Database.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateDatabaseController : ControllerBase
    {
        private readonly ICreateDatabase _createDatabaseService;
        


        public CreateDatabaseController(ICreateDatabase createDatabaseService)
        {
            _createDatabaseService = createDatabaseService;
        }

        [HttpGet("createDatabase")]
        public async Task<IActionResult> CreateDatabaseAsync()
        {
            try
            {
                await _createDatabaseService.CreateDatabaseAsync("OrganizationsDb");
                return Ok("Database created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

    }
}
