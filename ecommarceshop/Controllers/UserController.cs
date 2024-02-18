using ecommarceshop.DTO;
using ecommarceshop.Interfaces;
using ecommarceshop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommarceshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _repository.User.FindByCondition(x => x.Id.Equals("1"));
            var owners = _repository.User.FindAll();
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Create(RegisterRequestDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map RegisterRequestDto to Register entity
            var user = new Register
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                MobileNo = registerDto.MobileNo,
                Password = registerDto.Password
            };

            try
            {
                // Add the user to the repository and save changes
                _repository.User.Create(user);
                _repository.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            // Return 201 Created status code along with the created user
            return CreatedAtRoute("GetUserById", new { id = user.Id }, user);
        }
    }
}
