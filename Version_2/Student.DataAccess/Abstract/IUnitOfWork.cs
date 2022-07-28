using Student.Entity.Student;

namespace Student.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        public IBaseRepostitory<Entity.Student.Student, int> StudentRepository { get; set; }
        public IBaseRepostitory<Family, int> FamilyRepository { get; set; }
        public IBaseRepostitory<Guardian, int> GuardianRepository { get; set; }
        public IBaseRepostitory<GuardianType, int> GuardianTypeRepository { get; set; }
        public IBaseRepostitory<Address, int> AddressRepository { get; set; }

        public Task Commit();
    }
}