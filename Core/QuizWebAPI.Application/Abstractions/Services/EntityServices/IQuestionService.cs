using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Services.EntityServices
{
    public interface IQuestionService : IBaseEntityService
    {
        Task<Question> CreateQuestionAsync(string text);
        Task<bool> AddQuestionToQuizAsync(Question question, string quizId);
        Task<bool> AddQuestionToQuizAsync(List<Question> questions, string quizId);
    }
}
