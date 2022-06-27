using Student.DataAccess.Abstract.Communs;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract
{
    public interface IFamilyRepository: IBaseRepostitory<Family>
    {
        Task<Family> GetFamilyByCode(string code);

        Task<bool> IsAddedCode(string code);

        Task<bool> IsFounded(int id);
    }
}
