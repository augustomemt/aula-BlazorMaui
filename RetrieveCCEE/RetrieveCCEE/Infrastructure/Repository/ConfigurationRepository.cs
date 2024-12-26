using Microsoft.EntityFrameworkCore;
using RetrieveCCEE.Domain.Entities;
using RetrieveCCEE.Domain.Interfaces;
using RetrieveCCEE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Infrastructure.Repository
{
  
  public class ConfigurationRepository : IConfigurationCCEE
  {
    public SIGEContext _sigeContext { get; set; }

    public ConfigurationRepository(SIGEContext sigeContext)
    {

      _sigeContext = sigeContext;

    }
    public async Task<ConfigurationCCEE> LoadConfigurationsAsync()
    {
      return _sigeContext.ConfigurationCCEE.FirstOrDefault();
    }
    public async Task SaveConfigurationsAsync(ConfigurationCCEE configuration)
    {
      // Verificar se a configuração já existe
      var existingConfiguration = await _sigeContext.ConfigurationCCEE.FirstOrDefaultAsync();

      if (existingConfiguration == null)
      {
        configuration.ID = 1;
        await _sigeContext.ConfigurationCCEE.AddAsync(configuration);
      }
      else
      {
        // Atualizar registro existente
        existingConfiguration.CertificatePath = configuration.CertificatePath;
        existingConfiguration.Username = configuration.Username;
        existingConfiguration.Password = configuration.Password;
        existingConfiguration.CodAgent = configuration.CodAgent;

        _sigeContext.ConfigurationCCEE.Update(existingConfiguration);
      }

      // Salvar alterações no banco
      await _sigeContext.SaveChangesAsync();
    }


  }
}
