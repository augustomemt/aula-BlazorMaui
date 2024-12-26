using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Domain.Models
{
  public class Medidor
  {
    public string CodMedidor { get; set; }
    public string NomeMedidor { get; set; }
    public DateTime DataReferencia { get; set; }
    public double EnergiaAtivaConsumo { get; set; }
    public double EnergiaAtivaGeracao { get; set; }
    public double EnergiaReativaGeracao { get; set; }
    public double EnergiaReativaConsumo { get; set; }
    public Medidor(string cod, string nome, DateTime data, double ativaConsumo, double ativaGeracao, double reativaGeracao, double reativaConsumo)
    {
      CodMedidor = cod;
      NomeMedidor = nome;
      DataReferencia = data;
      EnergiaAtivaConsumo = ativaConsumo;
      EnergiaAtivaGeracao = ativaGeracao;
      EnergiaReativaGeracao = reativaGeracao;
      EnergiaReativaConsumo = reativaConsumo;
    }
  }
}
