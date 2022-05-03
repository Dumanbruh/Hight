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

        public EstabilishmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Estabilishment> GetEstabilishment(
            [FromQuery(Name = "s")] string s,
            [FromQuery(Name = "sortname")] string sortname,
            [FromQuery(Name = "sortrate")] string sortrate,
            [FromQuery(Name = "page")] int? querypage)
        {
            var estabilishments = from b in _context.Estabilishments
                                  select new EstabilishmentDto()
                                  {
                                      estabilishmentId = b.estabilishmentId,
                                      typeName = b.type.typeName,
                                      name = b.name,
                                      website = b.website,
                                      reviewNum = b.reviewNum,
                                      overallRating = b.overallRating,
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
                    reviewNum = b.reviewNum,
                    description = b.description,
                    location = b.location,
                    overallRating = b.overallRating,
                    locationRating = b.locationRating,
                    serviceRating = b.serviceRating,
                    price_qualityRating = b.price_qualityRating,
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
