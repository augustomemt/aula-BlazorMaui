using RetrieveCCEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Infrastructure.ExternalService
{
  public class CCEEservice : ICCEEService
  {
    private readonly HttpClientHandler _httpClient;

    public CCEEservice(HttpClientHandler httpClient)
    {
      _httpClient = httpClient;
    }
    

    public string BuildBodyRequest(DateTime dataReferencia, string codigoMedidor, string AuthCodigoPerfilAgente, string AuthUsername, string AuthPassword)
    {
      return $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" 
                                       xmlns:mh=""http://xmlns.energia.org.br/MH/v2"" 
                                       xmlns:bm=""http://xmlns.energia.org.br/BM/v2"" 
                                       xmlns:bo=""http://xmlns.energia.org.br/BO/v2"" 
                                       xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                <soapenv:Header>
                   <mh:messageHeader>
                       <mh:codigoPerfilAgente>{AuthCodigoPerfilAgente}</mh:codigoPerfilAgente>
                   </mh:messageHeader>
                   <oas:Security>
                       <oas:UsernameToken>
                           <oas:Username>{AuthUsername}</oas:Username>
                           <oas:Password>{AuthPassword}</oas:Password>
                       </oas:UsernameToken>
                   </oas:Security>
                   <mh:paginacao>
                       <mh:numero>1</mh:numero>
                       <mh:quantidadeItens>400</mh:quantidadeItens>
                   </mh:paginacao>
                </soapenv:Header>    
                <soapenv:Body>
                   <bm:listarMedidaCincoMinutosRequest>
                       <bm:dataReferencia>{dataReferencia:yyyy-MM-ddTHH:mm:ss}</bm:dataReferencia>
                       <bm:medidor>
                           <bo:codigo>{codigoMedidor}</bo:codigo>
                       </bm:medidor>
                   </bm:listarMedidaCincoMinutosRequest>
                </soapenv:Body>
             </soapenv:Envelope>";
    }
    public async Task<string> ListarMedidaCincoMinutosAsync(string body, string pathCertificate)
    {
      // Carrega o certificado
      var certificate = new X509Certificate2(pathCertificate);
     
      _httpClient.ClientCertificates.Add(certificate);

      // Configura o conteúdo da requisição
      var content = new StringContent(body, Encoding.UTF8, "application/xml");

      using (HttpClient client = new HttpClient(_httpClient))
      {
       
        content.Headers.Add("SOAPAction", "listarMedidaCincoMinutos");
        string url = "https://servicos.ccee.org.br:443/ws/v2/MedidaCincoMinutosBSv2";

        try
        {
          // Log do corpo da requisição
          Console.WriteLine("SOAP Body:");
          Console.WriteLine(body);

          HttpResponseMessage response = await client.PostAsync(url, content);
          string responseString = await response.Content.ReadAsStringAsync();

          if (response.IsSuccessStatusCode)
          {
            return responseString;
          }
          else
          {
            // Verifica se a resposta contém um SOAP Fault
            Console.WriteLine("Resposta com erro. Verificando conteúdo SOAP Fault...");

            // Tenta extrair detalhes do Fault se a resposta for XML
            string faultDetails = TryExtractSoapFault(responseString);
            Log.Error($"Erro: {response.StatusCode} - {faultDetails}");
            return $"Erro: {response.StatusCode} - {faultDetails}";
          }
        }
        catch (Exception ex)
        {
          return $"Erro: {ex.Message}";
        }
      }
    }
    private string TryExtractSoapFault(string responseString)
    {
      // Lógica para extrair informações de um Fault, caso a resposta contenha um
      return responseString.Contains("<soapenv:Fault>") ? "Erro no SOAP Fault." : "Erro desconhecido.";
    }
  }


}
