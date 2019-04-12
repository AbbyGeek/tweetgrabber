using System;
using System.IO;
using System.Text;
using TweetSharp;

namespace tweetgrabber
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("../../../settings.txt");
            string _customerKey = lines[0];
            string _customerSecret = lines[1];
            string _accessToken = lines[2];
            string _accessSecret = lines[3];


            TwitterService service = new TwitterService(_customerKey, _customerSecret, _accessToken, _accessSecret);


        var options = new ListTweetsOnUserTimelineOptions() { UserId = 624953558, Count = 100, MaxId = null }; //Max ID is the ID of the furthest back tweet
            StringBuilder sb = new StringBuilder();
            int i = 0;
            int x = 0;
            while (i < 50)
            {
                var tweets = service.ListTweetsOnUserTimeline(options);
                
                foreach (var tweet in tweets)
                {
                    if (tweet.IsTruncated == false && !tweet.Text.Contains('@') && !tweet.Text.Contains("http"))
                    {
                        string text = tweet.Text.Replace("\n", " ");
                        sb.Append(text + "\n");
                        options.MaxId = tweet.Id;
                        //TRIM URLs OFF TWEETS!
                    }
                    else
                    {
                        Console.WriteLine(x.ToString());
                        x++;
                    }
                    
                }
                i++;
            }
            File.WriteAllText(Path.Combine("../../../", "StockTD04Tweets.txt"), sb.ToString());
        }
    }
}
