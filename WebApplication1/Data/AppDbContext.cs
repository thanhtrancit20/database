using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistory { get; set; }
        public DbSet<AppFile> AppFiles { get; set; }
        public DbSet<LibCountry> LibCountries { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<SpaceMember> SpaceMembers { get; set; }
        public DbSet<Suite> Suites { get; set; }
        public DbSet<SuiteMember> SuiteMembers { get; set; }
        public DbSet<SuiteRoom> SuiteRooms { get; set; }
        public DbSet<SuiteRoomUser> SuiteRoomUsers { get; set; }
        public DbSet<SuiteRoomStage> SuiteRoomStages { get; set; }
        public DbSet<SuiteTask> SuiteTasks { get; set; }
        public DbSet<SuiteTaskUser> SuiteTaskUsers { get; set; }
        public DbSet<TaskChatMessage> TaskChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
