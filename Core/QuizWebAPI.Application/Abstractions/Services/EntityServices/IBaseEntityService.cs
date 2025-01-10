using QuizWebAPI.Application.DTOs.QuestionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Services.EntityServices
{
    public interface IBaseEntityService
    {
        Task<bool> SaveDatabaseChangesAsync();
    }
}
