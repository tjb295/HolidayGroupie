﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HolidayGroupie.Dtos;
using HolidayGroupie.Models;
using AutoMapper;
using HolidayGroupie.App_Start;

namespace HolidayGroupie.Controllers.Api
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/event
        public IEnumerable<EventDto> GetEvents()
        {
            //specify mapping to do its thang
            return _context.Events.ToList().Select(Mapper.Map<Event, EventDto>);
        }

        // GET /api/event/1
        public IHttpActionResult GetFriend(int id)
        {
            var myEvent = _context.Events.SingleOrDefault(e => e.Id == id);

            if (myEvent == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(myEvent));
        }

        //POST /api/friend
        [HttpPost]
        public IHttpActionResult CreateEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var myEvent = Mapper.Map<EventDto, Event>(eventDto);
            _context.Events.Add(myEvent);
            _context.SaveChanges();

            eventDto.Id = myEvent.Id;

            return Created(new Uri(Request.RequestUri + "/" + myEvent.Id), eventDto);
        }


        // PUT /api/event/1
        //[HttpPut]
        //public IHttpActionResult UpdateEvent(int id, EventDto eventDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);

        //    if (eventInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    Mapper.Map(eventDto, eventInDb);

        //    _context.SaveChanges();

        //    return Ok();
        //}

        [HttpPut]
        [Route("AddFriendToEvent/{eventId}/{friendId}")]
        public IHttpActionResult AddFriendToEvent(int eventId, int friendId)
        {
            //we need to take these two id's and add some other object
            var myEvent = _context.Events.SingleOrDefault(e => e.Id == eventId);
            if(myEvent == null)
            {
                return NotFound();
            }

            var friend = _context.Friends.SingleOrDefault(f => f.Id == friendId);
            if (friend == null)
            {
                return NotFound();
            }

            //now that we have them add this friend to the events table
            myEvent.Attendees.Add(friend);

            _context.SaveChanges();
            return Ok();
        }


        // DELETE /api/event/1
        public IHttpActionResult DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);

            if (eventInDb == null)
                return NotFound();

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();

            return Ok();
            
        }

    }
}
