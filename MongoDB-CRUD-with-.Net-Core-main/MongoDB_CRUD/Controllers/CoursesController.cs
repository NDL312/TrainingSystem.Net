using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Services;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseService.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var course = await _courseService.GetByIdAsync(id).ConfigureAwait(false);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _courseService.CreateAsync(course).ConfigureAwait(false);
            return Ok(course.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Course courseIn)
        {
            var course = await _courseService.GetByIdAsync(id).ConfigureAwait(false);
            if (course == null)
            {
                return NotFound();
            }
            courseIn.Id = course.Id;
            await _courseService.UpdateAsync(id, courseIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var course = await _courseService.GetByIdAsync(id).ConfigureAwait(false);
            if (course == null)
            {
                return NotFound();
            }
            await _courseService.DeleteAsync(course.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
