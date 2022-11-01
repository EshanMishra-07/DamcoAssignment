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
using System.Collections.Generic;
using System.Linq;

namespace Damco.Content.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "Creator")]
    public class ContentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("AddContent")]
        public IActionResult AddContent(ViewModelContent viewModelUser)
        {
            ContentBlog blog = new ContentBlog();
            blog.Title = viewModelUser.Title;
            blog.BlogContent = viewModelUser.BlogContent;
            blog.Title = viewModelUser.Title;
            blog.Template = viewModelUser.Template;
            //  blog.Title = viewModelUser.Title;
            blog.Topic = viewModelUser.Topic;
            blog.IsDeleted = viewModelUser.IsDeleted;
            blog.UserId = viewModelUser.UserId;
            blog.Doc=viewModelUser.Doc??DateTime.Now;   
            _unitOfWork.contentRepository.Add(blog);
            // _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("UpdateContent")]
        public IActionResult UpdateContent(ViewModelContent viewModelUser)
        {
            ContentBlog blog = new ContentBlog();
            blog.Title = viewModelUser.Title;
            blog.BlogContent = viewModelUser.BlogContent;
            blog.Title = viewModelUser.Title;
            blog.Template = viewModelUser.Template;
            //  blog.Title = viewModelUser.Title;
            blog.Topic = viewModelUser.Topic;
            blog.ContentId = viewModelUser.ContentId;
            blog.IsDeleted = viewModelUser.IsDeleted;
            blog.UserId = viewModelUser.UserId;
            blog.Doc = viewModelUser.Doc ?? DateTime.Now;
            _unitOfWork.contentRepository.Update(blog);
            // _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("DeleteContent")]
        public IActionResult DeleteContent(ViewModelContent viewModelUser)
        {
            ContentBlog blog = new ContentBlog();

            blog.ContentId = viewModelUser.ContentId;
            blog.IsDeleted = viewModelUser.IsDeleted;
            blog.UserId = viewModelUser.UserId;
            blog.Dod = viewModelUser.Dod ?? DateTime.Now;
            _unitOfWork.contentRepository.Update(blog);
            // _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("GetAllContent")]
        public IActionResult GetAllContent()
        {

            var contents = _unitOfWork.contentRepository.GetAll();
            var user = _unitOfWork.users.GetAll();
            List<ViewModelContentUserwise> list = (from c in contents
                                                   join u in user
                                                   on c.UserId equals u.UserId
                                                   where c.IsDeleted == false
                                                   select new ViewModelContentUserwise
                                                   {
                                                       Title = c.Title,
                                                       UserId = c.UserId,
                                                       UserName = u.UserName,
                                                       ContentId = c.ContentId,
                                                       IsDeleted = c.IsDeleted

                                                   }).ToList();


            return Ok(list);
        }
    }
}
