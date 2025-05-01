using Moq;
using Microsoft.AspNetCore.Mvc;
using NewsAPI_ServiceLayer.Interfaces;
using NewsAPI_Shared.Models;

public class NewsControllerTests
{
    private readonly Mock<INewsService> _mockNewsService;
    private readonly NewsController _controller;

    public NewsControllerTests()
    {
        _mockNewsService = new Mock<INewsService>();
        _controller = new NewsController(_mockNewsService.Object);
    }

    [Fact]
    public async Task GetLatestNewsStories_WithListOfNewsStories_ReturnsOkResult()
    {
        // Arrange
        var mockNewsStories = new List<NewsStory>
        {
            new NewsStory {  Title = "Latest News of Phalgam", Url = "https://www.thehindu.com/news/national/pahalgam-terror-attack-live-updates-jammu-kashmir-pakistan-loc-tension-april-28-2025/article69499872.ece" },
            new NewsStory {  Title = "Latest News of Elections in India", Url = "https://en.wikipedia.org/wiki/Elections_in_India" }
        };
        _mockNewsService.Setup(service => service.GetLatestStories())
            .ReturnsAsync(mockNewsStories);

        // Act
        var result = await _controller.GetLatestStories();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<NewsStory>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetLatestNewsStories_NotEmpty_ReturnsOkResult()
    {
        // Arrange
        var mockNewsStories = new List<NewsStory>
        {
            new NewsStory {  Title = "Latest News of Phalgam", Url = "https://www.thehindu.com/news/national/pahalgam-terror-attack-live-updates-jammu-kashmir-pakistan-loc-tension-april-28-2025/article69499872.ece" },
            new NewsStory {  Title = "Latest News of Elections in India", Url = "https://en.wikipedia.org/wiki/Elections_in_India" }
        };
        _mockNewsService.Setup(service => service.GetLatestStories())
            .ReturnsAsync(mockNewsStories);

        // Act
        var result = await _controller.GetLatestStories();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<NewsStory>>(okResult.Value);
        Assert.NotEmpty(returnValue);
    }

}