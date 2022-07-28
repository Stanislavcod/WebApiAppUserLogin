using WebApiAppUserLogin.Services.Contracts;
using WebApiAppUserLogin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAppUserLogin.Services.Implementations
{
    public class UsersService : IUserService
    {
        private readonly ApplicationContext _context;
        public UsersService(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) throw new Exception("Пользователь не найден");
            _context.Users.Remove(user);
            _context.SaveChanges();
            
        }
        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<IEnumerable<User>> GetUsers() =>
            _context.Users.AsNoTracking().ToList();

        public void Update(int id, User us)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) throw new Exception("Пользователь не найден");
            user = us;
            _context.Users.Update(user);
            _context.SaveChanges();           
        }
    }
}
