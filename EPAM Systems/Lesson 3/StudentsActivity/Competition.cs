using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsActivity
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public virtual ICollection<CompetitionStudentParticipation> CompetitionStudentParticipation { get; set; }
    }
}