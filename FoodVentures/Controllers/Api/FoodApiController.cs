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
        IFoodService _foodService = null;
        public FoodApiController(IFoodService foodService)
        {
            _foodService = foodService;
        }
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
                id = _foodService.Insert(model);
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

            List<Food> list = new List<Food>();
            list = _foodService.GetFoodById(personId);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteFoodById(int id)
        {
            try
            {
                _foodService.Delete(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
