using QuizWebAPI.Application.DTOs;
using QuizWebAPI.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.UserCommands.Login
{
    public class LoginCommandResponse : BaseResponse
    {
        public Token? Token { get; set; }
    }
}
