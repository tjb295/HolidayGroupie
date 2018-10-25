using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HolidayGroupie.Models;
using HolidayGroupie.Dtos;
using AutoMapper;

namespace HolidayGroupie.Controllers.Api
{
    public class FriendController : ApiController
    {
        private ApplicationDbContext _context;

        public FriendController()
        {
            _context = new ApplicationDbContext();
        }

        // Get /api/friends
        public IEnumerable<FriendDto> GetFriends()
        {
            //specify mapping what to what
            return _context.Friends.ToList().Select(Mapper.Map<Friend, FriendDto>);
        }

        // GET /api/friends/1
        public IHttpActionResult GetFriend(int id)
        {
            var friend = _context.Friends.SingleOrDefault(f => f.Id == id);

            if (friend == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Friend, FriendDto>(friend));
        }

        // POST /api/friends
        [HttpPost]
        public IHttpActionResult CreateFriend(FriendDto friendDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var friend = Mapper.Map<FriendDto, Friend>(friendDto);
            _context.Friends.Add(friend);
            _context.SaveChanges();

            friendDto.Id = friend.Id;

            return Created(new Uri(Request.RequestUri + "/" + friend.Id), friendDto);
        }

        // PUT /api/friends/1
        [HttpPut]
        public void UpdateFriend(int id, FriendDto friendDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var friendInDb = _context.Friends.SingleOrDefault(f => f.Id == id);

            if (friendInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //source and targt in parameters so do not need to define type
            Mapper.Map(friendDto, friendInDb);

            _context.SaveChanges();

        }

        // DELETE /api/friends/1
        public void DeleteFriend(int id)
        {
            var friendInDb = _context.Friends.SingleOrDefault(f => f.Id == id);

            if (friendInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Friends.Remove(friendInDb);
            _context.SaveChanges();
        }

    }
}
