using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IMongoCollection<Course> _collection;
        private readonly DbConfiguration _settings;
        public CourseRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Course>(_settings.courseCollectionName);
        }

        public Task<List<Course>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Course> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Course> CreateAsync(Course course)
        {
            await _collection.InsertOneAsync(course).ConfigureAwait(false);
            return course;
        }
        public Task UpdateAsync(string id, Course course)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, course);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
