using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuizCommands.CreateQuiz
{
    public class CreateQuizCommandRequest : IRequest<CreateQuizCommandResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
