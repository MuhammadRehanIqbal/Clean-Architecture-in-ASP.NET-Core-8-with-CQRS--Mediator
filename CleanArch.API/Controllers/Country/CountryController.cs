using CleanArch.Application.Authentication.Queries.Balance;
using CleanArch.Application.Countries.CreateCountry;
using CleanArch.Application.Countries.DeleteCountry;
using CleanArch.Application.Countries.GetAllCountry;
using CleanArch.Application.Countries.GetCountry;
using CleanArch.Application.Countries.UpdateCountry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers.Country
{
    [Route("country")]
    [ApiController]
    [Authorize]
    public class CountryController : ApiController
    {
        [HttpPost("CreateCoutry")] 
        public async Task<IActionResult> Create([FromBody] CreateCountryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] GetAllCountryQuery query) 
        {
            return Ok(await Mediator.Send(query));

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetCountryById([FromBody] GetCountryByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommand command)
        {

            return Ok(await Mediator.Send(command));
        }
        [HttpPost("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromBody] DeleteCountryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
