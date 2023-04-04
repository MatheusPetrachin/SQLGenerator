using System.ComponentModel.DataAnnotations.Schema;

namespace SQLGenerator.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public string UserId { get; set; }
        public string ProfileId { get; set; }
    }
}
