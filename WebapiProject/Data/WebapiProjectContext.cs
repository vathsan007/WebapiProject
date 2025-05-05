using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebapiProject.Models;

namespace WebapiProject.Data
{
    public class WebapiProjectContext : DbContext
    {
        public WebapiProjectContext (DbContextOptions<WebapiProjectContext> options)
            : base(options)
        {
        }

        public DbSet<WebapiProject.Models.Product> Product { get; set; } = default!;
        public DbSet<WebapiProject.Models.Order> Order { get; set; } = default!;
        public DbSet<WebapiProject.Models.Supplier> Supplier { get; set; } = default!;
    }
}
