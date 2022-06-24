using Student.Entity.Student;
using Student.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class GuardianTypeRepository:EfBaseRepository<GuardianType,StudentDbContext>,IGuardianTypeRepository
    {
        public GuardianTypeRepository(StudentDbContext context) : base(context) { }
    }
}
