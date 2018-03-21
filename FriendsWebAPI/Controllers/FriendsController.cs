using Data;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FriendsWebAPI.Controllers
{
    public class FriendsController : ApiController
    {
        FriendRepository _friendRepository = new FriendRepository();

        // GET: api/Friends
        public IEnumerable<Friend> Get()
        {
            return _friendRepository.GetAll();
        }

        // GET: api/Friends/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Friends
        public void Post([FromBody]Friend friend)
        {
            _friendRepository.Add(friend);
        }

        // PUT: api/Friends/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Friends/5
        public void Delete(int id)
        {
        }
    }
}
