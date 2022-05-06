using HightBackend.Data;
using HightBackend.Models;
using HightBackend.Models.Dtos;
using HightBackend.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HightBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly AppDbContext _context;
        public AuthController(IConfiguration configuration, IUserService userService, AppDbContext context)
        {
            _userService = userService;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("register/")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userDto) {

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.FirstName = userDto.Firstname;
            user.LastName = userDto.Lastname;
            user.Email = userDto.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            if (UserExists(userDto.Email)) {
                return BadRequest("Already exists");
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered!");
        }


        [HttpPost]
        [Route("login/")]
        public ActionResult<string> Login(UserLoginDto userDto)
        {
            var user = Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });


            var tokenString = CreateToken(user);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.userID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> PutUserInfo(UserDetailDto userinfo)
        {

            var userUpdate = _context.User.FirstOrDefault(u => u.userID == _userService.getUserId());

            if (!string.IsNullOrEmpty(userinfo.Email)) {
                userUpdate.Email = userinfo.Email; 
            }
            if (!string.IsNullOrEmpty(userinfo.Firstname))
            {
                userUpdate.FirstName = userinfo.Firstname;  
            }
            if (!string.IsNullOrEmpty(userinfo.Lastname))
            {
                userUpdate.LastName = userinfo.Lastname;
            }

            _context.Entry(userUpdate).State = EntityState.Modified;

            if (userUpdate.FirstName == "string" || userUpdate.FirstName == null) {
                _context.Entry(userUpdate).Property(x => x.FirstName).IsModified = false;
            }

            if (userUpdate.LastName == "string" || userUpdate.LastName == null)
            {
                _context.Entry(userUpdate).Property(x => x.LastName).IsModified = false;
            }

            if (userUpdate.Email == "string" || userUpdate.Email == null)
            {
                _context.Entry(userUpdate).Property(x => x.Email).IsModified = false;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(_userService.getUserId()))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }



        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("favourites/{id}"), Authorize]
        public async Task<ActionResult<Estabilishment>> AddUsersFavourites(int id)
        {
            usersFavourites usersFavourites = new usersFavourites();
            usersFavourites.estabilishmentID = id;
            usersFavourites.userID = _userService.getUserId();

            _context.usersFavourites.Add(usersFavourites);
            await _context.SaveChangesAsync();

            return Ok(usersFavourites);
        }

        [HttpGet, Authorize]
        [Route("favourites/")]
        public async Task<ActionResult<Estabilishment>> GetUsersFavourites()
        {
            var favourites = from b in _context.Estabilishments
                             join f in _context.usersFavourites on b.estabilishmentId equals f.estabilishmentID
                             select new EstabilishmentDto() {
                                 estabilishmentId = b.estabilishmentId,
                                 typeName = b.type.typeName,
                                 name = b.name,
                                 website = b.website,
                                 reviewNum = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Count(),
                                 overallRating = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Average(s => s.overallRating),
                                 location = b.location,
                                 imageTitle = b.estabilishmentImage.FirstOrDefault().Title
                             };


            if (favourites == null)
            {
                return NotFound();
            }

            return Ok(favourites);
        }

        [HttpDelete("favourites/{id}"), Authorize]
        public async Task<IActionResult> DeleteUsersFavourites(int id)
        {
            var favourites = await _context.usersFavourites.FindAsync(id);
            if (favourites == null)
            {
                return NotFound();
            }

            _context.usersFavourites.Remove(favourites);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds); 

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        protected User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.User.SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }

        private bool UserExists(string email)
        {
            return _context.User.Any(e => e.Email == email);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.userID == id);
        }

    }
}
