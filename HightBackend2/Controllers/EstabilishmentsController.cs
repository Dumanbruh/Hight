using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HightBackend.Data;
using HightBackend.Models;
using HightBackend.Models.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using HightBackend.Models.Services;

namespace HightBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstabilishmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public static Comment comment = new Comment();
        private readonly IUserService _userService;

        public EstabilishmentsController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<Estabilishment> GetEstabilishment(
            [FromQuery(Name = "s")] string s,
            [FromQuery(Name = "sortname")] string sortname,
            [FromQuery(Name = "sortrate")] string sortrate,
            [FromQuery(Name = "page")] int? querypage,
            [FromQuery(Name = "type")] string type)
        {
            


            var estabilishments = from b in _context.Estabilishments
                                  select new EstabilishmentDto()
                                  {
                                      estabilishmentId = b.estabilishmentId,
                                      typeName = b.type.typeName,
                                      name = b.name,
                                      website = b.website,
                                      reviewNum = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Count(),
                                      overallRating = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Average(s => s.overallRating),
                                      location = b.location,
                                      imageTitle = b.estabilishmentImage.FirstOrDefault().Title
                                  };    

            if (!string.IsNullOrEmpty(s))   
            {
                estabilishments = estabilishments.Where(b => b.name.Contains(s));
            }

            if (sortname == "asc")
            {
                estabilishments = estabilishments.OrderBy(b => b.name);
            }
            else if (sortname == "desc")
            {
                estabilishments = estabilishments.OrderByDescending(b => b.name);
            }


            if (sortrate == "asc")
            {
                estabilishments = estabilishments.OrderBy(b => b.overallRating);
            }
            else if (sortrate == "desc")
            {
                estabilishments = estabilishments.OrderByDescending(b => b.overallRating);
            }

            if (!string.IsNullOrEmpty(type)) {
                estabilishments = estabilishments.Where(b => b.typeName.Equals(type));
            }

            int perPage = 10;
            int page = querypage.GetValueOrDefault(1) == 0 ? 1 : querypage.GetValueOrDefault(1);
            var total = estabilishments.Count();



            return Ok(estabilishments.Skip((page - 1) * perPage).Take(perPage));
        }

        // GET: api/Estabilishments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estabilishment>> GetEstabilishment(int id)
        {
            var estabilishments = await _context.Estabilishments.Include(b => b.events).Select(b =>
                new EstabilishmentDetailDto()
                {
                    estabilishmentId = b.estabilishmentId,
                    typeName = b.type.typeName,
                    name = b.name,
                    website = b.website,
                    reviewNum = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Count(),
                    description = b.description,
                    location = b.location,
                    overallRating = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Average(d => d.overallRating),
                    locationRating = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Average(d => d.locationRating),
                    serviceRating = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Average(d => d.serviceRating),
                    price_qualityRating = _context.comments.Where(d => d.estabilishmentID == b.estabilishmentId).Average(d => d.price_qualityRating),
                    events = b.events.Where(d => d.estabilishmentID == b.estabilishmentId).ToList(),
                    comments = b.comments.Where(d => d.estabilishmentID == b.estabilishmentId).ToList(),
                    estabilishmentImages = b.estabilishmentImage.Where(d => d.estabilishmentID == b.estabilishmentId).ToList()
                }).SingleOrDefaultAsync(b => b.estabilishmentId == id);

            if (estabilishments == null)
            {
                return NotFound();
            }

            return Ok(estabilishments);
        }

    }
}
