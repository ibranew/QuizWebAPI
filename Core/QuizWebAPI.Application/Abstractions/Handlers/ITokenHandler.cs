using QuizWepAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Handlers
{
    public interface ITokenHandler
    {
        DTOs.Token CreateToken(int lifeTimeMinute, AppUser user);
    }
}
