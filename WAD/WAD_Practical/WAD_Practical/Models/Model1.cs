namespace WAD_Practical.Models
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

        public virtual DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.GroupName)
                .IsUnicode(false);
        }
    }
}
