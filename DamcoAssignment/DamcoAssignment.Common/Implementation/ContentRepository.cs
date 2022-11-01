using DamcoAssignment.Common.Interface;
using DamcoAssignment.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.Implementation
{
    public class ContentRepository: Repository<ContentBlog>, IContentRepository
    {
        public ContentRepository(DamcoPocContext context) : base(context)
        {

        }
       
    }
}
