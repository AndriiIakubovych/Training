using System;
using System.Collections.Generic;

namespace StudentsActivity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string University { get; set; }
        public int Course { get; set; }
        public virtual ICollection<OlympiadStudentParticipation> OlympiadStudentParticipation { get; set; }
        public virtual ICollection<CompetitionStudentParticipation> CompetitionStudentParticipation { get; set; }
    }
}