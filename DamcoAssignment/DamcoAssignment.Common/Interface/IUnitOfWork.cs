using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IUsersRepository users { get; }
        IContentRepository contentRepository { get; }
      
        int Complete();
    }
}
