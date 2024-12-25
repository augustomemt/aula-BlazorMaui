using RetrieveCCEE.Domain.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Domain.Interfaces
{
  public interface ISigeRepository
  {
    public List<string> GetAllTypePoints();
    public List<string> GetAllMeterPoints(List<string> typePoints);
    public List<Meter> GetAllMeters(List<string> points);






  }
}
