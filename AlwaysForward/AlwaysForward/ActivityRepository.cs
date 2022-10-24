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

        Activity IActivityRepository.GetActivity(int id)
        {
            return _conn.QuerySingle("SELECT * FROM ACTIVITIES WHERE ActivityID = @id;", 
                new { id = id });
        }

        //POST
        void IActivityRepository.InsertActivity(Activity activityToInsert)
        {
            _conn.Execute("INSERT INTO activites (Name, Description, Complete) VALUES (@activityName, @description, 0);",
                new { activityName = activityToInsert.Name, description = activityToInsert.Description });
        }

        //PUT
        void IActivityRepository.UpdateActivity(Activity activity)
        {
            _conn.Execute("UPDATE activities SET Name = @activityName, Description = @description WHERE ActivityID = @id;", 
                new { activityName = activity.Name, description = activity.Description, id = activity.ActivityID });
        }
        //DELETE
        void IActivityRepository.DeleteActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

    }
}
