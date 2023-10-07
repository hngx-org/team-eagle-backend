using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class SocialMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column("name")] // Maps to the "name" column in the database
        public string Name { get; set; }
    }
}
