﻿using FoodVentures.Models.Requests;
using FoodVentures.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodVentures.Controllers.Api
{
    [RoutePrefix("api/foodtags")]
    public class FoodTagsApiController : ApiController
    {
        IFoodTagsService _foodTagsService = null;
        public FoodTagsApiController(IFoodTagsService foodTagsService)
        {
            _foodTagsService = foodTagsService;
        }
        [Route, HttpPost]
        public HttpResponseMessage Insert(List<FoodTagsAddRequest> list)
        {
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
                _foodTagsService.Insert(list);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
