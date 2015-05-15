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
    public class EventCommentsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IEventCommentsRepository _eventCommentRepository;

        public EventCommentsController(IUnitOfWork db, IEventCommentsRepository eventCommentRepository)
        {
            _db = db;
            _eventCommentRepository = eventCommentRepository;
        }

        public HttpResponseMessage Get()
        {
            var eventComments = _eventCommentRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, eventComments);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var eventComment = _eventCommentRepository.Find(id);
            if (eventComment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, eventComment);
            return response;
        }

        public HttpResponseMessage Post(EventComment e)
        {
            if (ModelState.IsValid)
            {
                _eventCommentRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(EventComment e)
        {
            _eventCommentRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(EventComment e)
        {
            _eventCommentRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
