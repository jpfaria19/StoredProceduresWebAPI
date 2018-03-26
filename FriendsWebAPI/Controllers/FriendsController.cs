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
        Friend friend = new Friend();

        // GET: api/Friends
        public IEnumerable<Friend> Get()
        {
            return _friendRepository.GetAll().ToList();
        }

        // GET: api/Friends/5
        public HttpResponseMessage GetById(Guid id)
        {
            var amg = _friendRepository.GetById(id);

            if (amg != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, amg);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Id {amg.Id} não encontrado");
            }
        }

        // POST: api/Friends
        public void Post([FromBody]Friend friend)
        {
            _friendRepository.Add(friend);
        }

        // PUT: api/Friends/5
        public HttpResponseMessage Put(Guid Id, [FromBody]Friend friend)
        {
            var amg = _friendRepository.Update(friend, Id);

            if (amg == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, amg);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Id {friend.Id} não encontrado");
            }
        }

        // DELETE: api/Friends/5
        public HttpResponseMessage Delete(Guid Id)
        {
            var amg = _friendRepository.Delete(Id);

            if (amg == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, amg);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Id {Id} não encontrado");
            }
        }
    }
}
