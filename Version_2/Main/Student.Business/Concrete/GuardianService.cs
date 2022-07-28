using Student.Business.Abstract;
using Student.DataAccess.Abstract;
using Student.Entity.Student;

namespace Student.Business.Concrete
{
    public class GuardianService : IGuardianService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuardianService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guardian> Add(Guardian entity)
        {
            await _unitOfWork.GuardianRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<Guardian> Delete(int id)
        {
            if (id > 0)
            {
                var family = await _unitOfWork.GuardianRepository.GetFrist(x => x.Id == id);
                if (family == null) return null;
                await _unitOfWork.GuardianRepository.Delete(family);
                await _unitOfWork.Commit();
            }
            return null;
        }

        public async Task<List<Guardian>> GetAll()
        {
            return await _unitOfWork.GuardianRepository.GetAllList();
        }

        public async Task<Guardian> GetFrist(int id)
        {
            var upEntity = await _unitOfWork.GuardianRepository.GetFrist(x => x.Id == id);
            await _unitOfWork.Commit();
            return upEntity;
        }

        public async Task<Guardian> Update(Guardian entity)
        {
            return await _unitOfWork.GuardianRepository.Update(entity);
        }

        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element = await _unitOfWork.GuardianRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }
    }
}