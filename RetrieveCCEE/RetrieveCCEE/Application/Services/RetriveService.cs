using RetrieveCCEE.Domain.Interfaces;
using RetrieveCCEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Application.Services
{
  public class RetriveService : IRetriveService
  {
    public ISigeRepository _sigeRepository { get; set; }

    public RetriveService(ISigeRepository sigeRepository)
    {

      _sigeRepository = sigeRepository;

    }
    public List<string> GetAllTypePoints()
    {
      return _sigeRepository.GetAllTypePoints();
    }   

    public List<string> GetAllMeterPoints(List<string> typePoints)
    {
      return _sigeRepository.GetAllMeterPoints(typePoints);    }

    public List<Meter> GetAllMeters(List<string> points)
    {
      return _sigeRepository.GetAllMeters(points);
    }
  }
}
