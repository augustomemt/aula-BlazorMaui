using RetrieveCCEE.Domain.Entities;
using RetrieveCCEE.Domain.Interfaces;
using RetrieveCCEE.Domain.Models;
using RetrieveCCEE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Infrastructure.Repository
{
  public class SigeRepository : ISigeRepository
  {
    public SIGEContext _sigeContext { get; set; }

    public SigeRepository(SIGEContext sigeContext)
    {

      _sigeContext = sigeContext;

    }

    public List<string> GetAllMeterPoints(List<string> typePoints)
    {
      List<string> meterPoints = new List<string>();
      foreach (string typePoint in typePoints)
      {

        var meters = _sigeContext.VMeter.Where(s => s.sDescription == typePoint).Select(s => s.sPointName).Distinct().ToList();
        meterPoints.AddRange(meters);


      }
      return meterPoints;

    }

    public List<string> GetAllTypePoints()
    {
      var typePoints = _sigeContext.VMeter.Select(t => t.sDescription).Distinct().ToList();
      return typePoints;
    }

    public List<Meter> GetAllMeters(List<string> points)
    {
      List<Meter> meters = new List<Meter>();
      foreach (var point in points)
      {
        var source = _sigeContext.VMeter
        .Where(s => s.sPointName == point)
        .Select(s => new Meter { Id = s.iSourceID, Name = s.Name, CodeCCEE = s.sCodeCCEE }).ToList();
        meters.AddRange(source);
      }

      return meters;
    }



  }
}
