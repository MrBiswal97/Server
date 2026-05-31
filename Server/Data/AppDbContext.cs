using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions options):base(options) {
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TaskAssignment> Assignments { get; set; }
        public DbSet<TaskItem> Task {  get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(u => u.UserEnail)
                .IsRequired()
                .HasMaxLength(150);
            });

            // Project
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(u => u.ProjectId);

                entity.Property(u => u.ProjectName)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(u => u.ProjectDescriiption)
                .IsRequired()
                .HasMaxLength(1000);

                // create relationship (User -> Project)
                entity.HasOne(p => p.Creator)
                      .WithMany(u => u.Projects)
                      .HasForeignKey(p => p.CreatorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // TaskItem
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.TaskItemId);

                entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(t => t.Status)
                .HasMaxLength(50);

                // project relation (projet - taskitem)
                entity.HasOne(t => t.Project)
                      .WithMany(p => p.TaskItems)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                // creator relation(user - task)
                entity.HasOne(t => t.Creator)
                      .WithMany(u => u.TaskItems)
                      .HasForeignKey(t => t.CreatorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // comments
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);

                entity.Property(u => u.Content)
                        .IsRequired()
                        .HasMaxLength(1000);

                // task relationship (task -> comment)
                entity.HasOne(c => c.TaskItem)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(p => p.TaskId)
                      .OnDelete(DeleteBehavior.Cascade);

                // user Relationship
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            // Project Memberes
            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasKey(pm => new { pm.UserId, pm.ProjectId }); // composite key (combination of 2 primry key)

                entity.Property(pm => pm.Role)
                        .IsRequired()
                        .HasMaxLength(50);

                // 
                entity.HasOne(pm => pm.User)
                      .WithMany(u => u.projectMembers)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // 
                entity.HasOne(pm => pm.Project)
                      .WithMany(u => u.ProjectMembers)
                      .HasForeignKey(p => p.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Task Assignments
            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(ta => new { ta.UserId, ta.TaskItemId }); // composite key (combination of 2 primry key)

                // 
                entity.HasOne(ta => ta.User)
                      .WithMany(u => u.Assignments)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // 
                entity.HasOne(ta => ta.TaskItem)
                      .WithMany(u => u.Assignments)
                      .HasForeignKey(p => p.TaskItemId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);

                entity.Property(r => r.RoleName)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // User Roles
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ta => new { ta.UserId, ta.RoleId }); // composite key (combination of 2 primry key)

                // 
                entity.HasOne(ta => ta.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // 
                entity.HasOne(ta => ta.Role)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(p => p.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }


    }
}
