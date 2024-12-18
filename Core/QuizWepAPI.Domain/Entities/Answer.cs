using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public bool Correct { get; set; }
        public Question? Question { get; set; } // Soru ile ilişkisi
        public Guid QuestionId { get; set; }
    }
}
