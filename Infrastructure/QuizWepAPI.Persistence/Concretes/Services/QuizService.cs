using Microsoft.EntityFrameworkCore;
using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWebAPI.Application.DTOs.QuizDTOs;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Persistence.Concretes.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;

        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddQuizAsync(string title, string description)
        {
            Quiz quiz = new Quiz()
            {
                Title = title,
                Description = description
            };
            await _repository.AddAsync(quiz);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
        private async Task<int> GetQuizzesCountByQuery(string query)
        {
            return await _repository.Table
                .Where(q => q.Title.StartsWith(query))
                .CountAsync();
        }
        public async Task<List<QuizDTO>> GetQuizzesByQueryAsync(string query)
        {
            return await _repository.Table
                .Where(q => q.Title.StartsWith(query))
                .Select(q => new QuizDTO
                {
                    Id = q.Id.ToString(),
                    Title = q.Title,
                    Description = q.Description
                })
                .ToListAsync();
        }
        private async Task<List<QuizDTO>> GetQuizzesPagedAsync(int size, int page, string query)
        {
            return await _repository.Table
                .Where(q => q.Title.StartsWith(query))
                .Skip((page - 1) * size)
                .Take(size)
                .Select(q => new QuizDTO
                {
                    Id = q.Id.ToString(),
                    Title = q.Title,
                    Description = q.Description
                })
                .ToListAsync();
        }
        public async Task<(bool isSuccess, int count, List<QuizDTO> quizzes)> GetQuizzesWithTotalCountAsync(int size, int page, string query)
        {
            try
            {
                var count = await GetQuizzesCountByQuery(query);
                var quizzes = await GetQuizzesPagedAsync(size, page, query);
                // Eğer başarıyla sonuç dönerse
                return (true, count, quizzes);
            }
            catch (Exception ex)
            {
                // Loglama işlemi yapılabilir
                Console.WriteLine($"Error: {ex.Message}");
                // Başarısız durumda false ve varsayılan değerler
                return (false, 0, new List<QuizDTO>());
            }
        }

        public async Task<bool> DeleteQuizAsync(string id)
        {
            Quiz quiz = await _repository.GetByIdAsync(Guid.Parse(id));
            _repository.Delete(quiz);
            return 0 < await _repository.SaveChangesAsync();//1 true 0 false
        }
    }
}
