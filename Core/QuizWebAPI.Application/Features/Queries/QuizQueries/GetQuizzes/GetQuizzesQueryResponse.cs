using QuizWebAPI.Application.DTOs.QuizDTOs;
using QuizWebAPI.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Queries.QuizQueries.GetQuizzes
{
    public class GetQuizzesQueryResponse : BaseResponse
    {
        public int TotalCount { get; set; }
        public List<QuizDTO> Quizzes { get; set; } = new();
    }
}
