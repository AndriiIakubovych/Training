using System;

namespace WebService
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public DateTime BeginningTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}