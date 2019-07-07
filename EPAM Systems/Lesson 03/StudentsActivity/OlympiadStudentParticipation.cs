using System;

namespace StudentsActivity
{
    public class OlympiadStudentParticipation
    {
        public int ParticipationId { get; set; }
        public int StudentId { get; set; }
        public int OlympiadId { get; set; }
        public DateTime ParticipationDate { get; set; }
        public string Place { get; set; }
        public string Results { get; set; }
        public Student Student { get; set; }
        public Olympiad Olympiad { get; set; }
    }
}