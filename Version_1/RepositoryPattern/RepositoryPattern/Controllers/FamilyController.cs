using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.DataAccess.Abstract;
using Student.Entity.Student;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {

        private IFamilyRepository _familyRepository;

        public FamilyController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return BadRequest();

            var student = await _familyRepository.Get(id ?? 0);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _familyRepository.GetAll();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Family family)
        {
            await _familyRepository.Create(family);
            await _familyRepository.Commit();
            return Ok(family);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Family family)
        {
            await _familyRepository.Update(family);
            await _familyRepository.Commit();
            return Ok(family);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var student = await _familyRepository.Get(id ?? 0);
            await _familyRepository.Delete(student);
            await _familyRepository.Commit();
            return Ok(student);
        }

    }
}
