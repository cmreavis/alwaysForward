using System;
using System.Collections.Generic;
using AlwaysForward.Models;

namespace AlwaysForward
{
    public interface IActivityRepository
    {
        public IEnumerable<Activity> GetAllActivities();
        public IEnumerable<Activity> GetCompletedActivities();
        public IEnumerable<ActivityCategory> GetActivityCategories();
        public Activity GetActivity(int id);
        public void InsertActivity(Activity activityToInsert);
        public void UpdateActivity(Activity activity);
        public void CompleteActivity(Activity activityToComplete);
        public Activity AssignCategory();
        public void DeleteActivity(Activity activity);

    }



}
