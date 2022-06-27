using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract.Communs
{
    public interface IBaseRepostitory<T>: IChangeAccess<T>, IReadAccess<T>
    {
        Task Commit();
    }
}
