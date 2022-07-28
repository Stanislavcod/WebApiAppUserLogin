using Microsoft.AspNetCore.Mvc;
using WebApiAppUserLogin.Models;

namespace WebApiAppUserLogin.Services.Contracts
{
    public interface IProfileService
    {
        ActionResult<IEnumerable<UserProfile>> GetUsersProfiles();
        UserProfile GetUserProfile(int id);
        void Create(UserProfile userProfile);
        void Update(int id,UserProfile userProfile);
        void Delete(int id);
    }
}
