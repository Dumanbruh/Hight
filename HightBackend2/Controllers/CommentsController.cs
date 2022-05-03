using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HightBackend.Data;
using HightBackend.Models;
using HightBackend.Models.Services;
using Microsoft.AspNetCore.Authorization;

namespace HightBackend.Models.Dtos
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommentsController : ControllerBase
    {
        public static Comment comment = new Comment();  
        private readonly AppDbContext _context;
        private readonly ICommentService _commentService;

        public CommentsController(AppDbContext context, ICommentService commentService)
        {
            _context = context;
            _commentService = commentService;

        }

        [HttpGet, Authorize]
        public ActionResult<Comment> GetUserComments()
        {
            var comments = from b in _context.comments
                           where b.userID == _commentService.getUserId()
                           select new CommentDto()
                           {
                               comment = b.comment,
                               publishedDate = b.publishedDate,
                               overallRating = b.overallRating,
                               locationRating = b.locationRating,
                               serviceRating = b.serviceRating,
                               price_qualityRating = b.price_qualityRating
                           };

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        [HttpPost("{id}"), Authorize]
        public async Task<ActionResult<Comment>> PostComment(int id, CommentDto commentDto)
        {
            comment.userID = _commentService.getUserId();
            comment.comment = commentDto.comment;
            comment.publishedDate = DateTime.Now.Date;
            comment.overallRating = commentDto.overallRating;
            comment.locationRating = commentDto.locationRating;
            comment.serviceRating = commentDto.serviceRating;
            comment.price_qualityRating = commentDto.price_qualityRating;
            comment.estabilishmentID = id;

            _context.comments.Add(comment);
            await _context.SaveChangesAsync();


            return Ok(comment);
        }


        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteUserCommentsAsync(int id)
        {

            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
