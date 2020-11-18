namespace MyApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.GroupName)
                .IsUnicode(false);
        }
    }
}
