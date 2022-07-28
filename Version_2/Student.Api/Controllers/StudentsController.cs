using Microsoft.AspNetCore.Mvc;
using Student.DataAccess.Abstract;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IBaseRepostitory<Entity.Student.Student, int> _studentRepository;
        private readonly IBaseRepostitory<Entity.Student.Family, int> _familyRepository;

        public StudentsController(IBaseRepostitory<Entity.Student.Student, int> studentRepository, IBaseRepostitory<Entity.Student.Family, int> familyRepository)
        {
            _studentRepository = studentRepository;
            _familyRepository = familyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllList();
            return Ok(students);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _studentRepository.GetFrist(x => x.Id == id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Entity.Student.Student student)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            bool isFounded = (await _familyRepository.GetFrist(x => x.Id == student.FamilyId)) == null;

            if (!isFounded) return NotFound("Family id not found");
            await _studentRepository.Add(student);
            return Ok((student));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Entity.Student.Student student)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            if ((await _familyRepository.GetFrist(x => x.Id == student.FamilyId)) == null) return NotFound("Family id not found");
            await _studentRepository.Update(student);
            if (student == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(student);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _studentRepository.GetFrist(x => x.Id == id);
            if (student == null) return NotFound("Student not found");

            await _studentRepository.Delete(student);
            if (student == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(student);
        }
    }
}