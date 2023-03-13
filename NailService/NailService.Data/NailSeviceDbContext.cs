using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailService.Data
{
    internal class NailSeviceDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TypeOfWork> TypeOfWorks { get; set; }
        public virtual DbSet<Appountment> Appountments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appountment>().HasOne(p=>p.TypeOfWork).WithMany(b=>b.Appountments).HasForeignKey(p=>p.WorkId).OnDelete(DeleteBehavior.NoAction);
        }

        public NailSeviceDbContext(DbContextOptions options) : base(options) 
        { 
        }
    }
}
