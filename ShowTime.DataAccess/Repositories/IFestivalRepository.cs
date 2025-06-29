using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories;

public interface IFestivalRepository
{
    public Task<Festival?> GetByName(string name);
    public Task<IEnumerable<Festival>> GetAllByDate(DateTime date);
    public Task<IEnumerable<Festival>> GetAllByLocation(string location);
}