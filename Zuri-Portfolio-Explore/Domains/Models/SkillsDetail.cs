using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class SkillsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Skills is required")]
        [Column("skills")] // Maps to the "skills" column in the database
        public string Skills { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Column("user_id")] // Maps to the "user_id" column in the database
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Section ID is required")]
        [Column("section_id")] // Maps to the "section_id" column in the database
        public int SectionId { get; set; }
        public Section? Section { get; set; }
    }
}
