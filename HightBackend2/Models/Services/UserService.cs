using HightBackend.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace HightBackend.Models.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public UserService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public int getUserId()
        {
           var result = string.Empty;

           if (_httpContextAccessor.HttpContext != null)
           {
               result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
           }
           int userId = 0;

           userId = _context.User.Where(u => u.Email == result).FirstOrDefault().userID;

           return userId;
            
        }
    }
}
