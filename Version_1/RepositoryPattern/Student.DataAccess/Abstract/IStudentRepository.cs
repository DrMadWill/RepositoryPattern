using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DataAccess.Abstract.Communs;
using Student.Entity.Student;

namespace Student.DataAccess.Abstract
{
    public interface IStudentRepository : IBaseRepostitory<Entity.Student.Student>
    {
        Task<bool> IsFounded(int id);

    }
}
