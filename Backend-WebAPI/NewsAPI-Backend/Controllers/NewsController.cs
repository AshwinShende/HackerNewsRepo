using Microsoft.AspNetCore.Mvc;
using NewsAPI_ServiceLayer;
using NewsAPI_ServiceLayer.Interfaces;

[Route("api/news")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLatestStories()
    {
        return Ok(await _newsService.GetLatestStories());
    }
}
