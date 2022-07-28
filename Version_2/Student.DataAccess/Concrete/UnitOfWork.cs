using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete.MsSql;
using Student.Entity.Student;

namespace Student.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        // Lazy Loading Repository
        private IBaseRepostitory<Entity.Student.Student, int> _studentRepository;

        public IBaseRepostitory<Entity.Student.Student, int> StudentRepository
        {
            get => RepositoryBuilder<Entity.Student.Student, int>.Builder(_studentRepository, _dbContext);
            set => StudentRepository = value;
        }

        private IBaseRepostitory<Family, int> _familyRepository;

        public IBaseRepostitory<Family, int> FamilyRepository
        {
            get => RepositoryBuilder<Family, int>.Builder(_familyRepository, _dbContext);
            set => FamilyRepository = value;
        }

        private IBaseRepostitory<Guardian, int> _guardianRepository;

        public IBaseRepostitory<Guardian, int> GuardianRepository
        {
            get => RepositoryBuilder<Guardian, int>.Builder(_guardianRepository, _dbContext);
            set => GuardianRepository = value;
        }

        private IBaseRepostitory<GuardianType, int> _guardianTypeRepository;

        public IBaseRepostitory<GuardianType, int> GuardianTypeRepository
        {
            get => RepositoryBuilder<GuardianType, int>.Builder(_guardianTypeRepository, _dbContext);
            set => GuardianTypeRepository = value;
        }

        private IBaseRepostitory<Address, int> _addressRepository;

        public IBaseRepostitory<Address, int> AddressRepository
        {
            get => RepositoryBuilder<Address, int>.Builder(_addressRepository, _dbContext);
            set => AddressRepository = value;
        }

        private readonly StudentDbContext _dbContext;

        public UnitOfWork(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}