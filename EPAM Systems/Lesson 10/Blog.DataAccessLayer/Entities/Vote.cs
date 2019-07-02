using System;

namespace Blog.DataAccessLayer.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }
        public string VoteName { get; set; }
        public DateTime Date { get; set; }
    }
}