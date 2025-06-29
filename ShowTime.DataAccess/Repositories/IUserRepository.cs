using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories;

public interface IUserRepository
{
    public Task<User?> GetByEmail(string email);
}