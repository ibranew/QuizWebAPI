using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWebAPI.Application.Abstractions.Services.EntityServices;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Persistence.Concretes.Services
{
    public class QuestionService : IQuestionService
    {
        readonly IQuestionRepository _questionRepository;
        readonly IQuizRepository _quizRepository;

        public QuestionService(IQuestionRepository questionRepository, IQuizRepository quizRepository)
        {
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
        }

        public async Task<bool> AddQuestionToQuizAsync(Question question, string quizId)
        {
            Quiz q = await _quizRepository.GetByIdAsync(Guid.Parse(quizId));
            if(q is null)
                return false;
            
            question.QuizId = Guid.Parse(quizId);
          
            return true;//todo bak
        }

        public async Task<bool> AddQuestionToQuizAsync(List<Question> questions, string quizId)
        {
            Quiz q = await _quizRepository.GetByIdAsync(Guid.Parse(quizId));
            if (q is null)
                return false;

            foreach (var question in questions)
            {
                question.QuizId = Guid.Parse(quizId);
            }
            return true;//todo bak
        }

        public async Task<Question> CreateQuestionAsync(string text)
        {
            Question question = new Question();
            question.Text = text;
            await _questionRepository.AddAsync(question);
            return question;
        }

        public async Task<bool> SaveDatabaseChangesAsync()
        {
            int r = await _quizRepository.SaveChangesAsync();
            return  r > 0;
        }
    }
}
