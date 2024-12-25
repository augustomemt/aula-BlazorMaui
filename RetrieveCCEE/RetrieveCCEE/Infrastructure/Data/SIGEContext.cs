using Microsoft.EntityFrameworkCore;
using RetrieveCCEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Infrastructure.Data
{
  public class SIGEContext : DbContext
  {
     public SIGEContext(DbContextOptions<SIGEContext> options) : base(options) { }

     public DbSet<vMeter> VMeter { get; set; }     
     


  }
}
