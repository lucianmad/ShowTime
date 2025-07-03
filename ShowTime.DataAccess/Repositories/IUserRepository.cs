using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetByEmail(string email);
}