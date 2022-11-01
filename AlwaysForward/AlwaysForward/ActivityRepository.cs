using AlwaysForward.Models;
using Dapper;
using System.Data;
using System.Drawing.Design;

namespace AlwaysForward
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDbConnection _conn;

        public ActivityRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //CREATE
        public void InsertActivity(Activity activityToInsert)
        {
            _conn.Execute("INSERT INTO ACTIVITIES (Name, Description, Complete, CategoryID) VALUES (@activityName, @description, 0, @categoryID );",
                new { activityName = activityToInsert.Name, description = activityToInsert.Description, categoryID = activityToInsert.CategoryID });
        }

        //READ
        public IEnumerable<Activity> GetAllActivities()
        {
            return _conn.Query<Activity>("SELECT * FROM ACTIVITIES;");
        }
        public Activity GetActivity(int id)
        {
            return _conn.QueryFirstOrDefault<Activity>("SELECT * FROM ACTIVITIES WHERE ActivityID = @id;", 
                new { id = id });
        }
       
        public IEnumerable<ActivityCategory> GetActivityCategories()
        {
            return _conn.Query<ActivityCategory>("SELECT * FROM categories;");
        }


        //UPDATE
        public Activity AssignCategory()
        {
            var categoryList = GetActivityCategories();
            var activity = new Activity();
            activity.Categories = categoryList;
            return activity;
        }
        public void UpdateActivity(Activity activity)
        {
            _conn.Execute("UPDATE activities SET Name = @activityName, Description = @description, CategoryID = @categoryID WHERE ActivityID = @id;", 
                new { activityName = activity.Name, description = activity.Description, categoryID = activity.CategoryID, id = activity.ActivityID });
        }
        public void ActivityCompleteToggle(Activity activity)
        {
            _conn.Execute("UPDATE activites SET complete = @isComplete WHERE ActivityID = @id;",
                new { id = activity.ActivityID, isComplete = activity.IsCompleted});
        }

        //DELETE
        public void DeleteActivity(Activity activity)
        {
            _conn.Execute("DELETE FROM activities WHERE ActivityID = @id;", 
                new { id = activity.ActivityID });
        }


    }
}
