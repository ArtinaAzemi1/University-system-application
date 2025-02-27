using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniversityProject.Data;
using UniversityProject.Models;
using UniversityProject.Models.Auth;

namespace UniversityProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly UniversityDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<IdentityUser> userManager,
           RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            UniversityDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register registerModel)
        {
            if (ModelState.IsValid)
            {
                var perdoruesiEkziston = await _userManager.FindByEmailAsync(registerModel.Email);

                if (perdoruesiEkziston != null)
                {
                    return BadRequest(new AuthVariables()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already exists"
                        }
                    });
                }

                var perdoruesiIRI = new IdentityUser()
                {
                    Email = registerModel.Email,
                    UserName = registerModel.Username
                };

                var shtuarMeSukses = await _userManager.CreateAsync(perdoruesiIRI, registerModel.Password);

                if (shtuarMeSukses.Succeeded)
                {
                    await _userManager.AddToRoleAsync(perdoruesiIRI, "User");

                    User perdoruesi = new User
                    {
                        AspNetUserId = perdoruesiIRI.Id,
                        Username = perdoruesiIRI.UserName,
                        Email = perdoruesiIRI.Email
                    };
                    await _context.User.AddAsync(perdoruesi);
                    await _context.SaveChangesAsync();

                    return Ok(new AuthVariables()
                    {
                        Result = true
                    });
                }
                return BadRequest(new AuthVariables()
                {
                    Errors = new List<string>
                    {
                        "Server Errors"
                    },
                    Result = false
                });

            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {

                var useri_ekziston = await _userManager.FindByEmailAsync(login.Email);

                if (useri_ekziston == null)
                {
                    return BadRequest(new AuthVariables()
                    {
                        Errors = new List<string>()
                        {
                            "Inavlid Payload"
                        },
                        Result = false
                    });
                }

                var neRregull = await _userManager.CheckPasswordAsync(useri_ekziston, login.Password);

                if (!neRregull)
                {
                    return BadRequest(new AuthVariables()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid Credintials"
                        },
                        Result = false
                    });
                }

                var roles = await _userManager.GetRolesAsync(useri_ekziston);

                var jwtToken = GenerateJwtToken(useri_ekziston, roles);

                return Ok(new AuthVariables()
                {
                    Token = jwtToken,
                    Result = true
                });
            }

            return BadRequest(new AuthVariables()
            {
                Errors = new List<String>()
                {
                    "Inavlid Payload"
                }
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addUserRole")]
        public async Task<IActionResult> PrditesoAkses(string userID, string roli)
        {
            var user = await _userManager.FindByIdAsync(userID);

            if (user == null)
            {
                return BadRequest(new AuthVariables
                {
                    Errors = new List<string> { "User does not exist!" }
                });
            }

            var perditesoAkses = await _userManager.AddToRoleAsync(user, roli);

            if (perditesoAkses.Succeeded)
            {

                return Ok(new AuthVariables
                {
                    Result = true
                });
            }
            else if (await _userManager.IsInRoleAsync(user, roli))
            {
                return BadRequest(new AuthVariables
                {
                    Errors = new List<string> { "This User has this role!!" }
                });
            }
            else
            {
                return BadRequest(new AuthVariables
                {
                    Errors = new List<string> { "Thre's been a mistake while  updating the access" }
                });
            }
        }

        private string GenerateJwtToken(IdentityUser user, IList<string> roles)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            // Token descriptor
            var TokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, value:user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddDays(1).AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            foreach (var role in roles)
            {
                TokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var token = jwtTokenHandler.CreateToken(TokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }


    }
}
