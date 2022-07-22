using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.DataAccess.Abstract;
using Student.Entity.Student;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FamiliesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var family = await _unitOfWork.FamilyRepository.GetFrist( x =>x.Id == id );
            if (family == null) return NotFound();

            return Ok(family);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.FamilyRepository.GetAllList();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Family family)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            if ((await _unitOfWork.FamilyRepository.GetFrist(f=>f.Code == family.Code)) != null) return StatusCode(StatusCodes.Status409Conflict);

            await _unitOfWork.FamilyRepository.Add(family);
            await _unitOfWork.Commit();
            if (family == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(family);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Family family)
        {
            if (family.Id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            await _unitOfWork.FamilyRepository.Update(family);
            await _unitOfWork.Commit();

            if (family == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(family);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var family = await _unitOfWork.FamilyRepository.GetFrist(x => x.Id == id);
            if (family == null) return NotFound();

            await _unitOfWork.FamilyRepository.Delete(family);
            await _unitOfWork.Commit();

            return Ok(family);
        }

    }
}
