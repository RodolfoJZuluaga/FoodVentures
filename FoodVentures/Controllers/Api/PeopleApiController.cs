﻿using FoodVentures.Models.Domain;
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
    [RoutePrefix("Api/People")]
    public class PeopleApiController : ApiController
    {
        IPersonService _personService = null;
        public PeopleApiController(IPersonService personService)
        {
            _personService = personService;
        }
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage Select(int id)
        {
            Person p = new Person();
            try
            {
                p = _personService.Select(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, p);
        }
        [Route("{id:int}/edit"), HttpPut]
        public HttpResponseMessage Edit(int id, PersonUpdateRequest model)
        {
            model.Id = id;
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
                _personService.UpdatePerson(model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "way to go!");
        }
    }
}
