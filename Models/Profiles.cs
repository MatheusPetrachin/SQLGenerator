using System.ComponentModel.DataAnnotations.Schema;

namespace SQLGenerator.Models
{
    [Table("users")]
    public class Profiles
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
