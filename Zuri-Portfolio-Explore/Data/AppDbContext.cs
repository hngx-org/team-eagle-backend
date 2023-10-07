using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Domains.Models;

namespace Zuri_Portfolio_Explore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SkillsDetail> SkillsDetails { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocialUser> SocialUsers { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}
