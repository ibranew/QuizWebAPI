using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; } = string.Empty; // Quiz başlığı
        public string Description { get; set; } = string.Empty; // Quiz başlığı
        public ICollection<Question> Questions { get; set; } = new List<Question>(); // Sorularla ilişkili
    }
}
