using Student.Business.Abstract.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Abstract
{
    public interface IStudentService:IReadAccess<Entity.Student.Student>,IDataChangeAccess<Entity.Student.Student>
    {
        Task<bool> IsFounded(int id);
    }
}
