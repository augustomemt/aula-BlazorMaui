using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Domain.Interfaces
{
  public interface ICCEEService
  {
    Task<string> ListarMedidaCincoMinutosAsync(string dataReferencia, string codigoMedidor);
    string BuildBodyRequest(DateTime dataReferencia, string codigoMedidor, string AuthCodigoPerfilAgente, string AuthUsername, string AuthPassword);
  }
}
