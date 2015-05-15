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
    public class EventsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IEventsRepository _eventRepository;

        public EventsController(IUnitOfWork db, IEventsRepository eventRepository)
        {
            _db = db;
            _eventRepository = eventRepository;
        }

        public HttpResponseMessage Get()
        {
            var events = _eventRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, events);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var _event = _eventRepository.Find(id);
            if (_event == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, _event);
            return response;
        }

        public HttpResponseMessage Post(Event e)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(Event e)
        {
            _eventRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(Event e)
        {
            _eventRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
