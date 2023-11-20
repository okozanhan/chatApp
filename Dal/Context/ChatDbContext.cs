using Dal.Entity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Reflection;


namespace Dal.Context
{
    public class ChatDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           var connectionString="server=localhost;port=3306;database=chatapp;user=root;password=kkgg34174.";
            // optionsBuilder.UseMySql("server=localhost;port=3306;database=chatapp;user=root;password=kkgg34174.");
            optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            // optionsBuilder.UseSqlServer("Server=DESKTOP-1KD6P84\\SQLEXPRESS;Database=chatAppDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
