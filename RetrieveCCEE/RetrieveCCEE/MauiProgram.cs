using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using RetrieveCCEE.Application.Services;
using RetrieveCCEE.Domain.Interfaces;
using RetrieveCCEE.Infrastructure.Data;
using RetrieveCCEE.Infrastructure.Repository;

namespace RetrieveCCEE
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();

      
      var config = new ConfigurationBuilder()
          .SetBasePath("C:\\Users\\augusto.morais\\source\\repos\\RetrieveCCEE\\RetrieveCCEE") 
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .Build();

      builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        });

      builder.Services.AddMudServices();
      builder.Services.AddMauiBlazorWebView();
     

      var sigeConnectionString = config.GetConnectionString("SIGE_DataBase");
      var ionDataConnectionString = config.GetConnectionString("SIGE_DataBase");



      builder.Services.AddScoped<IRetriveService, RetriveService>();
      builder.Services.AddScoped<ISigeRepository, SigeRepository>();

      builder.Services.AddDbContext<SIGEContext>(options =>
        options.UseSqlServer(sigeConnectionString));

      builder.Services.AddDbContext<ION_DataContext>(options =>
        options.UseSqlServer(ionDataConnectionString));

#if DEBUG
      builder.Services.AddBlazorWebViewDeveloperTools();
  		builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
