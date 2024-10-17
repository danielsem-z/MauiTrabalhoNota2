using MauiApp1.Lib;
using MauiApp1.Entity;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Service
{
    public class PrevisaoService
    {
        private readonly JsonSerializerOptions _serializerOptions;

        private readonly string appId = "6135072afe7f6cec1537d5cb08a5a1a2";
        private readonly string url = "http://api.openweathermap.org/data/2.5/weather";

        public PrevisaoService()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<PrevisaoEntity?> GetPrevisaoAsync(string cidade)
        {
            PrevisaoEntity? previsao = null;
            var fetcher = Fetcher.Instance;

            var url = $"{this.url}?q={cidade}&units=metric&appid={this.appId}";
            try
            {
                var response = await fetcher.GetAsync(url);
                if (!string.IsNullOrWhiteSpace(response))
                {
                    previsao = JsonSerializer.Deserialize<PrevisaoEntity>(response, _serializerOptions);
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Erro ao buscar previsões: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Erro ao deserializar previsões: {ex.Message}");
            }

            return previsao;
        }

    }
}
