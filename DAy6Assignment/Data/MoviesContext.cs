using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAy6Assignment.Models;

namespace DAy6Assignment.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<DAy6Assignment.Models.Movies> Movies { get; set; } = default!;
    }
}
