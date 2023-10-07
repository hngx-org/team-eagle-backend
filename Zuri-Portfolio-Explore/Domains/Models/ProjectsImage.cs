using System.ComponentModel.DataAnnotations.Schema;

namespace Zuri_Portfolio_Explore.Domains.Models
{
    public class ProjectsImage
    {
        [Column("project_id")] // Maps to the "project_id" column in the database
        public int ProjectId { get; set; }

        [Column("image_id")] // Maps to the "image_id" column in the database
        public int ImageId { get; set; }
    }
}
