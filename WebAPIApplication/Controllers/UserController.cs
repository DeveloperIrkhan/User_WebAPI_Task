using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPIApplication.Services;

namespace WebAPIApplication.Controllers
{
    [ApiController]  
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetUsers(int pageNumber = 1, int pageSize = 10)
        {
            var users = await _service.GetAllUsersAsync(pageNumber, pageSize);
            if (users == null || !users.Any())
            {
                return BadRequest(new { message = "No users found" });
            }
            return Ok(new { Users = users, message = "users fetched successfully" });
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState });
            }
            if (user == null)
            {
                return BadRequest(new { message = "Invalid user data" });
            }
            var createdUser = await _service.CreateUserAsync(user);
            return Ok(new { User = createdUser, message = "User created successfully" });
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var updatingUser = await _service.UpdateUserAsync(userModel.Id, userModel);
                return Ok(new { updateduser = userModel, message = "User updated successfully" });
            }
            return BadRequest(new { message = "user updating Error!" });
        }

        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (userId ==0)
            {
                return BadRequest(new { message = "plase enter a valid user id" });
            }
            var result = await _service.DeleteUserAsync(userId);
            if (result) return Ok("deleted successfully!");
            return BadRequest("user delection unsuccessful");
        }

        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            if (userId == 0)
            {
                return BadRequest(new { message = "plase enter a valid user id" });
            }
            var result = await _service.GetUserByIdAsync(userId);
            if (result!=null) return Ok(new { user=result, message= "deleted successfully!"});
            return BadRequest($"user not found for {userId}");
        }
    }
}
