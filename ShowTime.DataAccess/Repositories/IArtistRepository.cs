using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories;

public interface IArtistRepository
{
    public Task<Artist?> GetByName(string name);
    public Task<IEnumerable<Artist>> GetAllByGenre(string genre);
}