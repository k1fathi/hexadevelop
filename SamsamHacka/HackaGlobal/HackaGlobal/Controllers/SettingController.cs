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
    public class SettingController : ApiController
    {
        private readonly IUnitOfWork _db;
        private readonly ISettingRepository _settingRepository;

        public SettingController(IUnitOfWork db, ISettingRepository settingRepository)
        {
            _db = db;
            _settingRepository = settingRepository;
        }

        public HttpResponseMessage Get()
        {
            var settings = _settingRepository.Select().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, settings);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var setting = _settingRepository.Find(id);
            if (setting == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, setting);
            return response;
        }

        public HttpResponseMessage Post(Setting e)
        {
            if (ModelState.IsValid)
            {
                _settingRepository.Add(e);
                var response = Request.CreateResponse(HttpStatusCode.Created, e);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = e.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(Setting e)
        {
            _settingRepository.Update(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }

        public HttpResponseMessage Delete(Setting e)
        {
            _settingRepository.Delete(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, e);
            return response;
        }
    }
}
