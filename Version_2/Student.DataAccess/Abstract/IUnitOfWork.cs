using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        public IBaseRepostitory<Entity.Student.Student,int> StudentRepository { get; set; }
        public IBaseRepostitory<Family,int> FamilyRepository { get; set; }
        public IBaseRepostitory<Guardian,int> GuardianRepository { get; set; }
        public IBaseRepostitory<GuardianType,int> GuardianTypeRepository { get; set; }
        public IBaseRepostitory<Address,int> AddressRepository { get; set; }

        public Task Commit();
    }

}
