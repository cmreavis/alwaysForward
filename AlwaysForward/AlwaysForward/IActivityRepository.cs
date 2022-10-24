using System;
using System.Collections.Generic;
using AlwaysForward.Models;

namespace AlwaysForward
{
    public interface IActivityRepository
    {
        public IEnumerable<Activity> GetAllActivities();
        public Activity GetActivity(int id);
        public void InsertActivity(Activity activityToInsert);
        public void UpdateActivity(Activity activity);
        public void DeleteActivity(Activity activity);

    }



}
