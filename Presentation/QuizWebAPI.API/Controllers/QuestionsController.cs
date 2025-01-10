using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebAPI.Application.Features.Commands.QuestionCommands.AddQuestion;

namespace QuizWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly IMediator mediator;

        public QuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-question")]
        public async Task<IActionResult> CreateQuestionAndAddToQuiz(AddQuestionCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
