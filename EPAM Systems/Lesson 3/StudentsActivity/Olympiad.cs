using System.Collections.Generic;

namespace StudentsActivity
{
    public class Olympiad
    {
        public int OlympiadId { get; set; }
        public string OlympiadName { get; set; }
        public virtual ICollection<OlympiadStudentParticipation> OlympiadStudentParticipation { get; set; }
    }
}