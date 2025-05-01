using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NewsAPI_ServiceLayer;
using NewsAPI_ServiceLayer.Interfaces;
using NewsAPI_Shared.Models;

[Route("api/news")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;
    private readonly IMemoryCache _cache;
    public NewsController(INewsService newsService, IMemoryCache cache)
    {
        _cache = cache;
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLatestStories()
    {
        if (!_cache.TryGetValue("latest_stories", out List<NewsStory> stories))
        {

            List<NewsStory> newStories= await _newsService.GetLatestStories();

            stories = newStories;

            _cache.Set("latest_stories", stories, TimeSpan.FromMinutes(10));
        }
        return Ok(stories);
    }
}
