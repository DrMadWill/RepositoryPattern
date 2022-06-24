using Student.DataAccess.Abstract;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class FamilyRepository : EfBaseRepository<Family,StudentDbContext>,IFamilyRepository
    {
        public FamilyRepository(StudentDbContext context) : base(context) { }
    }
}
