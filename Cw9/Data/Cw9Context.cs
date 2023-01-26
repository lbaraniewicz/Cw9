using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cw9.Models;

namespace Cw9.Data
{
    public class Cw9Context : DbContext
    {
        public Cw9Context (DbContextOptions<Cw9Context> options)
            : base(options)
        {
        }

        public DbSet<Cw9.Models.Movie> Movie { get; set; } = default!;
    }
}
