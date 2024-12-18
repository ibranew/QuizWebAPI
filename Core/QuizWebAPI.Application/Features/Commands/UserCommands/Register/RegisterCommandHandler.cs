using MediatR;
using Microsoft.AspNetCore.Identity;
using QuizWepAPI.Domain.Entities.Identity;

namespace QuizWebAPI.Application.Features.Commands.UserCommands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            //todo default exception
            RegisterCommandResponse response = new();
            // null kontrol
            if (request.User is null || request is null)
            {
                response.ResponseMessage = "Boş form";
                return response;

            }
            // şifreler aynı değilse
            if (!request.User.Password.Equals(request.User.ConfirmPassword))
            {
                response.ResponseMessage = "Şifreler eşleşmiyor";
                return response;
            }

            var result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.User.UserName,
                Name = request.User.Name,
                Surname = request.User.SurName,

                Email = request.User.Email,
            },request.User.Password);

            response.Succeed = result.Succeeded;

            if (response.Succeed)
                response.ResponseMessage = "Kaydolma işlemi başarılı";
            else
                foreach (var error in result.Errors)
                    response.ResponseMessage += $"Hata kodu :{error.Code}\nAçıklama :{error.Description}\n";

            return response;
        }
    }
}
