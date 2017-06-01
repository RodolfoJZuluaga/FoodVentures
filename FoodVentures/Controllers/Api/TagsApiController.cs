using FoodVentures.Models.Domain;
using FoodVentures.Models.Requests;
using FoodVentures.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodVentures.Controllers.Api
{
    [RoutePrefix("Api/Tags")]
    public class TagsApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage Select([FromUri]List<string> names)
        {
            List<Tag> list = new List<Tag>();
            try
            {
                TagsService svc = new TagsService();
                list = svc.Select(names);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
        [Route, HttpPost]
        public HttpResponseMessage Insert(TagsAddRequest model)
        {
            List<Tag> list = new List<Tag>();
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }
            try
            {
                TagsService svc = new TagsService();
                list = svc.Insert(model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}
