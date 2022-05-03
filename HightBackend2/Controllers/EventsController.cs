﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HightBackend.Data;
using HightBackend.Models;
using HightBackend.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<IQueryable<EventDto>>> GetEvents()
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

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.eventID)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            // New code:
            // Load author name
            _context.Entry(@event).Reference(x => x.estabilishment).Load();

            var dto = new EventDto()
            {
                eventID = @event.eventID,
                title = @event.title,
                estabilishmentName = @event.estabilishment.name
            };

            return CreatedAtRoute("DefaultApi", new { id = @event.eventID }, dto);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.eventID == id);
        }
    }
}
