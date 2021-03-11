using System.ComponentModel.DataAnnotations;

namespace EntityModels.Users
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public Role Role { get; set; }
    }
}
