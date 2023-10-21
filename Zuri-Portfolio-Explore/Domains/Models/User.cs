using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }
        [StringLength(255)]
        [Column("username")]
        public string? Username { get; set; }
        [Column("slug")]
        public string? Slug { get; set; }
        [Column("country")]
        [StringLength(255)]
        public string? Country { get; set; }
        [StringLength(255)]
        [Column("location")]
        public string? Location { get; set; }
        [StringLength(255)]
        [Column("first_name")] // Maps to the "first_name" column in the database
        public string? FirstName { get; set; }
        [StringLength(255)]
        [Column("last_name")] // Maps to the "last_name" column in the database
        public string? LastName { get; set; }
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column("email")]
        public string? Email { get; set; }

        [Column("section_order")] // Maps to the "section_order" column in the database
        public string? SectionOrder { get; set; }

        [StringLength(255)]
        [Column("password")]
        public string? Password { get; set; }

        [StringLength(255)]
        [Column("provider")]
        public string? Provider { get; set; }

        [Column("profile_pic")] // Maps to the "profile_pic" column in the database
        public string? ProfilePicture { get; set; }

        [StringLength(255)]
        [Column("refresh_token")] // Maps to the "refresh_token" column in the database
        public string? RefreshToken { get; set; }

        [Column("createdAt")] // Maps to the "created_at" column in the database
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<SkillsDetail> SkillDetails { get; set; }
        public List<UserTrack> UserTrack { get; set; }
        public List<Project> Projects { get; set; }
        //public UserRoles UserRoles { get; set; }
    }
}
