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

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLatestStories()
    {
        try
        {
            return Ok(await _newsService.GetLatestStories());
        }
        catch (Exception ex)
        {
           
            return StatusCode(500, new
            {
                Message = ex.Message,
                Details = ex
            });
        }


    } 
}
