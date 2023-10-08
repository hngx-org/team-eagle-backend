using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(255)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [StringLength(255)]
        public string Location { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(255)]
        [Column("first_name")] // Maps to the "first_name" column in the database
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(255)]
        [Column("last_name")] // Maps to the "last_name" column in the database
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Column("section_order")] // Maps to the "section_order" column in the database
        public string SectionOrder { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Provider { get; set; }

        [Column("profile_pic")] // Maps to the "profile_pic" column in the database
        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Refresh Token is required")]
        [StringLength(255)]
        [Column("refresh_token")] // Maps to the "refresh_token" column in the database
        public string RefreshToken { get; set; }

        [Column("created_at")] // Maps to the "created_at" column in the database
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<SkillsDetail> SkillDetails {get; set;}
        public List<Project> Projects {get; set;}
    }
}
