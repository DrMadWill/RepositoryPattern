using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Business.Abstract;
using Student.DataAccess.Abstract;
using Student.Entity.Student;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {

        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _familyService.Get(id ?? 0);
            if(student == null) return NotFound();

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _familyService.GetAll();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Family family)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            if (await _familyService.IsAddedCode(family.Code)) return StatusCode(StatusCodes.Status409Conflict);

            await _familyService.Create(family);
            if (family == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(family);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Family family)
        {
            if (family.Id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity); 
            await _familyService.Update(family);
            if (family == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(family);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _familyService.Get(id ?? 0);
            if (student == null) return NotFound();

            await _familyService.Delete(student);
            return Ok(student);
        }

    }
}
