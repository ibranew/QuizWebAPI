using MediatR;
using QuizWebAPI.Application.DTOs.QuestionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuestionCommands.AddQuestion
{
    public class AddQuestionCommandRequest : IRequest<AddQuestionCommandResponse>
    {
        public string QuizId { get; set; } = string.Empty;
        public QuestionDTO? Question { get; set; }
    }
}
