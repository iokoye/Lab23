using Lab23.Data;
using Lab23.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieViewModel>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<MovieViewModel> GetById(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task Create(MovieViewModel movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Update(MovieViewModel movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Movies.AnyAsync(e => e.ID == id);
        }
    }
}
