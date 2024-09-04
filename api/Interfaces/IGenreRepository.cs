using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAync(int id);
        Task<Genre> DeleteAsync(int id);
        Task<Genre> CreateAsync(Genre genre);

    }
}