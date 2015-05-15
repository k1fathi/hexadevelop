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
    public class CityOrganizersController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly ICityOrganizersRepository _citiyOrgRepository;

        public CityOrganizersController(IUnitOfWork db, ICityOrganizersRepository citiyOrgRepository)
        {
            _db = db;
            _citiyOrgRepository = citiyOrgRepository;
        }

        public HttpResponseMessage Get()
        {
            var citiyOrgs = _citiyOrgRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, citiyOrgs);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var citiyOrg = _citiyOrgRepository.Find(id);
            if (citiyOrg == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, citiyOrg);
            return response;
        }

        public HttpResponseMessage Post(CityOrganizer e)
        {
            if (ModelState.IsValid)
            {
                _citiyOrgRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(CityOrganizer e)
        {
            _citiyOrgRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(CityOrganizer e)
        {
            _citiyOrgRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
