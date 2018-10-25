using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HolidayGroupie.Models;

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
        public IEnumerable<Friend> GetFriends()
        {
            return _context.Friends.ToList();
        }

        // GET /api/friends/1
        public Friend GetFriend(int id)
        {
            var friend = _context.Friends.SingleOrDefault(f => f.Id == id);

            if (friend == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return friend;
        }

        // POST /api/friends
        [HttpPost]
        public Friend CreateFriend(Friend friend)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Friends.Add(friend);
            _context.SaveChanges();

            return friend;
        }

        // PUT /api/friends/1
        [HttpPut]
        public void UpdateFriend(int id, Friend friend)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var friendInDb = _context.Friends.SingleOrDefault(f => f.Id == id);

            if (friendInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            friendInDb.Name = friend.Name;
            friendInDb.Email = friend.Email;
            friendInDb.LastName = friend.LastName;
            friendInDb.MembershipTypeId = friend.MembershipTypeId;

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
