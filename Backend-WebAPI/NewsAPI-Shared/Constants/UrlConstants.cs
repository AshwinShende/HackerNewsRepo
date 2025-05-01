using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI_Shared.Constants
{
    public static class UrlConstants
    {
        public const string newStoriesUrl = "https://hacker-news.firebaseio.com/v0/newstories.json?print=pretty";
        public const string prefixNewsStoryUrl = "https://hacker-news.firebaseio.com/v0/item/";
        public const string suffixNewsStoryUrl = ".json?print=pretty";
    }
}
