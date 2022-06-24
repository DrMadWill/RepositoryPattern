using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract
{
    public interface IBaseRepostitory<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(T Entity);
        Task Commit();
        
    }
}
