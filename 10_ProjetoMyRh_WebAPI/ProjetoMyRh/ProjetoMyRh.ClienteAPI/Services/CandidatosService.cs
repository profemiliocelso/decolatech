using Newtonsoft.Json;
using ProjetoMyRh.ClienteAPI.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ProjetoMyRh.ClienteAPI.Services
{
    public class CandidatosService
    {
        private readonly HttpClient httpClient;

        public CandidatosService(IHttpClientFactory client)
        {
            httpClient = client.CreateClient();

            httpClient.BaseAddress = new Uri("http://localhost:5036/");
            httpClient.DefaultRequestHeaders.Accept.Add(new 
                MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<CandidatoClient>> ListarCandidatosAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/candidatosapi");
                if(response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<CandidatoClient[]>();
                    return lista!.ToList();
                }
                else
                {
                    throw new Exception("Não foi possível obter a lista de candidatos");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task IncluirCandidatoAsync(CandidatoClient candidato)
        {
            try
            {
                // gerar o json a partir do objeto fornecido como parâmetro
                string json = JsonConvert.SerializeObject(candidato);

                // gerar o fluxo de bytes para a API
                HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

                // enviando o objeto para a API
                var response = await httpClient.PostAsync("api/candidatosapi", content);
                if(!response.IsSuccessStatusCode)
                {
                    string erro = $"Erro: {response.StatusCode} - {response.ReasonPhrase}";
                    throw new Exception(erro);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
