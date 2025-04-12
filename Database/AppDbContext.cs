using ApplicationHelper.Domain;
using ApplicationHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ApplicationHelper.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<InterviewNote> Interviews { get; set; }
        public DbSet<DuringInterviewNote> DuringInterview { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=applicationCountingApp; User Id=sa; Password=Password12;");
            }
        }
    }
}
