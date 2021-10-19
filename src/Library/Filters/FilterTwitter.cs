using TwitterUCU;
using System;
namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("test1", @"src/Program\filteredluke.jpg"));
            return image;
        }

    }
}