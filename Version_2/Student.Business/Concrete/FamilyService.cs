using Student.Business.Abstract;
using Student.DataAccess.Abstract;
using Student.Entity.Student;

namespace Student.Business.Concrete
{
    public class FamilyService : IFamiliesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FamilyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Family> Add(Family entity)
        {
            await _unitOfWork.FamilyRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<Family> Delete(int id)
        {
            if (id > 0)
            {
                var family = await _unitOfWork.FamilyRepository.GetFrist(x => x.Id == id);
                if (family == null) return null;
                await _unitOfWork.FamilyRepository.Delete(family);
                await _unitOfWork.Commit();
            }
            return null;
        }

        public async Task<List<Family>> GetAll()
        {
            return await _unitOfWork.FamilyRepository.GetAllList();
        }

        public async Task<Family> GetFrist(int id)
        {
            return await _unitOfWork.FamilyRepository.GetFrist(x => x.Id == id);
        }

        public async Task<Family> Update(Family entity)
        {
            var upEntity = await _unitOfWork.FamilyRepository.Update(entity);
            await _unitOfWork.Commit();
            return upEntity;
        }

        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element = await _unitOfWork.FamilyRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }

        public async Task<bool> IsAlreadyAddedCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return false;
            var element = await _unitOfWork.FamilyRepository.Count(x => x.Code.ToLower() == code.ToLower());
            if (element == 0) return false;
            else return true;
        }
    }
}