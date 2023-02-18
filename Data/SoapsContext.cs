using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSoaps.Models;

namespace Soaps.Data
{
    public class SoapsContext : DbContext
    {
        public SoapsContext (DbContextOptions<SoapsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcSoaps.Models.soap> soap { get; set; }
    }
}
