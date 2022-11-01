//using DamcoAssignment.Common.Interface;
//using DamcoAssignment.Common.Models;
using DamcoAssignment.Common.Interface;
using DamcoAssignment.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Damco.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenRepository _tokenService;
        public TokenController(IUnitOfWork unitOfWork, ITokenRepository tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(AuthenticatedResponse tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");
            string accessToken = tokenApiModel.Token;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default
            User u = new User();
            var user = _unitOfWork.users.GetByParam(u);
            if (user is null || user.Token != refreshToken || user.ExpiryTime <= DateTime.Now)
                return BadRequest("Invalid client request");
            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.Token = newRefreshToken;
            _unitOfWork.Complete();
            return Ok(new AuthenticatedResponse()
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }
    }
}
