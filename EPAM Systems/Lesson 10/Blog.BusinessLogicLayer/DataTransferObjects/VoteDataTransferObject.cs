using System;

namespace Blog.BusinessLogicLayer.DataTransferObjects
{
    public class VoteDataTransferObject
    {
        public int VoteId { get; set; }
        public string VoteName { get; set; }
        public DateTime Date { get; set; }
    }
}