using System.ComponentModel.DataAnnotations;
namespace AlwaysForward.Models
{
    public class Activity
    {
        public Activity()
        {

        }

        public int ActivityID { get; set; } 
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<ActivityCategory> Categories { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must contain two or more characters.")]
        [MaxLength(200, ErrorMessage = "Name cannot contain more than 200 characters.")]
        public string Name { get; set; }
        public bool isCompleted { get; set; }
        
    }
}
