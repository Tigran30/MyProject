using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuperHeroAPI.Application.Configuration;
using SuperHeroAPI.Models;
using SuperHeroAPI.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperHeroAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        //  private readonly JwtConfig _jwtConfig;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;

            _configuration = configuration;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDTO requestDto)
        {
            if (ModelState.IsValid)
            {
                var user_exist = await _userManager.FindByEmailAsync(requestDto.Email);
                if (user_exist != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already exist"
                        }
                    });
                }
                var new_user = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Email
                };
                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);

                if (is_created.Succeeded)
                {
                    var token = GenerateJwtToken(new_user);
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    },
                    Result = false

                });
            }
            return BadRequest();
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoignRequestDTO loginResult)
        {
            if (ModelState.IsValid)
            {
                var _existing_user = await _userManager.FindByEmailAsync(loginResult.Email);
                if (_existing_user == null)
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid payload"
                        },
                        Result = false
                    });
                var isCorrect = await _userManager.CheckPasswordAsync(_existing_user, loginResult.Password);
                if (!isCorrect)
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "invalid credentials"
                        },
                        Result = false
                    });
                var jwtToken = GenerateJwtToken(_existing_user);
                return Ok(new AuthResult()
                {
                    Token = jwtToken,
                    Result = true
                });

            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "invalid payloda"
                },
                Result = false
            });
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            var _jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id",user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString()),
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = _jwtTokenHandler.CreateToken(tokenDescriptor);
            return _jwtTokenHandler.WriteToken(token);
        }
    }
}
