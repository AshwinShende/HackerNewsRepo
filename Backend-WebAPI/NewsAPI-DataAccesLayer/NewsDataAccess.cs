
using NewsAPI_DataAccesLayer.Interfaces;
using NewsAPI_Shared.Constants;
using NewsAPI_Shared.Utils;

namespace NewsAPI_DataAccesLayer
{
    public class NewsDataAccess : INewsData
    {
        public async Task<string> GetLatestStories(string url)
        {
            var data = await HttpClientUtility.GetAsync(url);

            return data;
        }
    }
}