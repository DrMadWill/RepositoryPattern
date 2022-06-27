using System;
using Student.Entity.Student;
using Student.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class GuardianRepository:EfBaseRepository<Guardian,StudentDbContext>,IGuardianRepository
    {
        public GuardianRepository(StudentDbContext context) : base(context) { }
        
    }
}
