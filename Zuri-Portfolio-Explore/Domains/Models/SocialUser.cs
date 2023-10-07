using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class SocialUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Column("user_id")] // Maps to the "user_id" column in the database
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Social Media ID is required")]
        [Column("social_media_id")] // Maps to the "social_media_id" column in the database
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }

        [Required(ErrorMessage = "URL is required")]
        [Column("url")] // Maps to the "url" column in the database
        public string Url { get; set; }
    }
}
