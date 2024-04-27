using ProductsApi.Data;

namespace ProductsApi.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByUserNameAsync(string username);

        Task<User?> GetUserByUserNumberAsync(int userNumber);
        
        Task<bool> AddUserAsync(User user);
        
    }
}
