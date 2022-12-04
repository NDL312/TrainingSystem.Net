using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IMongoCollection<Skill> _collection;
        private readonly DbConfiguration _settings;
        public SkillRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Skill>(_settings.skillCollectionName);
        }

        public Task<List<Skill>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Skill> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Skill> CreateAsync(Skill skill)
        {
            await _collection.InsertOneAsync(skill).ConfigureAwait(false);
            return skill;
        }
        public Task UpdateAsync(string id, Skill skill)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, skill);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
