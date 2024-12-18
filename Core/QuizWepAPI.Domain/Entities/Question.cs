using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public ICollection<Answer> Answers { get; set; } = new List<Answer>(); // Cevaplarla ilişkisi
        public bool IsDeleted { get; set; } = false;
        public Quiz? Quiz { get; set; }
        public Guid QuizId { get; set; }
    }
}
