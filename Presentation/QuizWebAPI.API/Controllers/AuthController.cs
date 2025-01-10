using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebAPI.Application.Features.Commands.UserCommands.Login;

namespace QuizWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginCommandRequest request)
        {
            var response =  await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("face-login")]
        public async Task<IActionResult> LoginFacebook([FromBody] LoginCommandRequest request)
        {
            //https://localhost:7039/api/auth/face-login
            var response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
