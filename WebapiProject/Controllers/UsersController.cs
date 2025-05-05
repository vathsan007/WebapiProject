using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using WebapiProject.Authentication;

using WebapiProject.Models;



using WebapiProject.Repository;

namespace WebapiProject.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    [EnableCors("MyCorsPolicy")]

    public class UsersController : ControllerBase

    {

        private readonly IUserRepository _userRepository;

        private readonly IAuth _authService;

        public static List<User> lstuser = new List<User>

        {

            new User{UserId=5,Name="React",Username="admin",Password="admin123",Email="admin@gmail.com",Phone="1234567890",Address="Office",Role="Admin"}

        };

        public UsersController(IUserRepository userRepository, IAuth authService)

        {

            _userRepository = userRepository;

            _authService = authService;

        }

        //[HttpPost("register")]

        //public IActionResult Register([FromBody] User user)

        //{

        //    try

        //    {

        //        Console.WriteLine($"Received username: {user.Username}");

        //        //var existingUser = _userRepository.GetUserByUsername(user.Username);

        //        //if (existingUser != null)

        //        //{

        //        //    return BadRequest(new { message = "Username already exists." });

        //        //}

        //        _userRepository.AddUser(user);

        //        return Ok(new { message = "User registered successfully" });

        //    }

        //    catch (Exception ex)

        //    {

        //        // Log the exception

        //        Console.WriteLine($"Exception in Register: {ex.Message}");

        //        return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });

        //    }

        //}

        [HttpPost("register")]

        public IActionResult Register([FromBody] User user)

        {

            try

            {

                var existingUser = _userRepository.GetUserByUsername(user.Username);

                if (existingUser != null)

                {

                    return BadRequest(new { message = "Username already exists" });

                }

                _userRepository.AddUser(user);

                return Ok(new { message = "User registered successfully" });

            }


            catch (System.Exception ex)

            {

                // Log the exception

                Console.WriteLine($"Exception in Register: {ex.Message}");

                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });

            }

        }

        [EnableCors("MyCorsPolicy")]

        //[Authorize(Roles = "User,Admin")]

        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginCredentials loginRequest)

        {

            try

            {

                if (_userRepository.ValidateUserCredentials(loginRequest.Username, loginRequest.Password))

                {

                    var user = _userRepository.GetUserByUsername(loginRequest.Username);

                    var token = _authService.GenerateToken(user);

                    Console.WriteLine($"Generated Token: {token}");

                    return Ok(new { Token = token, Role = user.Role });

                }

                return Unauthorized("Invalid credentials");

            }

            catch (System.Exception ex)

            {

                // Log the exception

                Console.WriteLine($"Exception in Login: {ex.Message}");

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [AllowAnonymous]

        [HttpPost("authentication")]

        public IActionResult Authentication([FromBody] User user)

        {

            try

            {

                var token = _authService.GenerateToken(user);

                if (token == null)

                    return Unauthorized();

                return Ok(token);

            }

            catch (System.Exception ex)

            {

                // Log the exception

                Console.WriteLine($"Exception in Authentication: {ex.Message}");

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        //[Authorize(Roles = "User,Admin")]

        [HttpGet("getUser/{username}")]

        public IActionResult GetUser(string username)

        {

            try

            {

                var user = _userRepository.GetUserByUsername(username);

                if (user != null)

                {

                    return Ok(user);

                }

                return NotFound("User not found");

            }

            catch (System.Exception ex)

            {

                // Log the exception

                Console.WriteLine($"Exception in GetUser: {ex.Message}");

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        //[Authorize(Roles = "Admin")]

        [HttpGet("{id}")]

        public IActionResult Get(int id)

        {

            try

            {

                var user = _userRepository.GetUserById(id);

                if (user != null)

                {

                    return Ok(user);

                }

                return NotFound("User not found");

            }

            catch (System.Exception ex)

            {

                // Log the exception

                Console.WriteLine($"Exception in Get: {ex.Message}");

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }


        [HttpPut("update")]

        public IActionResult UpdateUserDetail([FromBody] UpdateUserDetail dto)

        {

            try

            {

                _userRepository.UpdateUserDetail(dto);

                return Ok("User details updated successfully.");

            }

            catch (System.Exception ex)

            {

                return BadRequest($"Error updating user details: {ex.Message}");

            }

        }

        [HttpPost("reset-password")]

        public IActionResult ResetPassword([FromBody] PasswordReset dto)

        {

            try

            {

                _userRepository.PasswordReset(dto);

                return Ok("Password reset successfully.");

            }

            catch (System.Exception ex)

            {

                return BadRequest($"Error resetting password: {ex.Message}");

            }

        }

    }

}
