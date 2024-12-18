using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWepAPI.Domain.Entities;
using QuizWepAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Persistence.Concretes.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuizWebAPIDbContext context):base(context)
        {
            
        }
    }
}
