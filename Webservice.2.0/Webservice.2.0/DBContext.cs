namespace Webservice._2._0
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext1")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<StudentRegistration> StudentRegistration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Team)
                .WithRequired(e => e.Club1)
                .HasForeignKey(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.Team)
                .WithOptional(e => e.Message1)
                .HasForeignKey(e => e.Message)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Registration)
                .WithRequired(e => e.Student1)
                .HasForeignKey(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Student)
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
