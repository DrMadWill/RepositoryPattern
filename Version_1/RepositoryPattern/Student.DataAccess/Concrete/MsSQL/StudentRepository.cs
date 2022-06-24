using System;
using System.Collections.Generic;
using System.Linq;
using Student.Entity.Student;
using Student.DataAccess.Abstract;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class StudentRepository:EfBaseRepository<Entity.Student.Student,StudentDbContext>,IStudentRepository
    {
        public StudentRepository(StudentDbContext context) : base(context) { }

    }
}
