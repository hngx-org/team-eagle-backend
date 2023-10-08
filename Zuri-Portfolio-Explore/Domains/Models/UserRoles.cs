using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        [Column("role_id")] // Maps to the "role_id" column in the database
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Column("user_id")] // Maps to the "user_id" column in the database
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Column("created_at")] // Maps to the "created_at" column in the database
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
