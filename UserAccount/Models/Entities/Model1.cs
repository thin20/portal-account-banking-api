using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UserAccount.Models.Entities
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelUserAccount")
        {
        }

        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<permission>()
                .Property(e => e.idRole)
                .IsFixedLength();

            modelBuilder.Entity<permission>()
                .Property(e => e.permission1)
                .IsFixedLength();

            modelBuilder.Entity<role>()
                .Property(e => e.id)
                .IsFixedLength();

            modelBuilder.Entity<role>()
                .Property(e => e.description)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.userName)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.idRole)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.country)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsFixedLength();
        }
    }
}
