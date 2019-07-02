using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DataAccessLayer.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("BlogUser")]
        public string UserId { get; set; }
        public virtual BlogUser BlogUser { get; set; }
    }
}