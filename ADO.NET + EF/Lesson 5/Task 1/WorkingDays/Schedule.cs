using System;
using System.Data.Linq.Mapping;

namespace WorkingDays
{
    [Table()]
    sealed class Schedule
    {
        [Column(Name = "Schedule_id", DbType = "int", IsPrimaryKey = true)]
        public int ScheduleId { get; set; }

        [Column(Name = "Employee_name", DbType = "varchar(50)", CanBeNull = false)]
        public string EmployeeName { get; set; }

        [Column(Name = "Working_period_beginning", DbType = "datetime", CanBeNull = false)]
        public DateTime WorkingPeriodBeginning { get; set; }

        [Column(Name = "Working_period_end", DbType = "datetime", CanBeNull = false)]
        public DateTime WorkingPeriodEnd { get; set; }
    }
}