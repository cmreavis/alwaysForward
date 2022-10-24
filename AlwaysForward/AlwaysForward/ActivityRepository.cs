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


        //POST
        void IActivityRepository.InsertActivity(Activity activityToInsert)
        {
            _conn.Execute("INSERT INTO activites (Name, Description, Complete) VALUES (@activityName, @description, 0);",
                new { activityName = activityToInsert.ActivityName, description = activityToInsert.Description });
        }

        //PUT
        void IActivityRepository.UpdateActivity(Activity activity)
        {
            throw new NotImplementedException();
        }
        //DELETE
        void IActivityRepository.DeleteActivity(Activity activity)
        {
            throw new NotImplementedException();
        }


    }
}
