using FoodVentures.Models.Domain;
using FoodVentures.Models.ViewModels;
using FoodVentures.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodVentures.Controllers
{
    [RoutePrefix("fv")]
    public class DashboardController : Controller
    {
        IPersonService _personService = null;
        public DashboardController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: Dashboard
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route]
        public ActionResult Details()
        {
            ItemViewModel<int, int> model = new ItemViewModel<int, int>();
            string id = User.Identity.GetUserId();
            Person p = new Person();
            p = _personService.SelectByUserId(id);
            model.Item1 = p.Id;
            model.Item2 = p.Id;
            return View(model);
        }
        [Route("{id:int}")]
        [Route("{userUrl}")]
        public ActionResult Details(int id = 0, string userUrl = "")
        {
            ItemViewModel<int, int> model = new ItemViewModel<int, int>();
            string userId = User.Identity.GetUserId();
            Person targetUser = new Person();
            targetUser = _personService.Select(id);
            model.Item1 = targetUser.Id;
            if (userId == null)
            {
                return View(model);
            }
            else
            {
                Person currentUser = new Person();
                currentUser = _personService.SelectByUserId(userId);
                model.Item2 = currentUser.Id;
                return View(model);
            }
        }

    }
}