using Microsoft.EntityFrameworkCore;
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

        public async Task<Family> GetFamilyByCode(string code)
        {
            if(string.IsNullOrEmpty(code)) return null;
            var family = await _context.Families.FirstOrDefaultAsync(x => x.Code == code);
            return family;
        }

        public async Task<bool> IsAddedCode(string code)
        {
            var family = await GetFamilyByCode(code);
            if(family != null) return true;
            return false;
        }

        public async Task<bool> IsFounded(int id)
        {
            var family = await _context.Families.FirstOrDefaultAsync(x => x.Id == id);
            if(family != null) return true;
            return false;
        }
    }
}
