using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;

namespace RentWheelz.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterUserAsync(UserModel userModel)
    {
        var existingUser = await _userRepository.GetUserAsync(userModel.UserName, userModel.UserEmail);

        if (existingUser != null)
        {
            return false;
        }

        var newUser = new User
        {
            UserName = userModel.UserName,
            UserEmail = userModel.UserEmail,
            UserPassword = userModel.UserPassword, // Remember to hash and salt this password before storing it
            ProofId = userModel.ProofId
        };

        await _userRepository.AddUserAsync(newUser);
        await _userRepository.SaveChangesAsync();

        return true;
    }
    public async Task<LoginResponseModel> LoginAsync(LoginModel loginModel)
    {
        var user = await _userRepository.GetUserByEmailAsync(loginModel.UserEmail);

        if (user == null || user.UserPassword != loginModel.UserPassword) // Remember to hash and salt passwords, and compare the hashed values
        {
            return null;
        }

        return new LoginResponseModel
        {
            Status = "success",
            Message = "Login successful",
            Data = new UserModel
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                ProofId = user.ProofId
            }
        };
    }
}
