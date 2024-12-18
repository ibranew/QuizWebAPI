using MediatR;
using Microsoft.AspNetCore.Identity;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWepAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.UserCommands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        readonly IAuthService authService;

        public LoginCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            int minute = 3;
            DTOs.Token? token = await authService.LoginAsync(request.UserName,request.Password,minute);

            if (token is not null)
                return new(){ Token = token ,Succeed = true,ResponseMessage = "Giriş yapıldı" };

            return new() {ResponseMessage = "Giriş başarısız" }; ;
        }
    }
}
