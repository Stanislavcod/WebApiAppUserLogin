using Microsoft.AspNetCore.Mvc;
using WebApiAppUserLogin.Models;

namespace WebApiAppUserLogin.Services.Contracts
{
    public interface IUserService
    {
        ActionResult<IEnumerable<User>> GetUsers();
        User GetUser(int id);
        void Create(User user);
        void Update(int id,User user);
        void Delete(int id);
    }
}
