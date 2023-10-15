using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class UserTrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Skills is required")]
        [Column("track_id")] // Maps to the "skills" column in the database
        public int TrackId { get; set; }
		public Track Track { get; set; }

		[Required(ErrorMessage = "User ID is required")]
        [Column("user_id")] // Maps to the "user_id" column in the database
        public Guid UserId { get; set; }
        public User User { get; set; }
       

    }
}
