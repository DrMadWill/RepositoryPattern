using Student.Business.Abstract.Commons;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Abstract
{
    public interface IFamilyService:IReadAccess<Family>,IDataChangeAccess<Family>
    {
        Task<bool> IsAddedCode(string code);

        Task<bool> IsFounded(int id);

    }
}
