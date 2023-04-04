using System.ComponentModel.DataAnnotations.Schema;

namespace SQLGenerator.Models
{
    [Table("users")]
    public class Users
    {
        public Users(
            string id,
            string name,
            string lastName,
            string email,
            string password,
            int yearsOld
        )
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            YearsOld = yearsOld;
        }

        
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int YearsOld { get; set; }
    }
}
