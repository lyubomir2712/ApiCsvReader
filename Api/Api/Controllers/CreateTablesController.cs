using Database.Contracts;
using Database.CreationDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTablesController : ControllerBase
    {
        private readonly ICreateTables _createTables;
        public CreateTablesController(ICreateTables createTables) 
        {
            _createTables = createTables;
        }


        [HttpGet("createTables")]
        public async Task<IActionResult> CreateOrganizationTableAsync()
        {
            try
            {
                await _createTables.CreateTablesAsync();
                return Ok("Tables created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
