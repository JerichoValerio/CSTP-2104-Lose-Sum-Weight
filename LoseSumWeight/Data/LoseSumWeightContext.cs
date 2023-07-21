using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoseSumWeight.Models;

namespace LoseSumWeight.Data
{
    public class LoseSumWeightContext : DbContext
    {
        public LoseSumWeightContext (DbContextOptions<LoseSumWeightContext> options)
            : base(options)
        {
        }

        public DbSet<LoseSumWeight.Models.Products> Products { get; set; } = default!;
    }
}
