using Microsoft.AspNetCore.Mvc;
using WebApiAppUserLogin.Models;
using WebApiAppUserLogin.Services.Contracts;

namespace WebApiAppUserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public UserProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET: api/UserProfiles
        [HttpGet]
        public ActionResult<IEnumerable<UserProfile>> GetUserProfiles()
        {
            return Ok(_profileService.GetUsersProfiles());
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        public ActionResult<UserProfile> GetUserProfile(int id)
        {
            var userProfile = _profileService.GetUserProfile(id);
            if(userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        // PUT: api/UserProfiles/5
        [HttpPut("{id}")]
        public IActionResult PutUserProfile(int id, UserProfile userProfile)
        {
            if(id == userProfile.Id)
            {
                return BadRequest();
            }
            _profileService.Update(id, userProfile);
            return Ok();
        }

        // POST: api/UserProfiles
        [HttpPost]
        public IActionResult PostUserProfile(UserProfile userProfile)
        {
            _profileService.Create(userProfile);
            return Ok();
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserProfile(int id)
        {
            _profileService.Delete(id);
            return Ok();
        }
    }
}
