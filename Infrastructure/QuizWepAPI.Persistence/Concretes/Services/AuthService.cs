using Microsoft.AspNetCore.Identity;
using QuizWebAPI.Application.Abstractions.Handlers;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWebAPI.Application.DTOs;
using QuizWepAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Persistence.Concretes.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }



        public async Task<Token?> LoginAsync(string username, string password, int accessTokenLifeTimeMinute)
        {
            AppUser? user = await _userManager.FindByNameAsync(username);

            if (user is null)
                return null;

            //sondaki false yanlış değerlerde kitlenmesini devre dışı bıraktık
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
                return _tokenHandler.CreateToken(accessTokenLifeTimeMinute, user);

            return null;
        }
    }
}
