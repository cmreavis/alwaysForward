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
        //CREATE
        public IActionResult InsertActivity()
        {
            var act = repo.AssignCategory();
            return View(act);
        }

        public IActionResult InsertActivityToDatabase(Activity activityToInsert)
        {
            repo.InsertActivity(activityToInsert);
            return RedirectToAction("Index");
        }

        //READ
        public IActionResult Index()
        {
            var activities = repo.GetAllActivities();
            Activity act = repo.AssignCategory();
            foreach(var activ in activities)
            {
                activ.CategoryName = act.CategoryName;
            }
            return View(activities);
        }

        public IActionResult ViewActivity(int id)
        {
            var activity = repo.GetActivity(id);
            return View(activity);
        }

        //UPDATE
        public IActionResult UpdateActivity(int id)
        {
            var activity = repo.AssignCategory(); //Empty activity model with list of categories

            Activity act = repo.GetActivity(id); //Gets rest of activity at id
            if (act == null)
            {
                return View("ActivityNotFound");
            }

            act.Categories = activity.Categories; //Sets IEnumerable of categories to the grabbed cats from AssignCategory() above

            return View(act);
        }

        public IActionResult UpdateActivityToDatabase(Activity act)
        {
            repo.UpdateActivity(act);

            return RedirectToAction("ViewActivity", new { id = act.ActivityID });
        }
        public IActionResult ActivityCompleteToggle(int id)
        {
            var act = repo.GetActivity(id);
            if (act != null)
            {
                act.IsCompleted = !act.IsCompleted;
                repo.ActivityCompleteToggle(act);
            }
            return View("Index");
        }
        //DELETE
        public IActionResult DeleteActivity(Activity act)
        {
            repo.DeleteActivity(act);

            return RedirectToAction("Index");
        }

    }
}
