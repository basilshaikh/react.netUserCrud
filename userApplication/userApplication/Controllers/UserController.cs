using Microsoft.AspNetCore.Mvc;
using userApplication.Models;
using userApplication.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace userApplication.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices) =>
            _userServices = userServices;

        // GET: api/user
        [HttpGet]
        public async Task<List<User>> Get() => await _userServices.GetUsersAsync();


        // GET api/user/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userServices.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _userServices.CreateUserAsync(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/user/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var user = await _userServices.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            await _userServices.UpdateUserAsync(id, updatedUser);

            return NoContent();
        }

        // DELETE api/user/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userServices.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            await _userServices.RemoveUserAsync(id);

            return NoContent();
        }
    }
}
