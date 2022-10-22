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

        //POST

        //GET
        public IEnumerable<Activity> GetAllActivities()
        {
            return _conn.Query<Activity>("SELECT * FROM ACTIVITIES;");
        }

        //PUT

        //DELETE
    }
}
