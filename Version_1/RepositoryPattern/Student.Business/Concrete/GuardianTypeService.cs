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
    public class GuardianTypeService : IGuardianTypeService
    {
        private readonly IGuardianTypeRepository _guardianTypeRepository;
        public GuardianTypeService(IGuardianTypeRepository guardianTypeRepository)
        {
            _guardianTypeRepository = guardianTypeRepository;
        }

        public async Task<GuardianType> Get(int id)
        {
            if (id == 0) return null;

            var guardianType = await _guardianTypeRepository.Get(id);
            if (guardianType == null) return null;
            return guardianType;
        }

        public async Task<List<GuardianType>> GetAll()
        {
            return await _guardianTypeRepository.GetAll();
        }

        public async Task<GuardianType> Create(GuardianType entity)
        {
            try
            {
                await _guardianTypeRepository.Create(entity);
                await _guardianTypeRepository.Commit();

            }
            catch
            {

                entity = null;
            }
            return entity;
        }

        public async Task<GuardianType> Update(GuardianType entity)
        {

            try
            {
                await _guardianTypeRepository.Update(entity);
                await _guardianTypeRepository.Commit();

            }
            catch
            {

                entity = null;
            }
            return entity;

        }

        public async Task<GuardianType> Delete(GuardianType entity)
        {
            try
            {
                await _guardianTypeRepository.Delete(entity);
                await _guardianTypeRepository.Commit();

            }
            catch
            {

                entity = null;
            }
            return entity;
        }

    }
}
