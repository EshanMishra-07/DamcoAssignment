//using DamcoAssignment.Common.Interface;
//using DamcoAssignment.Common.Models;
//using DamcoAssignment.Common.ViewModel;
using DamcoAssignment.Common.Interface;
using DamcoAssignment.Common.Models;
using DamcoAssignment.Common.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Damco.Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("AddUsers")]
        public IActionResult AddUsers(ViewModelUser viewModelUser)
        {
            User user = new User();
            user.UserName = viewModelUser.UserName;
            user.Password = viewModelUser.Password;
            user.Email = viewModelUser.Email;
            user.Roles = viewModelUser.Roles;
            user.IsActive = viewModelUser.IsActive;
            user.Token = viewModelUser.Token;
            user.Doc = viewModelUser.Doc ?? DateTime.Now;
            _unitOfWork.users.Add(user);
        
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
