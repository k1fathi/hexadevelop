using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HackaGlobal.Models;
using HackaGlobal.Models.Interfaces;

namespace HackaGlobal.Controllers
{
    public class EventMembersController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IEventMembersRepository _eventMemberRepository;

        public EventMembersController(IUnitOfWork db, IEventMembersRepository eventMemberRepository)
        {
            _db = db;
            _eventMemberRepository = eventMemberRepository;
        }

        public HttpResponseMessage Get()
        {
            var eventMembers = _eventMemberRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, eventMembers);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var eventMember = _eventMemberRepository.Find(id);
            if (eventMember == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, eventMember);
            return response;
        }

        public HttpResponseMessage Post(EventMember e)
        {
            if (ModelState.IsValid)
            {
                _eventMemberRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(EventMember e)
        {
            _eventMemberRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(EventMember e)
        {
            _eventMemberRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
