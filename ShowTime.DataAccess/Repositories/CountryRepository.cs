using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    private readonly DbSet<Country> _countries;

    public CountryRepository(ShowTimeDbContext context) : base(context)
    {
        _countries = context.Set<Country>();   
    }
}