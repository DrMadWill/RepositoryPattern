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
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;
        public GuardianService(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }
        public async Task<Guardian> Create(Guardian entity)
        {
            try
            {
                await _guardianRepository.Create(entity);
                await _guardianRepository.Commit();
            }
            catch 
            {
                entity = null;
            }

            return entity;
        }

        public async Task<Guardian> Delete(Guardian entity)
        {
            try
            {
                await _guardianRepository.Delete(entity);
                await _guardianRepository.Commit();
            }
            catch 
            {
                entity = null;
            }

            return entity;
        }

        public async Task<Guardian> Get(int id)
        {
            return await _guardianRepository.Get(id);
        }

        public async Task<List<Guardian>> GetAll()
        {
            return await _guardianRepository.GetAll();
        }

        public async Task<Guardian> Update(Guardian entity)
        {
            try
            {
                await _guardianRepository.Update(entity);
                await _guardianRepository.Commit(); 
            }
            catch (Exception)
            {
                entity = null;
            }
            return entity;

        }


        public async Task<bool> IsFounded(int id)
        {
           return  await _guardianRepository.IsFounded(id);
        }
    }
}
