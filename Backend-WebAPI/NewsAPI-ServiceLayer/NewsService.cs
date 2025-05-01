using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using NewsAPI_DataAccesLayer.Interfaces;
using NewsAPI_ServiceLayer.Interfaces;
using NewsAPI_Shared.Constants;
using NewsAPI_Shared.Models;
using NewsAPI_Shared.Utils;
using Newtonsoft.Json;

namespace NewsAPI_ServiceLayer
{

    public class NewsService : INewsService
    {
        
        private readonly INewsData _newsRepo;
        public NewsService( INewsData newsRepo)
        {
          
            _newsRepo = newsRepo;
        }

        public async Task<List<NewsStory>> GetLatestStories()
        {
            
                // GET request
                var newStoryIdListArr = await _newsRepo.GetLatestStories(UrlConstants.newStoriesUrl);

                string[] storyIdStrings = newStoryIdListArr.Replace("[", "").Replace("]", "").Replace(" ","").Split(',');
                
                //Parallelism
                List<Task<string>> taskList = new List<Task<string>>();
               
                for (int i = 0; i <= storyIdStrings.Count()-1; i++)
                {
               
                    StringBuilder urlStringBuilder = new StringBuilder();
                    urlStringBuilder.Append(UrlConstants.prefixNewsStoryUrl).Append(storyIdStrings[i].ToString()).Append(UrlConstants.suffixNewsStoryUrl);

                    taskList.Add(Task.Run(() => _newsRepo.GetLatestStories(urlStringBuilder.ToString())));
                }


                await Task.WhenAll(taskList);
                //var results = await Task.WaitAll(taskList);

                List<NewsStory> lstNews=new List<NewsStory>();



                Parallel.ForEach(taskList, task =>
                {
                    lstNews.Add(JsonConvert.DeserializeObject<NewsStory>(task.Result));

                });

            return lstNews;
        }
    }
}
