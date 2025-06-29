using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(ShowTimeDbContext context) : base(context)
    {
        _users = context.Set<User>();
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        try
        {
            return await _users.SingleOrDefaultAsync(u => u.Email == email);       
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve user with email {email}: {ex.Message}");
        }
    }
}