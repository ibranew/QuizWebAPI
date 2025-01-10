using QuizWebAPI.Application.DTOs.AnswerDTOs;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Services.EntityServices
{
    public interface IAnswersService : IBaseEntityService
    {
        Task<Answer> CreateAnswerAsync(string text, bool correct);
        Task<List<Answer>?> CreateAnswerAsync(List<AnswerDTO> list);
        Task<bool> AddAnswerToQuestionAsync(Answer answer, Guid questionId);
        Task<bool> AddAnswerToQuestionAsync(List<Answer> answers, Guid questionId);
    }
}
