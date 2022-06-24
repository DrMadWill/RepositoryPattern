using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Student.DataAccess.Abstract;
using Student.Entity.Student;
namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return BadRequest();

            var student = await _studentRepository.Get(id ?? 0);
            return Ok(student);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student.Entity.Student.Student student)
        {
            await _studentRepository.Create(student);
            await _studentRepository.Commit();
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student.Entity.Student.Student student)
        {
            await _studentRepository.Update(student);
            await _studentRepository.Commit();
            return Ok(student);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var student = await _studentRepository.Get(id ?? 0);
            await _studentRepository.Delete(student);
            await _studentRepository.Commit();
            return Ok(student);
        }

    }
}
