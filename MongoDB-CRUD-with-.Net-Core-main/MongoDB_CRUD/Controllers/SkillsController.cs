using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Services;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _skillService.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var skill = await _skillService.GetByIdAsync(id).ConfigureAwait(false);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _skillService.CreateAsync(skill).ConfigureAwait(false);
            return Ok(skill.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Skill skillIn)
        {
            var skill = await _skillService.GetByIdAsync(id).ConfigureAwait(false);
            if (skill == null)
            {
                return NotFound();
            }
            skillIn.Id = skill.Id;
            await _skillService.UpdateAsync(id, skillIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var skill = await _skillService.GetByIdAsync(id).ConfigureAwait(false);
            if (skill == null)
            {
                return NotFound();
            }
            await _skillService.DeleteAsync(skill.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
