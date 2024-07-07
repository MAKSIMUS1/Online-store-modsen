using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO.Request.User;
using BLL.DTO.Response;
using BLL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;
using OnlineStore.JwtOptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(id, cancellationToken);
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDto userDto, CancellationToken cancellationToken)
        {
            await _userService.AddUserAsync(userDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto userDto, CancellationToken cancellationToken)
        {
            userDto.Id = id;
            await _userService.UpdateUserAsync(userDto, cancellationToken);
            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(id, cancellationToken);
            return NoContent();
        }



        // Post: api/user/login
        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserDto userDto, HttpContext context, CancellationToken cancellationToken)
        {
            var user = await _userService.LoginAsync(userDto, cancellationToken);
            if (user != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Email, user.Email) };
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                context.Response.Cookies.Append("jwtToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.Strict 
                });
        

            }
            return Ok(user);
        }


    }
}
