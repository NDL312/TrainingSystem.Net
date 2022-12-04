using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill> GetByIdAsync(string id);
        Task<Skill> CreateAsync(Skill skill);
        Task UpdateAsync(string id, Skill skill);
        Task DeleteAsync(string id);
    }
}
