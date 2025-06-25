using Core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_Infrastructor
{
    public class ProtectedSpace_context:DbContext
    {
        public ProtectedSpace_context(DbContextOptions options) :base(options)
        { 
        }
        public DbSet<Address> Address { get; set; }
        public DbSet<TypeStructure> TypeStructure { get; set; }
        public DbSet<Opinion> Opinion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Server=MC-XK1QNMU5BBQD\\SQLExpress;Database=ProtectedSpace1;Trusted_Connection=True;TrustServerCertificate=True");
        
    }


}
