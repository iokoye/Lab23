using Lab23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23.Repositories
{
    public interface IMovieRepository
    {
        Task Create(MovieViewModel movie);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<List<MovieViewModel>> Get();
        Task<MovieViewModel> GetById(int id);
        Task Update(MovieViewModel movie);
    }
}
