using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebAPI.Application.Features.Commands.UserCommands.Register;

namespace QuizWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("user-register")]
        public async Task<IActionResult> Resgister([FromBody] RegisterCommandRequest request)
        {
            await Task.Delay(1000);
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
