using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;

namespace MongoDB_CRUD.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<List<Course>> GetAllAsync()
        {
            return _courseRepository.GetAllAsync();
        }

        public Task<Course> GetByIdAsync(string id)
        {
            return _courseRepository.GetByIdAsync(id);
        }

        public Task<Course> CreateAsync(Course course)
        {
            return _courseRepository.CreateAsync(course);
        }

        public Task UpdateAsync(string id, Course course)
        {
            return _courseRepository.UpdateAsync(id, course);
        }

        public Task DeleteAsync(string id)
        {
            return _courseRepository.DeleteAsync(id);
        }
    }
}
