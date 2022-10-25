﻿namespace AlwaysForward.Models
{
    public class Activity
    {
        public Activity()
        {

        }

        public int ActivityID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<ActivityCategory> Categories { get; set; }
        
    }
}
