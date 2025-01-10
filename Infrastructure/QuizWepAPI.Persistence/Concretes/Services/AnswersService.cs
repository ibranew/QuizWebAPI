using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWebAPI.Application.DTOs.AnswerDTOs;
using QuizWepAPI.Domain.Entities;
using QuizWepAPI.Persistence.Concretes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizWebAPI.Application.Abstractions.Services.EntityServices;

namespace QuizWepAPI.Persistence.Concretes.Services
{
    public class AnswersService : IAnswersService
    {
        readonly IAnswerRepository _answerRepository;
        readonly IQuestionRepository _questionRepository;

        public AnswersService(
            IAnswerRepository answerRepository, 
            IQuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public async Task<bool> AddAnswerToQuestionAsync(Answer answer, Guid questionId)
        {
            if (answer == null)
            {
                throw new ArgumentException("", nameof(answer));
                
            }
            answer.QuestionId = questionId;
           
            //todo bak
            return true;
        }

        public async Task<bool> AddAnswerToQuestionAsync(List<Answer> answers, Guid questionId)
        {
                     
            if (answers == null || !answers.Any())
            {
                throw new ArgumentException("Answers list cannot be null or empty.", nameof(answers));
            }
            try
            {               
                answers.ForEach(answer => answer.QuestionId = questionId);
                return true;//todo bak
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<Answer> CreateAnswerAsync(string text, bool correct)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("text bos olamaz", nameof(text));
            }

            try
            {
                Answer answer = new Answer
                {
                    Text = text,
                    Correct = correct
                };

                await _answerRepository.AddAsync(answer);
                return answer;
            }
            catch (Exception ex)
            {
                //todo log
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new Exception("An error occurred while creating the answer.", ex);
            }
        }


        public async Task<List<Answer>?> CreateAnswerAsync(List<AnswerDTO> list)
        {
            if (list == null || !list.Any())
            {
                return null;
            }

            try
            {
              
                List<Answer> answerList = list.Select(answerDto => new Answer
                {
                    Text = answerDto.Text,
                    Correct = answerDto.IsCorrect
                }).ToList();

             
                await _answerRepository.AddRangeAsync(answerList);
              
                return answerList;
            }
            catch (Exception ex)
            {
                // Hataları loglama veya yönetme
                Console.WriteLine($"Error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> SaveDatabaseChangesAsync()
        {
            int r = await _answerRepository.SaveChangesAsync();
            return r > 0;
        }

    }
}
