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
    public class EventLikesController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IEventLikesRepository _eventLikeRepository;

        public EventLikesController(IUnitOfWork db, IEventLikesRepository eventLikeRepository)
        {
            _db = db;
            _eventLikeRepository = eventLikeRepository;
        }

        public HttpResponseMessage Get()
        {
            var eventLikes = _eventLikeRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, eventLikes);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var eventLike = _eventLikeRepository.Find(id);
            if (eventLike == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, eventLike);
            return response;
        }

        public HttpResponseMessage Post(EventLike e)
        {
            if (ModelState.IsValid)
            {
                _eventLikeRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(EventLike e)
        {
            _eventLikeRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(EventLike e)
        {
            _eventLikeRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
