using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Student.DataAccess.Abstract;
using Student.Entity.Student;
using Student.Business.Abstract;
using Newtonsoft.Json;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudnetsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IFamilyService _familyService;

        public StudnetsController(IStudentService studentService, IFamilyService familyService)
        {
            _studentService = studentService;
            _familyService = familyService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {

            if (id == null || id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _studentService.Get(id ?? 0);
            if (student == null) return NotFound();

            return Ok(student);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student.Entity.Student.Student student)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            bool isFounded = (await _familyService.IsFounded(student.FamilyId));

            if (!isFounded) return NotFound("Family id not found");
            await _studentService.Create(student);
            return Ok((student));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student.Entity.Student.Student student)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            if (!(await _familyService.IsFounded(student.FamilyId))) return NotFound("Family id not found");
            await _studentService.Update(student);
            if (student == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(student);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _studentService.Get(id ?? 0);
            if (student == null) return NotFound("Student not found");

            await _studentService.Delete(student);
            if (student == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(student);
        }

    }
}
