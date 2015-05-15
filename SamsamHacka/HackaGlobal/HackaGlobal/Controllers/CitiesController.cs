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
    public class CitiesController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly ICitiesRepository _cityRepository;

        public CitiesController(IUnitOfWork db, ICitiesRepository cityRepository)
        {
            _db = db;
            _cityRepository = cityRepository;
        }

        public HttpResponseMessage Get()
        {
            var cities = _cityRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, cities);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var city = _cityRepository.Find(id);
            if (city == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, city);
            return response;
        }

        public HttpResponseMessage Post(City e)
        {
            if (ModelState.IsValid)
            {
                _cityRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(City e)
        {
            _cityRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(City e)
        {
            _cityRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
