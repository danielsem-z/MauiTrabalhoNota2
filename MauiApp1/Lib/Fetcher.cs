using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace MauiApp1.Lib
{
    public class Fetcher
    {
        private static readonly Lazy<Fetcher> _instance = new Lazy<Fetcher>(() => new Fetcher());
        private readonly HttpClient _client;

        public static Fetcher Instance => _instance.Value;

        private Fetcher()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}
