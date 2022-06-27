using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract.Communs
{
    public interface IReadAccess<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }
}
