using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using System.Security.Cryptography.Xml;

namespace ProductsApi.Services
{
    public class UserService : IUserService
    {

        private readonly SqlServerDbContext _sqlServerDbContext;
        public UserService(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public Task<bool> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return await _sqlServerDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<User?> GetUserByUserNumberAsync(int userNumber)
        {
            return await _sqlServerDbContext.Users.FindAsync(userNumber);
        }
    }
}
