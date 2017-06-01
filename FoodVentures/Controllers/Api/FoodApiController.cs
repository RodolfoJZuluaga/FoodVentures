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
    [RoutePrefix("Api/Food")]
    public class FoodApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Insert(FoodAddRequest model)
        {
            int id;
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
                FoodService svc = new FoodService();
                id = svc.Insert(model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
        [Route("person/{personId:int}"), HttpGet]
        public HttpResponseMessage GetFoodById(int personId)
        {

            FoodService svc = new FoodService();
            List<Food> list = new List<Food>();
            list = svc.GetFoodById(personId);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteFoodById(int id)
        {
            FoodService svc = new FoodService();
            svc.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
