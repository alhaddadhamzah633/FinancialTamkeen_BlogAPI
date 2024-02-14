using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment
{
    public class EmployeeDbContext :DbContext
    {

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> context) : base(context)
        {
            
        }
        
        public DbSet<Employee> employee { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //Property Configurations
            modelBuilder.Entity<Employee>()
                    .Property(s => s.EmployeeID)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValue(0)
                    .IsRequired();

            //Separate method calls
            modelBuilder.Entity<Employee>().Property(s => s.EmployeeID).HasColumnName("EmployeeID");
            modelBuilder.Entity<Employee>().Property(s => s.EmployeeID).HasDefaultValue(0);
            modelBuilder.Entity<Employee>().Property(s => s.EmployeeID).IsRequired();


            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            }); 
        }
    }
}
