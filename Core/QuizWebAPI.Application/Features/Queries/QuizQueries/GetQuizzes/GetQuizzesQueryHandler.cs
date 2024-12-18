using MediatR;
using QuizWebAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Queries.QuizQueries.GetQuizzes
{
    public class GetQuizzesQueryHandler : IRequestHandler<GetQuizzesQueryRequest, GetQuizzesQueryResponse>
    {
        readonly IQuizService _quizService;

        public GetQuizzesQueryHandler(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task<GetQuizzesQueryResponse> Handle(GetQuizzesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _quizService.GetQuizzesWithTotalCountAsync(request.Size, request.Page, request.Query);

            string responseMessage = string.Empty;
            if (!result.isSuccess)
            {
                responseMessage = "Veriler çekilemedi";
            }

            return new()
            {
                Succeed = result.isSuccess,
                TotalCount = result.count,
                Quizzes = result.quizzes,
                ResponseMessage = responseMessage

            };

        }
    }
}
