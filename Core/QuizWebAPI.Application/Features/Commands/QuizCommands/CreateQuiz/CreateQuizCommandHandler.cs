using MediatR;
using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuizCommands.CreateQuiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommandRequest, CreateQuizCommandResponse>
    {
        readonly IQuizService _quizService;

        public CreateQuizCommandHandler(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task<CreateQuizCommandResponse> Handle(CreateQuizCommandRequest? request, CancellationToken cancellationToken)
        {
            if ((request is null) || string.IsNullOrEmpty(request.Title))
            {
                return new() { Succeed = false ,ResponseMessage = "Başlık boş olmaMAlı" };
            }
            bool result = await _quizService.AddQuizAsync(request.Title, request.Description);
            return new() { Succeed = result,ResponseMessage = "Quiz Eklendi" };
        }
    }
}
