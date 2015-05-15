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
    public class EventSponsorsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IEventSponsorsRepository _eventSponsRepository;

        public EventSponsorsController(IUnitOfWork db, IEventSponsorsRepository eventSponsRepository)
        {
            _db = db;
            _eventSponsRepository = eventSponsRepository;
        }

        public HttpResponseMessage Get()
        {
            var eventSponss = _eventSponsRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, eventSponss);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var eventSpons = _eventSponsRepository.Find(id);
            if (eventSpons == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, eventSpons);
            return response;
        }

        public HttpResponseMessage Post(EventSponsor e)
        {
            if (ModelState.IsValid)
            {
                _eventSponsRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(EventSponsor e)
        {
            _eventSponsRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(EventSponsor e)
        {
            _eventSponsRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
