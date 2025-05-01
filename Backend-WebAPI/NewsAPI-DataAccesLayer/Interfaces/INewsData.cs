using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI_DataAccesLayer.Interfaces
{
    public interface INewsData
    {
         Task<string> GetLatestStories(string url);
    }
}
