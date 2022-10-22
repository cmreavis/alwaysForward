namespace AlwaysForward.Models
{
    public class Activity
    {
        public Activity()
        {

        }

        public int ActivityID { get; set; } 
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }
        public int CategoryID { get; set; }

    }
}
