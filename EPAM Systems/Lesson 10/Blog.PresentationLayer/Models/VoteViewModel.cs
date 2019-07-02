using System;

namespace Blog.PresentationLayer.Models
{
    public class VoteViewModel
    {
        public int VoteId { get; set; }
        public string VoteName { get; set; }
        public DateTime Date { get; set; }
    }
}