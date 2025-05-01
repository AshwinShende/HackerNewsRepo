using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI_Shared.Utils
{
    public static class HttpClientUtility
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return string.Empty;
            }
        }

        public static async Task<string> PostAsync(string url, HttpContent content)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error posting data: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
