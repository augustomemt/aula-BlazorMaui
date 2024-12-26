using RetrieveCCEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Domain.Interfaces
{
  public interface IConfigurationCCEE
  {

    Task<ConfigurationCCEE> LoadConfigurationsAsync();
    Task SaveConfigurationsAsync(ConfigurationCCEE configuration);
  }
}
