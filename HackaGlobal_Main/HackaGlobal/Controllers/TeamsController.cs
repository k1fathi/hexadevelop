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
    public class TeamsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly ITeamsRepository _teamRepository;

        public TeamsController(IUnitOfWork db, ITeamsRepository teamRepository)
        {
            _db = db;
            _teamRepository = teamRepository;
        }

        public HttpResponseMessage Get()
        {
            var teams = _teamRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, teams);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var team = _teamRepository.Find(id);
            if (team == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, team);
            return response;
        }

        public HttpResponseMessage Post(Team e)
        {
            if (ModelState.IsValid)
            {
                _teamRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(Team e)
        {
            _teamRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(Team e)
        {
            _teamRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
