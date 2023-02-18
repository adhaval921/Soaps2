using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSoaps.Models;

namespace MvcSoaps.Data
{
    public class MvcSoapContext : DbContext
    {
        public MvcSoapContext(DbContextOptions<MvcSoapContext> options)
            : base(options)
        {
        }

        public DbSet<soap> Soaps { get; set; }
    }
}
