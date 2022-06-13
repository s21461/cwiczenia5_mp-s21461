using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using cwiczenia5_mp_s21461.Models;
using cwiczenia5_mp_s21461.Services;
using cwiczenia5_mp_s21461.Models.DTO;
using System;

namespace cwiczenia5_mp_s21461.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public TripsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {

            var trips = await _dbService.GetTrips();
            return Ok(trips);
        }

        [HttpPost]
        [Route("{idTrip}/clients")]
        public async Task<IActionResult> AddClientToTrip([FromBody] ClientRequestForTrip client, [FromRoute] int idTrip)
        {

            var result = await _dbService.AddClientToTrip(client, idTrip);
            switch (result)
            {
                case 0:
                    return Ok("Client add to trip");
                case 1:
                    return NotFound("Trip not found");
                case 2:
                    return Conflict("Client already booked this trip");
                default:
                    return BadRequest("Internal server error");

            }
            

        }

    }
}
