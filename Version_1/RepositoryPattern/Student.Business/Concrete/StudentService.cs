using Student.Business.Abstract;
using Student.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Entity.Student.Student> Create(Entity.Student.Student entity)
        {
            entity.CreateAt = DateTime.Now;
            await _studentRepository.Create(entity);
            await _studentRepository.Commit();
            return entity;
        }

        public async Task<Entity.Student.Student> Delete(Entity.Student.Student entity)
        {
            await _studentRepository.Delete(entity);
            await _studentRepository.Commit();
            return entity;
        }

        public async Task<Entity.Student.Student> Get(int id)
        {
            if (id == 0) return null;
            Entity.Student.Student student;
            try
            {
                student = await _studentRepository.Get(id);
            }
            catch
            {
                student = null;
            }
            return student;
        }

        public async Task<List<Entity.Student.Student>> GetAll()
        {
            var students = await _studentRepository.GetAll();
            return students;
        }

        public async Task<bool> IsFounded(int id)
        {
            return await _studentRepository.IsFounded(id);
        }

        public async Task<Entity.Student.Student> Update(Entity.Student.Student entity)
        {
            await _studentRepository.Update(entity);
            await _studentRepository.Commit();
            return entity;
        }
    }
}
