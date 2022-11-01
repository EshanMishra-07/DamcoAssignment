
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Claims;
using DamcoAssignment.Common.Models;
using DamcoAssignment.Common.ViewModel;
using DamcoAssignment.Common.Interface;

namespace Damco.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenRepository _tokenService;
        public AuthController(IUnitOfWork unitOfWork, ITokenRepository tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._tokenService = tokenService;
        }
        [HttpPost, Route("login")]
        public IActionResult Login(ViewModelUser loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request");
            }

            User user = new User();

            user = _unitOfWork.users.Find(a => a.Email == loginModel.Email && a.Password == loginModel.Password).FirstOrDefault(); ;



            if (user is null)
                return Unauthorized();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Roles)
        };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.Token = refreshToken;
            user.ExpiryTime = DateTime.Now.AddDays(7);
            _unitOfWork.Complete();
            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }


    }
}
