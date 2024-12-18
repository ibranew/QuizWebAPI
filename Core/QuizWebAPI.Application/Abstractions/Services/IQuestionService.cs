using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<bool> AddQuestionAsync(Question question);
    }
}
