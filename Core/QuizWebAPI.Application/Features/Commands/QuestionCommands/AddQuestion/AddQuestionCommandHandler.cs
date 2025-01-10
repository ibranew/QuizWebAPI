using MediatR;
using QuizWebAPI.Application.Abstractions.Services.EntityServices;
using QuizWebAPI.Application.DTOs.AnswerDTOs;
using QuizWebAPI.Application.DTOs.QuestionDTOs;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Commands.QuestionCommands.AddQuestion
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommandRequest, AddQuestionCommandResponse>
    {
        readonly IQuestionService _questionService;
        private readonly IAnswersService _answersService;
        private readonly IQuizService _quizService;

        public AddQuestionCommandHandler(
            IQuestionService questionService, 
            IAnswersService answersService, 
            IQuizService quizService)
        {
            _questionService = questionService;
            _answersService = answersService;
            _quizService = quizService;
        }

        public async Task<AddQuestionCommandResponse> Handle(AddQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var questionDTO = request.Question;

            if (questionDTO == null) 
            {
                return new()
                {
                    Succeed = false,
                    ResponseMessage = "Cevaplar bulunamadı"
                };
            }

            Question question = await _questionService.CreateQuestionAsync(questionDTO.QuestionText);
            bool result = await _questionService.AddQuestionToQuizAsync(question, request.QuizId);

            List<Answer>? answers = await _answersService.CreateAnswerAsync(questionDTO.Answers);
            if (answers is null)
                return new()
                {
                    Succeed = false,
                    ResponseMessage = "Cevaplar bulunamadı"
                };

            bool result2 = await _answersService.AddAnswerToQuestionAsync(answers, question.Id);

            if (!result || !result2)
                return new()
                {
                    Succeed = false,
                    ResponseMessage = "Hata var"
                };


            bool result3 =  await _quizService.SaveDatabaseChangesAsync();

            return result3 ? new()
            {
                Succeed = true,
                ResponseMessage = "eklendi"
            } : new() 
            { 
                Succeed = false,
                ResponseMessage = "Hata"
            };


        }
    }
}
