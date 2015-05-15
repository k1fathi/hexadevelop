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
    public class CitySponsorsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly ICitySponsorsRepository _citySponsRepository;

        public CitySponsorsController(IUnitOfWork db, ICitySponsorsRepository citySponsRepository)
        {
            _db = db;
            _citySponsRepository = citySponsRepository;
        }

        public HttpResponseMessage Get()
        {
            var citySponss = _citySponsRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, citySponss);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var citySpons = _citySponsRepository.Find(id);
            if (citySpons == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, citySpons);
            return response;
        }

        public HttpResponseMessage Post(CitySponsor e)
        {
            if (ModelState.IsValid)
            {
                _citySponsRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(CitySponsor e)
        {
            _citySponsRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(CitySponsor e)
        {
            _citySponsRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
