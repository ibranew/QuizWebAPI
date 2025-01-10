using MediatR;
using QuizWebAPI.Application.DTOs.QuizDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuizCommands.EditQuiz
{
    public class EditQuizCommandRequest : IRequest<EditQuizCommandResponse>
    {
        public QuizDTO Quiz { get; set; }
    }
}
