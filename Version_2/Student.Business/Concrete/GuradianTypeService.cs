using Student.Business.Abstract;
using Student.DataAccess.Abstract;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Concrete
{
    public class GuradianTypeService : IGuradianTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GuradianTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GuardianType> Add(GuardianType entity)
        {
            await _unitOfWork.GuardianTypeRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<GuardianType> Delete(int id)
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

        public async Task<List<GuardianType>> GetAll()
        {
            return await _unitOfWork.GuardianTypeRepository.GetAllList();
        }

        public async Task<GuardianType> GetFrist(int id)
        {
            return await _unitOfWork.GuardianTypeRepository.GetFrist(x => x.Id == id);
        }

        public async Task<GuardianType> Update(GuardianType entity)
        {
            var upEntity = await _unitOfWork.GuardianTypeRepository.Update(entity);
            await _unitOfWork.Commit();
            return upEntity;
        }
        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element = await _unitOfWork.GuardianTypeRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }
    }
}
