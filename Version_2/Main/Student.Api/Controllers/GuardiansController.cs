using Microsoft.AspNetCore.Mvc;
using Student.Business.Abstract;
using Student.Entity.Student;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardiansController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly IGuradianTypeService _guardianTypeService;

        public GuardiansController(IGuardianService guardianService, IGuradianTypeService guardianTypeService)
        {
            _guardianService = guardianService;
            _guardianTypeService = guardianTypeService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var guardian = await _guardianService.GetFrist(id ?? 0);
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

            if (!(await _guardianTypeService.IsAlreadyAdded(guardian.GuardianTypeId))) return StatusCode(StatusCodes.Status409Conflict, "Guardian Type Not Founded");

            await _guardianService.Add(guardian);
            if (guardian == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(guardian);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Guardian guardian)
        {
            if (guardian.Id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            if (!(await _guardianTypeService.IsAlreadyAdded(guardian.GuardianTypeId))) return StatusCode(StatusCodes.Status409Conflict, "Guardian Type Not Founded");
            await _guardianService.Update(guardian);
            if (guardian == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(guardian);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            var guardian = await _guardianService.GetFrist(id ?? 0);
            if (guardian == null) return NotFound();
            await _guardianService.Delete(guardian.Id);
            return Ok(guardian);
        }
    }
}