using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract.Communs
{
    public interface IChangeAccess<T>
    {
        Task<T> Create(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(T Entity);
    }
}
