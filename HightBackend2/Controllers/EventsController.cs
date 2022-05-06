using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HightBackend.Data;
using HightBackend.Models;
using HightBackend.Models.Dtos;

namespace HightBackend.Controllers
{
   
    [Route("estabilishments/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }   

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IQueryable<EventDto>>> GetEvents(
            [FromQuery(Name = "sortrate")] string sortrate)
        {


            var events = from b in _context.Events
                         select new EventDto()
                         {
                             eventID = b.eventID,
                             title = b.title,
                             time = b.time,
                             eventImage = b.eventImage,
                             estabilishmentName = b.estabilishment.name
                         };

            if (sortrate == "asc")
            {
                events = events.OrderBy(b => b.time).Take(4);
            }
            else if (sortrate == "desc")
            {
                events = events.OrderByDescending(b => b.time).Take(4);
            }

            return Ok(await events.ToListAsync());
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.Include(b => b.estabilishment).Select(b =>
                new EventDetailDto()
                {
                    eventID = b.eventID,
                    title = b.title,
                    time = b.time,
                    eventImage = b.eventImage,
                    description = b.description,
                    location = b.location,
                    price = b.price,
                    estabilishmentName = b.estabilishment.name
                }).SingleOrDefaultAsync(b => b.eventID == id);


            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

    }
}
