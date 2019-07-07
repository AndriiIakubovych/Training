using System.Data.Linq.Mapping;

namespace WorkingDays
{
    [Table()]
    class WorkingWeek
    {
        [Column(Name = "Weekday_number", DbType = "int", IsPrimaryKey = true)]
        public int WeekdayNumber { get; set; }

        [Column(Name = "Schedule_id", DbType = "int", IsPrimaryKey = true)]
        public int ScheduleId { get; set; }
    }
}