namespace Webservice._2._0
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<StudentRegistration> StudentRegistrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Club1)
                .HasForeignKey(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.Teams)
                .WithOptional(e => e.Message1)
                .HasForeignKey(e => e.Message)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Student1)
                .HasForeignKey(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
