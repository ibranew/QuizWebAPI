using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebAPI.Application.Features.Commands.QuizCommands.CreateQuiz;
using QuizWebAPI.Application.Features.Commands.QuizCommands.DeleteQuiz;
using QuizWebAPI.Application.Features.Commands.QuizCommands.EditQuiz;
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
            //https://localhost:7039/api/Quizzes/get-quizzes
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteQuizCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPut()]
        public async Task<IActionResult> Edit([FromBody] EditQuizCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
