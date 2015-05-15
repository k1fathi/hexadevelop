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
    public class UsersController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IUsersRepository _userRepository;

        public UsersController(IUnitOfWork db, IUsersRepository userRepository)
        {
            _db = db;
            _userRepository = userRepository;
        }

        public HttpResponseMessage Get()
        {
            var users = _userRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, users);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }

        public HttpResponseMessage Get(string name)
        {
            var users = _userRepository.Where(p => p.FullName.Contains(name));
            if (users == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, users);
            return response;
        }

        public HttpResponseMessage Post(User e)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(User e)
        {
            _userRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(User e)
        {
            _userRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
