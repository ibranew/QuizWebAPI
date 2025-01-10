using QuizWebAPI.Application.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.DTOs.QuestionDTOs
{
    public class QuestionDTO
    {
        public string QuestionText { get; set; } = string.Empty;
        public List<AnswerDTO> Answers { get; set; } = new();
    }
}
