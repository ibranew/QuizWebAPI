using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebAPI.Application.Features.Commands.QuizCommands.CreateQuiz;
using QuizWebAPI.Application.Features.Queries.QuizQueries.GetQuizzes;

namespace QuizWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        readonly IMediator mediator;

        public QuizzesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("create-quiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("get-quizzes")]
        public async Task<IActionResult> GetQuizzes([FromQuery] GetQuizzesQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
