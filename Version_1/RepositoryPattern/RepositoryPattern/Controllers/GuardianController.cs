using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Business.Abstract;
using Student.Entity.Student;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly IGuardianTypeService _guardianTypeService;

        public GuardianController(IGuardianService guardianService,IGuardianTypeService guardianTypeService)
        {
            _guardianService = guardianService;
            _guardianTypeService = guardianTypeService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var guardian = await _guardianService.Get(id ?? 0);
            if (guardian == null) return NotFound();

            return Ok(guardian);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _guardianService.GetAll();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guardian guardian)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            if(!(await _guardianTypeService.IsFounded(guardian.GuardianTypeId))) return StatusCode(StatusCodes.Status409Conflict,"Guardian Type Not Founded");

            await _guardianService.Create(guardian);
            if (guardian == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(guardian);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Guardian guardian)
        {
            if (guardian.Id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            if (!(await _guardianTypeService.IsFounded(guardian.GuardianTypeId))) return StatusCode(StatusCodes.Status409Conflict, "Guardian Type Not Founded");
            await _guardianService.Update(guardian);
            if (guardian == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(guardian);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _guardianService.Get(id ?? 0);
            if (student == null) return NotFound();

            await _guardianService.Delete(student);
            return Ok(student);
        }


    }
}
