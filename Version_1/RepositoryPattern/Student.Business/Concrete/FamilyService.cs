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
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;

        public FamilyService(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        public async Task<Family> Create(Family entity)
        {
           
            if (await _familyRepository.IsAddedCode(entity.Code)) return null;

            try
            {
                entity.CreateAt = DateTime.Now;
                await _familyRepository.Create(entity);
                await _familyRepository.Commit();
            }
            catch
            {
                 entity = null;
            }

            return entity;
        }

        public async Task<Family> Delete(Family entity)
        {
            var family = await _familyRepository.Get(entity.Id);
            await _familyRepository.Delete(family);
            await _familyRepository.Commit();
            return family;
        }

        public async Task<Family> Get(int id)
        {
            if(id == 0) return null;
            Family family;
            try
            {
                family = await _familyRepository.Get(id);
            }
            catch
            {
                family = null;
            }
            return family;
        }

        public async Task<List<Family>> GetAll()
        {
            var families = await _familyRepository.GetAll();
            return families;
        }

        public async Task<bool> IsAddedCode(string code)
        {
            return await _familyRepository.IsAddedCode(code);
        }

        public async Task<bool> IsFounded(int id)
        {
            return await _familyRepository.IsFounded(id);
        }

        public async Task<Family> Update(Family entity)
        {
            if (entity.Id == 0) return (entity = null);

            if (await _familyRepository.IsAddedCode(entity.Code)) return null;

            await _familyRepository.Update(entity);
            await _familyRepository.Commit();

            return entity;
        }
    }
}
