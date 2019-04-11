using System;
using System.IO;
using System.Text;
using TweetSharp;

namespace tweetgrabber
{
    class Program
    {
        //private static string _customerKey = "ePYV2uTt9Qbwznz2UMtUbgJf1";
        //private static string _customerSecret = "LFQNqjtCkvI3fctV2SnBnlwj3PhAspsyg7Cgeq3Fx9lVnTai7U";
        //private static string _accessToken = "2602556882-2rmLXmubMt4iGVLxHxq0CIzJIMOiVfFvdBrjUYg";
        //private static string _accessSecret = "EdIQGksrunteio5umGv1FxcmlQmxK5J2Fk64ItrtIeqpe";

        //private static TwitterService service = new TwitterService(_customerKey, _customerSecret, _accessToken, _accessSecret);
        static void Main()
        {

        string _customerKey = "ePYV2uTt9Qbwznz2UMtUbgJf1";
        string _customerSecret = "LFQNqjtCkvI3fctV2SnBnlwj3PhAspsyg7Cgeq3Fx9lVnTai7U";
        string _accessToken = "2602556882-2rmLXmubMt4iGVLxHxq0CIzJIMOiVfFvdBrjUYg";
        string _accessSecret = "EdIQGksrunteio5umGv1FxcmlQmxK5J2Fk64ItrtIeqpe";


        TwitterService service = new TwitterService(_customerKey, _customerSecret, _accessToken, _accessSecret);


        var options = new ListTweetsOnUserTimelineOptions() { UserId = 3183325776, Count = 100, MaxId = null }; //Max ID is the ID of the furthest back tweet
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < 100)
            {
                var tweets = service.ListTweetsOnUserTimeline(options);
                int x = 0;
                foreach (var tweet in tweets)
                {
                    if (tweet.IsTruncated == false && !tweet.Text.Contains('@'))
                    {
                        string text = tweet.Text.Replace("\n", " ");
                        sb.Append(text + "\n");
                        options.MaxId = tweet.Id;
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
