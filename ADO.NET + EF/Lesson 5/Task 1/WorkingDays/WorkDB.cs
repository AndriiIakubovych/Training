using System.Data.Linq;

namespace WorkingDays
{
    class WorkDB : DataContext
    {
        public Table<Schedule> schedule;
        public Table<WorkingWeek> workingWeek;

        public WorkDB(string connectionString) : base(connectionString) { }
    }
}