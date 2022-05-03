using HightBackend.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using HightBackend.Models;
using System.Linq;

namespace HightBackend.Models.Services
{
    public class CommentService : ICommentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;


        public CommentService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
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

            int userId = _context.User.Where(u => u.Email == result).FirstOrDefault().userID;
            
            return userId;
        }
    }
}
