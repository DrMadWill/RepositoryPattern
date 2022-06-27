using Student.Entity.Student;
using Student.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class GuardianTypeRepository:EfBaseRepository<GuardianType,StudentDbContext>,IGuardianTypeRepository
    {
        public GuardianTypeRepository(StudentDbContext context) : base(context) { }

        public async Task<bool> IsFounded(int id)
        {
            var guardianType = await _context.Guardians.FirstOrDefaultAsync(x => x.Id == id);
            if(guardianType != null) return true;
            return false; 
        }
    }
}
