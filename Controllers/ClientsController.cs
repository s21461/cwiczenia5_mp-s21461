using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using cwiczenia5_mp_s21461.Services;

namespace cwiczenia5_mp_s21461.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public ClientsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete]
        [Route("{idClient}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
        {

            var result = await _dbService.RemoveClient(idClient);

            switch (result)
            {
                case 0:
                    return Ok("Client removed");
                case 1:
                    return NotFound("Cant't delete - client has a scheduled trip");
                case 2:
                    return NotFound("Client not found");
                default:
                    return BadRequest("Internal server error");

            }

        }


    }
}
