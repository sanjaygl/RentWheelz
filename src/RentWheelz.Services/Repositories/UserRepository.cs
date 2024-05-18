using Microsoft.EntityFrameworkCore;
using RentWheelz.Database;
using RentWheelz.Database.Entities;

namespace RentWheelz.Service.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RentWheelzDbContext _context;

    public UserRepository(RentWheelzDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserAsync(string userName, string userEmail)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName || u.UserEmail == userEmail);
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<User> GetUserByEmailAsync(string userEmail)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == userEmail);
    }
}
