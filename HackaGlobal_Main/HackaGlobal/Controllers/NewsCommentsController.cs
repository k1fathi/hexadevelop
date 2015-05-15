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
    public class NewsCommentsController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly INewsCommentsRepository _newsCommentRepository;

        public NewsCommentsController(IUnitOfWork db, INewsCommentsRepository newsCommentRepository)
        {
            _db = db;
            _newsCommentRepository = newsCommentRepository;
        }

        public HttpResponseMessage Get()
        {
            var newsComments = _newsCommentRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, newsComments);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var newsComment = _newsCommentRepository.Find(id);
            if (newsComment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, newsComment);
            return response;
        }

        public HttpResponseMessage Post(NewsComment e)
        {
            if (ModelState.IsValid)
            {
                _newsCommentRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(NewsComment e)
        {
            _newsCommentRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(NewsComment e)
        {
            _newsCommentRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
