using System;
using System.Collections.Generic;
using AlwaysForward.Models;

namespace AlwaysForward
{
    public interface IActivityRepository
    {
        public IEnumerable<Activity> GetAllActivities();
        public void InsertActivity(Activity activityToInsert);
        public void UpdateActivity(Activity activity);
        public void DeleteActivity(Activity activity);

    }



}
