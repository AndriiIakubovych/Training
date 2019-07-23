using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsitesPerformanceEvaluating.Models
{
    public class Test
    {
        public int TestId { get; set; }
        [Required(ErrorMessage = "URL is required!")]
        public string Website { get; set; }
        public DateTime TestDate { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}