using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI_Shared.Models;

namespace NewsAPI_ServiceLayer.Interfaces
{
    public interface INewsService
    {
      public  Task<List<NewsStory>> GetLatestStories();
    }
}
