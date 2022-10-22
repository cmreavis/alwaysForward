using System;
using System.Collections.Generic;
using AlwaysForward.Models;

namespace AlwaysForward
{
    public interface IActivityRepository
    {
        public IEnumerable<Activity> GetAllActivities();
    }
}
