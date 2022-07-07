using Student.DataAccess.Abstract;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class AddressRepository:EfBaseRepository<Address,StudentDbContext>,IAddressRepository
    {
        public AddressRepository(StudentDbContext context) : base(context) { }

    }
}
