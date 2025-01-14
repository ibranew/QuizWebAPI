﻿using QuizWebAPI.Application.DTOs.QuizDTOs;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Services.EntityServices
{
    public interface IQuizService : IBaseEntityService
    {
        Task<bool> AddQuizAsync(string title, string description);
        Task<(bool isSuccess, int count, List<QuizDTO> quizzes)> GetQuizzesWithTotalCountAsync(int size, int page, string query);
        Task<List<QuizDTO>> GetQuizzesByQueryAsync(string query);
        Task<bool> DeleteQuizAsync(string id);
        Task<bool> EditQuizAsync(QuizDTO quiz);
        Task<Quiz> GetQuizById(Guid id);

    }
}
