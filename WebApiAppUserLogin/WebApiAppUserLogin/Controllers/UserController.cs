using Microsoft.AspNetCore.Mvc;
using WebApiAppUserLogin.Models;
using WebApiAppUserLogin.Services.Contracts;

namespace WebApiAppUserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
             return Ok(_userServices.GetUsers());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userServices.Update(id, user);
            return Ok();
        }

        // POST: api/User
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userServices.Create(user);
            return Ok();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userServices.Delete(id);
            return Ok();
        }
    }
}
