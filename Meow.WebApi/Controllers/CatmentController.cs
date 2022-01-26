using Meow.Models;
using Meow.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Meow.WebApi.Controllers
{
        [Authorize]
        [RoutePrefix("api/catment")]
        public class CatmentController : ApiController
        {
            public IHttpActionResult Get()
            {
                CatmentService catmentService = CreateCatmentService();
                var catments = catmentService.GetCatmentsGet();
                return Ok(catments);
            }
            public IHttpActionResult Post(CatmentCreate catment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatmentService();

            if (!service.CreateCatment(catment))
                return InternalServerError();

            return Ok();
        }

            private CatmentService CreateCatmentService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var catmentService = new CatmentService(userId);
                return catmentService;
            }

            public IHttpActionResult Get(int id)
            {
                CatmentService catmentService = CreateCatmentService();
                var catments = catmentService.GetCatmentById(id);
                return Ok(catments);
            }

            public IHttpActionResult Put(CatmentEdit catment)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateCatmentService();

                if (!service.UpdateCatment(catment))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateCatmentService();

                if (!service.DeleteCatment(id))
                    return InternalServerError();

                return Ok();
            }

        }
    }

