using RentWheelz.Database.Entities;

namespace RentWheelz.Service.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string userEmail);
    Task<User> GetUserAsync(string userName, string userEmail);
    Task AddUserAsync(User user);
    Task SaveChangesAsync();
}
