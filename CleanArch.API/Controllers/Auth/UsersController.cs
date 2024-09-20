using CleanArch.Application.Authentication.Commands.Register;
using CleanArch.Application.Authentication.Queries.Balance;
using CleanArch.Application.Authentication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers.Auth
{
    [Route("users")]
    [ApiController]
    public class UsersController : ApiController
    {
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("auth/balance")]
        [Authorize]
        public async Task<IActionResult> GetBalance([FromBody] BalanceQuery query)
        {
            if (query == null || string.IsNullOrWhiteSpace(query.Username))
            {
                return BadRequest("The Username field is required.");
            }

            return Ok(await Mediator.Send(query)); 
        }
        [HttpGet("auth/balancetst")] 
        public async Task<IActionResult>
         FindUserByIdAsynctst()
        {
            return Ok("unauthprized request");
        }
    }
}
