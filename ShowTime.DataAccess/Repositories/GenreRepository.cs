using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    private readonly DbSet<Genre> _genres;

    public GenreRepository(ShowTimeDbContext context) : base(context)
    {
        _genres = context.Set<Genre>();
    }
}