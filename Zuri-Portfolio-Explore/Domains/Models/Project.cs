using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title")] // Maps to the "title" column in the database
        public string Title { get; set; }

        [Column("year")] // Maps to the "year" column in the database
        public string Year { get; set; }

        [Column("url")] // Maps to the "url" column in the database
        public string Url { get; set; }

        [Column("tags")] // Maps to the "tags" column in the database
        public string Tags { get; set; }

        [Column("description")] // Maps to the "description" column in the database
        public string Description { get; set; }

        [Column("thumbnail")] // Maps to the "thumbnail" column in the database
        public int Thumbnail { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Column("user_id")] // Maps to the "user_id" column in the database
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Section ID is required")]
        [Column("section_id")] // Maps to the "section_id" column in the database
        public int SectionId { get; set; }
    }
}
