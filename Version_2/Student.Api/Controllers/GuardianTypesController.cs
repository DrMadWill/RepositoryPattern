using Microsoft.AspNetCore.Mvc;
using Student.Business.Abstract;
using Student.Entity.Student;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianTypesController : ControllerBase
    {
        private readonly IGuradianTypeService _guardianTypeService;

        public GuardianTypesController(IGuradianTypeService guardianTypeService)
        {
            _guardianTypeService = guardianTypeService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var guardianType = await _guardianTypeService.GetFrist(id ?? 0);
            if (guardianType == null) return NotFound();
            return Ok(guardianType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guardianType = await _guardianTypeService.GetAll();

            return Ok(guardianType);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GuardianType guardianType)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            await _guardianTypeService.Add(guardianType);
            if (guardianType == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok((guardianType));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GuardianType guardianType)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            await _guardianTypeService.Update(guardianType);
            if (guardianType == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(guardianType);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var gardianType = await _guardianTypeService.GetFrist(id ?? 0);
            if (gardianType == null) return NotFound("Address not found");

            await _guardianTypeService.Delete(gardianType.Id);
            if (gardianType == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(gardianType);
        }
    }
}