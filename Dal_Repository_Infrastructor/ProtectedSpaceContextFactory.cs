using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_Infrastructor
{
    public class ProtectedSpaceContextFactory : IDesignTimeDbContextFactory<ProtectedSpace_context>
    {
        public ProtectedSpace_context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProtectedSpace_context>();
            optionsBuilder.UseSqlServer("Server=MC-XK1QNMU5BBQD\\SQLExpress;Database=ProtectedSpace;Trusted_Connection=True;TrustServerCertificate=True");

            return new ProtectedSpace_context(optionsBuilder.Options);
        }
    }
}
