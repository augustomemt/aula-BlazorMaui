using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Domain.Entities
{
  public class vMeter
  {
    [Key]
    public int iPointID {  get; set; }
    public int iSourceID { get; set; }

    public string? sPointName { get; set; }

    public string? Name { get; set; }
    public string? sCodeCCEE { get; set; }

    public string? sDescription { get; set; }
  }
}
