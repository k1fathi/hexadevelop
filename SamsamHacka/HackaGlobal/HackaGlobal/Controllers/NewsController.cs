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
    public class NewsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly INewsRepository _newsRepository;

        public NewsController(IUnitOfWork db, INewsRepository newsRepository)
        {
            _db = db;
            _newsRepository = newsRepository;
        }

        public HttpResponseMessage Get()
        {
            var newss = _newsRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, newss);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var news = _newsRepository.Find(id);
            if (news == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, news);
            return response;
        }

        public HttpResponseMessage Post(News e)
        {
            if (ModelState.IsValid)
            {
                _newsRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(News e)
        {
            _newsRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(News e)
        {
            _newsRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
