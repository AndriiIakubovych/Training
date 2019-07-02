using System.ComponentModel.DataAnnotations;

namespace Blog.PresentationLayer.Models
{
    public class TestResultViewModel
    {
        public int ResultId { get; set; }
        [Required(ErrorMessage = "Respondent name is required!")]
        public string RespondentName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        [Required(ErrorMessage = "Country of residence is required!")]
        public string Country { get; set; }
        public string HasComputerEducation { get; set; }
        public string FoundOutBy { get; set; }
        public string ComputerType { get; set; }
        public string OperationSystem { get; set; }
        public string ReadsOtherBlogs { get; set; }
    }
}