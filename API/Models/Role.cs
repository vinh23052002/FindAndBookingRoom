using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int roleID { get; set; }
        public string roleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
