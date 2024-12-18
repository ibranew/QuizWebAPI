using MediatR;
using QuizWebAPI.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.UserCommands.Register
{
    public class RegisterCommandRequest :IRequest<RegisterCommandResponse>
    {
        public UserDTO? User { get; set; }
    }
}
