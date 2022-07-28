using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAppUserLogin.Models;
using WebApiAppUserLogin.Services.Contracts;

namespace WebApiAppUserLogin.Services.Implementations
{
    public class ProfilesService : IProfileService
    {
        private readonly ApplicationContext _context;
        public ProfilesService(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var profile = _context.UserProfiles.FirstOrDefault(p => p.Id == id);
            if (profile == null) throw new Exception("Пользователь не найден");
            _context.UserProfiles.Remove(profile);
            _context.SaveChanges();
        }

        public UserProfile GetUserProfile(int id)
        {
           return _context.UserProfiles.FirstOrDefault(p => p.Id == id);
        }
        

        public ActionResult<IEnumerable<UserProfile>> GetUsersProfiles()
        {
           return _context.UserProfiles.AsNoTracking().ToList();
        }

        public void Update(int id,UserProfile userProfile)
        {
            var userProf = _context.UserProfiles.FirstOrDefault(p => p.Id == id);
            if (userProf == null) throw new Exception("Пользователь не найден");
            userProf = userProfile;
            _context.UserProfiles.Update(userProfile);
            _context.SaveChanges();
        }
    }
}
