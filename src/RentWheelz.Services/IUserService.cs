using RentWheelz.ViewModel;

namespace RentWheelz.Service;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserModel userModel);
    Task<LoginResponseModel> LoginAsync(LoginModel loginModel);
}
