using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuizCommands.DeleteQuiz
{
    public class DeleteQuizCommandRequest : IRequest<DeleteQuizCommandResponse>
    {
        public string? Id { get; set; }
    }
}
