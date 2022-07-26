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
    public class StudentService: IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Student.Entity.Student.Student> Add(Entity.Student.Student entity)
        {
            await _unitOfWork.StudentRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<Entity.Student.Student> Delete(int id)
        {
            if (id > 0)
            {
                var family = await _unitOfWork.StudentRepository.GetFrist(x => x.Id == id);
                if (family == null) return null;
                await _unitOfWork.StudentRepository.Delete(family);
                await _unitOfWork.Commit();
            }
            return null;
        }

        public async Task<List<Entity.Student.Student>> GetAll()
        {
            return await _unitOfWork.StudentRepository.GetAllList();
        }

        public async Task<Entity.Student.Student> GetFrist(int id)
        {
            return await _unitOfWork.StudentRepository.GetFrist(x => x.Id == id);
        }

        public async Task<Entity.Student.Student> Update(Entity.Student.Student entity)
        {
            var upEntity = await _unitOfWork.StudentRepository.Update(entity);
            await _unitOfWork.Commit();
            return upEntity;
        }

        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element = await _unitOfWork.StudentRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }
    }
}
