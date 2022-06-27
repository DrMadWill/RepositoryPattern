using System;
using Student.Entity.Student;
using Student.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class GuardianRepository:EfBaseRepository<Guardian,StudentDbContext>,IGuardianRepository
    {
        public GuardianRepository(StudentDbContext context) : base(context) { }

        public async Task<bool> IsFounded(int id)
        {
            var guardian = await _context.Guardians
                .FirstOrDefaultAsync(x => x.Id == id);
            if (guardian != null) return true;
            return false;
        }
    }
}
