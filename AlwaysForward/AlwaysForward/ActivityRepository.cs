using AlwaysForward.Models;
using Activity = AlwaysForward.Models.Activity;
using Dapper;
using System.Data;
using System.Diagnostics;
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
            _conn.Execute("INSERT INTO ACTIVITIES (Name, Description, CategoryID) VALUES (@activityName, @description, @categoryID );",
                new { activityName = activityToInsert.Name, description = activityToInsert.Description, categoryID = activityToInsert.CategoryID });
        }

        //READ
        public IEnumerable<Activity> GetAllActivities()
        {
            return _conn.Query<Activity>("SELECT * FROM ACTIVITIES;");
        }
        public IEnumerable<Activity> GetCompletedActivities()
        {
            return _conn.Query<Activity>("SELECT * FROM COMPLETED;");
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

        //DELETE
        public void DeleteActivity(Activity activity)
        {
            _conn.Execute("DELETE FROM activities WHERE ActivityID = @id;", 
                new { id = activity.ActivityID });
        }
        public void CompleteActivity(Activity actToComplete)
        {
            _conn.Execute("INSERT INTO completed VALUES (@id, @name, @description, @categoryid);",
                new { id = actToComplete.ActivityID, name = actToComplete.Name, description = actToComplete.Description, categoryid = actToComplete.CategoryID });     
            _conn.Execute("DELETE FROM activities WHERE ActivityID = @id;",
                new { id = actToComplete.ActivityID });
        }
    }
}
