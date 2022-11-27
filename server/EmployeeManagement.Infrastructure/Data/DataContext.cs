using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Entities.Authentication;

namespace EmployeeManagement.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region EMPLOYEES TABLES
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        #endregion

        #region AUTHENTICATION TABLES
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.HireDate).ValueGeneratedOnAdd();
                
                entity.HasOne(e => e.Position)
                .WithMany(e => e.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(e => e.PositionID);
            });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Rol)
                .WithMany(e => e.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(e => e.RolID);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Department)
                .WithMany(e => e.Positions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(e => e.DepartmentID);
            });
        }
    }
}
