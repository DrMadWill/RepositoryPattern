using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Abstract.Commons
{
    public interface IReadAccess<T>
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
    }
}
