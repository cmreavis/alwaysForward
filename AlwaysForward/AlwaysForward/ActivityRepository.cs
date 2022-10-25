using AlwaysForward.Models;
using Dapper;
using System.Data;

namespace AlwaysForward
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDbConnection _conn;

        public ActivityRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        //GET
        public IEnumerable<Activity> GetAllActivities()
        {
            return _conn.Query<Activity>("SELECT * FROM ACTIVITIES;");
        }

        public Activity GetActivity(int id)
        {
            return _conn.QuerySingle<Activity>("SELECT * FROM ACTIVITIES WHERE ActivityID = @id;", 
                new { id = id });
        }

        //POST
        public void InsertActivity(Activity activityToInsert)
        {
            _conn.Execute("INSERT INTO activites (Name, Description, Complete) VALUES (@activityName, @description, 0);",
                new { activityName = activityToInsert.Name, description = activityToInsert.Description });
        }

        //PUT
        public void UpdateActivity(Activity activity)
        {
            _conn.Execute("UPDATE activities SET Name = @activityName, Description = @description WHERE ActivityID = @id;", 
                new { activityName = activity.Name, description = activity.Description, id = activity.ActivityID });
        }
        public void ActivityComplete(Activity activity)
        {
            _conn.Execute("UPDATE activites SET complete = ")
        }
        //DELETE
        public void DeleteActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

    }
}
