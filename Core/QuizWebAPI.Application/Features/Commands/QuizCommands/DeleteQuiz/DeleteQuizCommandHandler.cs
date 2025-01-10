using MediatR;
using QuizWebAPI.Application.Abstractions.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuizCommands.DeleteQuiz
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommandRequest, DeleteQuizCommandResponse>
    {
        readonly  IQuizService _service;

        public DeleteQuizCommandHandler(IQuizService service)
        {
            _service = service;
        }

        public async Task<DeleteQuizCommandResponse> Handle(DeleteQuizCommandRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
                return new() { ResponseMessage = "Bulunamadı" };

            bool result =  await _service.DeleteQuizAsync(request.Id);

            if (result)
            {
                return new() {Succeed = result, ResponseMessage = "Silindi" };
            }
            else
            {
                return new() { Succeed = result, ResponseMessage = "Silinemedi" };
            }

        }
    }
}
