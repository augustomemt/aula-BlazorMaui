using Microsoft.EntityFrameworkCore;
using RetrieveCCEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Infrastructure.Data
{
  public class ION_DataContext : DbContext
  {
    public ION_DataContext(DbContextOptions<ION_DataContext> options) : base(options) { }

    public DbSet<Source> Sources { get; set; }
    public DbSet<Quantity> Quantitys { get; set; }

  }
}
