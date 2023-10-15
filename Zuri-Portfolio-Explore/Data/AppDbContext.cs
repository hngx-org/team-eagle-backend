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
        public DbSet<Section> Sections { get; set; }
        public DbSet<SkillsDetail> SkillsDetails { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocialUser> SocialUsers { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserTrack> UserTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("user"); 
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<SkillsDetail>().ToTable("skills_detail");
            modelBuilder.Entity<Project>().ToTable("project");
            modelBuilder.Entity<UserTrack>().ToTable("user_track");
            modelBuilder.Entity<Track>().ToTable("tracks");
        }
    }
}
