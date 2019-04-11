using System;
using System.IO;
using System.Text;
using TweetSharp;

namespace tweetgrabber
{
    class Program
    {
        private static string _customerKey = "ePYV2uTt9Qbwznz2UMtUbgJf1";
        private static string _customerSecret = "LFQNqjtCkvI3fctV2SnBnlwj3PhAspsyg7Cgeq3Fx9lVnTai7U";
        private static string _accessToken = "2602556882-2rmLXmubMt4iGVLxHxq0CIzJIMOiVfFvdBrjUYg";
        private static string _accessSecret = "EdIQGksrunteio5umGv1FxcmlQmxK5J2Fk64ItrtIeqpe";

        private static TwitterService service = new TwitterService(_customerKey, _customerSecret, _accessToken, _accessSecret);
        static void Main()
        {
            var options = new ListTweetsOnUserTimelineOptions() { UserId = 624953558, Count = 100, MaxId = null }; //Max ID is the ID of the furthest back tweet
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < 70)
            {
                var tweets = service.ListTweetsOnUserTimeline(options);

                foreach (var tweet in tweets)
                {
                    if (!tweet.Text.Contains('@') && !tweet.Text.Contains("http"))
                    {
                        string text = tweet.Text.Replace("\n", " ");
                        sb.Append(text + "\n");
                        options.MaxId = tweet.Id;
                    }
                }
                i++;
            }
            File.WriteAllText(Path.Combine("../../../", "StockTD04Tweets.txt"), sb.ToString());
        }

        
    }
}
