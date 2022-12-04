﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(string id);
        Task<Course> CreateAsync(Course course);
        Task UpdateAsync(string id, Course course);
        Task DeleteAsync(string id);
    }
}
