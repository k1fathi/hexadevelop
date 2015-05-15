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
    public class TeamUsersController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly ITeamUsersRepository _teamUserRepository;

        public TeamUsersController(IUnitOfWork db, ITeamUsersRepository teamUserRepository)
        {
            _db = db;
            _teamUserRepository = teamUserRepository;
        }

        public HttpResponseMessage Get()
        {
            var teamUsers = _teamUserRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, teamUsers);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var teamUser = _teamUserRepository.Find(id);
            if (teamUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, teamUser);
            return response;
        }

        public HttpResponseMessage Post(TeamUser e)
        {
            if (ModelState.IsValid)
            {
                _teamUserRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(TeamUser e)
        {
            _teamUserRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(TeamUser e)
        {
            _teamUserRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
