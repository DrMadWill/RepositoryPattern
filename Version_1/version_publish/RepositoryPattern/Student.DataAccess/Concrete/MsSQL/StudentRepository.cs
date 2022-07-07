using System;
using System.Collections.Generic;
using System.Linq;
using Student.Entity.Student;
using Student.DataAccess.Abstract;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class StudentRepository:EfBaseRepository<Entity.Student.Student,StudentDbContext>,IStudentRepository
    {
        public StudentRepository(StudentDbContext context) : base(context) { }

        public async Task<bool> IsFounded(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null) return true;
            return false;

        }
    }
}
