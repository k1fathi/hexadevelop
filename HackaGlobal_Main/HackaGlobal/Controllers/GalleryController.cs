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
    public class GalleryController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly IGalleryRepository _galleryRepository;

        public GalleryController(IUnitOfWork db, IGalleryRepository galleryRepository)
        {
            _db = db;
            _galleryRepository = galleryRepository;
        }

        public HttpResponseMessage Get()
        {
            var gallerys = _galleryRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, gallerys);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var gallery = _galleryRepository.Find(id);
            if (gallery == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, gallery);
            return response;
        }

        public HttpResponseMessage Post(Gallery e)
        {
            if (ModelState.IsValid)
            {
                _galleryRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(Gallery e)
        {
            _galleryRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(Gallery e)
        {
            _galleryRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
