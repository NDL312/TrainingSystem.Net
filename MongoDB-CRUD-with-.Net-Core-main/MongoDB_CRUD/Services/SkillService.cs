using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;

namespace MongoDB_CRUD.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public Task<List<Skill>> GetAllAsync()
        {
            return _skillRepository.GetAllAsync();
        }

        public Task<Skill> GetByIdAsync(string id)
        {
            return _skillRepository.GetByIdAsync(id);
        }

        public Task<Skill> CreateAsync(Skill skill)
        {
            return _skillRepository.CreateAsync(skill);
        }

        public Task UpdateAsync(string id, Skill skill)
        {
            return _skillRepository.UpdateAsync(id, skill);
        }

        public Task DeleteAsync(string id)
        {
            return _skillRepository.DeleteAsync(id);
        }
    }
}
