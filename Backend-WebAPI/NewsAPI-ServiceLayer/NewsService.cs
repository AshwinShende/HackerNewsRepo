using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMemoryCache _cache;
        private readonly INewsData _newsRepo;
        public NewsService(INewsData newsRepo, IMemoryCache cache)
        {
            _cache = cache;
            _newsRepo = newsRepo;
        }

        public async Task<List<NewsStory>> GetLatestStories()
        {

            // GET request
            var newStoryIdListArr = await _newsRepo.GetLatestStories(UrlConstants.newStoriesUrl);

            string[] storyIdStrings = newStoryIdListArr.Replace("[", "").Replace("]", "").Replace("\n", "").Replace(" ", "").Split(',');


            //get cached stories from previous results
            List<NewsStory> cachedStoryList = _cache.Get<List<NewsStory>>("latest_cached_stories");

            List<string> newlyAddedStorieslst = new List<string>();

            List<NewsStory> lstNews = new List<NewsStory>();

            string[] missingStoryIdsincache = null;

            //get storyid's which are not present in cache
            if (cachedStoryList != null)
            {
                missingStoryIdsincache = storyIdStrings.Except(cachedStoryList.Select(x => x.Id)).ToArray();



                //prepare storyid's from cache which matched
                lstNews.AddRange(cachedStoryList.Where(x => storyIdStrings.Contains(x.Id)));
            }
            else
            {
                missingStoryIdsincache = storyIdStrings;
            }

                //Parallelism
                List<Task<string>> taskList = new List<Task<string>>();

            //get missingstoryid's from api's we minimise api call  due to caching
            for (int i = 0; i <= missingStoryIdsincache.Count() - 1; i++)
            {

                StringBuilder urlStringBuilder = new StringBuilder();
                urlStringBuilder.Append(UrlConstants.prefixNewsStoryUrl).Append(missingStoryIdsincache[i].ToString()).Append(UrlConstants.suffixNewsStoryUrl);

                taskList.Add(Task.Run(() => _newsRepo.GetLatestStories(urlStringBuilder.ToString())));
            }


            await Task.WhenAll(taskList);


            //add missing storyid's to main list

            foreach (var item in taskList)
            {
                lstNews.Add(JsonConvert.DeserializeObject<NewsStory>(item.Result));
            }
            

            //set newly added storyid's to cache
            _cache.Set("latest_cached_stories", lstNews, TimeSpan.FromMinutes(10));

            return lstNews;
        }
    }
}
