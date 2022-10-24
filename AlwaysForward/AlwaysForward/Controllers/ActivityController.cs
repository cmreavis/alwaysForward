using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlwaysForward.Models;

namespace AlwaysForward.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository repo;

        public ActivityController(IActivityRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var activities = repo.GetAllActivities();
            return View(activities);
        }

        public IActionResult ViewActivity(int id)
        {
            var activity = repo.GetActivity(id);
            return View(activity);
        }

        //public IActionResult UpdateActivity()
        //{
        //    Activity act = repo.
        //}
    }
}
