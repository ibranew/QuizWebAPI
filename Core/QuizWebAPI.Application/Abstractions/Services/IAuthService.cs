using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<DTOs.Token?> LoginAsync(string username, string password, int accessTokenLifeTimeMinute);
    }
}
