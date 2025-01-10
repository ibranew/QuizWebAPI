using MediatR;
using QuizWebAPI.Application.Abstractions.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuizCommands.EditQuiz
{
    public class EditQuizCommandHandler : IRequestHandler<EditQuizCommandRequest, EditQuizCommandResponse>
    {
        readonly IQuizService _quizService;

        public EditQuizCommandHandler(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task<EditQuizCommandResponse> Handle(EditQuizCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _quizService.EditQuizAsync(request.Quiz);

            if(result)
                return new() { Succeed = true , ResponseMessage = "Quiz editlendi"};
            else
                return new() { ResponseMessage = "Quiz editlenmedi" };

        }
    }
}
