using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Queries.QuizQueries.GetQuizzes
{
    public class GetQuizzesQueryRequest : IRequest<GetQuizzesQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Query { get; set; } = string.Empty;
    }
}
